using System;
using System.IO;
using HLib.Settings.Property;
using TB.Core.Classes.Handler;

namespace TB.Core.Classes.Properties
{
  public class PXPathExpr : Property<PXPathExpr>
  {
    #region Constructor

    private PXPathExpr()
    {
      this.LoginSessionID = ".//input[@name='login']";
      this.VillageOverviewBaseNode = ".//a[@href]";

      this.VillageWood = ".//span[@id='l1']";
      this.VillageMud = ".//span[@id='l2']";
      this.VillageStone = ".//span[@id='l3']";
      this.VillageCorn = ".//span[@id='l4']";

      this.VillageAcceptance = ".//div[@class='loyalty medium']";

      this.TBody = ".//tbody";
      this.Tr = ".//tr";
      this.AHrefVillageName = ".//a[@href]";
      this.TdVillageName = ".//td[@class='name']";
      this.SpanMainVillage = ".//span[@class='mainVillage']";
      this.TdInhabitants = ".//td[@class='inhabitants']";

      this.DivVillageName = ".//div[@class='name']";
      this.SpanCoordinateX = ".//span[@class='coordinateX']";
      this.SpanCoordinateY = ".//span[@class='coordinateY']";

      this.AreaFarm    = ".//area[(@shape='circle') and not (@alt='')]";
      this.AreaVillage = ".//area[(@shape='poly')]";

      // create the output directory
      if (!Directory.Exists(HInfo.PGlobal.Settings))
      {
        Directory.CreateDirectory(HInfo.PGlobal.Settings);
      }
      this.OutputDirectory = HInfo.PGlobal.Settings;
    }

    #endregion Constructor

    #region Properties

    public String LoginSessionID { get; set; }
    public String VillageOverviewBaseNode { get; set; }

    public String VillageWood { get; set; }
    public String VillageMud { get; set; }
    public String VillageStone { get; set; }
    public String VillageCorn { get; set; }
    public String VillageLimitGranary { get; set; }

    public String VillageAcceptance { get; set; }

    public String TBody { get; set; }
    public String Tr { get; set; }
    public String AHrefVillageName { get; set; }
    public String TdVillageName { get; set; }
    public String TdInhabitants { get; set; }
    public String SpanMainVillage { get; set; }

    public String DivVillageName { get; set; }
    public String SpanCoordinateX { get; set; }
    public String SpanCoordinateY { get; set; }

    public String AreaFarm { get; set; }
    public String AreaVillage { get; set; }

    #endregion Properties
  }
}