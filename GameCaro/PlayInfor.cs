//PlayInfor: Lớp này dùng cho việc Undo!. 
using System.Drawing;

namespace GameCaro
{
    public class PlayInfor
    {
        private Point point; 
        public Point Point
            { get { return point; } set { point = value; } }

        private int currentPlayer; 
        public int CurrentPlayer
            { get { return currentPlayer; } set { currentPlayer = value; } }

        public PlayInfor(Point point, int currentPlayer)
        {
            this.point = point; 
            this.currentPlayer = currentPlayer;
        }
    }
}
