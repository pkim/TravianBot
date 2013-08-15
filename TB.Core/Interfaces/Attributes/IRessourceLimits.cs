using System;

namespace TB.Core.Interfaces.Attributes
{
  /// <summary>
  /// This interface represents the ressources of a village
  /// </summary>
  public interface IRessourceLimits
  {

    /// <summary>
    /// The limit of wood, mud, stone this village can store
    /// </summary>
    Int32 LimitWareHouse { get; }

    /// <summary>
    /// The limit of corn this village can store
    /// </summary>
    Int32 LimtGranary { get; }

    /// <summary>
    /// The amount of corn production which raies the corn storage
    /// </summary>
    Int32 FreeCrop { get; }
  }
}
