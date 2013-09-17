using System;
using TB.Core.Enumerations;
using TB.Core.Interfaces.Attributes;

namespace TB.Core.Classes.Attributes
{
    public class Player : IPlayer
    {
        #region Constructor

        public Player()
        {
            this.Initialized = false;

            this.ID = new Int32();
            this.Name = String.Empty;
            this.Nation = ENation.UNKNOWN;
            this.Rank = new Int32();
            this.Age = new Int32();
            this.Gender = EGender.UNKNOWN;
            this.City = String.Empty;
        }

        #endregion Constructor

        #region Properties

        public Boolean Initialized { get; protected set; }
        public Int32 ID { get; protected set; }
        public String Name { get; protected set; }
        public ENation Nation { get; protected set; }
        public Int32 Rank { get; protected set; }
        public Int32 Age { get; protected set; }
        public EGender Gender { get; protected set; }
        public string City { get; protected set; }

        #endregion Properties

        #region Methods

        #region Public

        public EReturnCode Init()
        {
            throw new NotImplementedException();
        }

        public EReturnCode Init(EInitMode _initMode)
        {
            throw new NotImplementedException();
        }

        #endregion Public

        #region Protected

        /// <summary>
        /// Resovles the ID of the player
        /// </summary>
        /// <returns>
        /// Returns the code of the error if one has occured. 
        /// Note that this code would be "SUCCESS" if everything was ok. 
        /// </returns>
        protected EReturnCode ResolveID()
        {
            return EReturnCode.UNKNOWN;
        }

        #endregion Protected

        #endregion Methods
    }
}