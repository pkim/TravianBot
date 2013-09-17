using System;
using System.IO;
using HLib.Settings.Property;
using TB.Core.Classes.Handler;

namespace TB.Core.Classes.Properties
{
    public class PLinks : Property<PLinks>
    {
        #region Constructor

        private PLinks()
        {
            this.Server = "http://ts7.travian.de/";

            this.Farm = "dorf1.php";
            this.Village = "dorf2.php";
            this.VillagesOverview = "dorf3.php";

            this.Map = "karte.php";
            this.Statistic = "statistiken.php";
            this.Reports = "berichte.php";
            this.Messages = "nachrichten.php";

            this.Building = "build.php";
            this.Player = "spieler.php";

            this.Login = "login.php";
            this.Logout = "logout.php";

            // create the output directory
            if (!Directory.Exists(HInfo.PGlobal.Settings))
            {
                Directory.CreateDirectory(HInfo.PGlobal.Settings);
            }
            this.OutputDirectory = HInfo.PGlobal.Settings;
        }

        #endregion Constructor

        #region Properties

        public String Server { get; set; }

        public String Farm { get; set; }
        public String Village { get; set; }
        public String VillagesOverview { get; set; }

        public String Map { get; set; }
        public String Statistic { get; set; }
        public String Reports { get; set; }
        public String Messages { get; set; }
        public String Player { get; set; }

        public String Building { get; set; }

        public String Login { get; set; }
        public String Logout { get; set; }

        #endregion Properties
    }
}