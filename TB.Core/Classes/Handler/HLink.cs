using System;
using TB.Core.Enumeration;

namespace TB.Core.Classes.Handler
{
  public class HLink
  {
    public static Uri GetLink(EPageID _pageID)
    {
      switch (_pageID)
      {
        case EPageID.LOGIN:            return new Uri(String.Format("{0}{1}", HInfo.PLinks.Server, HInfo.PLinks.Login));              // login
        case EPageID.LOGOUT:           return new Uri(String.Format("{0}{1}", HInfo.PLinks.Server, HInfo.PLinks.Logout));             // logout
        case EPageID.FARM:             return new Uri(String.Format("{0}{1}", HInfo.PLinks.Server, HInfo.PLinks.Ressources));         // farm
        case EPageID.VILLAGE:          return new Uri(String.Format("{0}{1}", HInfo.PLinks.Server, HInfo.PLinks.Village));            // village
        case EPageID.VILLAGE_OVERVIEW: return new Uri(String.Format("{0}{1}", HInfo.PLinks.Server, HInfo.PLinks.VillagesOverview));   // village 3
        case EPageID.PLAYER:           return new Uri(String.Format("{0}{1}", HInfo.PLinks.Server, HInfo.PLinks.Player));             // player

        case EPageID.UNKNOWN:
        default:
          return null;
      }
    }

    public static Uri GetLink(EPageID _pageID, int _villageID)
    {
      String basrUrl = HLink.GetLink(_pageID).AbsoluteUri;

      return new Uri(String.Format("{0}?{1}={2}", basrUrl, HInfo.PHTMLParamters.VillageNewdID, _villageID));
    }
  }
}
