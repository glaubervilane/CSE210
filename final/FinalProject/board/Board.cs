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

        //Encapsulation giving access to a matrix element
        public Piece piece(int row, int column)
        {
            return pieces[row, column];
        }

        public void putPiece(Piece p, Position pos)
        {
            //Put a piece in a specific position
            pieces[pos._row, pos._column] = p;
            p.Position = pos;
        }
    }
}