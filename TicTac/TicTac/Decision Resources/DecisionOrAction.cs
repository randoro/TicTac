using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicTac
{
    abstract class DecisionOrAction 
    {
        public abstract Point Calculate(Board board, Dictionary<Tuple<int, int>, Tile> localfilledTiles, Dictionary<Tuple<int, int>, Tile> localMyTiles, Dictionary<Tuple<int, int>, Tile> localEnemyTiles, List<Row> localMy4Rows, List<Row> localEnemy4Rows, List<Row> localMy3Rows, List<Row> localEnemy3Rows, List<Row> localMy2Rows, List<Row> localEnemy2Rows);

        public abstract void printTree();

        public abstract void printTree(Boolean isRight, String indent);

        public abstract void printNodeValue();
    
    }
}
