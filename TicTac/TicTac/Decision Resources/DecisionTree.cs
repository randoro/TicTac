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
            CanGet5Dec canGet5Dec = new CanGet5Dec();
            ((Decision)root).trueCalc = firstOverallTurnDec;
            ((Decision)root).falseCalc = canGet5Dec;

            //layer 2
            RandomLocationAroundAct randomLocationAroundAct = new RandomLocationAroundAct();
            RandomLocationAct randomLocationAct = new RandomLocationAct();
            ((Decision)firstOverallTurnDec).trueCalc = randomLocationAct;
            ((Decision)firstOverallTurnDec).falseCalc = randomLocationAroundAct;

            GetA5Act getA5Act = new GetA5Act();
            NeedToBlock5Dec needToBlock5Dec = new NeedToBlock5Dec();
            ((Decision)canGet5Dec).trueCalc = getA5Act;
            ((Decision)canGet5Dec).falseCalc = needToBlock5Dec;

            //layer 3
            BlockA5Act blockA5Act = new BlockA5Act();
            CanGet4Dec canGet4Dec = new CanGet4Dec();
            ((Decision)needToBlock5Dec).trueCalc = blockA5Act;
            ((Decision)needToBlock5Dec).falseCalc = canGet4Dec;

            //layer 4
            GetBest4Act getBest4Act = new GetBest4Act();
            NeedToBlock4Dec needToBlock4Dec = new NeedToBlock4Dec();
            ((Decision)canGet4Dec).trueCalc = getBest4Act;
            ((Decision)canGet4Dec).falseCalc = needToBlock4Dec;

            //layer 5
            BlockBest4Act blockBest4Act = new BlockBest4Act();
            CanGet3Dec canGet3Dec = new CanGet3Dec();
            ((Decision)needToBlock4Dec).trueCalc = blockBest4Act;
            ((Decision)needToBlock4Dec).falseCalc = canGet3Dec;

            //layer 6
            GetBest3Act getBest3Act = new GetBest3Act();
            NeedToBlock3Dec needToBlock3Dec = new NeedToBlock3Dec();
            ((Decision)canGet3Dec).trueCalc = getBest3Act;
            ((Decision)canGet3Dec).falseCalc = needToBlock3Dec;

            //layer 7
            BlockBest3Act blockBest3Act = new BlockBest3Act();
            RandomLocationAroundAct randomLocationAroundAct2 = new RandomLocationAroundAct();
            ((Decision)needToBlock3Dec).trueCalc = blockBest3Act;
            ((Decision)needToBlock3Dec).falseCalc = randomLocationAroundAct2;


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
