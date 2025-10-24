using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameCaro
{
    public class ChessBoardManager
    {
        #region Properties 
        private Panel chessBoard;
        public Panel ChessBoard
        {
            get { return chessBoard; }
            set { chessBoard = value; }
        }
        private List<Player> players;
        private int currentPlayer; 
        public int CurrentPlayer
        {
            get { return currentPlayer;  }
            set { currentPlayer = value; }
        }
        private TextBox playerName;
        public TextBox PlayerName
        {
            get { return  playerName; }
            set { playerName = value; }
        }
        private PictureBox playerMark; 
        public PictureBox PlayerMark
        {
            get { return playerMark; }
            set { playerMark = value; }
        }
        #endregion
        private List<List<Button>> matrix; 
        #region Initialize
        public ChessBoardManager(Panel chessBoard, TextBox playerName, PictureBox mark)
        {
            this.chessBoard = chessBoard;
            this.playerName = playerName;
            this.playerMark = mark;


            this.players = new List<Player>()
            {
                new Player("Magnus Carlsen", Image.FromFile(Application.StartupPath + "\\Resources\\dauX.png")), 
                new Player("Hikaru Nakamura", Image.FromFile(Application.StartupPath + "\\Resources\\dauO.jpg"))
            };
            currentPlayer = 0;
            ChangePlayer(); 
        }
        #endregion

        #region Methods
        public void DrawChessBoard()
        {
            matrix = new List<List<Button>>(); 

            for (int i = 0; i < Constant.CHESS_BOARD_WIDTH; i++) // Số ô ngang
            {
                matrix.Add(new List<Button>()); 
                for (int j = 0; j < Constant.CHESS_BOARD_HEIGHT; j++) // Số ô dọc
                {
                    Button btn = new Button()
                    {
                        Width = Constant.CHESS_WIDTH,
                        Height = Constant.CHESS_HEIGHT,
                        // Tính toán vị trí trực tiếp từ i và j
                        Location = new Point(i * Constant.CHESS_WIDTH, j * Constant.CHESS_HEIGHT),
                        BackgroundImageLayout = ImageLayout.Stretch,
                        Tag = i.ToString()
                    }; 


                    btn.Click += Btn_Click;

                    chessBoard.Controls.Add(btn);
                    matrix[i].Add(btn); 
                }
            }
        }

        private bool isEndGame(Button btn)
        {
            return isEndHorizontal(btn) || isEndVertical(btn) || isEndMainDiagonal(btn) || isEndAntiDiagonal(btn);
        }
        private Point GetChessPoint(Button btn)
        {
            int vertical = Convert.ToInt32(btn.Tag); 
            int horizontal = matrix[vertical].IndexOf(btn);
            Point point = new Point(vertical, horizontal);
            return point; 
        }
        private bool isEndHorizontal(Button btn)
        {
            Point point = GetChessPoint(btn);
            int cntLeft = 0; 
            for(int i = point.X; i >= 0; i--)
            {
                if (matrix[i][point.Y].BackgroundImage == btn.BackgroundImage)
                {
                    cntLeft++;
                }
                else break; 
            }
            int cntRight = 0;
            for (int i = point.X+1; i < Constant.CHESS_BOARD_HEIGHT; i++)
            {
                if (matrix[i][point.Y].BackgroundImage == btn.BackgroundImage)
                {
                    cntRight++;
                }
                else break;
            }

            return cntLeft + cntRight == 5; 
        }
        private bool isEndVertical(Button btn)
        {
            Point point = GetChessPoint(btn);
            int cntTop = 0;
            for (int i = point.Y; i >= 0; i--)
            {
                if (matrix[point.X][i].BackgroundImage == btn.BackgroundImage)
                {
                    cntTop++;
                }
                else break;
            }
            int cntBottom = 0;
            for (int i = point.Y + 1; i < Constant.CHESS_BOARD_HEIGHT; i++)
            {
                if (matrix[point.X][i].BackgroundImage == btn.BackgroundImage)
                {
                    cntBottom++;
                }
                else break;
            }

            return cntTop + cntBottom == 5;
        }
        private bool isEndMainDiagonal(Button btn)
        {
            Point point = GetChessPoint(btn);
            int cntTop = 0;
            for (int i = 0; i <= Math.Min(point.X, point.Y); i++)
            {
                if (matrix[point.X - i][point.Y - i].BackgroundImage == btn.BackgroundImage)
                {
                    cntTop++;
                }
                else break;
            }
            int cntBottom = 0;
            for (int i = 1; i < Constant.CHESS_BOARD_WIDTH - Math.Max(point.X, point.Y); i++)
            {
                if (matrix[point.X + i][point.Y + i].BackgroundImage == btn.BackgroundImage)
                {
                    cntBottom++; 
                }
                else break;
            }

            return cntTop + cntBottom == 5;
        }
        private bool isEndAntiDiagonal(Button btn)
        {
            Point point = GetChessPoint(btn);
            int cntTop = 0;
            for (int i = 0; i <= Math.Min(point.X, point.Y); i++)
            {
                if (matrix[point.X - i][point.Y - i].BackgroundImage == btn.BackgroundImage)
                {
                    cntTop++;
                }
                else break;
            }
            int cntBottom = 0;
            for (int i = 1; i < Constant.CHESS_BOARD_WIDTH - Math.Max(point.X, point.Y); i++)
            {
                if (matrix[point.X + i][point.Y + i].BackgroundImage == btn.BackgroundImage)
                {
                    cntBottom++;
                }
                else break;
            }

            return cntTop + cntBottom == 5;
        }
        private void Btn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            if (btn.BackgroundImage != null) return;

            ChangeMark(btn);
            ChangePlayer();

            if (isEndGame(btn))
            {
                EndGame(); 
            }
        }
        private void EndGame()
        {
            MessageBox.Show("Kết thúc game!");
        }
        private void ChangeMark(Button btn)
        {
            btn.BackgroundImage = players[CurrentPlayer].Mark;

            CurrentPlayer = CurrentPlayer == 1 ? 0 : 1;
        }
        private void ChangePlayer()
        {
            PlayerName.Text = players[CurrentPlayer].Name;
            PlayerMark.Image = players[CurrentPlayer].Mark;
        }
        #endregion



    }
}
