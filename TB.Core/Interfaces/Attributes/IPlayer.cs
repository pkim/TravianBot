using System;
using TB.Core.Enumerations;

namespace TB.Core.Interfaces.Attributes
{
    /// <summary>
    /// This interface represents a player of travian
    /// </summary>
    public interface IPlayer : ICoreAttribute
    {
        #region Properties

        /// <summary>
        /// The ID of the player
        /// </summary>
        Int32 ID { get; }

        /// <summary>
        /// The name of the player
        /// </summary>
        String Name { get; }

        /// <summary>
        /// The nation the player is playing
        /// </summary>
        ENation Nation { get; }

        /// <summary>
        /// The rank of the player
        /// </summary>
        Int32 Rank { get; }

        /// <summary>
        /// The age of the player
        /// </summary>
        Int32 Age { get; }

        /// <summary>
        /// The gender of the player
        /// </summary>
        EGender Gender { get; }

        /// <summary>
        /// The city the player is situated
        /// </summary>
        String City { get; }

        #endregion Properties
    }
}