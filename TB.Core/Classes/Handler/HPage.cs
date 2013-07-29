using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Handler.Interface.NetworkHandler.IP.HTML;
using NetworkHandler.IP.HTML;
using TB.Core.Interfaces.Handler;

namespace TB.Core.Classes.Handler
{
  public class HPage : IHPage
  {
    #region Objects
    protected HTMLClient htmlClient;
    #endregion Objects
    
    #region Constructor
    private HPage()
    {
      this.COAccess    = new Int32();
      this.CODownloads = new Int32();
    }

    public HPage(HTMLClient _client) : this()
    {
      this.htmlClient = _client;
    }
    #endregion Constructor

    #region Properties
    public Int32 COAccess { get; private set; }
    public Int32 CODownloads { get; private set; }
    #endregion Properties

    #region Methods
    #region Public
    public HTMLDocument GetPageLogin()
    {
      throw new NotImplementedException();
    }

    public HTMLDocument GetPageLogout()
    {
      throw new NotImplementedException();
    }

    public HTMLDocument GetPageFarm(int _villageID)
    {
      throw new NotImplementedException();
    }

    public HTMLDocument GetPageVillage(int _villageID)
    {
      throw new NotImplementedException();
    }

    public HTMLDocument GetPageVillageOverview(int _villageID)
    {
      throw new NotImplementedException();
    }

    public HTMLDocument GetPageMap()
    {
      throw new NotImplementedException();
    }

    public HTMLDocument GetPageStatistic()
    {
      throw new NotImplementedException();
    }

    public HTMLDocument GetPageReports()
    {
      throw new NotImplementedException();
    }

    public HTMLDocument GetPageMessages()
    {
      throw new NotImplementedException();
    }

    public HTMLDocument GetPagePlayer()
    {
      throw new NotImplementedException();
    }
    #endregion Public
    #endregion Methods
  }
}
