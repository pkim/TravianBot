using System;
using Handler.Interface.NetworkHandler.IP.HTML;
using TBCore.Enumeration;

namespace TB.Core.Interfaces.Client
{
  public interface ITBWC_DOMBased : ITBWebClient
  {
    #region Properties
    /// <summary>
    /// Counter of access of the needed html documents or theirs doms
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

    HTMLDocument getSite(EPageID _pageID);
    HTMLDocument getSite(EPageID _pageID, Int32 _villageID);


    #endregion Methods
  }
}
