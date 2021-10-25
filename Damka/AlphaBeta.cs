using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Damka
{
    class AlphaBeta
    {
        public PlayerType maxPlayer { get; set; }
        public PlayerType minPlayer { get; set; }
        public AlphaBeta(PlayerType maxPlayer, PlayerType minPlayer)
        {
            this.maxPlayer = maxPlayer;
            this.minPlayer = minPlayer;
        }



        //2.4.15//
        public GameMove AlphaBetaMove(Board game, int maxLevel)
        {
            int a = Int32.MinValue; //srives for negative infinity (-∞)
            int b = Int32.MaxValue; //srives for positive infinity (+∞)
            GameMove maxMove = null;
            int temp = 0;
            foreach (var move in GenerateMoves(maxPlayer, game))
            {
                temp = MaxMove(ApplyMove(maxPlayer, move, game), a, b, maxLevel - 1);
                if (temp > a)
                {
                    a = temp;
                    maxMove = new GameMove(move);
                }
            }
            return maxMove;
        }



        public int MaxMove(Board game, int a, int b, int level)
        {
            List<GameMove> moves = GenerateMoves(maxPlayer, game);
            if (game.gameOver(game.gBoard, minPlayer) || level <= 0)
                return game.getScorePlayer(game.gBoard, maxPlayer);
            else
            {

                foreach (var move in moves)
                {
                    a = Math.Max(a, MinMove(ApplyMove(maxPlayer, move, game), a, b, level - 1));
                    if (b <= a)
                        break;
                }
                return a;
            }
        }


        public int MinMove(Board game, int a, int b, int level)
        {
            List<GameMove> moves = GenerateMoves(minPlayer, game);
            if (game.gameOver(game.gBoard, maxPlayer) || level <= 0)
                return game.getScorePlayer(game.gBoard, maxPlayer);
            else
            {
                foreach (var move in moves)
                {
                    b = Math.Min(MaxMove(ApplyMove(minPlayer, move, game), a, b, level - 1), b);
                    if (b <= a)
                        break;
                }
                return b;
            }
        }

        


        private Board ApplyMove(PlayerType player, GameMove move, Board board)
        {
            Board game = new Board(player);
            game.gBoard = board.applyMove(board.gBoard, player, move);
            return game;
        }



        private List<GameMove> GenerateMoves(PlayerType player, Board game)
        {
            List<GameMove> jumpMoves = new List<GameMove>();
            jumpMoves = game.getJumpMoves(player, game.gBoard);
            if (jumpMoves.Count > 0)
                return jumpMoves;
                List<GameMove> simpleMoves = new List<GameMove>();
                simpleMoves = game.getSimpleMoves(player, game.gBoard);
                return simpleMoves;
        }
    }
}
