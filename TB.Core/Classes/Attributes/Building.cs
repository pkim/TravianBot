using System;
using HtmlAgilityPack;
using TB.Core.Classes.Handler;
using TB.Core.Enumeration;
using TB.Core.Enumerations;
using TB.Core.Interfaces.Attributes;
using TB.Core.Interfaces.Handler;

namespace TB.Core.Classes.Attributes
{
  public class Building : IBuilding
  {
    #region Constructor
    public Building(IHPage _pageHandler, Int32 _villageID, Int32 _id, String _name)
    {
      this.HPage = _pageHandler;

      this.VillageID = _villageID;
      this.ID        = _id;
      this.Name      = _name;

      // set type if dictionary contains configuration for the name
      try
      {
        this.Type = HInfo.PDictionary.Buildings[this.Name];
      }
      catch (Exception exception)
      {
        HInfo.LogHandler.Error(String.Format("The building name {0} isn't configured in the dictionary of building names. Unable to resovle type", this.Name), exception);
        throw;
      }

      // set detail link
      this.DetailLink = HLink.GetLink(EPageID.BUILDING, this.VillageID, this.ID);
    }
    #endregion Constructor

    #region Properties

    #region Protected
    protected Uri UpgradeLink { get; set; }
    protected IHPage HPage { get; set; }
    #endregion Protected

    #region Public
    public int ID { get; protected set; }
    public int VillageID { get; protected set; }
    public string Name { get; protected set; }
    public int Level { get; protected set; }
    public String Description { get; protected set; }
    public ICosts Costs { get; protected set; }
    public EBuildingType Type { get; protected set; }
    public bool Upgradeable { get; protected set; }
    public TimeSpan UpgradeDuration { get; protected set; }
    public DateTime UpgradeEnding { get; protected set; }
    public bool UnderConstruction { get; protected set; }
    public Uri DetailLink { get; protected set; }
    public bool Initialized { get; protected set; }
    #endregion Public
    #endregion Properties

    #region Methods

    #region Protected

    protected EReturnCode ResolveCosts()
    {
        return EReturnCode.SUCCESS;
    }

    protected EReturnCode ResolveUpgradeable()
    {
      return EReturnCode.SUCCESS;
    }

    protected EReturnCode ResolveUpgradeDuration()
    {
        return EReturnCode.SUCCESS;
    }

    protected EReturnCode ResolveUpgradeEnding()
    {
        return EReturnCode.SUCCESS;
    }

    protected EReturnCode ResolveUnoderConstruction()
    {
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
      EReturnCode returnCode = EReturnCode.UNKNOWN;

      if (_initMode == EInitMode.FULL)
      {
        if ((returnCode = this.ResolveCosts()) != EReturnCode.SUCCESS)
        {
          return returnCode;
        }

        if ((returnCode = this.ResolveUpgradeable()) != EReturnCode.SUCCESS)
        {
          return returnCode;
        }

        if ((returnCode = this.ResolveUpgradeDuration()) != EReturnCode.SUCCESS)
        {
          return returnCode;
        }

        if ((returnCode = this.ResolveUpgradeEnding()) != EReturnCode.SUCCESS)
        {
          return returnCode;
        }

        if ((returnCode = this.ResolveUnoderConstruction()) != EReturnCode.SUCCESS)
        {
          return returnCode;
        }
      }

      this.Initialized = true;
      return returnCode;
    }

    public EReturnCode Upgrade()
    {
        throw new NotImplementedException();
    }

    public EReturnCode Upgrade(int _level)
    {
        throw new NotImplementedException();
    }

    public EReturnCode Downgrade()
    {
        throw new NotImplementedException();
    }

    public EReturnCode Downgrade(int _level)
    {
        throw new NotImplementedException();
    }

    public EReturnCode Remove()
    {
        throw new NotImplementedException();
    }

    public override string ToString()
    {
      return String.Format("Building: {0}\n ID: {1}\n Type: {2}\n Level: {3}", this.Name, this.ID, this.Type, this.Level);
    }

    #endregion Public

    #endregion Methods
  }
}