using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicTac
{
    class MyFirstTurnDec : Decision
    {
        public MyFirstTurnDec()
        {
            //Is this my first turn?
        }

        public override Point Calculate(Board board, Dictionary<Tuple<int, int>, Tile> localfilledTiles, Dictionary<Tuple<int, int>, Tile> localMyTiles, Dictionary<Tuple<int, int>, Tile> localEnemyTiles)
        {
            if (localfilledTiles.Count <= 1)
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
