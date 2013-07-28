namespace TB.Core.Enumerations
{
  /// <summary>
  /// The mode of updates specifies how synchronisation happens
  /// </summary>
  public enum EUpdateMode
  {
    /// <summary>
    /// The update mode is unknown.
    /// </summary>
    UNKNOWN = 0,

    /// <summary>
    /// The update happens local, which means that data changes causes in recalculation of 
    /// the local data objects. This mode saves time, and SHA (Simulated Human Activity).
    /// </summary>
    /// <example>
    /// Amount of Unit A = 100. Sending 50 of them to attack somebody will decrease the amount.
    /// The update mode "LOCAL" means that the recalucaltion of the amount of units happens
    /// localy and isn't synchronised with the server.
    /// </example>
    /// <remarks>
    /// This mode can cause in information inconsistency 
    /// </remarks>
    LOCAL = 100,

    /// <summary>
    /// Each update will synchronise the bot with the server. No or nearly no information inconsistency is possible.
    /// </summary>
    /// <remarks>
    /// This mode causes in more data transmisssion and SHA (Simulated Human Activity) which needs more time.
    /// </remarks>
    SERVER = 101,
  }
}
