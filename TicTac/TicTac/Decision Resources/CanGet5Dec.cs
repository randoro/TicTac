﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicTac
{
    class CanGet5Dec : Decision
    {
        public CanGet5Dec()
        {
            //Can I get 5 in a row?
        }

        public override Point Calculate(Board board, Dictionary<Tuple<int, int>, Tile> localfilledTiles, Dictionary<Tuple<int, int>, Tile> localMyTiles, Dictionary<Tuple<int, int>, Tile> localEnemyTiles, List<Row> localMy4Rows, List<Row> localEnemy4Rows, List<Row> localMy3Rows, List<Row> localEnemy3Rows, List<Row> localMy2Rows, List<Row> localEnemy2Rows)
        {
            if (localMy4Rows.Count > 0)
            {
                return trueCalc.Calculate(board, localfilledTiles, localMyTiles, localEnemyTiles, localMy4Rows, localEnemy4Rows, localMy3Rows, localEnemy3Rows, localMy2Rows, localEnemy2Rows);
            }
            else
            {
                return falseCalc.Calculate(board, localfilledTiles, localMyTiles, localEnemyTiles, localMy4Rows, localEnemy4Rows, localMy3Rows, localEnemy3Rows, localMy2Rows, localEnemy2Rows);
            }
        }
    }
}
