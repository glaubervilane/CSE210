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
    }
}