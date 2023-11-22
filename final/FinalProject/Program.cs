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
            ChessGame chessGame = new ChessGame();

            while (!chessGame.gameFinish)
            {
                try
                {
                    Console.Clear();
                    Screen.printChessGame(chessGame);

                    Console.WriteLine();
                    Console.Write("Origin: ");
                    Position origin = Screen.readChessPosition().toPosition();
                    chessGame.validateOriginPosition(origin);

                    bool[,] possiblePositions = chessGame.board.piece(origin).possibleMovements();

                    Console.Clear();
                    Screen.printBoard(chessGame.board, possiblePositions);

                    Console.WriteLine();
                    Console.Write("Destination: ");
                    Position destination = Screen.readChessPosition().toPosition();
                    chessGame.validateDestinationPosition(origin, destination);

                    chessGame.makePlay(origin, destination);
                }
                catch (BoardException e)
                {
                    Console.WriteLine(e.Message);
                    Console.ReadLine();
                }

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