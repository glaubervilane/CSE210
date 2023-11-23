using FinalProject.board;

namespace FinalProject.chess
{
    // Pawn inherit from class Piece
    public class Pawn : Piece
    {
        private ChessGame chessGame;
        public Pawn(Board board, Color color, ChessGame chessGame) : base(board, color)
        {
            this.chessGame = chessGame;
        }

        public override string ToString()
        {
            // return "P";
            return "♟";
        }

        private bool itCanMove(Position pos)
        {
            Piece p = board.piece(pos);
            return p == null || p.color != color;
        }

        public override bool[,] possibleMovements()
        {
            bool[,] mat = new bool[board.rows, board.columns];

            Position pos = new Position(0, 0);

            if (color == Color.White)
            {
                pos.getValues(Position._row - 1, Position._column);
                if (board.validPosition(pos) && free(pos))
                {
                    mat[pos._row, pos._column] = true;
                }
                pos.getValues(Position._row - 2, Position._column);
                Position p2 = new Position(Position._row - 1, Position._column);
                if (board.validPosition(p2) && free(p2) && board.validPosition(pos) && free(pos) && movements == 0)
                {
                    mat[pos._row, pos._column] = true;
                }
                pos.getValues(Position._row - 1, Position._column - 1);
                if (board.validPosition(pos) && enemyExist(pos))
                {
                    mat[pos._row, pos._column] = true;
                }
                pos.getValues(Position._row - 1, Position._column + 1);
                if (board.validPosition(pos) && enemyExist(pos))
                {
                    mat[pos._row, pos._column] = true;
                }

                // #special movement en passant
                if (Position._row == 4)
                {
                    Position left = new Position(Position._row, Position._column - 1);
                    if (board.validPosition(left) && enemyExist(left) && board.piece(left) == chessGame.vulnerableEnPassant)
                    {
                        mat[left._row + 1, left._column] = true;
                    }
                    Position right = new Position(Position._row, Position._column + 1);
                    if (board.validPosition(right) && enemyExist(right) && board.piece(right) == chessGame.vulnerableEnPassant)
                    {
                        mat[right._row + 1, right._column] = true;
                    }
                }
            }
            else
            {
                pos.getValues(Position._row + 1, Position._column);
                if (board.validPosition(pos) && free(pos))
                {
                    mat[pos._row, pos._column] = true;
                }
                pos.getValues(Position._row + 2, Position._column);
                Position p2 = new Position(Position._row + 1, Position._column);
                if (board.validPosition(p2) && free(p2) && board.validPosition(pos) && free(pos) && movements == 0)
                {
                    mat[pos._row, pos._column] = true;
                }
                pos.getValues(Position._row + 1, Position._column - 1);
                if (board.validPosition(pos) && enemyExist(pos))
                {
                    mat[pos._row, pos._column] = true;
                }
                pos.getValues(Position._row + 1, Position._column + 1);
                if (board.validPosition(pos) && enemyExist(pos))
                {
                    mat[pos._row, pos._column] = true;
                }

                // #Special movement en passant
                if (Position._row == 4)
                {
                    Position left = new Position(Position._row, Position._column - 1);
                    if (board.validPosition(left) && enemyExist(left) && board.piece(left) == chessGame.vulneravelEnPassant)
                    {
                        mat[left._row + 1, left._column] = true;
                    }
                    Position right = new Position(Position._row, Position._column + 1);
                    if (board.validPosition(right) && enemyExist(right) && board.piece(right) == chessGame.vulnerableEnPassant)
                    {
                        mat[right._row + 1, right._column] = true;
                    }
                }
            }

            return mat;
        }
    }
}