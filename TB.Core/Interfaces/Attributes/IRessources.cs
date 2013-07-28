using System;

namespace TB.Core.Interfaces.Attributes
{
  /// <summary>
  /// This interface represents the ressources of a village
  /// </summary>
  public interface IRessources : ICosts, ICash
  {
    /// <summary>
    /// The limit of wood this village can store
    /// </summary>
    Int32 LimitWood { get; set; }

    /// <summary>
    /// The limit of mud this village can store
    /// </summary>
    Int32 LimitMud { get; set; }

    /// <summary>
    /// The limit of stone this village can store
    /// </summary>
    Int32 LimitStone { get; set; }

    /// <summary>
    /// The limit of corn this village can store
    /// </summary>
    Int32 LimitCorn { get; set; }

    /// <summary>
    /// The amount of corn production which raies the corn storage
    /// </summary>
    Int32 FreeCorn { get; set; }
  }
}
