using System;
using TB.Core.Enumerations;

namespace TB.Core.Interfaces.Attributes
{
    public interface IUnit
    {
        #region Properties

        /// <summary>
        /// The type of the unit
        /// </summary>
        EUnitType Type { get; }

        /// <summary>
        /// The name of the unit
        /// </summary>
        String Name { get; }

        /// <summary>
        /// The description of the unit
        /// </summary>
        String Description { get; }

        /// <summary>
        /// The id of the village the units are at home
        /// </summary>
        Int32 HomeVillageID { get; }

        /// <summary>
        /// The attack value of the unit
        /// </summary>
        Int32 Attack { get; }

        /// <summary>
        /// The defense value of the unit
        /// </summary>
        Int32 Defense { get; }

        /// <summary>
        /// The speed of the unit in fields per hour
        /// </summary>
        Int32 Speed { get; }

        #endregion Properties
    }
}