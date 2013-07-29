using System;
using TB.Core.Classes.Handler;
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

      this.ID     = new Int32();
      this.Name   = String.Empty;
      this.Nation = ENation.UNKNOWN;
    }
    #endregion Constructor

    #region Properties
    public Boolean Initialized { get; private set; }
    public Int32 ID { get; private set; }
    public String Name { get; private set; }
    public ENation Nation { get; private set; }
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
      // resovle id here before changing output directory //

      /* Set the output directory for the cached HTML Documents              *
       * Maybe it would be nessecery to move the cached html document of the *
       * current directory which is a random generated number to the new one */
      HInfo.PConfig.CacheHTMLOutputDirectory = String.Format("{0}/{1}/",
                                                    AppDomain.CurrentDomain.BaseDirectory,
                                                    this.ID);
      return EReturnCode.UNKNOWN;
    }
    #endregion Protected
    #endregion Methods

  }
}
