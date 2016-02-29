using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicTac
{

    public enum GameState { menu, playing, gameover }
    public enum PlayerType { Human, AI }

    public static class Globals
    {
        public const int windowX = 1280;
        public const int windowY = 720;


        public const int gridOffsetX = 50;
        public const int gridOffsetY = 50;

        public static Random rand = new Random();

        public static TileState getOtherTileState(TileState state)
        {
            switch (state)
            {
                case TileState.none:
                    return TileState.none;
                    break;
                case TileState.Xmark:
                    return TileState.Omark;
                    break;
                case TileState.Omark:
                    return TileState.Xmark;
                    break;
                default:
                    return TileState.none;
                    break;
            }
        }


        public static Dictionary<Tuple<int, int>, Tile> Clone(Dictionary<Tuple<int, int>, Tile> oldDictionary)
        {
            Dictionary<Tuple<int, int>, Tile> newDictionary = new Dictionary<Tuple<int, int>, Tile>();
            foreach (KeyValuePair<Tuple<int, int>, Tile> pair in oldDictionary)
            {
                newDictionary.Add(pair.Key, pair.Value);
            }

            return newDictionary;
        }

    }
}
