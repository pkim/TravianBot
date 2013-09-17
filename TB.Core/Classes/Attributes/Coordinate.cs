using System;
using TB.Core.Interfaces.Attributes;

namespace TB.Core.Classes.Attributes
{
    public class Coordinate : ICoordinate
    {
        #region Objects

        private static ICoordinate zero = new Coordinate(0, 0);

        #endregion Objects

        #region Constructor

        public Coordinate(Int32 _x, Int32 _y)
        {
            this.X = _x;
            this.Y = _y;
        }

        #endregion Constructor

        #region Properties

        /// <summary>
        /// The absolute zero point with x = 0 and y = 0
        /// </summary>
        public static ICoordinate Zero
        {
            get { return Coordinate.zero; }
        }

        public int X { get; private set; }
        public int Y { get; private set; }

        #endregion Properties
    }
}