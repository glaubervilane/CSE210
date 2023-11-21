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
            // return "N";
            return "♞";
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