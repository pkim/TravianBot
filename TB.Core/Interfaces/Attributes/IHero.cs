using System;
using System.Collections.Generic;
using TB.Core.Enumerations;

namespace TB.Core.Interfaces.Attributes
{
    public interface IHero : ICoreAttribute
    {
        #region Properties

        /// <summary>
        /// The level of the hero
        /// </summary>
        Int32 Level { get; }

        /// <summary>
        /// The health of the hero
        /// </summary>
        Int32 Health { get; }

        /// <summary>
        /// The health regenartion of the hero in percentage
        /// </summary>
        Int32 HealthRegeneration { get; }

        /// <summary>
        /// The current amount of experience
        /// </summary>
        Int32 Experience { get; }

        /// <summary>
        /// The amount of experience which is needed for level up
        /// </summary>
        Int32 ExperienceForLevelUp { get; }

        /// <summary>
        /// The speed of the hero in fields/hour
        /// </summary>
        Int32 Speed { get; }

        /// <summary>
        /// The amount of ressources the hero improves
        /// </summary>
        ICosts HeroProduction { get; }

        /// <summary>
        /// Specifies if the hero is currently hided from battles
        /// </summary>
        Boolean Hided { get; }

        /// <summary>
        /// The strength of the hero. Specifies how much health he has 
        /// and how much damage he makes
        /// </summary>
        Int32 Strength { get; }

        /// <summary>
        /// The amount of offensive bonus
        /// </summary>
        Int32 OffBonus { get; }

        /// <summary>
        /// The amount of defensive bonus
        /// </summary>
        Int32 DefBonus { get; }

        /// <summary>
        /// The amount of skill points which are used for 
        /// extend the local ressource production
        /// </summary>
        Int32 Ressources { get; }

        /// <summary>
        /// The id of the village the hero is at home
        /// </summary>
        Int32 Home { get; }

        /// <summary>
        /// The adventures the hero can go on
        /// </summary>
        SortedList<TimeSpan, IAdventure> Adventures { get; }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Sends the hero to another village which is his new home. 
        /// A hero can only be send from his home to another coordinates.
        /// </summary>
        /// <param name="_coordinate">The coordinates of the village which should be the new home</param>
        /// <returns>
        /// Returns the code of the error if one has occured. 
        /// Note that this code would be "SUCCESS" if everything was ok.
        /// </returns>
        EReturnCode SwitchHome(ICoordinate _coordinate);

        /// <summary>
        /// Sends the hero to another village which is his new home. 
        /// A hero can only be send from his home to another coordinates.
        /// </summary>
        /// <param name="_village">The village which should be the new home</param>
        /// <returns>
        /// Returns the code of the error if one has occured. 
        /// Note that this code would be "SUCCESS" if everything was ok.
        /// </returns>
        EReturnCode SwitchHome(IVillage _village);

        /// <summary>
        /// Sends the hero to an adventure
        /// </summary>
        /// <param name="_adventure">The adventure the hero should go on</param>
        /// <returns>
        /// Returns the code of the error if one has occured. 
        /// Note that this code would be "SUCCESS" if everything was ok.
        /// </returns>
        EReturnCode GoOnAdventure(IAdventure _adventure);

        #endregion Methods
    }
}