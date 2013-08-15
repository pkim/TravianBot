using System.IO;
using Handler.Settings.Property;
using TB.Core.Classes.Handler;
using TB.Core.Interfaces.Properties;

namespace TB.Core.Classes.Properties.Languages
{
  public class PDictionaryDE : Property<PDictionaryDE>, IPDictionary
  {
    #region Constructor
    private PDictionaryDE()
    {
      this.Unused        = "Bauplatz";
      this.Ironmine      = "Eisenmine";
      this.Claypit       = "Lehmgrube";
      this.Cornfarm      = "Getreidefarm";
      this.Lumberjack    = "Holzfäller";
      this.Stash         = "Versteck";
      this.Warehouse     = "Rohstofflager";
      this.Granary       = "Kornspeicher";
      this.Cornmil       = "Getreidemühle";
      this.HeroYard      = "Heldenhof";
      this.Palace        = "Palast";
      this.Barrack       = "Kaserne";
      this.Embassy       = "Botschaft";
      this.Claystill     = "Lehmbrennerei";
      this.Market        = "Marktplatz";
      this.MainBuilding  = "Hauptgebäude";
      this.IronFoundry   = "Eisengießerei";
      this.Lumbermil     = "Sägewerk";
      this.Academy       = "Akademie";
      this.Blacksmith    = "Schmiede";
      this.Workshop      = "Werkstatt";
      this.AssemblyPlace = "Versammlungsplatz";
      this.Wall          = "Stadtmauer";
      this.Bakery        = "Bäckerei";
      this.Barn          = "Stall";
      this.Chiseler      = "Steinmetz";

      // create the output directory
      if (!Directory.Exists(HInfo.PGlobal.Languages))
      { Directory.CreateDirectory(HInfo.PGlobal.Languages); }
      this.OutputDirectory = HInfo.PGlobal.Languages;
    }
    #endregion Constructor

    #region Properties
    public string Unused { get; set; }
    public string Lumberjack { get; set; }
    public string Ironmine { get; set; }
    public string Claypit { get; set; }
    public string Cornfarm { get; set; }
    public string Cornmil { get; set; }
    public string HeroYard { get; set; }
    public string Palace { get; set; }
    public string Barrack { get; set; }
    public string Embassy { get; set; }
    public string Claystill { get; set; }
    public string Market { get; set; }
    public string MainBuilding { get; set; }
    public string IronFoundry { get; set; }
    public string Lumbermil { get; set; }
    public string Academy { get; set; }
    public string Blacksmith { get; set; }
    public string Workshop { get; set; }
    public string Stash { get; set; }
    public string Warehouse { get; set; }
    public string Granary { get; set; }
    public string AssemblyPlace { get; set; }
    public string Wall { get; set; }
    public string Bakery { get; set; }
    public string Barn { get; set; }
    public string Chiseler { get; set; }
    #endregion Properties
  }
}
