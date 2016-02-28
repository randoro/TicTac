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


        /* temp comment
         * 
         * myfirstturn?
         * firstturnoverall?
         * canIget5?
         * any4sneedblock?
         * canIget4?
         * any3sneedblock? //make sure to block a -OOO- over a -OOOX
         * canIget3?
         * any2sneedblock?
         * canIget2?
         * 
         * 
         * */
        public DecisionTree()
        {
            //layer 0
            root = new MyFirstTurnDec();

            //layer 1
            FirstOverallTurnDec firstOverallTurnDec = new FirstOverallTurnDec();
            RandomLocationAroundAct randomLocationAroundAct = new RandomLocationAroundAct();
            ((Decision)root).trueCalc = firstOverallTurnDec;
            ((Decision)root).falseCalc = randomLocationAroundAct;

            //layer 2
            RandomLocationAroundAct randomLocationAroundAct2 = new RandomLocationAroundAct();
            RandomLocationAct randomLocationAct = new RandomLocationAct();
            ((Decision)firstOverallTurnDec).trueCalc = randomLocationAct;
            ((Decision)firstOverallTurnDec).falseCalc = randomLocationAroundAct2;


            PrintTree();
            //(Decision)(((Decision)root).trueCalc).trueCalc = new FirstOverallTurnDec();
        }

        public Point DoTurn(Board board, Dictionary<Tuple<int, int>, Tile> localfilledTiles, Dictionary<Tuple<int, int>, Tile> localMyTiles, Dictionary<Tuple<int, int>, Tile> localEnemyTiles, List<Row> localMy4Rows, List<Row> localEnemy4Rows, List<Row> localMy3Rows, List<Row> localEnemy3Rows, List<Row> localMy2Rows, List<Row> localEnemy2Rows)
        {
            try
            {
                return root.Calculate(board, localfilledTiles, localMyTiles, localEnemyTiles, localMy4Rows, localEnemy4Rows, localMy3Rows, localEnemy3Rows, localMy2Rows, localEnemy2Rows);
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
