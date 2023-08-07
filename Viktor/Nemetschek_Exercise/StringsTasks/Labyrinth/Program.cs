using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;



class Program
{
    static void Main()
    {
        string resourceName = "./Problem.in";
        string outputFilePath = "Problem.out";

        string input;
        using (Stream stream = File.OpenRead(resourceName))
        {
            if (stream == null)
            {
                Console.WriteLine("Input resource not found. Make sure to set the correct namespace and file name.");
                return;
            }



            using (StreamReader reader = new StreamReader(stream))
            {
                input = reader.ReadToEnd();
            }
        }

        string[] lines = input.Split('\n');
        int n = int.Parse(lines[0]);
        char[,] maze = new char[n, n];
        int startX = -1, startY = -1;



        for (int i = 0; i < n; i++)
        {
            string line = lines[i + 1];
            for (int j = 0; j < n; j++)
            {
                maze[i, j] = line[j];
                if (line[j] == '*')
                {
                    startX = i;
                    startY = j;
                }
            }
        }



        int minSteps = FindMinSteps(maze, startX, startY) + 1;
        File.WriteAllText(outputFilePath, minSteps.ToString());
    }



    static int FindMinSteps(char[,] maze, int startX, int startY)
    {
        int n = maze.GetLength(0);
        int[] dx = { -1, 1, 0, 0 };
        int[] dy = { 0, 0, -1, 1 };



        Queue<(int, int, int)> queue = new Queue<(int, int, int)>();
        bool[,] visited = new bool[n, n];



        queue.Enqueue((startX, startY, 0));
        visited[startX, startY] = true;



        while (queue.Count > 0)
        {
            (int x, int y, int steps) = queue.Dequeue();



            if (maze[x, y] == 'x') continue;
            if (x == 0 || x == n - 1 || y == 0 || y == n - 1) return steps++;



            for (int i = 0; i < 4; i++)
            {
                int nx = x + dx[i];
                int ny = y + dy[i];



                if (nx >= 0 && nx < n && ny >= 0 && ny < n && !visited[nx, ny])
                {
                    queue.Enqueue((nx, ny, steps + 1));
                    visited[nx, ny] = true;
                }
            }
        }



        return -1;
    }
}