using System;
using System.Reflection.Metadata;
using FinalProject;
using FinalProject.board;
using FinalProject.chess;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            ChessGame chessGame =  new ChessGame();

            while (!chessGame.gameFinish) 
            {
                Console.Clear();
                Screen.printBoard(chessGame.board);

                Console.WriteLine();
                Console.Write("Origin: ");
                Position origin = Screen.readChessPosition().toPosition();

                bool[,] possiblePositions = chessGame.board.piece(origin).possibleMovements();

                Console.Clear();
                Screen.printBoard(chessGame.board, possiblePositions);

                Console.WriteLine();
                Console.Write("Destination: ");
                Position destination = Screen.readChessPosition().toPosition();

                chessGame.move(origin, destination);
            }

            Screen.printBoard(chessGame.board);
        }
        catch (BoardException e)
        {
            Console.WriteLine(e.Message);
        }
        

        Console.ReadLine();
    }
}