using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicTac
{
    class BlockBest4Act : Action
    {
        public BlockBest4Act()
        {
            //Block best 4 from list and a location of it.
        }


        public override Point Calculate(Board board, Dictionary<Tuple<int, int>, Tile> localfilledTiles, Dictionary<Tuple<int, int>, Tile> localMyTiles, Dictionary<Tuple<int, int>, Tile> localEnemyTiles, List<Row> localMy4Rows, List<Row> localEnemy4Rows, List<Row> localMy3Rows, List<Row> localEnemy3Rows, List<Row> localMy2Rows, List<Row> localEnemy2Rows)
        {
            bool foundBest = false;
            Row bestRow = null;

            for (int i = 0; i < localEnemy3Rows.Count; i++)
            {
                Row tempRow = localEnemy3Rows[i];
                //might be unbalanced
                if (tempRow.emptyTile1.X != -1 && tempRow.emptyTile1.Y != -1 && tempRow.emptyTile2.X != -1 && tempRow.emptyTile2.Y != -1)
                {
                    foundBest = true;
                    bestRow = tempRow;
                }
            }

            if (foundBest)
            {
                int side = Globals.rand.Next(0, 2);
                if(side == 0) 
                {
                    return bestRow.emptyTile1;
                }
                else 
                {
                    return bestRow.emptyTile2;
                }
                
            }
            else
            {
                int index = Globals.rand.Next(0, localEnemy3Rows.Count);
                Row tempRow = localEnemy3Rows[index];

                //might be unbalanced
                if (tempRow.emptyTile1.X != -1 && tempRow.emptyTile1.Y != -1)
                {
                    return tempRow.emptyTile1;
                }

                if (tempRow.emptyTile2.X != -1 && tempRow.emptyTile2.Y != -1)
                {
                    return tempRow.emptyTile2;
                }

            }

            

            return new Point(-1, -1);
        }
    }
}
