using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicTac
{
    class RandomLocationAroundAct : Action
    {
        public RandomLocationAroundAct()
        {
            //Create random location around the already placed tiles on grid. (Thus a valid, random move).
        }


        public override Point Calculate(Board board, Dictionary<Tuple<int, int>, Tile> localfilledTiles, Dictionary<Tuple<int, int>, Tile> localMyTiles, Dictionary<Tuple<int, int>, Tile> localEnemyTiles, List<Row> localMy4Rows, List<Row> localEnemy4Rows, List<Row> localMy3Rows, List<Row> localEnemy3Rows, List<Row> localMy2Rows, List<Row> localEnemy2Rows)
        {

            if (localfilledTiles.Count != board.tiles.Length && localfilledTiles.Count != 0)
            {
                bool isEmpty = false;
                while (!isEmpty)
                {
                    Tile randomTile = localfilledTiles.ElementAt(Globals.rand.Next(0, localfilledTiles.Count)).Value;
                    Point exactPoint = new Point(randomTile.Xpos, randomTile.Ypos);

                    if (board.HasEmptyNeighbour(exactPoint) > 0)
                    {
                        bool found = false;
                        Point refPoint = new Point(-1, -1);
                        while (!found)
                        {
                            if(board.RandomNeighbour(exactPoint, ref refPoint)) 
                            {
                                if (!(localfilledTiles.ContainsKey(Tuple.Create<int, int>(refPoint.X, refPoint.Y))))
                                {
                                        found = true;
                                        return refPoint;
                                }
                            }
                        }
                    }

                }
            }
            return new Point(-1, -1);
        }
    }
}
