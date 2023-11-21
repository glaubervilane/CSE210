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
            return "R";
        }
    }
}