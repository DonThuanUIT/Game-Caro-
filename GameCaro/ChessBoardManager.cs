using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameCaro
{
    public class ChessBoardManager
    {
        #region Properties 
        private Panel chessBoard;
        #endregion

        #region Initialize
        public ChessBoardManager(Panel chessBoard)
        {
            this.chessBoard = chessBoard;
        }
        #endregion

        #region Methods
        public void DrawChessBoard()
        {
            for (int i = 0; i < Constant.CHESS_BOARD_WIDTH; i++) // Số ô ngang
            {
                for (int j = 0; j < Constant.CHESS_BOARD_HEGHT; j++) // Số ô dọc
                {
                    Button btn = new Button()
                    {
                        Width = Constant.CHESS_WIDTH,
                        Height = Constant.CHESS_HEIGHT,
                        // Tính toán vị trí trực tiếp từ i và j
                        Location = new Point(i * Constant.CHESS_WIDTH, j * Constant.CHESS_HEIGHT),
                    };

                    chessBoard.Controls.Add(btn);
                }
            }
        }
        #endregion



    }
}
