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

        public override bool[,] possibleMovements()
        {
            return null;
        }
    }
}