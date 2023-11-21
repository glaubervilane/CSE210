using System;
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

            Screen.printBoard(chessGame.board);
        }
        catch (BoardException e)
        {
            Console.WriteLine(e.Message);
        }
        

        Console.ReadLine();
    }
}