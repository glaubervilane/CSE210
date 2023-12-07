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

        public Piece piece(Position pos)
        {
            return pieces[pos._row, pos._column];
        }

        public bool pieceExists(Position pos)
        {
            validatePosition(pos);
            return piece(pos) != null;
        }

        //Encapsulation put pieces under the board
        public void putPiece(Piece p, Position pos)
        {
            if (pieceExists(pos))
            {
                throw new BoardException("There is already a piece in that position!");
            }
            //Put a piece in a specific position
            pieces[pos._row, pos._column] = p;
            p.Position = pos;
        }

        public Piece removePiece(Position pos)
        {
            if (piece(pos) == null)
            {
                return null;
            }
            Piece helper = piece(pos);
            helper.Position = null;
            pieces[pos._row, pos._column] = null;
            return helper;
        }

        // Check to have position inside of Matrix 8x8
        public bool validPosition(Position pos)
        {
            if (pos._row < 0 || pos._row >= rows || pos._column < 0 || pos._column >= columns)
            {
                return false;
            }
            return true;
        }

        public void validatePosition(Position pos)
        {
            if (!validPosition(pos))
            {
                throw new BoardException("Invalid Position!");
            }
        }
    }
}