using System;
using TB.Core.Enumerations;

namespace TB.Core.Interfaces.Attributes
{
  public interface IBuilding
  {
    #region Properties
    /// <summary>
    /// The id of this building; Is unique in the vilage it is part off
    /// </summary>
    Int32  ID        { get; }
    /// <summary>
    /// The id of the village this building is part off
    /// </summary>
    Int32  VillageID { get; }
    /// <summary>
    /// The name of the buildng
    /// </summary>
    String Name      { get; }
    /// <summary>
    /// The current Level of the building
    /// </summary>
    Int32  Level     { get; }
    /// <summary>
    /// The costs for the upgrade of this building
    /// </summary>
    ICosts Costs     { get; }

    /// <summary>
    /// The type of the building represents his functionality
    /// </summary>
    EBuildingType Type { get; }

    /// <summary>
    /// Calculates on demand if this building is upgradeable and return this result
    /// </summary>
    Boolean Upgradeable { get; }

    /// <summary>
    /// Calculates on demand how long upgrading this building will take and return this result
    /// </summary>
    TimeSpan UpgradenDuration  { get; }
    DateTime UpgradeBeginning  { get; }
    DateTime UpgradeEnding     { get; }
    Boolean  UnderConstruction { get; }
    #endregion Properties

    #region Methods
    /// <summary>
    /// Tries to upgrade the given building by one level.
    /// </summary>
    /// <returns>
    /// True if the upgrade was successfull, otherwise false.
    /// Note that this action can fail, if not enough ressources
    /// </returns>
    EReturnCode Upgrade();

    /// <summary>
    /// Tries to upgrade the given building by a given 
    /// </summary>
    /// <param name="_level">
    /// The amount of levels this building should be upgraded to</param>
    /// <returns>
    /// Returns the code of the error if one has occured. 
    /// Note that this code is "SUCCESS" if everything was ok.
    /// </returns>
    EReturnCode Upgrade(Int32 _level);

    /// <summary>
    /// Reduce the level of a given building by one.
    /// </summary>
    /// <remarks>
    /// That the building will be deleted if the level is equal to zero
    /// </remarks>
    /// <returns>
    /// Returns the code of the error if one has occured. 
    /// Note that this code is "SUCCESS" if everything was ok.
    /// </returns>
    EReturnCode Downgrade();

    /// <summary>
    /// Reduce the level of a given building by one.
    /// </summary>
    /// <remarks>
    /// That the building will be deleted if the level is equal to zero
    /// </remarks>
    /// <param name="_level">
    /// The amount of levels this building should be upgraded to</param>
    /// <returns>
    /// Returns the code of the error if one has occured. 
    /// Note that this code is "SUCCESS" if everything was ok.
    /// </returns>
    EReturnCode Downgrade(Int32 _level);

    /// <summary>
    /// Removes a given building.
    /// </summary>
    /// <remarks>
    /// That this method just reduces the level of the building as long it is not 
    /// zero
    /// </remarks>
    /// <returns>
    /// Returns the code of the error if one has occured. 
    /// Note that this code is "SUCCESS" if everything was ok.
    /// </returns>
    EReturnCode Remove();
    #endregion Methods
  }
}
