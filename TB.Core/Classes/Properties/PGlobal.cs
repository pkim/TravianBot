using System;
using System.IO;
using HLib.Settings.Property;

namespace TB.Core.Classes.Properties
{
  public class PGlobal : Property<PGlobal>
  {
    #region Objects

    private String profile;

    #endregion Objects

    #region Constructor
    private PGlobal()
    {
      // login credentials
      this.S1     = "Einloggen";
      this.W      = "1600%3A900";
      this.LowRes = "1";

      this.TorExe = "tor.exe";

      this.Base      = AppDomain.CurrentDomain.BaseDirectory;
      this.Tor       = this.Base;
      this.Profiles  = String.Format("{0}{1}\\", this.Base, "Profiles" );
      this.Languages = String.Format("{0}{1}\\", this.Base, "Languages");

      // the following one must be set dynamically  
      this.Profile   = this.Base;
      this.Cache     = this.Base;
      this.Settings  = this.Base;
      this.Languages = this.Base;

      this.LogConfig = this.Base;

      // create the output directory
      if (!Directory.Exists(this.Profiles))
      {
          Directory.CreateDirectory(this.Profiles);
      }
      this.OutputDirectory = this.Profiles;
    }
    #endregion Constructor

    #region Properties

    /// <summary>
    /// The path of the log config file
    /// </summary>
    public String LogConfig { get; set; }

    /// <summary>
    /// The base directory of the program
    /// </summary>
    public String Base { get; set; }

    public String Languages { get; set; }

    /// <summary>
    /// The cache of the html documents
    /// </summary>
    public String Cache { get; set; }

    /// <summary>
    /// Must be dynamically allocated because the name of the player 
    /// will also be dynamically resolved 
    /// </summary>
    public String Profile
    {
      get { return profile; }

      set
      {
        this.profile  = value;
        this.Cache    = String.Format("{0}{1}\\", this.profile, "Cache");
        this.Settings = String.Format("{0}{1}\\", this.profile, "Settings");
      }
    }

    /// <summary>
    /// The path to the profiles
    /// </summary>
    public String Profiles { get; set; }

    /// <summary>
    /// The path to the properties
    /// </summary>
    public String Settings { get; set; }

    /// <summary>
    /// The directory the tor exe file is situated
    /// </summary>
    public String Tor { get; set; }

    /// <summary>
    /// The name of the Tor executable
    /// </summary>
    public String TorExe { get; set; }

    /// <summary>
    /// The session key
    /// </summary>
    public String S1 { get; set; }

    /// <summary>
    /// The resolution of the screen
    /// </summary>
    public String W { get; set; }

    /// <summary>
    /// Specifies if the server should send low resolution pictures
    /// </summary>
    public String LowRes { get; set; }

    #endregion Properties
  }
}