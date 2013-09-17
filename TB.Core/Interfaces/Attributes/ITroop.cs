using System;
using TB.Core.Enumerations;

namespace TB.Core.Interfaces.Attributes
{
    /// <summary>
    /// This interface specifies the type and amoun of units a troop can have.
    /// </summary>
    public interface ITroop
    {
        #region Properties    

        /// <summary>
        /// The type of the troop
        /// </summary>
        EUnitType Type { get; }

        /// <summary>
        /// The amount of units
        /// </summary>
        Int32 COUnit { get; }

        #endregion Properties
    }
}