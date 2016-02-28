using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicTac
{
    class BlockA5Act : Action
    {
        public BlockA5Act()
        {
            //Block a 5 from list and a location of it.
        }


        public override Point Calculate(Board board, Dictionary<Tuple<int, int>, Tile> localfilledTiles, Dictionary<Tuple<int, int>, Tile> localMyTiles, Dictionary<Tuple<int, int>, Tile> localEnemyTiles, List<Row> localMy4Rows, List<Row> localEnemy4Rows, List<Row> localMy3Rows, List<Row> localEnemy3Rows, List<Row> localMy2Rows, List<Row> localEnemy2Rows)
        {
            int index = Globals.rand.Next(0, localEnemy4Rows.Count);
            Row tempRow = localEnemy4Rows[index];



            //might be unbalanced
            if (!(tempRow.emptyTile1.X == -1 && tempRow.emptyTile1.Y == -1))
            {
                return tempRow.emptyTile1;
            }

            if (!(tempRow.emptyTile2.X == -1 && tempRow.emptyTile2.Y == -1))
            {
                return tempRow.emptyTile2;
            }

            return new Point(-1, -1);
        }
    }
}
