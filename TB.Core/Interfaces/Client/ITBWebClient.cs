using System;
using TB.Core.Enumerations;

namespace TB.Core.Interfaces.Client
{
  /// <summary>
  /// This interface represents the travian bot web client.
  /// It extends the HTMLClient of the namespace Handler.Netzworking
  /// </summary>
  /// <remarks>
  /// Note that this class just catches erros which are aimed for the user and 
  /// just handle it so far they represents a problem for the stability
  /// </remarks>
  public interface ITBWebClient
  {
    #region Properties
    /// <summary>
    /// Specifies it the client is loged in
    /// </summary>
    Boolean LogedIn { get; }
    #endregion Properties

    #region Methods
    /// <summary>
    /// Tries to log in the client on the travian website.
    /// </summary>
    /// <remarks>
    /// The needed information for the log in has be to configured befor
    /// </remarks>
    /// <remarks>
    /// Sets the LogedIn property to true if successfull.
    /// </remarks>
    /// <returns>
    /// Returns the code of the error if one has occured. 
    /// Note that this code is "SUCCESS" if everything was ok.
    /// </returns>
    EReturnCode Login();

    /// <summary>
    /// Tries to log out the client from the travian website
    /// </summary>
    /// <remarks>Sets the LogedIn property to false if successfull</remarks>
    /// <returns>
    /// Returns the code of the error if one has occured. 
    /// Note that this code is "SUCCESS" if everything was ok.
    /// </returns>
    EReturnCode Logout();

    /// <summary>
    /// Tries to refresh the current requested website. 
    /// Can be used to solve request errors.
    /// </summary>
    /// <remarks>
    /// Should reset the session timer of the web server.
    /// </remarks>
    /// <returns>
    /// Returns the code of the error if one has occured. 
    /// Note that this code is "SUCCESS" if everything was ok.
    /// </returns>
    EReturnCode Refresh();
    #endregion Methods
  }
}
