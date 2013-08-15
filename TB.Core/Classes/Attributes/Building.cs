using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TB.Core.Enumerations;
using TB.Core.Interfaces.Attributes;

namespace TB.Core.Classes.Attributes
{
  public class Building : IBuilding
  {
    #region Constructor
    public Building(Int32 _villageID, Int32 _id, String _name, EBuildingType _type)
    {
      this.VillageID = _villageID;
      this.ID        = _id;
      this.Name      = _name;
      this.Type      = _type;
    }
    #endregion Constructor

    #region Properties
    public int ID { get; private set; }
    public int VillageID { get; private set; }
    public string Name { get; private set; }
    public int Level { get; private set; }
    public ICosts Costs { get; private set; }
    public EBuildingType Type { get; private set; }
    public bool Upgradeable { get; private set; }
    public TimeSpan UpgradeDuration { get; private set; }
    public DateTime UpgradeEnding { get; private set; }
    public bool UnderConstruction { get; private set; }
    public bool Initialized { get; private set; }
    #endregion Properties

    #region Methods

    #region Protected
    protected EReturnCode ResolveLevel()
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
      EReturnCode returnCode;

      if((returnCode = this.ResolveLevel()) != EReturnCode.SUCCESS)
      { return returnCode; }

      if (_initMode == EInitMode.FULL)
      {
        
      }

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
    #endregion Public
    #endregion Methods
  }
}
