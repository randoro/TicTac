using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicTac
{
    class FirstOverallTurnDec : Decision
    {

        public FirstOverallTurnDec()
        {
            //Is this the first turn of all?
        }

        public override Point Calculate(Board board, Dictionary<Tuple<int, int>, Tile> localfilledTiles, Dictionary<Tuple<int, int>, Tile> localMyTiles, Dictionary<Tuple<int, int>, Tile> localEnemyTiles)
        {
            if (localfilledTiles.Count == 0)
            {
                return trueCalc.Calculate(board, localfilledTiles, localMyTiles, localEnemyTiles);
            }
            else
            {
                return falseCalc.Calculate(board, localfilledTiles, localMyTiles, localEnemyTiles);
            }
        }
    }
}
