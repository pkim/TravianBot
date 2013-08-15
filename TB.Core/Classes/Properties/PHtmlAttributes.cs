using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Handler.Settings.Property;
using TB.Core.Classes.Handler;

namespace TB.Core.Classes.Properties
{
  public class PHtmlAttributes : Property<PHtmlAttributes>
  {
    #region Constructor
    private PHtmlAttributes()
    {
      this.Value = "value";
      this.HRef  = "href";
      this.Alt   = "alt";

      this.IDOverview = "overview";
      this.IDLowRes   = "lowRes";
      this.IDVillages = "villages";
      this.IDStockBar = "stockBar";

      this.IDStockBarWarehouse = "stockBarWarehouse";
      this.IDStockBarGranary   = "stockBarGranary";
      this.IDStockBarFreeCrop  = "stockBarFreeCrop";

      this.IDRx = "rx";

      // create the output directory
      if (!Directory.Exists(HInfo.PGlobal.Settings))
      { Directory.CreateDirectory(HInfo.PGlobal.Settings); }
      this.OutputDirectory = HInfo.PGlobal.Settings;
    }
    #endregion Constructor

    #region Properties
    public String Value { get; set; }
    public String HRef { get; set; }
    public String Alt { get; set; }

    public String IDOverview { get; set; }
    public String IDLowRes { get; set; }
    public String IDVillages { get; set; }
    public String IDStockBar { get; set; }
    public String IDStockBarWarehouse { get; set; }
    public String IDStockBarGranary { get; set; }
    public String IDStockBarFreeCrop { get; set; }
    public String IDRx { get; set; }
    #endregion Properties
  }
}
