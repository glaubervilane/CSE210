using System.ComponentModel.DataAnnotations.Schema;
using FinalProject.board;

namespace FinalProject.chess
{
    public class ChessGame
    {
        public Board board { get; private set; }
        public int turn { get; private set; }
        public Color actualPlayer { get; private set; }
        public bool gameFinish { get; private set; }

        public ChessGame()
        {
            board = new Board(8, 8);
            turn = 1;
            actualPlayer = Color.White;
            gameFinish = false;
            putPieces();
        }

        public void move(Position origin, Position destination)
        {
            Piece p = board.takeOffPiece(origin);
            p.incrementMovements();
            Piece capturedPiece = board.takeOffPiece(destination);
            board.putPiece(p, destination);
        }

        public void makePlay(Position origin, Position destination) 
        {
            move(origin, destination);
            turn++;
            changePlayer();
        }

        public void validateOriginPosition(Position pos) 
        { 
            if (board.piece(pos) == null )
            {
                throw new BoardException("There is no piece in the chosen origin position!");
            }
            if (actualPlayer != board.piece(pos).color)
            {
                throw new BoardException("The original piece chosen is not yours!");
            }
            if (!board.piece(pos).existPossibleMovements())
            {
                throw new BoardException("There are no movements possible for the chosen piece!");
            }
        }

        public void validateDestinationPosition(Position origin, Position destination) 
        { 
            if (!board.piece(origin).canMoveTo(destination))
            {
                throw new BoardException("Destination invalid!");
            }
        }

        private void changePlayer()
        {
            if (actualPlayer == Color.White)
            {
                actualPlayer = Color.Black;
            }
            else 
            {
                actualPlayer = Color.White;
            }
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