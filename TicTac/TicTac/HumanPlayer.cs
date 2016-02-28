using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicTac
{
    class HumanPlayer : Player
    {
        Board board;
        TileState playersOwnState;

        public HumanPlayer(Board board, TileState playersOwnState)
        {
            this.board = board;
            this.playersOwnState = playersOwnState;
        }

        public override bool DoTurn()
        {
            if (KeyMouseReader.LeftClick())
            {
                Point mousePos = new Point(KeyMouseReader.mouseState.X, KeyMouseReader.mouseState.Y);
                Rectangle tempRect = new Rectangle(Globals.gridOffsetX, Globals.gridOffsetY, board.width * 32, board.height * 32);
                if (tempRect.Contains(mousePos))
                {
                    //is inside playfield
                    Point ExactTile = new Point((KeyMouseReader.mouseState.X - Globals.gridOffsetX) / 32, (KeyMouseReader.mouseState.Y - Globals.gridOffsetY) / 32);
                    int index = ExactTile.Y * board.width + ExactTile.X;
                    if (board.IsTileEmpty(index))
                    {
                        if (board.HasAnyNeighbour(ExactTile))
                        {
                            board.ChangeTile(index, playersOwnState);
                            return true;
                        }
                        else
                        {
                            if (board.filledTiles.Count == 0)
                            {
                                board.ChangeTile(index, playersOwnState);
                                return true;
                            }
                        }
                    }

                }

            }
            return false;
        }
    }
}
