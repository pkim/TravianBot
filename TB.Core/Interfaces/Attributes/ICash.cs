using System;

namespace TB.Core.Interfaces.Attributes
{
    public interface ICash
    {
        /// <summary>
        /// The amount of gold
        /// </summary>
        Int32 Gold { get; }

        /// <summary>
        /// The amount of silver
        /// </summary>
        Int32 Silver { get; }
    }
}