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

        public override bool[,] possibleMovements() {
            
        }
    }
}