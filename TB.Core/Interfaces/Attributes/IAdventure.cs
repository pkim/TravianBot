using System;
using TB.Core.Enumerations;

namespace TB.Core.Interfaces.Attributes
{
    public interface IAdventure
    {
        #region Properties

        /// <summary>
        /// The id of the adventure
        /// </summary>
        Int32 ID { get; }

        /// <summary>
        /// The coordinates of the adventure
        /// </summary>
        ICoordinate Coordinate { get; }

        /// <summary>
        /// The time span the hero needs to get to
        /// </summary>
        TimeSpan Runtime { get; }

        /// <summary>
        /// The date the adventure expires
        /// </summary>
        DateTime Expired { get; }

        /// <summary>
        /// The link to send the hero on the adventure
        /// </summary>
        Uri Link { get; }

        /// <summary>
        /// The difficulty of the adventure
        /// </summary>
        EDifficulty Difficulty { get; }

        #endregion Properties
    }
}