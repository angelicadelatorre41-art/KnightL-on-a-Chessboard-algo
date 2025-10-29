using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{

    /*
     * Complete the 'knightlOnAChessboard' function below.
     *
     * The function is expected to return a 2D_INTEGER_ARRAY.
     * The function accepts INTEGER n as parameter.
     */

    public static List<List<int>> knightlOnAChessboard(int n)
    {
    List<List<int>> result = new List<List<int>>();

    for (int a = 1; a < n; a++)
    {
        List<int> row = new List<int>();
        for (int b = 1; b < n; b++)
        {
            row.Add(MinMoves(n, a, b));
        }
        result.Add(row);
    }

    return result;
}

private static int MinMoves(int n, int a, int b)
{
    int[,] board = new int[n, n];
    for (int i = 0; i < n; i++)
        for (int j = 0; j < n; j++)
            board[i, j] = -1;

    int[] dx = { a, a, -a, -a, b, b, -b, -b };
    int[] dy = { b, -b, b, -b, a, -a, a, -a };

    Queue<(int x, int y)> queue = new Queue<(int x, int y)>();
    queue.Enqueue((0, 0));
    board[0, 0] = 0;

    while (queue.Count > 0)
    {
        var (x, y) = queue.Dequeue();
        for (int i = 0; i < 8; i++)
        {
            int nx = x + dx[i];
            int ny = y + dy[i];

            if (nx >= 0 && ny >= 0 && nx < n && ny < n && board[nx, ny] == -1)
            {
                board[nx, ny] = board[x, y] + 1;
                queue.Enqueue((nx, ny));
            }
        }
    }

    return board[n - 1, n - 1];
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<List<int>> result = Result.knightlOnAChessboard(n);

        textWriter.WriteLine(String.Join("\n", result.Select(x => String.Join(" ", x))));

        textWriter.Flush();
        textWriter.Close();
    }
}
