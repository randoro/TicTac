using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicTac
{
    class RandomLocationAct : Action
    {
        public override Point Calculate(Board board, Dictionary<Tuple<int, int>, Tile> localfilledTiles, Dictionary<Tuple<int, int>, Tile> localMyTiles, Dictionary<Tuple<int, int>, Tile> localEnemyTiles)
        {
            
            if (localfilledTiles.Count != board.tiles.Length)
            {
                bool isEmpty = false;
                while (!isEmpty)
                {
                    int xPos = Globals.rand.Next(0, board.width);
                    int yPos = Globals.rand.Next(0, board.height);
                    if (!(localfilledTiles.ContainsKey(Tuple.Create<int, int>(xPos, yPos))))
                    {
                        return new Point(xPos, yPos);
                    }

                }
            }
            return new Point(-1, -1);
        }
    }
}
