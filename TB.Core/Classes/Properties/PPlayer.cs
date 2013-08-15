using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Handler.Settings.Property;
using TB.Core.Classes.Handler;
using TB.Core.Enumerations;

namespace TB.Core.Classes.Properties
{
  public class PPlayer : Property<PPlayer>
  {
    #region Constrctor
    private PPlayer()
    {
      this.Name       = String.Empty;
      this.Password   = String.Empty;
      

      // create the output directory
      if (!Directory.Exists(HInfo.PGlobal.Settings))
      { Directory.CreateDirectory(HInfo.PGlobal.Settings); }
      this.OutputDirectory = HInfo.PGlobal.Settings;
    }
    #endregion Constructor

    #region Properties
    
    /// <summary>
    /// The name for login
    /// </summary>
    public String Name { get; set; }

    /// <summary>
    /// The password for login
    /// </summary>
    public String Password { get; set; }

    #endregion Properties
  }
}
