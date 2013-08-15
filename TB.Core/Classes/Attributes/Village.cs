using System;
using System.Collections.Generic;
using HtmlAgilityPack;
using TB.Core.Classes.Handler;
using TB.Core.Enumeration;
using TB.Core.Enumerations;
using TB.Core.Interfaces.Attributes;
using TB.Core.Interfaces.Handler;

namespace TB.Core.Classes.Attributes
{
  public class Village : IVillage
  {
    #region Constructor
    public Village(IHPage _handlerPage, Int32 _id, String _name)
    {
      this.HPage = _handlerPage;

      this.ID   = _id;
      this.Name = _name;

      this.Ressources   = null;
      this.Buildings    = new Dictionary<EBuildingType, IDictionary<Int32, IBuilding>>();
      this.Acceptance   = new Double();
      this.DefenseBonus = new Double();
      this.Units        = new Dictionary<EUnitType, IUnit>();
      this.Coordinate   = null;
      this.URLFarm      = HLink.GetLink(EPageID.FARM,    _id);
      this.URLVillage   = HLink.GetLink(EPageID.VILLAGE, _id);
      this.Inhabitants  = new Int32();
      this.MainVillage  = false;

      this.Initialized = false;
    }
    #endregion Constructor

    #region Properties
    #region Protected
    protected IHPage HPage { get; set; }
    #endregion Protected

    #region Public
    public bool Initialized { get; private set; }
    
    public Int32 ID { get; private set; }
    public String Name { get; private set; }
    public IRessourceLimits Ressources { get; private set; }
    public IDictionary<EBuildingType, IDictionary<int, IBuilding>> Buildings { get; private set; }
    public Double Acceptance { get; private set; }
    public Double DefenseBonus { get; private set; }
    public IDictionary<EUnitType, IUnit> Units { get; private set; }
    public ICoordinate Coordinate { get; private set; }
    public Uri URLFarm { get; private set; }
    public Uri URLVillage { get; private set; }
    public Int32 Inhabitants { get; private set; }
    public Boolean MainVillage { get; private set; }

    #endregion Public
    #endregion Properties

    #region Methods

    #region Protected

    protected EReturnCode ResolveBuildings(EInitMode _initMode)
    {
      IBuilding building;
      String    value;
      Int32     id;
      String    name;
      EBuildingType type = EBuildingType.UNKNOWN;

      HInfo.LogHandler.Debug(String.Format("START RESOLVE BUILDINGS OF VILLAGE {0}", this.Name));
      try
      {
        HtmlNode baseNode = HPage.GetPageFarm(this.ID).GetElementbyId(HInfo.PHtmlAttributes.IDRx);

        foreach (HtmlNode hnFarm in baseNode.SelectNodes(HInfo.PXPathExpr.AreaFarm))
        {
          // resolve id
          value = hnFarm.GetAttributeValue(HInfo.PHtmlAttributes.HRef, String.Empty);
          value = value.Substring(value.IndexOf('=') + 1);
          id = Int32.Parse(value);

          // resoble name
          value = hnFarm.GetAttributeValue(HInfo.PHtmlAttributes.Alt, String.Empty);
          name = value.Substring(0, value.IndexOf(' '));

          // resolve type
          type = HInfo.PDictionary.Buildings[name];

          building = new Building(this.ID, id, name, type);
          building.Init(_initMode);
          
          // create dictionary if this type doesn't exists already in it
          if (!this.Buildings.ContainsKey(type))
          {
            IDictionary<Int32, IBuilding> dictionary = new Dictionary<Int32, IBuilding>();
            this.Buildings.Add(type, dictionary);
          }
         
          this.Buildings[type].Add(id, building);
        }
      }
      catch (Exception exception)
      {
        HInfo.LogHandler.Error(String.Format("Unable to resolve the buildings of vilage {0}", this.Name), exception);
        return EReturnCode.FAIL;
      }
      finally
      {
        HInfo.LogHandler.Debug(String.Format("END RESOLVE BUILDINGS OF VILLAGE {0}", this.Name));
      }

      return EReturnCode.SUCCESS;
    }

    /// <summary>
    /// This method resolves the inhabitants of this village and
    /// specifies if this village is the main village
    /// </summary>
    protected EReturnCode ResolveInhabitants()
    {
      String name;

      HInfo.LogHandler.Debug(String.Format("START RESOLVE INHABITANTS OF VILLAGE {0}", this.Name));
      try
      {
        HtmlNode hnTBody = this.HPage.GetPagePlayer().GetElementbyId(HInfo.PHtmlAttributes.IDVillages);
        hnTBody = hnTBody.SelectSingleNode(HInfo.PXPathExpr.TBody);

        HtmlNode hnTd;
        foreach (HtmlNode hnTr in hnTBody.SelectNodes(HInfo.PXPathExpr.Tr))
        {
          hnTd = hnTr.SelectSingleNode(HInfo.PXPathExpr.TdVillageName);
          name = hnTd.SelectSingleNode(HInfo.PXPathExpr.AHrefVillageName).InnerText;

          if (this.Name.Equals(name))
          {
            try
            {
              // Resolve if this village is a main village
              if (hnTr.SelectSingleNode(HInfo.PXPathExpr.SpanMainVillage) != null)
              {
                this.MainVillage = true;
              }
            }
            catch (Exception exception)
            {
              HInfo.LogHandler.Error(String.Format("Unable to resolve if the village {0} is the main village", this.Name), exception);
            }

            try
            {
              // Resolve Inhabitants
              this.Inhabitants = Int32.Parse(hnTr.SelectSingleNode(HInfo.PXPathExpr.TdInhabitants).InnerText);
            }
            catch (Exception exception)
            {
              HInfo.LogHandler.Error(String.Format("Unable to resolve if the village {0} is the main village", this.Name), exception);
              return EReturnCode.FAIL;
            }
            
          }
        }
      }
      catch (Exception exception)
      {
        HInfo.LogHandler.Error(String.Format("Unable to resolve Html document : {0}", HInfo.PLinks.Player), exception);
        return EReturnCode.FAIL;
      }
      finally
      {
        HInfo.LogHandler.Debug(String.Format("END RESOLVE INHABITANTS OF VILLAGE {0}", this.Name));
      }

      return EReturnCode.SUCCESS;
    }

    /// <summary>
    /// This method resolves the acceptance of the village
    /// </summary>
    protected EReturnCode ResolveAcceptance()
    {
      HInfo.LogHandler.Debug(String.Format("START RESOLVE ACCEPTANCE OF VILLAGE {0}", this.Name));
      try
      {
        // <div class="loyalty medium">
        HtmlNode hn = HPage.GetPageVillage(this.ID).DocumentNode;
        hn = hn.SelectSingleNode(HInfo.PXPathExpr.VillageAcceptance);

        String value = hn.ChildNodes[1].InnerText;
        value = value.Substring(17);
        value = value.Substring(0, value.IndexOf('&'));

        this.Acceptance = Int32.Parse(value);
      }
      catch (Exception exception)
      {
        HInfo.LogHandler.Error(String.Format("Unable to resolve acceptance in village {0}", this.Name), exception);
        return EReturnCode.FAIL;
      }
      finally
      {
        HInfo.LogHandler.Debug(String.Format("END RESOLVE ACCEPTANCE OF VILLAGE {0}", this.Name));
      }

      return EReturnCode.SUCCESS;
    }

    /// <summary>
    /// This method resolves the ressources of this village
    /// </summary>
    protected EReturnCode ResolveRessources()
    {
      Int32 wood;
      Int32 mud;
      Int32 stone;
      Int32 corn;
      Int32 limitWarehouse;
      Int32 limitGranary;
      Int32 freeCrop;

      HInfo.LogHandler.Debug(String.Format("START RESOLVE RESSOURCES OF VILLAGE {0}", this.Name));
      try
      {
        HtmlDocument hd = this.HPage.GetPageVillage(this.ID);
        HtmlNode hn = hd.GetElementbyId(HInfo.PHtmlAttributes.IDStockBar);

        wood = Int32.Parse(hn.SelectSingleNode(HInfo.PXPathExpr.VillageWood).InnerText);
        mud = Int32.Parse(hn.SelectSingleNode(HInfo.PXPathExpr.VillageMud).InnerText);
        stone = Int32.Parse(hn.SelectSingleNode(HInfo.PXPathExpr.VillageStone).InnerText);
        corn = Int32.Parse(hn.SelectSingleNode(HInfo.PXPathExpr.VillageCorn).InnerText);

        limitWarehouse = Int32.Parse(hd.GetElementbyId(HInfo.PHtmlAttributes.IDStockBarWarehouse).InnerText);
        limitGranary = Int32.Parse(hd.GetElementbyId(HInfo.PHtmlAttributes.IDStockBarGranary).InnerText);

        freeCrop = Int32.Parse(hd.GetElementbyId(HInfo.PHtmlAttributes.IDStockBarFreeCrop).InnerText);

        this.Ressources = new Ressources(wood, mud, stone, corn, limitWarehouse, limitGranary, freeCrop);
      }
      catch (Exception exception)
      {
        HInfo.LogHandler.Error(String.Format("Unable to resolve ressources in village {0}", this.Name), exception);
        return EReturnCode.FAIL;
      }
      finally
      {
        HInfo.LogHandler.Debug(String.Format("END RESOLVE RESSOURCES OF VILLAGE {0}", this.Name));  
      }

      return EReturnCode.SUCCESS;
    }

    /// <summary>
    /// This method resolves the x and y coordiantes of this village
    /// </summary>
    protected EReturnCode ResolveCoordinates()
    {
      Int32 x;
      Int32 y;
      String value;

      HInfo.LogHandler.Debug(String.Format("START RESOLVE COORDINATES OF VILLAGE {0}", this.Name));
      try
      {
        HtmlNode hd = this.HPage.GetPageStatic().DocumentNode;
        //hd = hd.SelectSingleNode(".//span[@class='coordinates coordinatesWrapper coordinatesAligned coordinatesLTR']");
        hd = hd.SelectSingleNode(HInfo.PXPathExpr.DivVillageName).ParentNode.ParentNode;

        // Parse x coordinate
        value = hd.SelectSingleNode(HInfo.PXPathExpr.SpanCoordinateX).InnerText.Substring(17);
        value = value.Substring(0, value.IndexOf('&'));
        if (!Int32.TryParse(value, out x))
        {
          HInfo.LogHandler.Error(String.Format("Unable to resolve coordinate OF VILLAGE {0}", this.Name));
        }

        // Parse y coordinate
        value = hd.SelectSingleNode(HInfo.PXPathExpr.SpanCoordinateY).InnerText.Substring(16);
        value = value.Substring(0, value.IndexOf('&'));
        if (!Int32.TryParse(value, out y))
        {
          HInfo.LogHandler.Error(String.Format("Unable to resolve coordinate OF VILLAGE {0}", this.Name));
        }

        this.Coordinate = new Coordinate(x, y);
      }
      catch (Exception exception)
      {
        HInfo.LogHandler.Error(String.Format("Unable to resolve coordinate OF VILLAGE {0}", this.Name), exception);
        return EReturnCode.FAIL;
      }
      finally
      {
        HInfo.LogHandler.Debug(String.Format("END RESOLVE COORDINATES OF VILLAGE {0}", this.Name));  
      }

      return EReturnCode.SUCCESS;
    }
    #endregion Protected

    #region Public
    public EReturnCode Init()
    {
      return this.Init(EInitMode.ON_DEMAND);
    }

    public EReturnCode Init(EInitMode _initMode)
    {
      EReturnCode returnCode;

      // Coordinates
      if ((returnCode = this.ResolveCoordinates()) != EReturnCode.SUCCESS)
      { return returnCode; }

      // Ressources
      if ((returnCode = this.ResolveRessources()) != EReturnCode.SUCCESS)
      { return returnCode; }

      // Acceptance
      if ((returnCode = this.ResolveAcceptance()) != EReturnCode.SUCCESS)
      { return returnCode; }

      // Inhabitants
      if ((returnCode = this.ResolveInhabitants()) != EReturnCode.SUCCESS)
      { return returnCode; }

      // Inhabitants
      if ((returnCode = this.ResolveBuildings(_initMode)) != EReturnCode.SUCCESS)
      { return returnCode; }

      if (_initMode == EInitMode.FULL)
      {
        
      }

      return returnCode;
    }

    public EReturnCode Attack(IList<ITroop> _troops, ICoordinate _coordinate)
    {
      throw new NotImplementedException();
    }

    public EReturnCode Support(IList<ITroop> _troops, ICoordinate _coordinate)
    {
      throw new NotImplementedException();
    }

    public EReturnCode CallBackTroops(ICoordinate _coordinate)
    {
      throw new NotImplementedException();
    }

    public EReturnCode SendRessources(IList<IRessourceLimits> _ressources, ICoordinate _coordinate)
    {
      throw new NotImplementedException();
    }

    public EReturnCode TrainUnit(EUnitType _unitType, int _amount)
    {
      throw new NotImplementedException();
    }

    public EReturnCode TrainTraders(int _amount)
    {
      throw new NotImplementedException();
    }

    public EReturnCode ChangeName(string _name)
    {
      throw new NotImplementedException();
    }
    #endregion Public
    #endregion Methods
  }
}
