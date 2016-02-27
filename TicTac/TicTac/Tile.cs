using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicTac
{
    public enum TileState { none, Xmark, Omark }

    public class Tile
    {
        int Xpos;
        int Ypos;
        public TileState tileState { get; set; }

        public Tile(int Xpos, int Ypos)
        {
            tileState = TileState.none;
            this.Xpos = Xpos;
            this.Ypos = Ypos;
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Game1.boardTexture, new Vector2(Globals.gridOffsetX + Xpos * 32, Globals.gridOffsetX + Ypos * 32), new Rectangle(0, 0, 32, 32), Color.White);

            switch (tileState)
            {
                case TileState.none:
                    break;
                case TileState.Xmark:
                    spriteBatch.Draw(Game1.boardTexture, new Vector2(Globals.gridOffsetX + Xpos * 32, Globals.gridOffsetX + Ypos * 32), new Rectangle(0, 32, 32, 32), Color.White);

                    break;
                case TileState.Omark:
                    spriteBatch.Draw(Game1.boardTexture, new Vector2(Globals.gridOffsetX + Xpos * 32, Globals.gridOffsetX + Ypos * 32), new Rectangle(32, 32, 32, 32), Color.White);

                    break;
                default:
                    break;
            }
        
        }
    }
}
