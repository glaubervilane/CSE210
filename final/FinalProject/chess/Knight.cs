using FinalProject.board;

namespace FinalProject.chess
{
    // Pawn inherit from class Piece
    public class Knight : Piece
    {
        public Knight(Board board, Color color) : base(board, color)
        {
        }

        public override string ToString()
        {
            // return "♞";
            return "♞";
        }

        private bool itCanMove(Position pos)
        {
            Piece p = board.piece(pos);
            return p == null || p.color != color;
        }

        // Demonstrate polymorphism applying the method from Piece abstract class
        public override bool[,] possibleMovements()
        {
            bool[,] mat = new bool[board.rows, board.columns];

            Position pos = new Position(0, 0);

            pos.getValues(Position._row - 1, Position._column - 2);
            if (board.validPosition(pos) && itCanMove(pos))
            {
                mat[pos._row, pos._column] = true;
            }
            pos.getValues(Position._row - 2, Position._column - 1);
            if (board.validPosition(pos) && itCanMove(pos))
            {
                mat[pos._row, pos._column] = true;
            }
            pos.getValues(Position._row - 2, Position._column + 1);
            if (board.validPosition(pos) && itCanMove(pos))
            {
                mat[pos._row, pos._column] = true;
            }
            pos.getValues(Position._row - 1, Position._column + 2);
            if (board.validPosition(pos) && itCanMove(pos))
            {
                mat[pos._row, pos._column] = true;
            }
            pos.getValues(Position._row + 1, Position._column + 2);
            if (board.validPosition(pos) && itCanMove(pos))
            {
                mat[pos._row, pos._column] = true;
            }
            pos.getValues(Position._row + 2, Position._column + 1);
            if (board.validPosition(pos) && itCanMove(pos))
            {
                mat[pos._row, pos._column] = true;
            }
            pos.getValues(Position._row + 2, Position._column - 1);
            if (board.validPosition(pos) && itCanMove(pos))
            {
                mat[pos._row, pos._column] = true;
            }
            pos.getValues(Position._row + 1, Position._column - 2);
            if (board.validPosition(pos) && itCanMove(pos))
            {
                mat[pos._row, pos._column] = true;
            }

            return mat;
        }
    }
}