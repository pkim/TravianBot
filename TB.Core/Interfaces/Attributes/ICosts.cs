using System;

namespace TB.Core.Interfaces.Attributes
{
  public interface ICosts
  {
    /// <summary>
    /// The amount of wood
    /// </summary>
    Int32 Wood { get; }

    /// <summary>
    /// The amount of mud
    /// </summary>
    Int32 Mud { get; }

    /// <summary>
    /// The amount of stone
    /// </summary>
    Int32 Stone { get; }

    /// <summary>
    /// The amount of corn
    /// </summary>
    Int32 Corn { get; }
  }
}
