using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicTac
{
    class Row
    {
        public Point emptyTile1 { get; private set; }
        public Point emptyTile2 { get; private set; }
        Tile[] tiles;
        int length;

        public Row(Point emptyTile1, Point emptyTile2, Tile[] tiles, int length)
        {
            this.emptyTile1 = emptyTile1;
            this.emptyTile2 = emptyTile2;
            this.tiles = tiles;
            this.length = length;


        }
    }
}
