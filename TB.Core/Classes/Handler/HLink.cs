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
        case EPageID.LOGIN:
          return new Uri(String.Format("{0}{1}", HInfo.PLinks.Server, HInfo.PLinks.Login));

        case EPageID.LOGOUT:
          return new Uri(String.Format("{0}{1}", HInfo.PLinks.Server, HInfo.PLinks.Logout));

        case EPageID.FARM:
          return new Uri(String.Format("{0}{1}", HInfo.PLinks.Server, HInfo.PLinks.Farm));

        case EPageID.VILLAGE:
          return new Uri(String.Format("{0}{1}", HInfo.PLinks.Server, HInfo.PLinks.Village)); 

        case EPageID.VILLAGE_OVERVIEW:
          return new Uri(String.Format("{0}{1}", HInfo.PLinks.Server, HInfo.PLinks.VillagesOverview));

        case EPageID.PLAYER:
          return new Uri(String.Format("{0}{1}", HInfo.PLinks.Server, HInfo.PLinks.Player)); 
        
        case EPageID.BUILDING:
          return new Uri(String.Format("{0}{1}", HInfo.PLinks.Server, HInfo.PLinks.Building)); 

        case EPageID.UNKNOWN:
        default:
          return null;
      }
    }

    public static Uri GetLink(EPageID _pageID, int _villageID)
    {
      String basrUrl = HLink.GetLink(_pageID).AbsoluteUri;

      return new Uri(String.Format("{0}?{1}={2}", basrUrl, HInfo.PHTTPParameters.VillageNewdID, _villageID));
    }

    public static Uri GetLink(EPageID _pageID, Int32 _villageID, Int32 _buildingID)
    {
      String basrUrl = HLink.GetLink(_pageID, _villageID).AbsoluteUri;

      return new Uri(String.Format("{0}?{1}={2}", basrUrl, HInfo.PHTTPParameters.BuildingID, _buildingID));
    }
  }
}