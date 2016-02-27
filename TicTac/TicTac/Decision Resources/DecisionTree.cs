using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicTac
{
    class DecisionTree
    {
        DecisionOrAction root;

        public DecisionTree()
        {
            root = new MyFirstTurnDec();
            
            ((Decision)root).trueCalc = new FirstOverallTurnDec();
            ((Decision)root).falseCalc = new RandomLocationAct();

            PrintTree();
            //(Decision)(((Decision)root).trueCalc).trueCalc = new FirstOverallTurnDec();
        }

        public Point DoTurn(Board board, Dictionary<Tuple<int, int>, Tile> localfilledTiles, Dictionary<Tuple<int, int>, Tile> localMyTiles, Dictionary<Tuple<int, int>, Tile> localEnemyTiles)
        {
            try
            {
                return root.Calculate(board, localfilledTiles, localMyTiles, localEnemyTiles);
            }
            catch (Exception e)
            {
                return new Point(-1, -1);
            }
        }

        public void PrintTree()
        {
            if (root != null)
            {
                root.printTree();
            }
            else
            {
                Console.WriteLine("DecisionTree is empty.");
            }
        }
    }
}
