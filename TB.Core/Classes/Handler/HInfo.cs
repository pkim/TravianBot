using System.IO;
using log4net;
using TB.Core.Classes.Properties;

[assembly: log4net.Config.XmlConfigurator(ConfigFile = "Logging.config", Watch = true)]

namespace TB.Core.Classes.Handler
{
    public static class HInfo
    {
        #region Objects

        private static ILog logHandler;

        #endregion Objects

        #region Properties

        /// <summary>
        /// This class serves all HTTP Parameters which are needed
        /// for the Travian Bot
        /// </summary>
        public static PHTTPParameters PHTTPParameters
        {
            get { return PHTTPParameters.GetInstance(); }
        }

        /// <summary>
        /// This class serves XPath expressions which are needed
        /// to extract elements from a html document which are part 
        /// of Travian
        /// </summary>
        public static PXPathExpr PXPathExpr
        {
            get { return PXPathExpr.GetInstance(); }
        }

        /// <summary>
        /// This class serves the attributes of the player like login credentials
        /// </summary>
        public static PPlayer PPlayer
        {
            get { return PPlayer.GetInstance(); }
        }

        /// <summary>
        /// This class serves HTML attributes which are needed
        /// to extract values from a html document which are part
        /// of Travian
        /// </summary>
        public static PHtmlAttributes PHtmlAttributes
        {
            get { return PHtmlAttributes.GetInstance(); }
        }

        /// <summary>
        /// This class serves all the links of html documents which
        /// are part of travian
        /// </summary>
        public static PLinks PLinks
        {
            get { return PLinks.GetInstance(); }
        }

        /// <summary>
        /// This class serves all the links of html documents which
        /// are part of travian
        /// </summary>
        public static PDictionary PDictionary
        {
            get { return PDictionary.GetInstance(); }
        }

        /// <summary>
        /// This class serves the global configuration of the travian bot
        /// </summary>
        public static PGlobal PGlobal
        {
            get { return PGlobal.GetInstance(); }
        }

        /// <summary>
        /// This class serves the configuration of the travian bot
        /// </summary>
        public static PConfig PConfig
        {
            get { return PConfig.GetInstance(); }
        }

        /// <summary>
        /// The log4net logging handler
        /// </summary>
        public static ILog LogHandler
        {
            get
            {
                if (HInfo.logHandler == null)
                {
                    log4net.Config.XmlConfigurator.Configure(new FileInfo(HInfo.PGlobal.LogConfig));
                    HInfo.logHandler = LogManager.GetLogger(typeof (TravianBot));
                }

                return HInfo.logHandler;
            }
        }

        public static void Serialize()
        {
            HInfo.PGlobal.Serialize();
            HInfo.PPlayer.Serialize();
        }

        #endregion Properties
    }
}