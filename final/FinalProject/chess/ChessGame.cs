using System.Collections.Generic;
using FinalProject.board;

namespace FinalProject.chess
{
    //Encapsulation applied in the ChessGame class through the use of private fields with public getters/setters
    public class ChessGame
    {
        public Board board { get; private set; }
        public int turn { get; private set; }
        public Color actualPlayer { get; private set; }
        public bool gameFinish { get; private set; }
        public HashSet<Piece> pieces { get; set; }
        public HashSet<Piece> captured { get; set; }
        public bool check { get; private set; }

        public ChessGame()
        {
            board = new Board(8, 8);
            turn = 1;
            actualPlayer = Color.White;
            gameFinish = false;
            check = false;
            pieces = new HashSet<Piece>();
            captured = new HashSet<Piece>();
            putPieces();
        }

        public Piece move(Position origin, Position destination)
        {
            Piece p = board.takeOffPiece(origin);
            p.incrementMovements();
            Piece capturedPiece = board.takeOffPiece(destination);
            board.putPiece(p, destination);
            if (capturedPiece != null)
            {
                captured.Add(capturedPiece);
            }

            // #special movement little castle
            if (p is King && destination._column == origin._column + 2)
            {
                Position originR = new Position(origin._row, origin._column + 3);
                Position destinationR = new Position(origin._row, origin._column + 1);
                Piece R = board.takeOffPiece(originR);
                R.incrementMovements();
                board.putPiece(R, destinationR);
            }

            // #special movement big castle
            if (p is King && destination._column == origin._column - 2)
            {
                Position originR = new Position(origin._row, origin._column - 4);
                Position destinationR = new Position(origin._row, origin._column - 1);
                Piece R = board.takeOffPiece(originR);
                R.incrementMovements();
                board.putPiece(R, destinationR);
            }

            // #special movement en passant
            if (p is Pawn)
            {
                if (origin._column != destination._column && capturedPiece == null)
                {
                    Position posP;
                    if (p.color == Color.White)
                    {
                        posP = new Position(destination._row + 1, destination._column);
                    }
                    else
                    {
                        posP = new Position(destination._row - 1, destination._column);
                    }
                    capturedPiece = board.takeOffPiece(posP);
                    captured.Add(capturedPiece);
                }
            }
            return capturedPiece;
        }

        public void undoMove(Position origin, Position destination, Piece capturedPiece)
        {
            Piece p = board.takeOffPiece(destination);
            p.decrementMovements();
            board.putPiece(p, destination);
            if (capturedPiece != null)
            {
                board.putPiece(capturedPiece, destination);
                captured.Remove(capturedPiece);
            }
            board.putPiece(p, origin);
        }

        public void makePlay(Position origin, Position destination)
        {
            Piece capturedPiece = move(origin, destination);

            if (isInCheck(actualPlayer))
            {
                undoMove(origin, destination, capturedPiece);
                throw new BoardException("You can't put yourself in check");
            }

            if (isInCheck(enemy(actualPlayer)))
            {
                check = true;
            }
            else
            {
                check = false;
            }

            if (testCheckMate(enemy(actualPlayer)))
            {
                gameFinish = true;
            }
            else
            {
                turn++;
                changePlayer();
            }
        }

        public void validateOriginPosition(Position pos)
        {
            if (board.piece(pos) == null)
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

        public HashSet<Piece> capturedPieces(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in captured)
            {
                if (x.color == color)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }

        public HashSet<Piece> onGamePieces(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in pieces)
            {
                if (x.color == color)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(capturedPieces(color));
            return aux;
        }

        private Color enemy(Color color)
        {
            if (color == Color.White)
            {
                return Color.Black;
            }
            else
            {
                return Color.White;
            }
        }

        private Piece king(Color color)
        {
            foreach (Piece x in onGamePieces(color))
            {
                if (x is King)
                {
                    return x;
                }
            }
            return null;
        }

        public bool isInCheck(Color color)
        {
            Piece K = king(color);
            if (K == null)
            {
                throw new BoardException("There is no King on board!");
            }

            foreach (Piece x in onGamePieces(enemy(color)))
            {
                bool[,] mat = x.possibleMovements();
                if (mat[K.Position._row, K.Position._column])
                {
                    return true;
                }
            }
            return false;
        }

        public bool testCheckMate(Color color)
        {
            if (!isInCheck(color))
            {
                return false;
            }
            foreach (Piece x in onGamePieces(color))
            {
                bool[,] mat = x.possibleMovements();
                for (int i = 0; 1 < board.rows; i++)
                {
                    for (int j = 0; j < board.rows; j++)
                    {
                        if (mat[i, j])
                        {
                            Position origin = x.Position;
                            Position destination = new Position(i, j);
                            Piece capturedPiece = move(origin, destination);
                            bool testCheck = isInCheck(color);
                            undoMove(origin, destination, capturedPiece);
                            if (!testCheck)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }

        public void putNewPiece(char column, int _row, Piece piece)
        {
            board.putPiece(piece, new ChessPosition(column, _row).toPosition());
            pieces.Add(piece);
        }
        private void putPieces()
        {
            putNewPiece('a', 1, new Rook(board, Color.White));
            putNewPiece('b', 1, new Knight(board, Color.White));
            putNewPiece('c', 1, new Bishop(board, Color.White));
            putNewPiece('d', 1, new Queen(board, Color.White));
            putNewPiece('e', 1, new King(board, Color.White, this));
            putNewPiece('f', 1, new Bishop(board, Color.White));
            putNewPiece('g', 1, new Knight(board, Color.White));
            putNewPiece('h', 1, new Rook(board, Color.White));
            putNewPiece('a', 2, new Pawn(board, Color.White, this));
            putNewPiece('b', 2, new Pawn(board, Color.White, this));
            putNewPiece('c', 2, new Pawn(board, Color.White, this));
            putNewPiece('d', 2, new Pawn(board, Color.White, this));
            putNewPiece('e', 2, new Pawn(board, Color.White, this));
            putNewPiece('f', 2, new Pawn(board, Color.White, this));
            putNewPiece('g', 2, new Pawn(board, Color.White, this));
            putNewPiece('h', 2, new Pawn(board, Color.White, this));

            putNewPiece('a', 8, new Rook(board, Color.Black));
            putNewPiece('b', 8, new Knight(board, Color.Black));
            putNewPiece('c', 8, new Bishop(board, Color.Black));
            putNewPiece('d', 8, new Queen(board, Color.Black));
            putNewPiece('e', 8, new King(board, Color.Black, this));
            putNewPiece('f', 8, new Bishop(board, Color.Black));
            putNewPiece('g', 8, new Knight(board, Color.Black));
            putNewPiece('h', 8, new Rook(board, Color.Black));
            putNewPiece('a', 7, new Pawn(board, Color.Black, this));
            putNewPiece('b', 7, new Pawn(board, Color.Black, this));
            putNewPiece('c', 7, new Pawn(board, Color.Black, this));
            putNewPiece('d', 7, new Pawn(board, Color.Black, this));
            putNewPiece('e', 7, new Pawn(board, Color.Black, this));
            putNewPiece('f', 7, new Pawn(board, Color.Black, this));
            putNewPiece('g', 7, new Pawn(board, Color.Black, this));
            putNewPiece('h', 7, new Pawn(board, Color.Black, this));
        }
    }
}