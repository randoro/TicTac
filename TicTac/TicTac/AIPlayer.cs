using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicTac
{
    class AIPlayer : Player
    {
        Board board;
        TileState playersOwnState;
        DecisionTree tree;

        public AIPlayer(Board board, TileState playersOwnState)
        {
            this.board = board;
            this.playersOwnState = playersOwnState;
            tree = new DecisionTree();
        }

        public override bool DoTurn()
        {
            //Adding local dictionaries
            Dictionary<Tuple<int, int>, Tile> localfilledTiles = new Dictionary<Tuple<int, int>, Tile>();
            Dictionary<Tuple<int, int>, Tile> localMyTiles = new Dictionary<Tuple<int, int>, Tile>();
            Dictionary<Tuple<int, int>, Tile> localEnemyTiles = new Dictionary<Tuple<int, int>, Tile>();


            foreach (KeyValuePair<Tuple<int, int>, Tile> pair in board.filledTiles)
            {
                localfilledTiles.Add(pair.Key, pair.Value);
                if(pair.Value.tileState == playersOwnState) 
                {
                    localMyTiles.Add(pair.Key, pair.Value);
                }
                else
                {
                    localEnemyTiles.Add(pair.Key, pair.Value);
                }

            }

            //My 4 in a row
            List<Row> localMy4Rows = GetInARowCombo(5, localfilledTiles, localMyTiles);

            //Enemy 4 in a row
            List<Row> localEnemy4Rows = GetInARowCombo(5, localfilledTiles, localEnemyTiles);

            //My 3 in a row
            List<Row> localMy3Rows = GetInARowCombo(4, localfilledTiles, localMyTiles);

            //Enemy 3 in a row
            List<Row> localEnemy3Rows = GetInARowCombo(4, localfilledTiles, localEnemyTiles);

            //My 2 in a row
            List<Row> localMy2Rows = GetInARowCombo(3, localfilledTiles, localMyTiles);

            //Enemy 2 in a row
            List<Row> localEnemy2Rows = GetInARowCombo(3, localfilledTiles, localEnemyTiles);

            Point tileToChange = tree.DoTurn(board, localfilledTiles, localMyTiles, localEnemyTiles, localMy4Rows, localEnemy4Rows, localMy3Rows, localEnemy3Rows, localMy2Rows, localEnemy2Rows);
            if (tileToChange.X != -1)
            {
                board.ChangeTile(board.toIndex(tileToChange.X, tileToChange.Y), playersOwnState);
                
            }
            else
            {
                Console.WriteLine("Error! Could not make AI turn.");
            }
            return true;
            
        }



        private List<Row> GetInARowCombo(int comboLength, Dictionary<Tuple<int, int>, Tile> localfilledTiles, Dictionary<Tuple<int, int>, Tile> localSearchTiles)
        {
            List<Row> rows = new List<Row>();
            foreach (KeyValuePair<Tuple<int, int>, Tile> pair in localSearchTiles)
            {
                Point pos = new Point(pair.Key.Item1, pair.Key.Item2);


                Point direction1 = new Point(1, 0);
                Row newRow1 = GetRow(comboLength, pos, direction1, localfilledTiles, localSearchTiles);
                if (newRow1 != null)
                {
                    rows.Add(newRow1);
                }


                Point direction2 = new Point(1, 1);
                Row newRow2 = GetRow(comboLength, pos, direction2, localfilledTiles, localSearchTiles);
                if (newRow2 != null)
                {
                    rows.Add(newRow2);
                }


                Point direction3 = new Point(0, 1);
                Row newRow3 = GetRow(comboLength, pos, direction3, localfilledTiles, localSearchTiles);
                if (newRow3 != null)
                {
                    rows.Add(newRow3);
                }


                Point direction4 = new Point(-1, 1);
                Row newRow4 = GetRow(comboLength, pos, direction4, localfilledTiles, localSearchTiles);
                if (newRow4 != null)
                {
                    rows.Add(newRow4);
                }



            }



            return rows;
        }

        private Row GetRow(int comboLength, Point pos, Point direction, Dictionary<Tuple<int, int>, Tile> localfilledTiles, Dictionary<Tuple<int, int>, Tile> localSearchTiles)
        {
            Tile startsideTile;
            Point tempStartPoint = new Point(pos.X - direction.X, pos.Y - direction.Y);
            Point returnStartPoint = new Point(-1, -1);
            int fullLength = 0; //problem?

            if (board.IsInsideBorder(tempStartPoint))
            {
                //check if inside grid fix

                if (!localfilledTiles.TryGetValue(Tuple.Create<int, int>(tempStartPoint.X, tempStartPoint.Y), out startsideTile))
                {

                    returnStartPoint = tempStartPoint;
                }
                else
                {
                    fullLength++;
                }
            }

            Tile[] tempArray = new Tile[comboLength - 2];

            
            for (int i = 0; i < comboLength - 2; i++)
            {

                Tile tempTile;
                if (localSearchTiles.TryGetValue(Tuple.Create<int, int>(pos.X, pos.Y), out tempTile))
                {
                    tempArray[i] = tempTile;
                    fullLength++;

                    pos.X = pos.X + direction.X;
                    pos.Y = pos.Y + direction.Y;
                }

                

                
            }

            Tile endsideTile;
            Point tempEndPoint = new Point(pos.X, pos.Y);
            Point returnEndPoint = new Point(-1, -1);
            if (board.IsInsideBorder(tempEndPoint))
            {
                //check if inside grid fix
                if (!localfilledTiles.TryGetValue(Tuple.Create<int, int>(tempEndPoint.X, tempEndPoint.Y), out endsideTile))
                {
                    returnEndPoint = tempEndPoint;
                }
                else
                {
                    fullLength++;
                }
            }


            if (returnStartPoint.X == -1 && returnStartPoint.Y == -1 && returnEndPoint.X == -1 && returnEndPoint.Y == -1)
            {
                return null;
            }


            if (fullLength == comboLength - 1)
            {
                return new Row(returnStartPoint, returnEndPoint, tempArray, comboLength);
            }
            return null;
        }

    }
}
