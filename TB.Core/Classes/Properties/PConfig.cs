using System;
using Handler.Settings.Property;

namespace TB.Core.Classes.Properties
{
  public class PConfig : Property<PConfig>
  {
    #region Constructor
    private PConfig()
    {
      this.SleepDurationBetweenActions = 1024;
      this.SleepDurationBetweenActionsDevianceMin = 64;
      this.SleepDurationBetweenActionsDevianceMax = 512;

      this.CacheHTML = false;
      this.CacheHTMLOutputDirectory = String.Format("{0}/{1}/", 
                                                    AppDomain.CurrentDomain.BaseDirectory, 
                                                    new Random().Next());
    }
    #endregion Constructor

    #region Properties
    /// <summary>
    /// Specifies the time span between two interactions with the server.
    /// Default is 1024 ms.
    /// </summary>
    public Int32 SleepDurationBetweenActions { get; set; }

    /// <summary>
    /// Specifies the minium of deviance of the time span between two interactions with the server.
    /// Default is 64 ms.
    /// </summary>
    public Int32 SleepDurationBetweenActionsDevianceMin { get; set; }
    
    /// <summary>
    /// Specifies the minium of deviance of the time span between two interactions with the server.
    /// Default is 512 ms.
    /// </summary>
    public Int32 SleepDurationBetweenActionsDevianceMax { get; set; }

    /// <summary>
    /// Specifies if the bot should cache the html document on the disk.
    /// Default is false.
    /// </summary>
    public Boolean CacheHTML { get; set; }

    /// <summary>
    /// Specifies the path of the cached HTML documents the bot should save them at.
    /// Default is "install directory"/"player id" or a random generated number if the player id 
    /// can not be parsed
    /// </summary>
    public String CacheHTMLOutputDirectory { get; set; }
    #endregion Properties

  }
}
