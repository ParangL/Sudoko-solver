using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Sudoku
{
    //tom sudokutabell
    int[,] board = new int[9, 9];

    //constructor
    public Sudoku(int[,] board)
    {
        //loop för att sätta värden i tom sudokutabell
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                this.board[i, j] = board[i, j];
            }
        }
    }

    private bool isInRow(int row, int number)
    {
        for (int i = 0; i < 9; i++)
            if (board[row, i] == number)
                return true;
        return false;
    }

    private bool isInCol(int col, int number)
    {
        for (int i = 0; i < 9; i++)
            if (board[i, col] == number)
                return true;
        return false;
    }

    private bool isInBox(int row, int col, int number)
    {
        int r = row - row % 3;
        int c = col - col % 3;
        for (int i = r; i < r + 3; i++)
            for (int j = c; j < c + 3; j++)
                if (board[i, j] == number)
                    return true;
        return false;

    }

    private bool isOk(int row, int col, int number)
    {
        return !isInRow(row, number) && !isInCol(col, number) && !isInBox(row, col, number);

    }

    public bool Solve()
    {
        for (int row = 0; row < 9; row++)
        {
            for (int col = 0; col < 9; col++)
            {
                if (board[row, col] == 0)
                {
                    for (int number = 1; number <= 9; number++)
                    {
                        if (isOk(row, col, number))
                        {
                            board[row, col] = number;

                            if (Solve())
                            {
                                return true;
                            }
                            else
                            {
                                board[row, col] = 0;
                            }
                        }
                    }
                    return false;
                }
            }
        }
        return true;

    }
    //utskrift av sudokutabell
    public void BoardAsText()
    {
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                Console.Write(" " + board[i, j]);
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }

}

class Program
{
    static void Main(string[] args)
    {
        int[,] StartingBoard = {

/* //private const string easy1
  { 0, 0, 3, 0, 2, 0, 6, 0, 0 },
  { 9, 0, 0, 3, 0, 5, 0, 0, 1 },
  { 0, 0, 1, 8, 0, 6, 4, 0, 0 },
  { 0, 0, 8, 1, 0, 2, 9, 0, 0 },
  { 7, 0, 0, 0, 0, 0, 0, 0, 8 },
  { 0, 0, 6, 7, 0, 8, 2, 0, 0 },
  { 0, 0, 2, 6, 0, 9, 5, 0, 0 },
  { 8, 0, 0, 2, 0, 3, 0, 0, 9 },
  { 0, 0, 5, 0, 1, 0, 3, 0, 0 }*/

/*//private const string easy2
{ 6, 1, 9, 0, 3, 0, 0, 4, 0 },
{ 2, 7, 0, 0, 6, 1, 0, 0, 8 },
{ 0, 0, 0, 0, 4, 7, 6, 2, 1 },
{ 4, 8, 6, 3, 0, 2, 0, 7, 9 },
{ 0, 0, 0, 0, 1, 4, 5, 8, 0 },
{ 0, 3, 1, 0, 0, 9, 0, 6, 0 },
{ 0, 0, 5, 7, 2, 0, 8, 0, 6 },
{ 3, 2, 0, 1, 0, 6, 0, 5, 7 },
{ 1, 6, 0, 4, 0, 0, 0, 3, 0 }*/

/* //private const string medium1
{ 0, 3, 7, 0, 6, 0, 0, 0, 0 },
{ 2, 0, 5, 0, 0, 0, 8, 0, 0 },
{ 0, 0, 6, 9, 0, 8, 0, 0, 0 },
{ 0, 0, 0, 6, 0, 0, 0, 2, 4 },
{ 0, 0, 1, 5, 0, 3, 6, 0, 0 },
{ 6, 5, 0, 0, 0, 9, 0, 0, 0 },
{ 0, 0, 0, 3, 0, 2, 7, 0, 0 },
{ 0, 0, 9, 0, 0, 0, 4, 0, 2 },
{ 0, 0, 0,0, 5, 0, 3, 6, 0 }*/

/*// private const string diabolic1
{ 0, 0, 0, 0, 0, 0, 0, 0, 0 },
{ 0, 0, 0, 0, 0, 3, 0, 8, 5 },
{ 0, 0, 1, 0, 2, 0, 0, 0, 0 },
{ 0, 0, 0, 5, 0, 7, 0, 0, 0 },
{ 0, 0, 4, 0, 0, 0, 1, 0, 0 },
{ 0, 9, 0, 0, 0, 0, 0, 0, 0 },
{ 5, 0, 0, 0, 0, 0, 0, 7, 3 },
{ 0, 0, 2, 0, 1, 0, 0, 0, 0 },
{ 0, 0, 0, 0, 4, 0, 0, 0, 9 }*/

/*//private const string diabolic2
{ 9, 0, 0, 0, 4, 0, 0, 0, 0 },
{ 0, 0, 0, 0, 1, 0, 2, 0, 0 },
{ 3, 7, 0, 0, 0, 0, 0, 0, 5 },
{ 0, 0, 0, 0, 0, 0, 0, 9, 0 },
{ 0, 0, 1, 0, 0, 0, 4, 0, 0 },
{ 0, 0, 0, 7, 0, 5, 0, 0, 0 },
{ 0, 0, 0, 0, 2, 0, 1, 0, 0 },
{ 5, 8, 0, 3, 0, 0, 0, 0, 0 },
{ 0, 0, 0, 0, 0, 0, 0, 0, 0 }*/

// private const string zen
{ 0, 0, 0, 0, 0, 0, 0, 0, 0 },
{ 0, 0, 0, 0, 0, 0, 0, 0, 0 },
{ 0, 0, 0, 0, 0, 0, 0, 0, 0 },
{ 0, 0, 0, 0, 0, 0, 0, 0, 0 },
{ 0, 0, 0, 0, 1, 0, 0, 0, 0 },
{ 0, 0, 0, 0, 0, 0, 0, 0, 0 },
{ 0, 0, 0, 0, 0, 0, 0, 0, 0 },
{ 0, 0, 0, 0, 0, 0, 0, 0, 0 },
{ 0, 0, 0, 0, 0, 0, 0, 0, 0 }

/* //private const string unsolvable1
 { 0, 0, 9, 0, 2, 8, 7, 0, 0 },
 { 8, 0, 6, 0, 0, 4, 0, 0, 5 },
 { 0, 0, 3, 0, 0, 0, 0, 0, 4 },
 { 6, 0, 0, 0, 0, 0, 0, 0, 0 },
 { 0, 2, 0, 7, 1, 3, 4, 5, 0 },
 { 0, 0, 0, 0, 0, 0, 0, 0, 2 },
 { 3, 0, 0, 0, 0, 0, 5, 0, 0 },
 { 9, 0, 0, 4, 0, 0, 8, 0, 7 },
 { 0, 0, 1, 2, 5, 0, 3, 0, 0 }*/

/*//private const string unsolvable2
{ 0, 9, 0, 3, 0, 0, 0, 0, 1 },
{ 0, 0, 0, 0, 8, 0, 0, 4, 6 },
{ 0, 0, 0, 0, 0, 0, 8, 0, 0 },
{ 4, 0, 5, 0, 6, 0, 0, 3, 0 },
{ 0, 0, 3, 2, 7, 5, 6, 0, 0 },
{ 0, 6, 0, 0, 1, 0, 9, 0, 4 },
{ 0, 0, 1, 0, 0, 0, 0, 0, 0 },
{ 5, 8, 0, 0, 2, 0, 0, 0, 0 },
{ 2, 0, 0, 0, 0, 7, 0, 6, 0 }*/

/*//private const string unsolvable3
{ 0, 0, 0, 0, 4, 1, 0, 0, 0 },
{ 0, 6, 0, 0, 0, 0, 0, 2, 0 },
{ 0, 0, 2, 0, 0, 0, 0, 0, 0 },
{ 3, 2, 0, 6, 0, 0, 0, 0, 0 },
{ 0, 0, 0, 0, 5, 0, 0, 4, 1 },
{ 7, 0, 0, 0, 0, 0, 0, 0, 2 },
{ 0, 0, 0, 0, 0, 0, 2, 3, 0 },
{ 0, 4, 8, 0, 0, 0, 0, 0, 0 },
{ 5, 0, 1, 0, 0, 2, 0, 0, 0 }*/

/*// private const string unsolvable4
{ 9, 0, 0, 1, 0, 0, 0, 0, 4 },
{ 0, 1, 4, 0, 3, 0, 8, 0, 0 },
{ 0, 0, 3, 0, 0, 0, 0, 9, 0 },
{ 0, 0, 0, 7, 0, 8, 0, 0, 1 },
{ 8, 0, 0, 0, 0, 3, 0, 0, 0 },
{ 0, 0, 0, 0, 0, 0, 0, 3, 0 },
{ 0, 2, 1, 0, 0, 0, 0, 7, 0 },
{ 0, 0, 9, 0, 4, 0, 5, 0, 0 },
{ 5, 0, 0, 0, 1, 6, 0, 0, 3 }*/

/*//private const string unsolvable5
{ 0, 4, 0, 1, 0, 0, 3, 5, 0 },
{ 0, 0, 0, 0, 0, 0, 0, 0, 0 },
{ 0, 0, 0, 2, 0, 5, 0, 0, 0 },
{ 0, 0, 0, 4, 0, 8, 9, 0, 0 },
{ 2, 6, 0, 0, 0, 0, 0, 1, 2 },
{ 0, 5, 0, 3, 0, 0, 0, 0, 7 },
{ 0, 0, 4, 0, 0, 0, 1, 6, 0 },
{ 6, 0, 0, 0, 0, 7, 0, 0, 0 },
{ 0, 1, 0, 0, 8, 0, 0, 2, 0 }*/

/*//easy
 { 3, 0, 5, 4, 2, 0, 8, 1, 0 },
 { 4, 8, 7, 9, 0, 1, 5, 0, 6 },
 { 0, 2, 9, 0, 5, 6, 3, 7, 4 },
 { 8, 5, 0, 7, 9, 3, 0, 4, 1 },
 { 6, 1, 3, 2, 0, 8, 9, 5, 7 },
 { 0, 7, 4, 0, 6, 5, 2, 8, 0 },
 { 2, 4, 1, 3, 0, 9, 0, 6, 5 },
 { 5, 0, 8, 6, 7, 0, 1, 9, 2 },
 { 0, 9, 6, 5, 1, 2, 4, 0, 8 }*/

/*//M
{ 0, 0, 2, 0, 3, 0, 0, 0, 8 },
{ 0, 0, 0, 0, 0, 8, 0, 0, 0 },
{ 0, 3, 1, 0, 2, 0, 0, 0, 0 },
{ 0, 6, 0, 0, 5, 0, 2, 7, 0 },
{ 0, 1, 0, 0, 0, 0, 0, 5, 0 },
{ 2, 0, 4, 0, 6, 0, 0, 3, 1 },
{ 0, 0, 0, 0, 8, 0, 6, 0, 5 },
{ 0, 0, 0, 0, 0, 0, 0, 1, 3 },
{ 0, 0, 5, 3, 1, 0, 4, 0, 0 }*/

/*//S
{ 0, 9, 0, 3, 0, 0, 0, 0, 1 },
{ 0, 0, 0, 0, 8, 0, 0, 4, 6 },
{ 0, 0, 0, 0, 0, 0, 8, 0, 0 },
{ 4, 0, 5, 0, 6, 0, 0, 3, 0 },
{ 0, 0, 3, 2, 7, 5, 6, 0, 0 },
{ 0, 6, 0, 0, 1, 0, 9, 0, 4 },
{ 0, 0, 1, 0, 0, 0, 0, 0, 0 },
{ 5, 8, 0, 0, 2, 0, 0, 0, 0 },
{ 2, 0, 0, 0, 0, 7, 0, 6, 0 }*/


};
        Sudoku game = new Sudoku(StartingBoard);
        Console.WriteLine(" Sudoku game to solve: ");
        game.BoardAsText();

        if (game.Solve())
        {
            //det bygger stegvis kandidater till lösningen och lämnar en kandidat ("backtracks") så fort det bestämmer
            //att kandidaten inte kan slutföras till en giltig lösning
            Console.WriteLine("Sudoku Grid solved with simple BT");
            game.BoardAsText();

        }
        else
            Console.WriteLine("UNsolvable!");


        Console.ReadKey();


    }
}

 


