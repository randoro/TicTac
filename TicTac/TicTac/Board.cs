using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicTac
{
    class Board
    {
        int width;
        int height;
        public Tile[] tiles { get; private set; }
        List<int> filledIndex;

        public Board(int width, int height)
        {
            this.width = width;
            this.height = height;

            tiles = new Tile[width * height];
            filledIndex = new List<int>();
        }

        public void ResetBoard()
        {
            for (int i = 0; i < tiles.Length; i++)
            {
                tiles[i] = new Tile();
            }

            filledIndex.Clear();
        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {

        }

        public void ChangeTile(int index, TileState newState)
        {
            if (tiles[index].tileState == TileState.none)
            {
                tiles[index].tileState = newState;
                filledIndex.Add(index);
            }
            else
            {
                throw new Exception("Tile is already occupied! index:" + index);
            }
        }



    }
}
