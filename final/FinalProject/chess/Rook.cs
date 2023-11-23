using FinalProject.board;

namespace FinalProject.chess
{
    // Rook inherit from class Piece
    public class Rook : Piece
    {
        public Rook(Board board, Color color) : base(board, color)
        {
        }

        public override string ToString()
        {
            // return "R";
            return "♜";
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

            //Verify position on top
            pos.getValues(Position._row - 1, Position._column);
            while (board.validPosition(pos) && itCanMove(pos))
            {
                mat[pos._row, pos._column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color)
                {
                    break;
                }
                pos._row = pos._row - 1;
            }

            // Verify position on bottom
            pos.getValues(Position._row + 1, Position._column);
            while (board.validPosition(pos) && itCanMove(pos))
            {
                mat[pos._row, pos._column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color)
                {
                    break;
                }
                pos._row = pos._row + 1;
            }

            // Verify position on right
            pos.getValues(Position._row, Position._column + 1);
            while (board.validPosition(pos) && itCanMove(pos))
            {
                mat[pos._row, pos._column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color)
                {
                    break;
                }
                pos._column = pos._column + 1;
            }

            // Verify position on left
            pos.getValues(Position._row, Position._column - 1);
            while (board.validPosition(pos) && itCanMove(pos))
            {
                mat[pos._row, pos._column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color)
                {
                    break;
                }
                pos._column = pos._column - 1;
            }

            return mat;
        }
    }
}