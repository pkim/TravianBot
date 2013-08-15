using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using Handler.Interface.NetworkHandler.IP.HTTP;
using HtmlAgilityPack;
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
    public TravianBot(Boolean _useTor) : this(null)
    {
      HInfo.PConfig.UseTor = _useTor;
    }

    public TravianBot(WebProxy _proxy)
    {
      this.Villages = new Dictionary<Int32, IVillage>();
      this.Messages = new Dictionary<Int32, IMessage>();
      this.Player   = new Player();
      this.Hero     = new Hero();
      this.Alliance = new Alliance();
      this.LogedIn  = false;

      this.HTMLClient = new HTMLClient(_proxy);
      this.HPage      = new HPage(this.HTMLClient);
      
      this.Initialized     = false;
      HInfo.PConfig.UseTor = false;
    }
    #endregion Constructor

    #region Properties
    #region Public
    public IPAddress ClientIP { get { return this.WhatsMyIp(); } }

    public DateTime LastLogIn { get; private set; }
    public DateTime LastLogOut { get; private set; }
    public TimeSpan LoginDuration { get; private set; }
    public IDictionary<Int32, IVillage> Villages { get; private set; }
    public IDictionary<Int32, IMessage> Messages { get; private set; }
    public IPlayer Player { get; private set; }
    public IHero Hero { get; private set; }
    public IAlliance Alliance { get; private set; }
    public Boolean LogedIn { get; private set; }
    public Boolean Initialized { get; private set; }
    #endregion Public
    
    #region Protected

    protected HTMLClient HTMLClient { get; set; }
    protected IHPage HPage { get; set; }
    protected Process ProcessTor { get; set; }
    #endregion Protected
    #endregion Properties

    #region Methods
    #region Protected

    /// <summary>
    /// Something for debugging tor works
    /// can be removed afterwards
    /// </summary>
    protected IPAddress WhatsMyIp()
    {
      IPAddress ipAddress;
      try
      {
        HtmlDocument hd = this.HTMLClient.getHTML("http://www.whatsmyip.de/", null, null, Encoding.Default);
        String ip = hd.GetElementbyId("content").SelectSingleNode(".//h3").InnerText;
        
        return IPAddress.TryParse(ip, out ipAddress) ? ipAddress : null;
      }
      catch (Exception e)
      {
        HInfo.LogHandler.Debug("error", e);
        throw;
      }
    }

    /// <summary>
    /// Starts the tor server
    /// </summary>
    protected void StartTor()
    {
      try
      {
        Process[] processes = Process.GetProcessesByName(HInfo.PGlobal.TorExe);

        if (processes.Length == 0)
        {
          this.ProcessTor = new Process
            {
              StartInfo =
                {
                  FileName = String.Format("{0}\\{1}", HInfo.PGlobal.Tor, HInfo.PGlobal.TorExe),
                  RedirectStandardOutput = true,
                  UseShellExecute        = false,
                  CreateNoWindow         = true
                }
            };
          this.ProcessTor.Start();
        }
        else
        {
          this.ProcessTor = processes[0];
        }
      }
      catch (Exception exception)
      {
        HInfo.LogHandler.Error("Starting Tor failed", exception);
      }
    }

    /// <summary>
    /// Stops the tor server
    /// </summary>
    protected void StopTor()
    {
      try
      {
        if (this.ProcessTor != null && !this.ProcessTor.HasExited)
        {
          this.ProcessTor.CloseMainWindow();
          this.ProcessTor.Kill();
          while (!this.ProcessTor.HasExited)
          {
            this.ProcessTor.WaitForExit(1000);
          }
        }
      }
      catch (Exception exception)
      {
        HInfo.LogHandler.Error("Stopping Tor failed", exception);
      }
    }

    protected void ResovleLanguageID(String _server)
    {
      String server = _server.Substring(_server.LastIndexOf('.') + 1);
      if (server.EndsWith("/"))
      {
        server = server.Remove(server.Length - 1);
      }
      HInfo.PDictionary.LanguageID = HInfo.PDictionary.Languages[server];
    }


    /// <summary>
    /// Resolve the ids and names of the controlled villages
    /// </summary>
    /// <param name="_initMode">The initialization mode</param>
    /// <returns>
    /// Returns the code of the error if one has occured. 
    /// Note that this code would be "SUCCESS" if everything was ok.
    /// </returns>
    protected EReturnCode ResolveVillages(EInitMode _initMode)
    {
      Int32  id;
      String name;

      EReturnCode returnCode = EReturnCode.SUCCESS;

      try
      {
        HtmlNode baseNode = this.HPage.GetPagePlayer().DocumentNode;

        HtmlNodeCollection hnColl = baseNode.SelectNodes(".//li[@class=' active']");
        foreach (HtmlNode hnLi in hnColl)
        {
          String idValue;

          HtmlNode hn = hnLi.SelectSingleNode(".//a[@class='active']");

          idValue = hn.GetAttributeValue(HInfo.PHtmlAttributes.HRef, String.Empty);
          idValue = idValue.Substring(idValue.IndexOf("=", System.StringComparison.Ordinal) + 1,  // start index
                                      idValue.IndexOf("&", System.StringComparison.Ordinal) -     // length
                                      idValue.IndexOf("=", System.StringComparison.Ordinal) - 1); // length

          id   = Int32.Parse(idValue);
          name = hn.SelectSingleNode(HInfo.PXPathExpr.DivVillageName).InnerText;

          // add new village to dictionary
          IVillage village = new Village(this.HPage, id, name);
          returnCode = village.Init(_initMode);
          this.Villages.Add(id, village);
        }
      }
      catch (Exception exception)
      {
        HInfo.LogHandler.Error("Unable to resolve the id and name of the villages", exception);
        return EReturnCode.FAIL;
      }

      return returnCode;
    }

    protected EReturnCode ResolvePlayer()
    {
      try
      {
        //HtmlDocument hd = this.HPage.GetPagePlayer();


        return EReturnCode.SUCCESS;
      }
      catch (Exception exception)
      {
        HInfo.LogHandler.Error("Unable to resolve the id and name of the villages", exception);
        return EReturnCode.FAIL;
      }
    }
    #endregion Protected

    #region Public
    public EReturnCode Login(String _server, String _name, String _password)
    {
      String loginSessionID;

      if (!this.LogedIn)
      {
        try
        {
          HInfo.LogHandler.Debug("START LOGIN");
          HInfo.LogHandler.Debug(String.Format("Client IP: {0}", this.ClientIP));

          // start tor if configured
          if (HInfo.PConfig.UseTor)
          {
            this.StartTor();
          }

          /* NOTE ERROR *
           * Still some problems with the property class... meaning problems by serializing properties?? 
           * Problem dedected at the following lines of code on saving server, name and pwd.
           * NOTE ERROR */
          HInfo.PGlobal.Profile = String.Format("{0}{1}\\", HInfo.PGlobal.Profiles, _name);

          // Set the server base URL and the login credentials
          // NOTE: Password is stored unsecured... May be a problem ?!
          HInfo.PLinks.Server = _server;
          HInfo.PPlayer.Name = _name;
          HInfo.PPlayer.Password = _password;

          this.ResovleLanguageID(_server);

          // get hidden parameters - SessionID
          HtmlDocument hd = this.HPage.GetPageLogin();
          HtmlNode hn = hd.DocumentNode.SelectSingleNode(HInfo.PXPathExpr.LoginSessionID);

          // no node found
          if (hn == null)
          {
            HInfo.LogHandler.Error("Attribute \"session id\" not found");
            return EReturnCode.FAIL;
          }

          // get the ID of the session
          loginSessionID = hn.GetAttributeValue(HInfo.PHtmlAttributes.Value, "0");

          // generate POST parameters for login requeset
          IList<HTTPParameter> postParameters = new List<HTTPParameter>();
          postParameters.Add(new HTTPParameter(HInfo.PHTTPParameters.LoginName, _name)); // login name
          postParameters.Add(new HTTPParameter(HInfo.PHTTPParameters.LoginPassword, _password)); // password
          postParameters.Add(new HTTPParameter(HInfo.PHTTPParameters.LoginS1, HInfo.PGlobal.S1)); // s1 value
          postParameters.Add(new HTTPParameter(HInfo.PHTTPParameters.LoginW, HInfo.PGlobal.W)); // resolution value
          postParameters.Add(new HTTPParameter(HInfo.PHTTPParameters.Login, loginSessionID));
            // session id - a hidden parameter
          postParameters.Add(new HTTPParameter(HInfo.PHTTPParameters.LoginLowRes, HInfo.PGlobal.LowRes));
            // use low quality pictures (higher performance)

          // login to server
          this.HTMLClient.loginToServer(HLink.GetLink(EPageID.FARM),
                                        postParameters,
                                        HTMLClient.WebRequestMethod.POST,
                                        Encoding.Default);

          /* if the login was successfull but the returned html document of village overview don't  *
           * have an element with the id "lowRes"                                               */
          if (HPage.GetPagePlayer().GetElementbyId(HInfo.PHtmlAttributes.IDLowRes) == null)
          {
            this.LogedIn = true;
            this.LastLogIn = DateTime.Now;
            return EReturnCode.SUCCESS;
          }

          // if the login was't sucessfull
          this.LogedIn = false;
          return EReturnCode.FAIL;
        }
        catch (WebException webException)
        {
          HInfo.LogHandler.Error("ERROR: LOGIN - Unable to connect to server: ", webException);
          this.LogedIn = false;
          return EReturnCode.FAIL;
        }
        catch (Exception exception)
        {
          HInfo.LogHandler.Error("ERROR: LOGIN - ", exception);
          this.LogedIn = false;
          return EReturnCode.FAIL;
        }

        finally
        {
          HInfo.LogHandler.Debug("END LOGIN");
        }
      }

      return EReturnCode.SUCCESS;
    }

    public EReturnCode Logout()
    {
      HInfo.LogHandler.Debug("START LOGOUT");

      try
      {
        if (this.LogedIn)
        {
          // downloading the html source logs the player out
          this.HPage.GetPageLogout();
        }
        else
        {
          HInfo.LogHandler.Error("Unable to logout because no connection has been established yet");
          return EReturnCode.NOT_LOGED_IN;
        }

        HInfo.LogHandler.Debug("Count of Access: "    + this.HPage.COAccess   );
        HInfo.LogHandler.Debug("Count of Downloads: " + this.HPage.CODownloads);
        
        // Stop tor if configured to run
        if (HInfo.PConfig.UseTor)
        {
          /* uncommented because of faster debugging and starting reasons.  *
           * ensures that the tor server will be started once and will be   *
           * terminated when windows is shutting down                       *
           * Should be undone before using it at normal conditions          */
          // this.StopTor();
        }

        this.LogedIn = false;
        this.LastLogOut = DateTime.Now;
        this.LoginDuration = this.LastLogOut - this.LastLogIn;
        HInfo.Serialize();

        HInfo.LogHandler.Debug("END LOGOUT");
        return EReturnCode.SUCCESS;
      }
      catch (Exception exception)
      {
        HInfo.LogHandler.Debug("ERROR: LOGOUT - ", exception);
        return EReturnCode.FAIL;
      }
    }

    public EReturnCode Refresh()
    {
      HInfo.LogHandler.Debug("START REFRESH");

      if (this.LogedIn)
      {
        // logout - ignore if something went wrong because relogin will happen next anymore
        this.Logout();
      }
      
      // relogin
      EReturnCode returnCode = this.Login(HInfo.PLinks.Server, HInfo.PPlayer.Name, HInfo.PPlayer.Password);
      
      HInfo.LogHandler.Debug("END REFRESH");

      return returnCode;
    }

    public EReturnCode Init()
    {
      return this.Init(EInitMode.ON_DEMAND);
    }

    public EReturnCode Init(EInitMode _initMode)
    {
      EReturnCode returnCode;

      try
      {
        HInfo.LogHandler.Debug("START INIT");

        if (!this.LogedIn)
        { return EReturnCode.NOT_LOGED_IN; }

        returnCode = this.ResolvePlayer();
        if (returnCode != EReturnCode.SUCCESS)
        { return returnCode; }

        returnCode = this.ResolveVillages(_initMode);
        if (returnCode != EReturnCode.SUCCESS)
        { return returnCode; }

        this.Initialized = true;
        return EReturnCode.SUCCESS;
      }
      catch (Exception exception)
      {
        HInfo.LogHandler.Debug("ERROR: Init - ", exception);
        return EReturnCode.FAIL;
      }
      finally
      {
        HInfo.LogHandler.Debug("END Init");
      }
    }
    #endregion Public
    #endregion Methods
  }
}
