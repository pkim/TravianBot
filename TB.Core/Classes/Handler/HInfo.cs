using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TB.Core.Classes.Properties;
using log4net;

namespace TB.Core.Classes.Handler
{
  public static class HInfo
  {
    #region Objects
    private static ILog logHandler = null;
    #endregion Objects

    #region Properties
    public static PHTTPParameters PHTMLParamters
    {
      get { return PHTTPParameters.GetInstance(); }
    }

    public static PLinks PLinks
    {
      get { return PLinks.GetInstance(); }
    }

    public static PConfig PConfig
    {
      get { return PConfig.GetInstance(); }
    }
   
    public static ILog LogHandler
    {
      get
      {
        if (HInfo.logHandler == null)
        {
          log4net.Config.XmlConfigurator.Configure();
          HInfo.logHandler = LogManager.GetLogger(typeof(TravianBot));
        }

        return HInfo.logHandler;
      }
    }
    #endregion Properties
  }
}
