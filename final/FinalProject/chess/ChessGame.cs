using FinalProject.board;

namespace FinalProject.chess
{
    public class ChessGame
    {
        public Board board { get; private set; }
        private int turn;
        private Color actualPlayer;

        public ChessGame()
        {
            board = new Board(8, 8);
            turn = 1;
            actualPlayer = Color.White;
            putPieces();
        }

        public void move(Position origin, Position destination)
        {
            Piece p = board.takeOffPiece(origin);
            p.incrementMovements();
            Piece capturedPiece = board.takeOffPiece(destination);
            board.putPiece(p, destination);
        }

        private void putPieces() 
        {
            board.putPiece(new Rook(board, Color.White), new ChessPosition('c',1).toPosition());
            board.putPiece(new Rook(board, Color.White), new ChessPosition('c',2).toPosition());
            board.putPiece(new Rook(board, Color.White), new ChessPosition('d',2).toPosition());
            board.putPiece(new Rook(board, Color.White), new ChessPosition('e',1).toPosition());
            board.putPiece(new Rook(board, Color.White), new ChessPosition('e',2).toPosition());
            board.putPiece(new King(board, Color.White), new ChessPosition('d',1).toPosition());

            board.putPiece(new Rook(board, Color.Black), new ChessPosition('c',7).toPosition());
            board.putPiece(new Rook(board, Color.Black), new ChessPosition('c',8).toPosition());
            board.putPiece(new Rook(board, Color.Black), new ChessPosition('d',7).toPosition());
            board.putPiece(new Rook(board, Color.Black), new ChessPosition('e',7).toPosition());
            board.putPiece(new Rook(board, Color.Black), new ChessPosition('e',8).toPosition());
            board.putPiece(new King(board, Color.Black), new ChessPosition('d',8).toPosition());
        }
    }
}