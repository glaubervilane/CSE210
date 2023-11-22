using FinalProject.board;

namespace FinalProject.chess
{
    // Pawn inherit from class Piece
    public class Queen : Piece
    {
        public Queen(Board board, Color color) : base(board, color)
        {
        }

        public override string ToString()
        {
            // return "Q";
            return "♛";
        }

        private bool itCanMove(Position pos) 
        {
            Piece p = board.piece(pos);
            return p == null || p.color != color;
        }

        public override bool[,] possibleMovements() {
            bool[,] mat = new bool[board.rows, board.columns];

            Position pos = new Position(0, 0);

            // Laft
            pos.getValues(Position._row, Position._column - 1);
            while (board.validPosition(pos) && itCanMove(pos)) {
                mat[pos._row, pos._column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color) {
                    break;
                }
                pos.getValues(pos._row, pos._column - 1);
            }

            // Right
            pos.getValues(Position._row, Position._column + 1);
            while (board.validPosition(pos) && itCanMove(pos)) {
                mat[pos._row, pos._column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color) {
                    break;
                }
                pos.getValues(pos._row, pos._column + 1);
            }

            // Top
            pos.getValues(Position._row - 1, Position._column);
            while (board.validPosition(pos) && itCanMove(pos)) {
                mat[pos._row, pos._column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color) {
                    break;
                }
                pos.getValues(pos._row - 1, pos._column);
            }

            // Bottom
            pos.getValues(Position._row + 1, Position._column);
            while (board.validPosition(pos) && itCanMove(pos)) {
                mat[pos._row, pos._column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color) {
                    break;
                }
                pos.getValues(pos._row + 1, pos._column);
            }

            // NW
            pos.getValues(Position._row - 1, Position._column - 1);
            while (board.validPosition(pos) && itCanMove(pos)) {
                mat[pos._row, pos._column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color) {
                    break;
                }
                pos.getValues(pos._row - 1, pos._column - 1);
            }

            // NE
            pos.getValues(Position._row - 1, Position._column + 1);
            while (board.validPosition(pos) && itCanMove(pos)) {
                mat[pos._row, pos._column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color) {
                    break;
                }
                pos.getValues(pos._row - 1, pos._column + 1);
            }

            // SE
            pos.getValues(Position._row + 1, Position._column + 1);
            while (board.validPosition(pos) && itCanMove(pos)) {
                mat[pos._row, pos._column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color) {
                    break;
                }
                pos.getValues(pos._row + 1, pos._column + 1);
            }

            // SW
            pos.getValues(Position._row + 1, Position._column - 1);
            while (board.validPosition(pos) && itCanMove(pos)) {
                mat[pos._row, pos._column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color) {
                    break;
                }
                pos.getValues(pos._row + 1, pos._column - 1);
            }

            return mat;
        }
    }
}