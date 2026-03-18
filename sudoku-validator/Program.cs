using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int[][] sudoku = {
            new int[] {7,8,4, 1,5,9, 3,2,6},
            new int[] {5,3,9, 6,7,2, 8,4,1},
            new int[] {6,1,2, 4,3,8, 7,5,9},
            new int[] {9,2,8, 7,1,5, 4,6,3},
            new int[] {3,5,7, 8,4,6, 1,9,2},
            new int[] {4,6,1, 9,2,3, 5,8,7},
            new int[] {8,7,6, 3,9,4, 2,1,5},
            new int[] {2,4,3, 5,6,1, 9,7,8},
            new int[] {1,9,5, 2,8,7, 6,3,4}
        };

        Console.WriteLine(IsValidSudoku(sudoku));
    }

    static bool IsValidSudoku(int[][] sudoku)
    {
        
        if (!IsValidStructure(sudoku))
            return false;

        int N = sudoku.Length;

        return CheckRows(sudoku, N)
            && CheckColumns(sudoku, N)
            && CheckBoxes(sudoku, N);
    }

   
    static bool IsValidStructure(int[][] sudoku)
    {
        if (sudoku == null || sudoku.Length == 0)
            return false;

        int N = sudoku.Length;

        
        int sqrt = (int)Math.Sqrt(N);
        if (sqrt * sqrt != N)
            return false;

        foreach (var row in sudoku)
        {
            if (row == null || row.Length != N)
                return false;
        }

        return true;
    }

    static bool CheckRows(int[][] sudoku, int N)
    {
        for (int i = 0; i < N; i++)
        {
            var seen = new HashSet<int>();

            for (int j = 0; j < N; j++)
            {
                int num = sudoku[i][j];

                if (num < 1 || num > N || !seen.Add(num))
                    return false;
            }
        }

        return true;
    }

  
    static bool CheckColumns(int[][] sudoku, int N)
    {
        for (int j = 0; j < N; j++)
        {
            var seen = new HashSet<int>();

            for (int i = 0; i < N; i++)
            {
                int num = sudoku[i][j];

                if (num < 1 || num > N || !seen.Add(num))
                    return false;
            }
        }

        return true;
    }

    static bool CheckBoxes(int[][] sudoku, int N)
    {
        int boxSize = (int)Math.Sqrt(N);

        for (int row = 0; row < N; row += boxSize)
        {
            for (int col = 0; col < N; col += boxSize)
            {
                var seen = new HashSet<int>();

                for (int i = 0; i < boxSize; i++)
                {
                    for (int j = 0; j < boxSize; j++)
                    {
                        int num = sudoku[row + i][col + j];

                        if (num < 1 || num > N || !seen.Add(num))
                            return false;
                    }
                }
            }
        }

        return true;
    }
}