using System;
using System.Collections.Generic;
using TB.Core.Interfaces.Attributes;
using TB.Core.Interfaces.Client;

namespace TB.Core.Interfaces
{
  public interface ITravianBot : ITBWebClient
  {
    #region Properties
    /// <summary>
    /// The villages of the account this bot maybe should handle
    /// </summary>
    IDictionary<Int32, IVillage> Villages { get; }

    /// <summary>
    /// The messages of the account this bot maybe should handle
    /// </summary>
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
    #endregion Properties
  }
}
