using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Damka
{
    //properties of Cell
    public enum CellState
    {
        EMPTY,
        BLACK,
        WHITE,
        BLACKKING,
        WHITEKING,
    }

    public partial class RealTime : Form
    {
        private bool multiplayer;
        private bool enemyPlay = false;
        public static int depth;
        private bool endGame = false;
        public PlayerType turn { get; set; }
        AlphaBeta whitePlayer { get; set; }
        AlphaBeta blackPlayer { get; set; }
        Board gameBoard { get; set; }
        public Button lastClickButton { set; get; }



        public RealTime(bool multiplayer, int depthLevel)
        {
            InitializeComponent();
            depth = depthLevel;
            this.multiplayer = multiplayer;
            if (!multiplayer)
                blackPlayer = new AlphaBeta(PlayerType.Black, PlayerType.White);
            this.algorithmWorker.WorkerReportsProgress = true;
            this.algorithmWorker.DoWork += new DoWorkEventHandler(algorithmWorker_DoWork);
            this.algorithmWorker.ProgressChanged += new ProgressChangedEventHandler(algorithmWorker_ProgressChanged);
        }
        



        private void RealTime_Load(object sender, EventArgs e)
        {


            //set the currect "Turn"(Black/White)
            if (Main.blackPlayer)
                this.turn = PlayerType.Black;
            else
                this.turn = PlayerType.White;


            depth = Main.depth;

            gameBoard = new Board(turn);

            //create defult buttons(cells)
            for (int i = 0; i < tbl.RowCount; i++)
                for (int j = 0; j < tbl.ColumnCount; j++)
                {
                    Button btn = new Button(); //button = cell
                    btn.Click += new EventHandler(Btn_Click); //create "event" - what happens if the player clicks on the same button(cell)
                    btn.FlatStyle = FlatStyle.Flat; //button(cell) design
                    btn.Height = 80; //button(cell) height size
                    btn.Width = 80; //button(cell) width size
                    btn.BackgroundImageLayout = ImageLayout.Stretch;

                    //first painting board (WITHOUT Discs)
                    if ((j + i) % 2 != 0) 
                    {
                        btn.BackColor = Color.Sienna;
                    }
                    else
                        btn.BackColor = Color.SandyBrown;

                    //first painting board (WITH Discs)
                    switch (gameBoard.gBoard[i, j]) //for each cell checks which disc should be placed in the cell(black/white/empty)
                    {
                        case CellState.BLACK:
                            btn.BackgroundImage = Damka.Properties.Resources.BlackDisc;
                            break;
                        case CellState.WHITE:
                            btn.BackgroundImage = Damka.Properties.Resources.WhiteDisc;
                            break;
                        default:
                            if ((j + i) % 2 != 0)
                            {
                                btn.BackColor = Color.Sienna;
                            }
                            else
                                btn.BackColor = Color.SandyBrown;
                            break;
                    }
                    
                    tbl.Controls.Add(btn, j, i); //add the button(cell) to the "Board"(tbl)
                }

            //change the "Turn Label"(the text of the turn) to the turn of the current player
            if (gameBoard.playTurn == PlayerType.Black)
                playTurnLabel.Text = "Black player";
            if (gameBoard.playTurn == PlayerType.White)
                playTurnLabel.Text = "White player";

            //in case "Singleplayer mode" the Black player starts fisrt
            if (this.multiplayer == false && gameBoard.playTurn == PlayerType.Black)
            {   
                enemyPlay = true;
                this.algorithmWorker.RunWorkerAsync();
            }

        }

        //what happens if the player clicks on the same button(cell)
        private void Btn_Click(object sender, EventArgs e)
        {
            if (!enemyPlay)
               ClickLogic(sender);
        }


        //function that is responsible for button(cell) options
        private void ClickLogic(object sender)
        {
            Button btn = sender as Button;
            TableLayoutPanelCellPosition cellPosition = tbl.GetPositionFromControl(btn); //get the postition(row,col) of the "Now Clicked Button(cell)"

            GameMove move = new GameMove();
            move.fromCol = cellPosition.Column; //set the "From Cell(col)"
            move.fromRow = cellPosition.Row; //set the "From Cell(row)"
            CellState cell = gameBoard.gBoard[move.fromRow, move.fromCol]; //set the "From Button(cell)" to "CellState"

            if (btn.BackColor.Equals(Color.Firebrick)) //if the player already clicked on his disc that he want to move and now clicked on the "To Button(cell)" that he want to move his disc
            {
                TableLayoutPanelCellPosition fromPos = tbl.GetPositionFromControl(lastClickButton); //get the postition(row,col) of the "Last Clicked Button(cell)" / "From Button(cell)"
                //set the "Move"
                move.fromCol = fromPos.Column; //set the "From Cell(col)"
                move.fromRow = fromPos.Row; //set the "From Cell(row)"
                move.toCol = cellPosition.Column; //set the "To Cell(col)"
                move.toRow = cellPosition.Row; //set the "To Cell(row)"
                gameBoard.gBoard = gameBoard.applyMove(gameBoard.gBoard, gameBoard.playTurn, move); //apply the "Move" in "Marks"(in the class "Board" and not in "RealTime")
                repaintBoard(); //paint the Board in "RealTime"
                
                if (gameBoard.gameOver(gameBoard.gBoard, gameBoard.playTurn))
                {
                    switch (gameBoard.getWinner(gameBoard.gBoard, gameBoard.playTurn))
                    {
                        case PlayerType.White: //White win
                            MessageBox.Show("Congratulations! The WHITE player is the winner!", "Congratulations! White Victory", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        case PlayerType.Black: //Black win
                            MessageBox.Show("Congratulations! The BLACK player is the winner!", "Congratulations! Black Victory", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        case PlayerType.TechnicalBlack: //if to the White player has no more moves
                            MessageBox.Show("Congratulations! Technical BLACK player victory! (The possible moves are over to the WHITE player)", "Congratulations! Black Victory", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        case PlayerType.TechnicalWhite: //if to the Black player has no more moves
                            MessageBox.Show("Congratulations! Technical WHITE player victory! (The possible moves are over to the BLACK player)", "Congratulations! White Victory", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                    }
                    endGame = true;
                    this.Close();
                }

                //check if this turn is computer turn(Black player)
                if (this.multiplayer == false && gameBoard.playTurn == PlayerType.Black && !endGame)
                {
                    enemyPlay = true;
                    this.algorithmWorker.RunWorkerAsync();
                }

            }


            else //if the player didn't already clicked on button(cell) and now clicked on button AND there is not active/pressed buttons
            {
                if (turnValidForCell(cell, gameBoard.playTurn)) //check if the "Clicked Button(cell)/Disc" belongs to the currect player
                {
                    //set "From Button(cell)"
                    lastClickButton = btn;
                    bool wasNotJump = true;
                    repaintBoard(); //in case the player click on another button
                    List<GameMove> simpleMovesLst = gameBoard.getSimpleMoves(gameBoard.playTurn, gameBoard.gBoard);
                    List<GameMove> jumpMovesLst = gameBoard.getJumpMoves(gameBoard.playTurn, gameBoard.gBoard);


                    //----Jump----
                    if (canJump(gameBoard.playTurn, gameBoard.gBoard)) //check if the player can jump
                    {
                        foreach (var Move in jumpMovesLst)
                        {
                            if (Move.fromRow == move.fromRow && Move.fromCol == move.fromCol)
                            {
                                Button toBtn = tbl.GetControlFromPosition(Move.toCol, Move.toRow) as Button;
                                toBtn.BackColor = Color.Firebrick;
                                wasNotJump = false;
                            }
                        }

                        //check if to the player was option to jump and didn't jump
                        if (wasNotJump)
                            MessageBox.Show("Cannot make action, please eat the other player", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }



                    //----Simple----
                    else
                    {
                        foreach (var Move in simpleMovesLst)
                        {
                            if (Move.fromRow == move.fromRow && Move.fromCol == move.fromCol)
                            {
                                Button toBtn = tbl.GetControlFromPosition(Move.toCol, Move.toRow) as Button;
                                toBtn.BackColor = Color.Firebrick;
                            }
                        }
                    }



                }
                
            }
            
        }





        //paint the Board in "RealTime"
        public void repaintBoard()
        {
            //create defult buttons(cells)
            for (int i = 0; i < tbl.RowCount; i++)
                for (int j = 0; j < tbl.ColumnCount; j++)
                {
                    Button btn = tbl.GetControlFromPosition(j, i) as Button;

                    if ((j + i) % 2 != 0)
                    {
                        btn.BackColor = Color.Sienna;
                    }
                    else
                        btn.BackColor = Color.SandyBrown;


                    switch (gameBoard.gBoard[i, j]) //for each cell checks which disc should be placed in the cell(black/white/empty)
                    {
                        case CellState.BLACK:
                            btn.BackgroundImage = Damka.Properties.Resources.BlackDisc;
                            break;
                        case CellState.WHITE:
                            btn.BackgroundImage = Damka.Properties.Resources.WhiteDisc;
                            break;
                        case CellState.BLACKKING:
                            btn.BackgroundImage = Damka.Properties.Resources.KingBlackDisc;
                            break;
                        case CellState.WHITEKING:
                            btn.BackgroundImage = Damka.Properties.Resources.KingWhiteDisc;
                            break;
                        default:
                            btn.BackgroundImage = null;
                            if ((j + i) % 2 != 0)
                            {
                                btn.BackColor = Color.Sienna;
                            }
                            else
                                btn.BackColor = Color.SandyBrown;
                            break;
                    }

                    //change the "Turn Label"(the text of the turn) to the turn of the current player
                    if (gameBoard.playTurn == PlayerType.Black)
                        playTurnLabel.Text = "Black player";
                    if (gameBoard.playTurn == PlayerType.White)
                        playTurnLabel.Text = "White player";
                }
        }




        void algorithmWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            var move = e.UserState as GameMove; //the final move of your computer
            gameBoard.gBoard = gameBoard.applyMove(gameBoard.gBoard, PlayerType.Black, move);
            repaintBoard();
            if (gameBoard.gameOver(gameBoard.gBoard, gameBoard.playTurn))
            {
                switch (gameBoard.getWinner(gameBoard.gBoard, gameBoard.playTurn))
                {
                    case PlayerType.White:
                        MessageBox.Show("Congratulations! The WHITE player is the winner!", "Congratulations! White Victory", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    case PlayerType.Black:
                        MessageBox.Show("Congratulations! The BLACK player is the winner!", "Congratulations! Black Victory", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    case PlayerType.TechnicalBlack:
                        MessageBox.Show("Congratulations! Technical BLACK player victory! (The possible moves are over to the WHITE player)", "Congratulations! Black Victory", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    case PlayerType.TechnicalWhite:
                        MessageBox.Show("Congratulations! Technical WHITE player victory! (The possible moves are over to the BLACK player)", "Congratulations! White Victory", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                }
                this.Close();
            }
        }


        void algorithmWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Random rand = new Random();
            int i = rand.Next(1, 100);
            var move = enemyPlayerMakesMove(); //getting the final move of your computer
            this.algorithmWorker.ReportProgress(i, move);
            enemyPlay = false;
        }


        //check if the player clicked on his Disc
        private bool turnValidForCell(CellState cell, PlayerType turn)
        {
            if ((cell == CellState.BLACK || cell == CellState.BLACKKING) && turn == PlayerType.Black)
                return true;
            if ((cell == CellState.WHITE || cell == CellState.WHITEKING) && turn == PlayerType.White)
                return true;
            return false;
        }


        //check if the player has option to "Jump"
        public bool canJump(PlayerType player, CellState[,] gBoard)
        {
            List<GameMove> jumpMovesLst = gameBoard.getJumpMoves(player, gBoard);
            if (jumpMovesLst.Count() > 0)
            {
                return true;
            }
            return false;
        }



        //activate the AlphaBeta and geting the final computer move
        private GameMove enemyPlayerMakesMove()
        {
            GameMove move = blackPlayer.AlphaBetaMove(gameBoard, depth);
            return move;
        }









        private void MenuButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void SettingsButton_Click(object sender, EventArgs e)
        {
            
        Settings stFR = new Settings(true); //have game activated = first turn option not available
            stFR.Show();
        stFR.Invalidated += stFR_Invalidated;
        }


       
          

        private void stFR_Invalidated(object sender, InvalidateEventArgs e)
        {
            this.Show();
        }

        private void InstructionsButton_Click(object sender, EventArgs e)
        {
            About instFR = new About(false); //false = instTab
            instFR.Show();
            instFR.Invalidated += InstFR_Invalidated;
        }

        private void InstFR_Invalidated(object sender, InvalidateEventArgs e)
        {
            this.Show();
        }
    }
}
