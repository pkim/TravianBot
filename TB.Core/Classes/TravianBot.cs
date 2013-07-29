using System;
using System.Collections.Generic;
using System.Text;
using Handler.Interface.NetworkHandler.IP.HTML;
using Handler.Interface.NetworkHandler.IP.HTTP;
using NetworkHandler.IP.HTML;
using TB.Core.Classes.Attributes;
using TB.Core.Classes.Handler;
using TB.Core.Enumeration;
using TB.Core.Enumerations;
using TB.Core.Interfaces;
using TB.Core.Interfaces.Attributes;
using TB.Core.Interfaces.Handler;

namespace TB.Core.Classes
{
  public class TravianBot : ITravianBot
  {
    #region Constructor
    public TravianBot()
    {
      this.Villages = new Dictionary<Int32, IVillage>();
      this.Messages = new Dictionary<Int32, IMessage>();
      this.Player   = new Player();
      this.Hero     = new Hero();
      this.Alliance = new Alliance();
      this.LogedIn  = false;
    }
    #endregion Constructor

    #region Properties
    #region Public
    public IDictionary<Int32, IVillage> Villages { get; private set; }
    public IDictionary<Int32, IMessage> Messages { get; private set; }
    public IPlayer Player { get; private set; }
    public IHero Hero { get; private set; }
    public IAlliance Alliance { get; private set; }
    public bool LogedIn { get; private set; }
    #endregion Public
    
    #region Protected
    protected HTMLClient HTMLClient { get; private set; }
    protected IHPage HPage { get; private set; }
    #endregion Protected
    #endregion Properties

    #region Methods
    public EReturnCode Login(String _name, String _password)
    {
      String   login_SessionID   = String.Empty;
      HTMLPage loginResponsePage = null;

      if (!this.LogedIn)
      {
        try
        {
          HInfo.LogHandler.Debug("START LOGIN");

          // get hidden parameters - SessionID
          login_SessionID = RegexHandler.getMatch(
                              this.HPage.GetPageLogin().Content,      // get the HTML source of the login page
                              this.PropertyRegexTags.Login_SessionID  // load the needed regex term to resolve it from the html source
                            );

          // generate POST parameters for login requeset
          IList<HTTPParameter> postParameters = new List<HTTPParameter>();
          postParameters.Add(new HTTPParameter(HInfo.PHTMLParamters.LoginName, _name));                        // login name
          postParameters.Add(new HTTPParameter(HInfo.PHTMLParamters.LoginPassword, _password));                // password
          postParameters.Add(new HTTPParameter(HInfo.PHTMLParamters.LoginS1, this.PropertyLogin.S1));          // s1 value
          postParameters.Add(new HTTPParameter(HInfo.PHTMLParamters.LoginW, this.PropertyLogin.W));            // resolution value
          postParameters.Add(new HTTPParameter(HInfo.PHTMLParamters.Login, login_SessionID));                  // session id - a hidden parameter
          postParameters.Add(new HTTPParameter(HInfo.PHTMLParamters.LoginLowRes, this.PropertyLogin.LowRes));  // use low quality pictures (higher performance)

          // login to server
          loginResponsePage = this.HTMLClient.loginToServer(HLink.GetLink(EPageID.FARM),
                                                             postParameters,
                                                             HTMLClient.WebRequestMethod.POST,
                                                             Encoding.Default);

          // wait a random timespan
          HHumanActivity.Simulate();
          HInfo.LogHandler.Debug("END LOGIN");

          // UNTESTED !!!!!
          // if the login was successfull
          if (!System.Text.RegularExpressions.Regex.IsMatch(loginResponsePage.Content, "<div id=\"content\" class=\"login\">"))
          {
            this.LogedIn = true;
          }
            // if the login was't sucessfull
          else
          {
            this.LogedIn = false;
          }
        }

        catch (Exception exception)
        {
          HInfo.LogHandler.Debug("ERROR: LOGIN");
          HInfo.LogHandler.Error(String.Format("ERROR: LOGIN - {0}", exception.Message));
        }
      }
    }

    public EReturnCode Logout()
    {
      throw new NotImplementedException();
    }

    public EReturnCode Refresh()
    {
      throw new NotImplementedException();
    }
    #endregion Methods
  }
}
