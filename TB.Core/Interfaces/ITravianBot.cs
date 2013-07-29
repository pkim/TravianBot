using System;
using System.Collections.Generic;
using TB.Core.Enumerations;
using TB.Core.Interfaces.Attributes;

namespace TB.Core.Interfaces
{
  /// <summary>
  /// This interface serves the main methods and properties of the travian bot
  /// </summary>
  public interface ITravianBot
  {
    #region Properties
    /// <summary>
    /// The villages of the account this bot maybe should handle
    /// </summary>
    IDictionary<Int32, IVillage> Villages { get; }

    /// <summary>
    /// The messages of the account this bot maybe should handle
    /// </summary>
    /// <remarks>
    /// This method is temporary because in future it should hold the 
    /// statistic in a (maybe distributed) database.
    /// </remarks>
    IDictionary<Int32, IMessage> Messages { get; }

    /// <summary>
    /// Specific information about the player of the account
    /// this bot should handle.
    /// </summary>
    IPlayer Player { get; }

    /// <summary>
    /// The hero of the account this bot maybe should handle
    /// </summary>
    IHero Hero { get; }

    /// <summary>
    /// The alliance of the account this bot maybe should handle
    /// </summary>
    IAlliance Alliance { get; }

    /// <summary>
    /// Specifies if the bot is loged in
    /// </summary>
    Boolean LogedIn { get; }
    #endregion Properties

    #region Methods

    /// <summary>
    /// Tries to log in the client on the travian website.
    /// </summary>
    /// <param name="_name">The login name</param>
    /// <param name="_password">The login password</param>
    /// <remarks>
    /// The needed information for the log in has be to configured befor
    /// </remarks>
    /// <remarks>
    /// Sets the LogedIn property to true if successfull.
    /// </remarks>
    /// <returns>
    /// Returns the code of the error if one has occured. 
    /// Note that this code would be "SUCCESS" if everything was ok.
    /// </returns>
    EReturnCode Login(String _name, String _password);

    /// <summary>
    /// Tries to log out the client from the travian website
    /// </summary>
    /// <remarks>Sets the LogedIn property to false if successfull</remarks>
    /// <returns>
    /// Returns the code of the error if one has occured. 
    /// Note that this code would be "SUCCESS" if everything was ok.
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
    /// Note that this code would be "SUCCESS" if everything was ok.
    /// </returns>
    EReturnCode Refresh();
    #endregion Methods
  }
}
