using FinalProject.board;
using FinalProject.chess;

namespace FinalProject
{
    public class Screen
    {

        public static void printChessGame(ChessGame chessGame)
        {
            printBoard(chessGame.board);
            Console.WriteLine();
            printCapturedPieces(chessGame);
            Console.WriteLine();
            Console.WriteLine("Turn: " + chessGame.turn);
            if (!chessGame.gameFinish)
            {
                Console.WriteLine("Waiting turn: " + chessGame.actualPlayer);
                if (chessGame.check)
                {
                    Console.WriteLine("CHECK!");
                }
            }
            else
            {
                Console.WriteLine("CHECKMATE!");
                Console.WriteLine("Winner: " + chessGame.actualPlayer);
            }
            Console.WriteLine();
        }

        public static void printCapturedPieces(ChessGame chessGame)
        {
            Console.WriteLine("Captured pieces: ");
            Console.Write("White: ");
            printSet(chessGame.capturedPieces(Color.White));
            Console.WriteLine();
            Console.Write("Black: ");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            printSet(chessGame.capturedPieces(Color.Black));
            Console.ForegroundColor = aux;
            Console.WriteLine();
        }

        public static void printSet(HashSet<Piece> set)
        {
            Console.Write("[");
            foreach (Piece x in set)
            {
                Console.Write(x + " ");
            }
            Console.Write("]");
        }
        public static void printBoard(Board board)
        {
            for (int i = 0; i < board.rows; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.columns; j++)
                {
                    printPiece(board.piece(i, j));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static void printBoard(Board board, bool[,] possiblePositions)
        {
            ConsoleColor originalBackground = Console.BackgroundColor;
            ConsoleColor updatedBackground = ConsoleColor.DarkGray;

            for (int i = 0; i < board.rows; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.columns; j++)
                {
                    if (possiblePositions[i, j])
                    {
                        Console.BackgroundColor = updatedBackground;
                    }
                    else
                    {
                        Console.BackgroundColor = originalBackground;
                    }
                    printPiece(board.piece(i, j));
                    Console.BackgroundColor = originalBackground;
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
            Console.BackgroundColor = originalBackground;
        }

        public static ChessPosition readChessPosition()
        {
            while (true) // Keep looping until valid input is provided
            {
                string s = Console.ReadLine();

                // Check if the string is long enough to extract column and row
                if (s.Length < 2)
                {
                    Console.WriteLine("Invalid input. Please enter a valid chess position.");
                    // Continue to the next iteration of the loop to prompt the user again
                    continue;
                }

                char column = s[0];

                // Attempt to parse the second character as an integer
                if (int.TryParse(s[1].ToString(), out int row))
                {
                    // Check if the row is within a valid range
                    if (row >= 1 && row <= 8)
                    {
                        return new ChessPosition(column, row);
                    }
                }

                Console.WriteLine("Invalid input. Please enter a valid chess position.");
                // Continue to the next iteration of the loop to prompt the user again
            }
        }



        public static void printPiece(Piece piece)
        {
            if (piece == null)
            {
                Console.Write("- ");
            }
            else
            {
                if (piece.color == Color.White)
                {
                    Console.Write(piece);
                }
                else
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(piece);
                    Console.ForegroundColor = aux;
                }
                Console.Write(" ");
            }
        }
    }
}