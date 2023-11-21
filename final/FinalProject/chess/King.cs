using FinalProject.board;

namespace FinalProject.chess
{
    // King inherit from class Piece
    public class King : Piece
    {
        public King(Board board, Color color) : base(board, color)
        {
        }

        public override string ToString()
        {
            return "K";
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

            //Verify position on top
            pos.getValues(Position._row -1, Position._column);
            if (board.validPosition(pos) && itCanMove(pos)) 
            {
                mat[pos._row, pos._column] = true;
            }

            //Verify position NE
            pos.getValues(Position._row -1, Position._column +1);
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
            return mat;
        }
    }
}