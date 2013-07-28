using System;
using System.Collections.Generic;
using TB.Core.Enumerations;

namespace TB.Core.Interfaces.Attributes
{
  /// <summary>
  /// This interface represents the public methods and properties
  /// of a village in travian
  /// </summary>
  public interface IVillage : ICoreAttribute
  {
    #region Properties
    /// <summary>
    /// The ID of the village
    /// </summary>
    Int32 ID { get; }
    
    /// <summary>
    /// The name of the village
    /// </summary>
    String Name { get; }

    /// <summary>
    /// The ressources of the village
    /// </summary>
    IRessources Ressources { get; }

    /// <summary>
    /// The buildings of the village
    /// </summary>
    IDictionary<EBuildingType, IDictionary<Int32, IBuilding>> Buildings { get; }

    /// <summary>
    /// The acceptance of the village
    /// </summary>
    Double Acceptance { get; }
    
    /// <summary>
    /// The defense bonus of the village in percentage
    /// </summary>
    Double DefenseBonus { get; }

    /// <summary>
    /// The units which are located at this village at the moment
    /// </summary>
    /// <remarks>
    /// Note that you can only send the units you are the owner of
    /// </remarks>
    IDictionary<EUnitType, IUnit> Units { get; }

    /// <summary>
    /// The coordinates of the village
    /// </summary>
    ICoordinate Coordinate { get; }

    /// <summary>
    /// The URL of the farm of the village
    /// </summary>
    Uri URLFarm { get; } 

    /// <summary>
    /// The URL of the buildings of the village
    /// </summary>
    Uri URLVillage { get; }
    #endregion Properties

    #region Methods
    /// <summary>
    /// Attack somebody with a amount of troops at a specific coordinate.
    /// </summary>
    /// <param name="_troops">The troops which should attack somebody</param>
    /// <param name="_coordinate">The coordinate where the troops should attack</param>
    /// <returns>
    /// Returns the code of the error if one has occured. 
    /// Note that this code would be "SUCCESS" if everything was ok.
    /// </returns>
    EReturnCode Attack(IList<ITroop> _troops, ICoordinate _coordinate);

    /// <summary>
    /// Supports somebody with a amount of troops at a specific coordinate.
    /// </summary>
    /// <param name="_troops">The troops which should support somebody</param>
    /// <param name="_coordinate">The coordinate where the troops should support</param>
    /// <returns>
    /// Returns the code of the error if one has occured. 
    /// Note that this code would be "SUCCESS" if everything was ok.
    /// </returns>
    EReturnCode Support(IList<ITroop> _troops, ICoordinate _coordinate);

    /// <summary>
    /// Call troops back to their home village
    /// </summary>
    /// <param name="_coordinate">The coordinate from where the troops should be call back</param>
    /// <returns>
    /// Returns the code of the error if one has occured. 
    /// Note that this code would be "SUCCESS" if everything was ok.
    /// </returns>
    EReturnCode CallBackTroops(ICoordinate _coordinate);

    /// <summary>
    /// Send ressources to a specific coordinate
    /// </summary>
    /// <param name="_ressources">The list of ressources which should be sended</param>
    /// <param name="_coordinate">The coordinate the ressources should be sended to</param>
    /// <returns>
    /// Returns the code of the error if one has occured. 
    /// Note that this code would be "SUCCESS" if everything was ok.
    /// </returns>
    EReturnCode SendRessources(IList<IRessources> _ressources, ICoordinate _coordinate);

    /// <summary>
    /// Trains a amount of units of a specific type
    /// </summary>
    /// <param name="_unitType">The type of the unit which should be trained</param>
    /// <param name="_amount">The count of units which should be trained</param>
    /// <returns>
    /// Returns the code of the error if one has occured. 
    /// Note that this code would be "SUCCESS" if everything was ok.
    /// </returns>
    EReturnCode TrainUnit(EUnitType _unitType, Int32 _amount);

    /// <summary>
    /// Trains a amount of traders
    /// </summary>
    /// <param name="_amount">The count of traders which should be trained</param>
    /// <returns>
    /// Returns the code of the error if one has occured. 
    /// Note that this code would be "SUCCESS" if everything was ok.
    /// </returns>
    EReturnCode TrainTraders(Int32 _amount);

    /// <summary>
    /// Change the name of the village
    /// </summary>
    /// <param name="_name">The new name of the village</param>
    /// <returns>
    /// Returns the code of the error if one has occured. 
    /// Note that this code would be "SUCCESS" if everything was ok.
    /// </returns>
    EReturnCode ChangeName(String _name);

    #endregion Methods
  }
}