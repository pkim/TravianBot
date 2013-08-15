using System;
using System.IO;
using Handler.Settings.Property;
using TB.Core.Classes.Handler;

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

      this.CacheHTML = true;
      this.UseTor    = true;

      // create the output directory
      if (!Directory.Exists(HInfo.PGlobal.Profile))
      { Directory.CreateDirectory(HInfo.PGlobal.Profile); }
      this.OutputDirectory = HInfo.PGlobal.Profile;
    }
    #endregion Constructor

    #region Properties
    /// <summary>
    /// Specifies if the client should use tor to access the server.
    /// </summary>
    /// <remarks>
    /// Default is true.
    /// </remarks>
    public Boolean UseTor { get; set; }

    /// <summary>
    /// The name of the Tor executable
    /// </summary>
    public String TorExe { get; set; }

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
    #endregion Properties
  }
}
