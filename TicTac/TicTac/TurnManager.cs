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

        public TurnManager(Board board, PlayerType newPlayer1Type, PlayerType newPlayer2Type)
        {
            this.board = board;
            players = new Player[2];

            switch (newPlayer1Type)
            {
                case PlayerType.Human:
                    players[0] = new HumanPlayer(board, TileState.Xmark);
                    break;
                case PlayerType.AI:
                    players[0] = new AIPlayer(board, TileState.Xmark);
                    break;
                default:
                    break;
            }

            switch (newPlayer2Type)
            {
                case PlayerType.Human:
                    players[1] = new HumanPlayer(board, TileState.Omark);
                    break;
                case PlayerType.AI:
                    players[1] = new AIPlayer(board, TileState.Omark);
                    break;
                default:
                    break;
            }
            
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
