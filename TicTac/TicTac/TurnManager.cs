using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicTac
{

    

    class TurnManager
    {
        Player[] players;
        int turn;
        Board board;

        int turnPause = 0;
        int turnPauseMax = 20;

        public TurnManager(Board board)
        {
            this.board = board;
            players = new Player[2];
            players[0] = new HumanPlayer(board, TileState.Omark);
            players[1] = new AIPlayer(board, TileState.Xmark);
            turn = 0;
        }

        public void Update(GameTime gameTime)
        {
            if (turnPause < turnPauseMax)
            {
                turnPause++;
            }
            else
            {
                bool done = DoTurn();
                if (done)
                {
                    turnPause = 0;
                }
            }

        }

        private bool DoTurn()
        {
            bool done = players[turn].DoTurn();
            if (done)
            {
                ChangeTurn();
            }
            return done;
        }


        private void ChangeTurn()
        {
            turn++;
            turn %= 2;
        }


    }
}
