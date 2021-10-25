using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Damka
{
    class Board : GameState
    {
        public PlayerType playTurn { get; set; }
        const int SIZE = 8;
        public CellState[,] gBoard;
        public Board(PlayerType playTurn)
        {

            this.playTurn = playTurn;

            gBoard = new CellState[SIZE, SIZE];
              for (int i = 0; i < SIZE; i++)
                for (int j = 0; j < SIZE; j++)
                {
                  
                if ((j + i) % 2 != 0) // Discs can only be when row+col (i+j) = Ezugi
                {
                    if (i < 3)
                        gBoard[i, j] = CellState.BLACK; //Black Discs are up
                    if (i > 4)
                        gBoard[i, j] = CellState.WHITE; //White Discs are down
                }
                else
                    gBoard[i, j] = CellState.EMPTY;
                  
                }  
        }


        //2.4.1//
        //check if the cell equals to the player(Black/White)
        public bool belongToPlayer(CellState cell, PlayerType player)
        {
            if (player == PlayerType.Black && (cell == CellState.BLACK || cell == CellState.BLACKKING))
                return true;
            else if (player == PlayerType.White && (cell == CellState.WHITE || cell == CellState.WHITEKING))
                return true;
            else
                return false;

        }

        //2.4.2//
        //List of all Discs of player(Black/White) on the board
        public List<Point> playerDiscs(CellState[,] gBoard, PlayerType player)
        {
            List<Point> positionsLst = new List<Point>();
            for (int i = 0; i < SIZE; i++)
                for (int j = 0; j < SIZE; j++)
                {
                    if ((j + i) % 2 != 0) // Discs can only be when row+col (i+j) = Ezugi
                    {
                        if (belongToPlayer(gBoard[i, j], player))
                        {
                            Point point = new Point();
                            point.row = i;
                            point.col = j;
                            point.Type = gBoard[i, j];  // (BLACK/WHITE)
                            positionsLst.Add(point);
                        }
                    }
                }
            return positionsLst;
        }

        //2.4.3//
        //check if the "move" is legal to the player in the cell ("Simple Move")
        public bool isValidSimpleMove(PlayerType player, GameMove move, CellState[,] gBoard)
        {
            if (move.fromCol <= 7 && move.fromCol >= 0 && move.fromRow <= 7 && move.fromRow >= 0) //check if the "From Move" is in the board
            {
                if (move.toCol <= 7 && move.toCol >= 0 && move.toRow <= 7 && move.toRow >= 0) //check if the "To Move" is in the board
                {
                    if (belongToPlayer(gBoard[move.fromRow, move.fromCol], player)) //check if the "From Cell" is belong to the currect player
                    {
                        if (gBoard[move.toRow, move.toCol] == CellState.EMPTY) //check if the target cell = Empty
                        {
                            if (move.fromCol + 1 == move.toCol || move.fromCol - 1 == move.toCol) //check if the the target cell legal (col)
                            {

                                //////////////////////////////////     BLACK     //////////////////////////////////
                                if (player == PlayerType.Black)
                                {
                                    if (gBoard[move.fromRow, move.fromCol] == CellState.BLACKKING) //check if the the "From Cell" is "King Black"
                                        return true;
                                    if (move.fromRow + 1 == move.toRow) //check if the the target cell legal to "Simple Black" (no king)
                                        return true;
                                }

                                //////////////////////////////////     WHITE     //////////////////////////////////
                                else if (player == PlayerType.White)
                                {
                                    if (gBoard[move.fromRow, move.fromCol] == CellState.WHITEKING) //check if the the "From Cell" is "King White"
                                        return true;
                                    if (move.fromRow - 1 == move.toRow) ////check if the the target cell legal to "Simple White" (no king)
                                        return true;
                                }
                                ///////////////////////////////////////////////////////////////////////////////////
                            }
                        }
                    }
                }

            }
            return false;
        }

        

        //2.4.4//
        //get List of ALL "Simple Moves"(no jump) to the player
        public List<GameMove> getSimpleMoves(PlayerType player, CellState[,] gBoard)
        {
            List<GameMove> simpleMovesLst = new List<GameMove>();
            List<Point> DiscsLst = playerDiscs(gBoard, player);
            foreach (var disc in DiscsLst)
            {
                GameMove simpleMove = new GameMove();

                simpleMove.fromRow = disc.row;
                simpleMove.fromCol = disc.col;

                simpleMove.toRow = disc.row + 1;
                simpleMove.toCol = disc.col + 1;
                if (isValidSimpleMove(player, simpleMove, gBoard))
                {
                    simpleMovesLst.Add(new GameMove(simpleMove));
                }
                
                simpleMove.toRow = disc.row - 1;
                simpleMove.toCol = disc.col - 1;
                if (isValidSimpleMove(player, simpleMove, gBoard))
                {
                    simpleMovesLst.Add(new GameMove(simpleMove));
                }

                simpleMove.toRow = disc.row + 1;
                simpleMove.toCol = disc.col - 1;
                if (isValidSimpleMove(player, simpleMove, gBoard))
                {
                    simpleMovesLst.Add(new GameMove(simpleMove));
                }
                simpleMove.toRow = disc.row - 1;
                simpleMove.toCol = disc.col + 1;
                if (isValidSimpleMove(player, simpleMove, gBoard))
                {
                    simpleMovesLst.Add(new GameMove(simpleMove));
                }
            }
            
            return simpleMovesLst;
        }
        


        

        //2.4.5//
        //check if the "move" is legal to the player in the cell ("Jump Move")
        public bool isValidJumpMove(PlayerType player, GameMove move, CellState[,] gBoard)
        {
            CellState rivalP = rivalPlayer(gBoard[move.fromRow, move.fromCol]);  //get the "Rival Player"
            CellState rivalPKing = rivalPlayerKing(gBoard[move.fromRow, move.fromCol]);  //get the "Rival King Player"
            if (move.fromCol <= 7 && move.fromCol >= 0 && move.fromRow <= 7 && move.fromRow >= 0) //check if the "From Move" is in the board
            {
                if (move.toCol <= 7 && move.toCol >= 0 && move.toRow <= 7 && move.toRow >= 0) //check if the "To Move" is in the board
                {
                    if (belongToPlayer(gBoard[move.fromRow, move.fromCol], player))  //check if the "From Cell" is belong to the currect player
                    {
                        if (gBoard[move.toRow, move.toCol] == CellState.EMPTY)  //check if the target cell = Empty
                        {
                            if ((move.fromCol - 1) <= 7 && (move.fromCol - 1) >= 0 && (move.fromRow - 1) <= 7 && (move.fromRow - 1) >= 0) //check if the rival player existing in the board
                            {
                                if (gBoard[move.fromRow - 1, move.fromCol - 1] == rivalP || gBoard[move.fromRow - 1, move.fromCol - 1] == rivalPKing)  //check if the "Eat Cell" is the opponent's cell (cell = down,left)
                                {
                                    if (move.toCol == move.fromCol - 2)  //check if the the target cell belongs to the player (col)
                                    {
                                        if (gBoard[move.fromRow, move.fromCol] == CellState.BLACKKING || gBoard[move.fromRow, move.fromCol] == CellState.WHITEKING)  //check if the the "From Cell" is "King Disc"
                                            if (move.toRow== move.fromRow - 2)  //check if the the target cell belongs to the player (row)
                                                return true;
                                        if (gBoard[move.fromRow, move.fromCol] == CellState.WHITE)  //check if the the "From Cell" legal to "Simple White"(no king)
                                            if (move.toRow == move.fromRow - 2)  //check if the the target cell belongs to the player (row)
                                                return true;

                                    }
                                }
                            }

                            if ((move.fromCol - 1) <= 7 && (move.fromCol - 1) >= 0 && (move.fromRow + 1) <= 7 && (move.fromRow + 1) >= 0) //check if the rival player existing in the board
                            {
                                if (gBoard[move.fromRow + 1, move.fromCol - 1] == rivalP || gBoard[move.fromRow + 1, move.fromCol - 1] == rivalPKing)  //check if the "Eat Cell" is the opponent's cell (cell = up,left)
                                {
                                    if (move.fromCol - 2 == move.toCol)  //check if the the target cell belongs to the player (col) 
                                    {
                                        if (gBoard[move.fromRow, move.fromCol] == CellState.BLACKKING || gBoard[move.fromRow, move.fromCol] == CellState.WHITEKING)  //check if the the "From Cell" is "King Disc"
                                            if (move.fromRow + 2 == move.toRow)  //check if the the target cell belongs to the player (row)
                                                return true;
                                        if (gBoard[move.fromRow, move.fromCol] == CellState.BLACK)  //check if the the "From Cell" legal to "Simple Black"(no king)
                                            if (move.fromRow + 2 == move.toRow)  //check if the the target cell belongs to the player (row)
                                                return true;

                                    }
                                }
                            }

                            if ((move.fromCol + 1) <= 7 && (move.fromCol + 1) >= 0 && (move.fromRow + 1) <= 7 && (move.fromRow + 1) >= 0) //check if the rival player existing in the board
                            {
                                if (gBoard[move.fromRow + 1, move.fromCol + 1] == rivalP || gBoard[move.fromRow + 1, move.fromCol + 1] == rivalPKing)  //check if the "Eat Cell" is the opponent's cell (cell = up,right)
                                {
                                    if (move.fromCol + 2 == move.toCol)  //check if the the target cell belongs to the player (col)  
                                    {
                                        if (gBoard[move.fromRow, move.fromCol] == CellState.BLACKKING || gBoard[move.fromRow, move.fromCol] == CellState.WHITEKING)  //check if the the "From Cell" is "King Disc"
                                            if (move.fromRow + 2 == move.toRow)  //check if the the target cell belongs to the player (row)
                                                return true;
                                        if (gBoard[move.fromRow, move.fromCol] == CellState.BLACK)  //check if the the "From Cell" legal to "Simple Black"(no king)
                                            if (move.fromRow + 2 == move.toRow)  //check if the the target cell belongs to the player (row)
                                                return true;

                                    }
                                }
                            }

                            if ((move.fromCol + 1) <= 7 && (move.fromCol + 1) >= 0 && (move.fromRow - 1) <= 7 && (move.fromRow - 1) >= 0) //check if the rival player existing in the board
                            {
                                if (gBoard[move.fromRow - 1, move.fromCol + 1] == rivalP || gBoard[move.fromRow - 1, move.fromCol + 1] == rivalPKing)  //check if the "Eat Cell" is the opponent's cell (cell = down,right)
                                {
                                    if (move.fromCol + 2 == move.toCol)  //check if the the target cell belongs to the player (col) 
                                    {
                                        if (gBoard[move.fromRow, move.fromCol] == CellState.BLACKKING || gBoard[move.fromRow, move.fromCol] == CellState.WHITEKING)  //check if the the "From Cell" is "King Disc"
                                            if (move.fromRow - 2 == move.toRow)  //check if the the target cell belongs to the player (row)
                                                return true;
                                        if (gBoard[move.fromRow, move.fromCol] == CellState.WHITE)  //check if the the "From Cell" legal to "Simple White"(no king)
                                            if (move.fromRow - 2 == move.toRow)  //check if the the target cell belongs to the player (row)
                                                return true;

                                    }
                                }
                            }
                        }
                    }
                }
            }
            return false;
        }

        //2.4.6//
        //get the "Rival Player" (if "White", return "Black"...)
        public CellState rivalPlayer(CellState cell)
        {
            CellState rivalP = new CellState();
            if (cell == CellState.BLACK || cell == CellState.BLACKKING)
                rivalP = CellState.WHITE;
            if (cell == CellState.WHITE || cell == CellState.WHITEKING)
                rivalP = CellState.BLACK;
            return rivalP;
        }

        //2.4.7//
        //get the "Rival Player" of kind - "King" (if "White", return "BlackKing"...)
        public CellState rivalPlayerKing(CellState cell)
        {
            CellState rivalP = new CellState();
            if (cell == CellState.BLACK || cell == CellState.BLACKKING)
                rivalP = CellState.WHITEKING;
            if (cell == CellState.WHITE || cell == CellState.WHITEKING)
                rivalP = CellState.BLACKKING;
            return rivalP;
        }

        //2.4.8//
        //get List of ALL "Jump Moves"(no simple) to the player
        public List<GameMove> getJumpMoves(PlayerType player, CellState[,] gBoard)
        {
            List<GameMove> jumpMovesLst = new List<GameMove>();
            List<Point> DiscsLst = new List<Point>();
            DiscsLst = playerDiscs(gBoard, player);
            foreach (var disc in DiscsLst)
            {
                GameMove jumpMove = new GameMove();

                jumpMove.fromRow = disc.row;
                jumpMove.fromCol = disc.col;
                jumpMove.toRow = disc.row + 2;
                jumpMove.toCol = disc.col + 2;
                if (isValidJumpMove(player, jumpMove, gBoard))
                    jumpMovesLst.Add(new GameMove(jumpMove));
                jumpMove.toRow = disc.row - 2;
                jumpMove.toCol = disc.col - 2;
                if (isValidJumpMove(player, jumpMove, gBoard))
                    jumpMovesLst.Add(new GameMove(jumpMove));
                jumpMove.toRow = disc.row + 2;
                jumpMove.toCol = disc.col - 2;
                if (isValidJumpMove(player, jumpMove, gBoard))
                    jumpMovesLst.Add(new GameMove(jumpMove));
                jumpMove.toRow = disc.row - 2;
                jumpMove.toCol = disc.col + 2;
                if (isValidJumpMove(player, jumpMove, gBoard))
                    jumpMovesLst.Add(new GameMove(jumpMove));
            }
            return jumpMovesLst;
        }

        //2.4.9//
        //check if the "move" valid to the player
        public bool isValidMove(CellState[,] gBoard, PlayerType player, GameMove move)
        {
            bool simple = isValidSimpleMove(player, move, gBoard);
            bool jump = isValidJumpMove(player, move, gBoard);
            if (jump || simple)
            {
                return true;
            }
            return false;
        }

        //2.4.10//
        //check if the player has "moves"
        public bool hasValidMoves(CellState[,] gBoard, PlayerType player)
        {
            List<GameMove> simpleMovesLst = getSimpleMoves(player, gBoard);
            List<GameMove> jumpMovesLst = getJumpMoves(player, gBoard);
            if (simpleMovesLst.Count > 0 || jumpMovesLst.Count > 0)
                return true;
            return false;
        }

        //2.4.11//
        //apply the "move" on the board
        public CellState[,] applyMove(CellState[,] gBoard, PlayerType player, GameMove move)
        {
            CellState[,] board = new CellState[SIZE, SIZE];
            for (int i = 0; i < SIZE; i++)
            {
                for (int j = 0; j < SIZE; j++)
                {
                    board[i, j] = gBoard[i, j];
                }
            }

            bool checkSimple = isValidSimpleMove(player, move, board);
            bool checkJump = isValidJumpMove(player, move, board);
            CellState playerState = new CellState();
            playerState = gBoard[move.fromRow, move.fromCol]; //"playerState" = the current player
            if (checkSimple)
            {
                board[move.fromRow, move.fromCol] = CellState.EMPTY;
                if (move.toRow == 0 || move.toRow == 7) //if the Disc be "King"
                {
                    if (playerState == CellState.WHITE || playerState == CellState.WHITEKING)
                        board[move.toRow, move.toCol] = CellState.WHITEKING;
                    if (playerState == CellState.BLACK || playerState == CellState.BLACKKING)
                        board[move.toRow, move.toCol] = CellState.BLACKKING;
                }
                else //if the Disc will not be "King"
                    board[move.toRow, move.toCol] = playerState;
            }
            if (checkJump)
            {
                board[move.fromRow, move.fromCol] = CellState.EMPTY;
                int enemyRow = (move.fromRow + move.toRow) / 2;
                int enemyCol = (move.fromCol + move.toCol) / 2;
                board[enemyRow, enemyCol] = CellState.EMPTY; //"Eating" the rival Disc
                if (move.toRow == 0 || move.toRow == 7) //if the Disc be "King"
                {
                    if (playerState == CellState.WHITE || playerState == CellState.WHITEKING)
                        board[move.toRow, move.toCol] = CellState.WHITEKING;
                    if (playerState == CellState.BLACK || playerState == CellState.BLACKKING)
                        board[move.toRow, move.toCol] = CellState.BLACKKING;
                }
                else //if the Disc will not be "King"
                    board[move.toRow, move.toCol] = playerState;
            }


            //switch turn
            if (player == PlayerType.Black)
            {
                this.playTurn = PlayerType.White;
            }
            else if (player == PlayerType.White)
                this.playTurn = PlayerType.Black;

            return board;
        }


        //2.4.12//
        //check if the game is over (if to the currect player has NOT "Moves" / to the one of the players has NOT Discs)
        public bool gameOver(CellState[,] gBoard, PlayerType player)
        {
            bool playerMoves = hasValidMoves(gBoard, player);
            List<Point> whiteDiscs = playerDiscs(gBoard, PlayerType.White);
            List<Point> blackDiscs = playerDiscs(gBoard, PlayerType.Black);
            if ((whiteDiscs.Count == 0 && blackDiscs.Count > 0) || (blackDiscs.Count == 0 && whiteDiscs.Count > 0))
                return true;
            if (!playerMoves)
            {
                return true;
            }
            return false;
        }


        //2.4.13//
        //get the winner
        public PlayerType getWinner(CellState[,] gBoard, PlayerType player)
        {
            bool playerMoves = hasValidMoves(gBoard, player);
            List<Point> whiteDiscs = playerDiscs(gBoard, PlayerType.White);
            List<Point> blackDiscs = playerDiscs(gBoard, PlayerType.Black);
            if (!playerMoves && blackDiscs.Count != 0 && whiteDiscs.Count != 0) //if there are not more moves
            {
                if (player == PlayerType.Black)
                    return PlayerType.TechnicalWhite;
                else if(player == PlayerType.White)
                    return PlayerType.TechnicalBlack;
            }
            if ((blackDiscs.Count > 0) && (whiteDiscs.Count == 0))
                return PlayerType.Black;
            return PlayerType.White;
        }


        //2.4.14//
        //get the Points of the currect player
        public int getScorePlayer(CellState[,] gBoard, PlayerType player)
        {
            int whiteScore = 0;
            int blackScore = 0;
            List<Point> whiteDiscs = playerDiscs(gBoard, PlayerType.White); //list of all the discs of the "White Player"
            List<Point> blackDiscs = playerDiscs(gBoard, PlayerType.Black); //list of all the discs of the "Black Player"
            foreach (var disc in whiteDiscs) //scan the list to get Score of the player ("Simple Disc" = 1 , "King Disc" = 2)
            {
                if (gBoard[disc.row, disc.col] == CellState.WHITE)
                    whiteScore = whiteScore + 1; //"Simple Disc" = 1
                if (gBoard[disc.row, disc.col] == CellState.WHITEKING)
                    whiteScore = whiteScore + 2; //"King Disc" = 2
            }

            foreach (var disc in blackDiscs)
            {
                if (gBoard[disc.row, disc.col] == CellState.BLACK)
                    blackScore = blackScore + 1; //"Simple Disc" = 1
                if (gBoard[disc.row, disc.col] == CellState.BLACKKING)
                    blackScore = blackScore + 2; //"King Disc" = 2
            }

            //////return the Score of the currect player//////
            if (player == PlayerType.White)
                return whiteScore;
            //if the player NOT White return the score of the Black player
            return blackScore;
        }

       

       

    }
}
