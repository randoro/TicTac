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

            Point tileToChange = tree.DoTurn(board, localfilledTiles, localMyTiles, localEnemyTiles);
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
    }
}
