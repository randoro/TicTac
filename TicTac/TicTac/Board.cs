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
        public int width { get; private set; }
        public int height { get; private set; }
        public Tile[] tiles { get; private set; }
        public Dictionary<Tuple<int, int>, Tile> filledTiles { get; private set; }

        public Board(int width, int height)
        {
            this.width = width;
            this.height = height;

            tiles = new Tile[width * height];
            filledTiles = new Dictionary<Tuple<int, int>, Tile>();

            ResetBoard();

        }

        public void ResetBoard()
        {
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    tiles[i*width + j] = new Tile(j, i);
                }
            }

            filledTiles.Clear();
        }

        public int toIndex(int xPos, int yPos)
        {
            return yPos * width + xPos;
        }

        public Point toPoint(int index)
        {
            return new Point(index % width, index / width);
        }

        public Tuple<int, int> toTuple(int index)
        {
            return Tuple.Create<int, int>(index % width, index / width);
        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < tiles.Length; i++)
            {
                tiles[i].Draw(spriteBatch);
            }

        }

        public bool IsTileEmpty(int index)
        {
            return (tiles[index].tileState == TileState.none);
                    
        }


        public void ChangeTile(int index, TileState newState)
        {
            if (tiles[index].tileState == TileState.none)
            {
                tiles[index].tileState = newState;
                filledTiles.Add(toTuple(index), tiles[index]);
            }
            else
            {
                throw new Exception("Tile is already occupied! index:" + index);
            }
        }



    }
}
