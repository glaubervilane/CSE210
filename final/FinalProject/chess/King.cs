using FinalProject.board;

namespace FinalProject.chess
{
    // King inherit from class Piece
    public class King : Piece
    {
        private ChessGame chessGame;
        public King(Board board, Color color, ChessGame chessGame) : base(board, color)
        {
            this.chessGame = chessGame;
        }

        public override string ToString()
        {
            // return "K";
            return "♚";
        }

        private bool itCanMove(Position pos)
        {
            Piece p = board.piece(pos);
            return p == null || p.color != color;
        }

        // Encapsulation applied
        private bool testRookToCastle(Position pos)
        {
            Piece p = board.piece(pos);
            return p != null && p is Rook && p.color == color && p.movements == 0;
        }

        // Demonstrate polymorphism applying the method from Piece abstract class
        public override bool[,] possibleMovements()
        {
            bool[,] mat = new bool[board.rows, board.columns];

            Position pos = new Position(0, 0);

            //Verify position on top
            pos.getValues(Position._row - 1, Position._column);
            if (board.validPosition(pos) && itCanMove(pos))
            {
                mat[pos._row, pos._column] = true;
            }

            //Verify position NE
            pos.getValues(Position._row - 1, Position._column + 1);
            if (board.validPosition(pos) && itCanMove(pos))
            {
                mat[pos._row, pos._column] = true;
            }

            //Verify position right
            pos.getValues(Position._row, Position._column + 1);
            if (board.validPosition(pos) && itCanMove(pos))
            {
                mat[pos._row, pos._column] = true;
            }

            //Verify position SE
            pos.getValues(Position._row + 1, Position._column + 1);
            if (board.validPosition(pos) && itCanMove(pos))
            {
                mat[pos._row, pos._column] = true;
            }

            //Verify position bottom
            pos.getValues(Position._row + 1, Position._column);
            if (board.validPosition(pos) && itCanMove(pos))
            {
                mat[pos._row, pos._column] = true;
            }

            //Verify position SW
            pos.getValues(Position._row + 1, Position._column - 1);
            if (board.validPosition(pos) && itCanMove(pos))
            {
                mat[pos._row, pos._column] = true;
            }

            //Verify position Left
            pos.getValues(Position._row, Position._column - 1);
            if (board.validPosition(pos) && itCanMove(pos))
            {
                mat[pos._row, pos._column] = true;
            }

            //Verify position NW
            pos.getValues(Position._row - 1, Position._column - 1);
            if (board.validPosition(pos) && itCanMove(pos))
            {
                mat[pos._row, pos._column] = true;
            }

            // #special turn castle
            if (movements == 0 && !chessGame.check)
            {
                // #special turn litle castle
                Position posT1 = new Position(Position._row, Position._column + 3);
                if (testRookToCastle(posT1))
                {
                    Position p1 = new Position(Position._row, Position._column + 1);
                    Position p2 = new Position(Position._row, Position._column + 2);
                    if (board.piece(p1) == null && board.piece(p2) == null)
                    {
                        mat[Position._row, Position._column + 2] = true;
                    }
                }
                // #special turn big castle
                Position posT2 = new Position(Position._row, Position._column - 4);
                if (testRookToCastle(posT2))
                {
                    Position p1 = new Position(Position._row, Position._column - 1);
                    Position p2 = new Position(Position._row, Position._column - 2);
                    Position p3 = new Position(Position._row, Position._column - 3);
                    if (board.piece(p1) == null && board.piece(p2) == null && board.piece(p3) == null)
                    {
                        mat[Position._row, Position._column - 2] = true;
                    }
                }
            }
            return mat;
        }
    }
}