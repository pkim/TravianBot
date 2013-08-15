using System;
using TB.Core.Interfaces.Attributes;

namespace TB.Core.Classes.Attributes
{
  class Ressources : IRessources
  {
    #region Constructor

    /// <summary>
    /// This object serves properties for ressource and their limits
    /// </summary>
    /// <param name="_wood">The amount of wood</param>
    /// <param name="_mud">The amount of mud</param>
    /// <param name="_stone">The amount of stone</param>
    /// <param name="_corn">The amount of corn</param>
    /// <param name="_limitWareHouse">The limit of wood, stone and mud which can be stored</param>
    /// <param name="_limitGranary">The limit of corn which can be stored</param>
    /// <param name="_freeCrop">The amount of free corn</param>
    public Ressources(Int32 _wood, Int32 _mud, Int32 _stone, Int32 _corn, 
                      Int32 _limitWareHouse, Int32 _limitGranary, Int32 _freeCrop)
    {
      this.Wood  = _wood;
      this.Mud   = _mud;
      this.Stone = _stone;
      this.Corn  = _corn;

      this.LimitWareHouse = _limitWareHouse;
      this.LimtGranary    = _limitGranary;
      this.FreeCrop       = _freeCrop;
    }
    #endregion Constructor

    #region Properties

    public Int32 LimitWareHouse { get; protected set; }
    public Int32 LimtGranary { get; protected set; }
    public Int32 FreeCrop { get; protected set; }

    public int Wood { get; protected set; }
    public int Mud { get; protected set; }
    public int Stone { get; protected set; }
    public int Corn { get; protected set; }
    #endregion Properties
  }
}
