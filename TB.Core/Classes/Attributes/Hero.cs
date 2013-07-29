using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TB.Core.Enumerations;
using TB.Core.Interfaces.Attributes;

namespace TB.Core.Classes.Attributes
{
  public class Hero : IHero
  {

    #region Constructor
    public Hero()
    {
      this.Initialized = false;
      
      this.Level      = new Int32();
      this.Health     = new Int32();
      this.Experience = new Int32();
      this.Speed      = new Int32();
      this.Hided      = false;

      this.HealthRegeneration   = new Int32();
      this.ExperienceForLevelUp = new Int32();

      this.Strength   = new Int32();
      this.OffBonus   = new Int32();
      this.DefBonus   = new Int32();
      this.Ressources = new Int32();

      this.Home = new Int32();
      this.Adventures = new SortedList<TimeSpan, IAdventure>();
    }
    #endregion Constructor

    #region Properties
    public Boolean Initialized { get; private set; }
    public Int32 Level { get; private set; }
    public Int32 Health { get; private set; }
    public Int32 HealthRegeneration { get; private set; }
    public Int32 Experience { get; private set; }
    public Int32 ExperienceForLevelUp { get; private set; }
    public Int32 Speed { get; private set; }
    public ICosts HeroProduction { get; private set; }
    public Boolean Hided { get; private set; }
    public Int32 Strength { get; private set; }
    public Int32 OffBonus { get; private set; }
    public Int32 DefBonus { get; private set; }
    public Int32 Ressources { get; private set; }
    public Int32 Home { get; private set; }
    public SortedList<TimeSpan, IAdventure> Adventures { get; private set; }
    #endregion Properties
    
    #region Methods
    
    public EReturnCode Init()
    {
      throw new NotImplementedException();
    }

    public EReturnCode Init(EInitMode _initMode)
    {
      throw new NotImplementedException();
    }


    public EReturnCode SwitchHome(ICoordinate _coordinate)
    {
      throw new NotImplementedException();
    }

    public EReturnCode SwitchHome(IVillage _village)
    {
      throw new NotImplementedException();
    }

    public EReturnCode GoOnAdventure(IAdventure _adventure)
    {
      throw new NotImplementedException();
    }
    #endregion Methods
  }
}
