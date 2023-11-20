using System.IO.Pipes;

namespace FinalProject.board
{
    public class Board
    {
        public int rows { get; set; }
        public int columns { get; set; }
        private Piece[,] pieces;
        
        public Board(int rows, int columns)
        {
            this.rows = rows;
            this.columns = columns;
            pieces = new Piece[rows, columns];
        }
    }
}