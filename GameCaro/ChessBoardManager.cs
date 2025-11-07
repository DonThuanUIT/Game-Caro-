// File: ChessBoardManager.cs
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace GameCaro
{
    public class ChessBoardManager
    {
        #region Properties
        private Panel chessBoard;
        private List<Player> players;
        private int currentPlayer; // 0 hoặc 1 đại diện cho 2 player. 
        private List<List<Button>> matrix;
        private Stack<PlayInfor> playTimeLine; // Lưu lại các vị trí đã đánh. 

        // Logic của game: 
        private GameLogic logic;

        // Các sự kiện để "báo" cho Form1
        public event EventHandler playerMarked;
        public event EventHandler endedGame;
        #endregion

        #region Initialize
        // Constructor: 
        public ChessBoardManager(Panel chessBoard)
        {
            this.chessBoard = chessBoard;
            this.logic = new GameLogic(); 

            this.players = new List<Player>()
            {
                new Player("Magnus Carlsen", Image.FromFile(Application.StartupPath + "\\Resources\\dauX.png")),
                new Player("Hikaru Nakamura", Image.FromFile(Application.StartupPath + "\\Resources\\dauO.jpg"))
            };
        }
        #endregion

        #region Methods
        public void DrawChessBoard() // vẽ Bảng để chơi: 
        {
            chessBoard.Enabled = true;
            chessBoard.Controls.Clear();

            logic.ClearBoard(); // trước tiên phải đảm bảo bảng trống chưa có người đánh. 
            playTimeLine = new Stack<PlayInfor>(); // khởi tạo stack lưu các vị trí đã đánh. 
            currentPlayer = 0; // Set người chơi đầu tiên. 

            // Báo cho Form1 cập nhật UI cho người chơi đầu tiên
            FirePlayerMarkedEvent();

            matrix = new List<List<Button>>();
            for (int i = 0; i < Constant.CHESS_BOARD_WIDTH; i++)
            {
                matrix.Add(new List<Button>());
                for (int j = 0; j < Constant.CHESS_BOARD_HEIGHT; j++)
                {
                    Button btn = new Button()
                    {
                        Width = Constant.CHESS_WIDTH,
                        Height = Constant.CHESS_HEIGHT,
                        Location = new Point(i * Constant.CHESS_WIDTH, j * Constant.CHESS_HEIGHT),
                        BackgroundImageLayout = ImageLayout.Stretch,

                        Tag = new Point(i, j) // gắn tọa độ logic (hàng i, cột j) vào chính button này luôn. 
                    };

                    btn.Click += Btn_Click; // Gắn hàm Btn_Click vào sự kiện Click của nút này. 
                    chessBoard.Controls.Add(btn);
                    matrix[i].Add(btn);
                }
            }
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn.BackgroundImage != null) return;

            // Lấy tọa độ từ Tag (đã lưu ở hàm DrawChessBoard)
            Point point = (Point)btn.Tag;

            // 1. Đặt quân cờ (cập nhật UI)
            btn.BackgroundImage = players[currentPlayer].Mark;

            // 2. Cập nhật "bộ não" logic
            // (currentPlayer + 1) để lưu 1 (Player 1) hoặc 2 (Player 2)
            logic.Mark(point.X, point.Y, currentPlayer + 1);

            // 3. Lưu vào Stack để Undo
            playTimeLine.Push(new PlayInfor(point, currentPlayer));

            // 4. Kiểm tra thắng. 
            if (logic.IsEndGame(point.X, point.Y, currentPlayer + 1))
            {
                EndGame();
            }
            else // 5. Nếu chưa thắng thì đổi người
            {
                currentPlayer = currentPlayer == 1 ? 0 : 1;
                // Báo cho Form1 biết để cập nhật TextBox, PictureBox
                FirePlayerMarkedEvent();
            }
        }

        public void EndGame()
        {
            chessBoard.Enabled = false; // Vô hiệu hóa bàn cờ để người chơi không đánh nữa. 
            // Báo cho Form1 biết game đã kết thúc
            if (endedGame != null)
                endedGame(this, new EventArgs());
        }

        public void Timeout()
        {
            // Đảo người chơi, người chơi hiện tại hết giờ, người còn lại thắng: 
            currentPlayer = (currentPlayer == 0) ? 1 : 0;

            // Bây giờ end game với trường hợp người chơi hết giờ. 
            EndGame(); 
        }
        public bool Undo()
        {
            if (playTimeLine.Count <= 0) return false;

            PlayInfor oldMove = playTimeLine.Pop();
            Point point = oldMove.Point;

            // 1. Bỏ đánh dấu trên matrix trong logic game. 
            logic.UnMark(point.X, point.Y);

            // 2. Xóa hình trên UI
            Button btn = matrix[point.X][point.Y];
            btn.BackgroundImage = null;

            // 3. Khôi phục lượt của người chơi vừa Undo
            currentPlayer = oldMove.CurrentPlayer;

            // 4. Báo cho Form1 cập nhật lại UI
            FirePlayerMarkedEvent();

            // Kích hoạt lại bàn cờ nếu nó đã bị khóa
            chessBoard.Enabled = true;

            return true;
        }

        
        private void FirePlayerMarkedEvent()
        {
            if (playerMarked != null)
                playerMarked(this, new EventArgs());
        }

        // Cung cấp thông tin người chơi hiện tại cho Form1
        public Player GetCurrentPlayerInfo()
        {
            return players[currentPlayer];
        }

       
        #endregion
    }
}