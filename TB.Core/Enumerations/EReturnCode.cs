namespace TB.Core.Enumerations
{
  /// <summary>
  /// Represents the codes of erros this library can throw
  /// </summary>
  public enum EReturnCode
  {
    /// <summary>
    /// Something maybe went wrong or not.
    /// </summary>
    UNKNOWN = 0,

    /// <summary>
    /// Something went wrong, details are unknown
    /// </summary>
    FAIL = 100,

    /// <summary>
    /// Everything is fine; No problems
    /// </summary>
    SUCCESS = 200,

    /// <summary>
    /// Something went wrong with the connection, details are unknown
    /// </summary>
    CONNECTION_PROBLEM = 300,

    /// <summary>
    /// The connection seems to be ok but something went wrong
    /// by handling this action. e.g.: UpgradeBuilding().
    /// The main reason for this problem is unknown.
    /// </summary>
    ACTION_PROBLEM = 400,

    /// <summary>
    /// There are not enough ressources for this action.
    /// </summary>
    NOT_ENOUGH_RESSOURCES = 401,

    /// <summary>
    /// Occurs if tb should upgrade a building which l
    /// </summary>
    MAX_LEVEL_REACHED = 402,
  }
}
