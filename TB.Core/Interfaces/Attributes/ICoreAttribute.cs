using System;
using TB.Core.Enumerations;

namespace TB.Core.Interfaces.Attributes
{
    public interface ICoreAttribute
    {
        #region Properties

        /// <summary>
        /// Specifies if the bot is already initilized.
        /// </summary>
        Boolean Initialized { get; }

        #endregion Properties

        #region Methods

        /// <summary>
        /// This method should be callen after initializing this class.
        /// Note that the default EInitMode is "OnDemand", which means 
        /// that it will initialice the core attribute objects like villages, 
        /// buildings, units .. and no details about specific buildings or 
        /// units for example
        /// </summary>
        /// <returns>
        /// Returns the code of the error if one has occured. 
        /// Note that this code would be "SUCCESS" if everything was ok.
        /// </returns>
        EReturnCode Init();

        /// <summary>
        /// This method should be callen after initializing this class.
        /// It will initialice the core attribute objects like villages, 
        /// buildings, units .. 
        /// </summary>
        /// <param name="_initMode">
        /// The mode specifies how much information about the core attributes
        /// will be initialized. "OnDemand" means that no details will be resolved,
        /// "Full" means everything will be downloaded but note that this will cause
        /// in high amount of simulated human activity. This will take a lot of time
        /// and will maybe noticed by the travian bot server, because no human takes
        /// a closer look at all buildings, units ... he has at once.
        /// </param>
        /// <returns>
        /// Returns the code of the error if one has occured. 
        /// Note that this code would be "SUCCESS" if everything was ok.
        /// </returns>
        EReturnCode Init(EInitMode _initMode);

        #endregion Methods
    }
}