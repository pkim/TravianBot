using System;
using Handler.Interface.NetworkHandler.IP.HTML;
using HtmlAgilityPack;

namespace TB.Core.Interfaces.Handler
{
  public interface IHPage
  {
    #region Properties
    /// <summary>
    /// Counter of access of the needed html documents
    /// </summary>
    Int32 COAccess { get; }

    /// <summary>
    /// Counter of downloads of needed html documents.
    /// <remarks>
    /// That CODownloads should always be smaller than COAccess to
    /// ensure human activity simulaiton by waiting a amount of time
    /// before redownloading a html document
    /// </remarks>
    /// </summary>
    Int32 CODownloads { get; }
    #endregion Properties

    #region Methods

    /// <summary>
    /// Downloads the player page generally but not that this happens only 
    /// if no other page like player, farm, village which contains the static frame around 
    /// center is already downloaded.
    /// </summary>
    /// <remarks>
    /// This page will dynamically resetted by the latest downloaded html document 
    /// which contains the static frame around the center.
    /// </remarks>
    /// <returns>
    /// A page which contains the static frame around the center
    /// </returns>
    HtmlDocument GetPageStatic();

    /// <summary>
    /// Download of the login HTML document
    /// </summary>
    /// <returns>
    /// The login HTML document
    /// </returns>
    HtmlDocument GetPageLogin();

    /// <summary>
    /// Download of the logout HTML document
    /// </summary>
    /// <returns>
    /// The logout HTML document
    /// </returns>
    HtmlDocument GetPageLogout();

    /// <summary>
    /// Download of the farm HTML document
    /// </summary>
    /// <param name="_villageID">The id of the requested village HTML document</param>
    /// <returns>The farm HTML document</returns>
    HtmlDocument GetPageFarm(Int32 _villageID);

    /// <summary>
    /// Download of the village HTML document
    /// </summary>
    /// <param name="_villageID">The id of the requested village HTML document</param>
    /// <returns>
    /// The village HTML document
    /// </returns>
    HtmlDocument GetPageVillage(Int32 _villageID);

    /// <summary>
    /// Download of the village overview HTML document
    /// </summary>
    /// <returns>
    /// The village overview HTML document
    /// </returns>
    HtmlDocument GetPageVillageOverview();

    /// <summary>
    /// Download of the map HTML document
    /// </summary>
    /// <returns>
    /// The map HTML document
    /// </returns>
    HtmlDocument GetPageMap();

    /// <summary>
    /// Download of the statistic HTML document
    /// </summary>
    /// <returns>
    /// The statistic HTML document
    /// </returns>
    HtmlDocument GetPageStatistic();

    /// <summary>
    /// Download of the reports HTML document
    /// </summary>
    /// <returns>
    /// The reports HTML document
    /// </returns>
    HtmlDocument GetPageReports();

    /// <summary>
    /// Download of the messages HTML document
    /// </summary>
    /// <returns>
    /// The messages HTML document
    /// </returns>
    HtmlDocument GetPageMessages();

    /// <summary>
    /// Download of the player HTML document
    /// </summary>
    /// <returns>
    /// The player HTML document
    /// </returns>
    HtmlDocument GetPagePlayer();

    #endregion Methods
  }
}
