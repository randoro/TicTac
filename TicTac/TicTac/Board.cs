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

        public bool HasAnyNeighbour(Point exactPos)
        {
            //minus Y
            if(filledTiles.ContainsKey(Tuple.Create<int, int>(exactPos.X - 1, exactPos.Y - 1)))
            {
                return true;
            }
            if (filledTiles.ContainsKey(Tuple.Create<int, int>(exactPos.X, exactPos.Y - 1)))
            {
                return true;
            }
            if (filledTiles.ContainsKey(Tuple.Create<int, int>(exactPos.X + 1, exactPos.Y - 1)))
            {
                return true;
            }

            //same Y
            if (filledTiles.ContainsKey(Tuple.Create<int, int>(exactPos.X - 1, exactPos.Y)))
            {
                return true;
            }
            if (filledTiles.ContainsKey(Tuple.Create<int, int>(exactPos.X + 1, exactPos.Y)))
            {
                return true;
            }


            //plus Y
            if (filledTiles.ContainsKey(Tuple.Create<int, int>(exactPos.X - 1, exactPos.Y + 1)))
            {
                return true;
            }
            if (filledTiles.ContainsKey(Tuple.Create<int, int>(exactPos.X, exactPos.Y + 1)))
            {
                return true;
            }
            if (filledTiles.ContainsKey(Tuple.Create<int, int>(exactPos.X + 1, exactPos.Y + 1)))
            {
                return true;
            }

            return false;
        }


        public int HasEmptyNeighbour(Point exactPos)
        {
            int emptyNeighbour = 0;
            //minus Y
            Point tempPoint0 = new Point(exactPos.X - 1, exactPos.Y - 1);
            if (!filledTiles.ContainsKey(Tuple.Create<int, int>(tempPoint0.X, tempPoint0.Y)))
            {
                if (tempPoint0.X >= 0 && tempPoint0.X < width && tempPoint0.Y >= 0 && tempPoint0.Y < height)
                {
                    emptyNeighbour++;
                }
            }

            Point tempPoint1 = new Point(exactPos.X, exactPos.Y - 1);
            if (!filledTiles.ContainsKey(Tuple.Create<int, int>(tempPoint1.X, tempPoint1.Y)))
            {
                if (tempPoint1.X >= 0 && tempPoint1.X < width && tempPoint1.Y >= 0 && tempPoint1.Y < height)
                {
                    emptyNeighbour++;
                }
            }

            Point tempPoint2 = new Point(exactPos.X + 1, exactPos.Y - 1);
            if (!filledTiles.ContainsKey(Tuple.Create<int, int>(tempPoint2.X, tempPoint2.Y)))
            {
                if (tempPoint2.X >= 0 && tempPoint2.X < width && tempPoint2.Y >= 0 && tempPoint2.Y < height)
                {
                    emptyNeighbour++;
                }
            }

            //same Y
            Point tempPoint3 = new Point(exactPos.X - 1, exactPos.Y);
            if (!filledTiles.ContainsKey(Tuple.Create<int, int>(tempPoint3.X, tempPoint3.Y)))
            {
                if (tempPoint3.X >= 0 && tempPoint3.X < width && tempPoint3.Y >= 0 && tempPoint3.Y < height)
                {
                    emptyNeighbour++;
                }
            }

            Point tempPoint4 = new Point(exactPos.X + 1, exactPos.Y);
            if (!filledTiles.ContainsKey(Tuple.Create<int, int>(tempPoint4.X, tempPoint4.Y)))
            {
                if (tempPoint4.X >= 0 && tempPoint4.X < width && tempPoint4.Y >= 0 && tempPoint4.Y < height)
                {
                    emptyNeighbour++;
                }
            }


            //plus Y
            Point tempPoint5 = new Point(exactPos.X - 1, exactPos.Y + 1);
            if (!filledTiles.ContainsKey(Tuple.Create<int, int>(tempPoint5.X, tempPoint5.Y)))
            {
                if (tempPoint5.X >= 0 && tempPoint5.X < width && tempPoint5.Y >= 0 && tempPoint5.Y < height)
                {
                    emptyNeighbour++;
                }
            }

            Point tempPoint6 = new Point(exactPos.X, exactPos.Y + 1);
            if (!filledTiles.ContainsKey(Tuple.Create<int, int>(tempPoint6.X, tempPoint6.Y)))
            {
                if (tempPoint6.X >= 0 && tempPoint6.X < width && tempPoint6.Y >= 0 && tempPoint6.Y < height)
                {
                    emptyNeighbour++;
                }
            }

            Point tempPoint7 = new Point(exactPos.X + 1, exactPos.Y + 1);
            if (!filledTiles.ContainsKey(Tuple.Create<int, int>(tempPoint7.X, tempPoint7.Y)))
            {
                if (tempPoint7.X >= 0 && tempPoint7.X < width && tempPoint7.Y >= 0 && tempPoint7.Y < height)
                {
                    emptyNeighbour++;
                }
            }

            return emptyNeighbour;
        }


        public bool RandomNeighbour(Point exactPos, ref Point neighbourPos)
        {
            int xAdd = Globals.rand.Next(-1, 2);
            int yAdd = Globals.rand.Next(-1, 2);
            Point newPoint = new Point(exactPos.X + xAdd, exactPos.Y + yAdd);
            if (newPoint.X == exactPos.X && newPoint.Y == exactPos.Y)
            {
                return false;
            }
            else
            {
                if (newPoint.X >= 0 && newPoint.X < width && newPoint.Y >= 0 && newPoint.Y < height)
                {
                    neighbourPos = newPoint;
                    return true;
                }
                return false;
            }

        }

        public bool IsInsideBorder(Point exactPos)
        {
            return (exactPos.X >= 0 && exactPos.X < width && exactPos.Y >= 0 && exactPos.Y < height);
        }


    }
}
