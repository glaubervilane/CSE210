using FinalProject.board;

namespace FinalProject.chess
{
    // Pawn inherit from class Piece
    public class Pawn : Piece
    {
        public Pawn(Board board, Color color) : base(board, color)
        {
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
            return null;
        }
    }
}