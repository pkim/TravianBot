using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using HLib.Network.IP.HTML;
using HLib.Network.IP.HTTP;
using HtmlAgilityPack;
using TB.Core.Enumeration;
using TB.Core.Interfaces.Handler;

namespace TB.Core.Classes.Handler
{
  public class HPage : IHPage
  {
    #region Constructor

    private HPage()
    {
      this.COAccess = new Int32();
      this.CODownloads = new Int32();
      this.PageDictionary = new SortedDictionary<EPageID, HtmlDocument>();

      /* add a empty html document to the indox of static frame page
       * this is needed by ensuring that the index of the static frame page is nerver null
      */
      this.PageDictionary.Add(EPageID.STATIC_FRAME, new HtmlDocument());
    }

    public HPage(HTMLClient _client) : this()
    {
      this.HTMLClient = _client;
    }

    #endregion Constructor

    #region Properties

    protected HTMLClient HTMLClient { get; private set; }
    protected SortedDictionary<EPageID, HtmlDocument> PageDictionary { get; private set; }
    public Int32 COAccess { get; private set; }
    public Int32 CODownloads { get; private set; }

    #endregion Properties

    #region Methods

    #region Protected

    protected HtmlDocument GetHtmlDocument(EPageID _pageID)
    {
      return this.GetHtmlDocument(_pageID, null, null);
    }

    protected HtmlDocument GetHtmlDocument(EPageID _pageID, IList<HTTPParameter> _get, IList<HTTPParameter> _post)
    {
      HtmlDocument htmlDocument;

      // increase the counter of access by one
      this.COAccess++;

      // if the html document is already cached
      if (this.PageDictionary.ContainsKey(_pageID))
      {
        HInfo.LogHandler.Debug(String.Format("ACCESS - {0}", HLink.GetLink(_pageID).Segments.Last()));
        htmlDocument = this.PageDictionary[_pageID];
      }

        // if the document in the cache is out of the date or not cached yet
      else
      {
        HInfo.LogHandler.Debug(String.Format("DOWNLOAD - {0}", HLink.GetLink(_pageID).Segments.Last()));

        // set options
        htmlDocument = new HtmlDocument();
        htmlDocument.OptionComputeChecksum               = false;
        //htmlDocument.OptionFixNestedTags                 = true;
        htmlDocument.OptionUseIdAttribute                = true;
        //htmlDocument.OptionOutputOptimizeAttributeValues = false;
        //htmlDocument.OptionOutputOriginalCase            = false;
        //htmlDocument.OptionOutputAsXml                   = true;
        //htmlDocument.OptionReadEncoding                  = false;
        

        // Download the html document of the login
        this.HTMLClient.getHTML(HLink.GetLink(_pageID),
          _get, // GET Parameter
          _post, // POST Parameter
          Encoding.Unicode,
          ref htmlDocument);

        // wait for a random time to simulate human activity
        HHumanActivity.Simulate();

        // Increase the counter of downloads by one
        this.CODownloads++;

        // Add the html document to the page dictionary
        this.PageDictionary.Add(_pageID, htmlDocument);

        if (HInfo.PConfig.CacheHTML)
        {
          if (!Directory.Exists(HInfo.PGlobal.Cache))
          {
            Directory.CreateDirectory(HInfo.PGlobal.Cache);
          }

          // save html document at the configured path
          htmlDocument.Save(String.Format("{0}{1}",
            HInfo.PGlobal.Cache, // The configured output directory
            HLink.GetLink(_pageID).Segments.Last())); // the name of the document
        }
      }

      // update the static frame page
      this.PageDictionary[EPageID.STATIC_FRAME] = this.PageDictionary[_pageID];
      return htmlDocument;
    }

    #endregion Protected

    #region Public

    public HtmlDocument GetPageStatic()
    {
      return this.PageDictionary[EPageID.STATIC_FRAME];
    }

    public HtmlDocument GetPageLogin()
    {
      return this.GetHtmlDocument(EPageID.LOGIN);
    }

    public HtmlDocument GetPageLogout()
    {
      return this.GetHtmlDocument(EPageID.LOGOUT);
    }

    public HtmlDocument GetPageFarm(Int32 _villageID)
    {
      List<HTTPParameter> get = new List<HTTPParameter>(1)
      {
        new HTTPParameter(HInfo.PHTTPParameters.VillageNewdID, // attribute name
          _villageID.ToString(CultureInfo.InvariantCulture)) // atribute value
      };

      HtmlDocument page = this.GetHtmlDocument(EPageID.FARM, get, null);
      return page;
    }

    public HtmlDocument GetPageVillage(Int32 _villageID)
    {
      List<HTTPParameter> get = new List<HTTPParameter>(1)
      {
        new HTTPParameter(HInfo.PHTTPParameters.VillageNewdID, // attribute name
          _villageID.ToString(CultureInfo.InvariantCulture)) // atribute value
      };

      return this.GetHtmlDocument(EPageID.VILLAGE, get, null);
    }

    public HtmlDocument GetPageVillageOverview()
    {
      return this.GetHtmlDocument(EPageID.VILLAGE_OVERVIEW);
    }

    public HtmlDocument GetPageMap()
    {
      throw new NotImplementedException();
    }

    public HtmlDocument GetPageStatistic()
    {
      throw new NotImplementedException();
    }

    public HtmlDocument GetPageReports()
    {
      throw new NotImplementedException();
    }

    public HtmlDocument GetPageMessages()
    {
      throw new NotImplementedException();
    }

    public HtmlDocument GetPagePlayer()
    {
      return this.GetHtmlDocument(EPageID.PLAYER);
    }

    #endregion Public

    #endregion Methods
  }
}