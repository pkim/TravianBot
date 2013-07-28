using System;
using Handler.Interface.NetworkHandler.IP.HTML;

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
    /// Download of the login HTML document
    /// </summary>
    /// <returns>
    /// The login HTML document
    /// </returns>
    HTMLDocument GetPageLogin();

    /// <summary>
    /// Download of the logout HTML document
    /// </summary>
    /// <returns>
    /// The logout HTML document
    /// </returns>
    HTMLDocument GetPageLogout();

    /// <summary>
    /// Download of the farm HTML document
    /// </summary>
    /// <param name="_villageID">The id of the requested village HTML document</param>
    /// <returns>The farm HTML document</returns>
    HTMLDocument GetPageFarm(Int32 _villageID);

    /// <summary>
    /// Download of the village HTML document
    /// </summary>
    /// <param name="_villageID">The id of the requested village HTML document</param>
    /// <returns>
    /// The village HTML document
    /// </returns>
    HTMLDocument GetPageVillage(Int32 _villageID);

    /// <summary>
    /// Download of the village overview HTML document
    /// </summary>
    /// <param name="_villageID">The id of the requested village HTML document</param>
    /// <returns>
    /// The village overview HTML document
    /// </returns>
    HTMLDocument GetPageVillageOverview(Int32 _villageID);

    /// <summary>
    /// Download of the map HTML document
    /// </summary>
    /// <returns>
    /// The map HTML document
    /// </returns>
    HTMLDocument GetPageMap();

    /// <summary>
    /// Download of the statistic HTML document
    /// </summary>
    /// <returns>
    /// The statistic HTML document
    /// </returns>
    HTMLDocument GetPageStatistic();

    /// <summary>
    /// Download of the reports HTML document
    /// </summary>
    /// <returns>
    /// The reports HTML document
    /// </returns>
    HTMLDocument GetPageReports();

    /// <summary>
    /// Download of the messages HTML document
    /// </summary>
    /// <returns>
    /// The messages HTML document
    /// </returns>
    HTMLDocument GetPageMessages();

    /// <summary>
    /// Download of the player HTML document
    /// </summary>
    /// <returns>
    /// The player HTML document
    /// </returns>
    HTMLDocument GetPagePlayer();

    #endregion Methods
  }
}
