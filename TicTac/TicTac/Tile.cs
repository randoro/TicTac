using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicTac
{
    public enum TileState { none, Xmark, Omark }

    class Tile
    {

        public TileState tileState { get; set; }

        public Tile()
        {
            tileState = TileState.none;
        }
    }
}
