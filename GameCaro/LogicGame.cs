// File: GameLogic.cs
using System.Drawing;

namespace GameCaro
{
    public class GameLogic
    {
        // Dùng mảng 2D int để lưu trạng thái bàn cờ. 
        // 0: Trống(chưa có người đánh), 1: Player 1, 2: Player 2
        private int[,] gameBoard;

        public GameLogic()
        {
            // Khởi tạo mảng 2D 
            this.gameBoard = new int[Constant.CHESS_BOARD_WIDTH, Constant.CHESS_BOARD_HEIGHT];
        }

        // Xóa sạch bàn cờ (khi New Game)
        public void ClearBoard()
        {
            for (int i = 0; i < Constant.CHESS_BOARD_WIDTH; i++)
            {
                for (int j = 0; j < Constant.CHESS_BOARD_HEIGHT; j++)
                {
                    gameBoard[i, j] = 0;
                }
            }
        }

        // Đánh dấu một ô
        public void Mark(int col, int row, int playerID)
        {
            gameBoard[col, row] = playerID;
        }

        // Bỏ đánh dấu (cho Undo)
        public void UnMark(int col, int row)
        {
            gameBoard[col, row] = 0;
        }

        // Hàm kiểm tra thắng tổng quát
        public bool IsEndGame(int col, int row, int playerID)
        {
            return IsEndHorizontal(col, row, playerID) ||
                   IsEndVertical(col, row, playerID) ||
                   IsEndMainDiagonal(col, row, playerID) ||
                   IsEndAntiDiagonal(col, row, playerID);
        }

        #region Các hàm logic kiểm tra

        // Các hàm này giờ làm việc với mảng int[,] nhanh và độc lập
        private bool IsEndHorizontal(int col, int row, int playerID)
        {
            int count = 0;
            // Đếm sang trái (bao gồm ô vừa đánh)
            for (int i = col; i >= 0; i--)
            {
                if (gameBoard[i, row] == playerID) count++;
                else break;
            }
            // Đếm sang phải (không đếm lại ô vừa đánh)
            for (int i = col + 1; i < Constant.CHESS_BOARD_WIDTH; i++)
            {
                if (gameBoard[i, row] == playerID) count++;
                else break;
            }
            return count >= 5;
        }

        private bool IsEndVertical(int col, int row, int playerID)
        {
            int count = 0;
            // Đếm lên trên
            for (int i = row; i >= 0; i--)
            {
                if (gameBoard[col, i] == playerID) count++;
                else break;
            }
            // Đếm xuống dưới
            for (int i = row + 1; i < Constant.CHESS_BOARD_HEIGHT; i++)
            {
                if (gameBoard[col, i] == playerID) count++;
                else break;
            }
            return count >= 5;
        }

        // Chéo chính 
        private bool IsEndMainDiagonal(int col, int row, int playerID)
        {
            int count = 0;
            // Đếm lên trên-trái
            for (int i = 0; col - i >= 0 && row - i >= 0; i++)
            {
                if (gameBoard[col - i, row - i] == playerID) count++;
                else break;
            }
            // Đếm xuống dưới-phải
            for (int i = 1; col + i < Constant.CHESS_BOARD_WIDTH && row + i < Constant.CHESS_BOARD_HEIGHT; i++)
            {
                if (gameBoard[col + i, row + i] == playerID) count++;
                else break;
            }
            return count >= 5;
        }

        // Chéo phụ 
        private bool IsEndAntiDiagonal(int col, int row, int playerID)
        {
            int count = 0;
            // Đếm lên trên-phải
            for (int i = 0; col + i < Constant.CHESS_BOARD_WIDTH && row - i >= 0; i++)
            {
                if (gameBoard[col + i, row - i] == playerID) count++;
                else break;
            }
            // Đếm xuống dưới-trái
            for (int i = 1; col - i >= 0 && row + i < Constant.CHESS_BOARD_HEIGHT; i++)
            {
                if (gameBoard[col - i, row + i] == playerID) count++;
                else break;
            }
            return count >= 5;
        }
        #endregion
    }
}