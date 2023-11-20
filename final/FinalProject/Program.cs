using System;
using FinalProject;
using FinalProject.board;

class Program
{
    static void Main(string[] args)
    {
        Board board = new Board(8, 8);

        Screen.printBoard(board);

        Console.ReadLine();
    }
}