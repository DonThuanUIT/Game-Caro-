// File: Form1.cs
using System;
using System.Windows.Forms;

namespace GameCaro
{
    public partial class Form1 : Form
    {
        #region Properties
        ChessBoardManager ChessBoard;
        #endregion

        public Form1()
        {
            InitializeComponent();

            ChessBoard = new ChessBoardManager(pnlChessBoard);

            // Lắng nghe 1 event người chơi đánh hoặc end Game để start lại Thời gian: 
            ChessBoard.playerMarked += ChessBoard_PlayerMarked;
            ChessBoard.endedGame += ChessBoard_EndedGame;

            prcbCoolDown.Step = Constant.COOL_DOWN_STEP;
            prcbCoolDown.Maximum = Constant.COOL_DOWN_TIME;
            prcbCoolDown.Value = 0;
            tmCoolDown.Interval = Constant.COOL_DOWN_INTERVAL;

            NewGame();
        }

        #region Methods
        void NewGame()
        {
            picFireWorks.Visible = false;
            picFireWorks.Image = null; // ngưng load ảnh để tiết kiệm bộ nhớ !. 

            prcbCoolDown.Value = 0; // set thanh thời gian về 0. 
            tmCoolDown.Stop(); // cho nó không chạy để chờ người chơi đánh rồi mới chạy. 
            undoToolStripMenuItem.Enabled = true;
            ChessBoard.DrawChessBoard();  // vẽ lại 1 bàn cờ mới. 
        }

        void Quit()
        {
            Application.Exit();
        }

        void Undo()
        {
            ChessBoard.Undo();
        }

        void EndGame()
        {
            tmCoolDown.Stop();
            pnlChessBoard.Enabled = false; // khóa bàn cờ lại không cho đánh. 
            undoToolStripMenuItem.Enabled = false; // khóa nút Undo lại. 

            MessageBox.Show("Chúc mừng " + ChessBoard.GetCurrentPlayerInfo().Name + " đã chiến thắng!");

            try
            {
                // Lấy ảnh GIF từ Resources: 
                picFireWorks.Image = Properties.Resources.fireworks;
                picFireWorks.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải hiệu ứng pháo hoa: " + ex.Message);
            }
        }
        private void ChessBoard_PlayerMarked(object sender, EventArgs e)
        {
            // Lấy thông tin người chơi hiện tại từ BoardManager
            Player currentPlayerInfo = ChessBoard.GetCurrentPlayerInfo();

            // Form1 tự cập nhật control của mình
            txbPlayerName.Text = currentPlayerInfo.Name;
            pctbMark.Image = currentPlayerInfo.Mark;

            // Reset thanh thời gian
            tmCoolDown.Start();
            prcbCoolDown.Value = 0;
        }

        // Hàm này nhận thông báo từ BoardManager để end game: 
        private void ChessBoard_EndedGame(object sender, EventArgs e)
        {
            EndGame();
        }

        //---- Các sự kiện Click của Menu ----
        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewGame(); 
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Quit();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Undo();
        }
        // -----------------------------------------------------
        private void tmCoolDown_Tick(object sender, EventArgs e)
        {
            prcbCoolDown.PerformStep();
            if (prcbCoolDown.Value >= prcbCoolDown.Maximum)
            {
                // Dừng timer lại: 
                tmCoolDown.Stop();

                // Gọi hàm TimeOut trong ChessBoardManager: 
                ChessBoard.Timeout(); 
            }
        }
        

        // Hàm xử lý việc tắt game: 
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn thoát?", "Thông báo", MessageBoxButtons.OKCancel) != DialogResult.OK)
                e.Cancel = true;
        }

        #endregion
    }
}