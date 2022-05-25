using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Shortest_Path
{
    class Program
    {
        private static List<int>[] graph;
        private static bool[] visited;
        private static int[] parent;

        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var e = int.Parse(Console.ReadLine());

            graph = ReadGraph(n, e);
            visited = new bool[graph.Length];
            parent = new int[graph.Length];
            Array.Fill(parent, -1);

            var start = int.Parse(Console.ReadLine());
            var destination = int.Parse(Console.ReadLine());

            BFS(start, destination);
        }

        private static void BFS(int startNode, int destination)
        {
            var queue = new Queue<int>();
            queue.Enqueue(startNode);

            visited[startNode] = true;

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                if (node == destination)
                {
                    var path = GetPath(destination);
                    Print(path);
                    break;
                }

                foreach (var child in graph[node])
                {
                    if (!visited[child])
                    {
                        parent[child] = node;
                        visited[child] = true;
                        queue.Enqueue(child);
                    }
                }
            }

        }

        private static Stack<int> GetPath(int destination)
        {
            var path = new Stack<int>();
            var index = destination;

            while (index != -1)
            {
                path.Push(index);
                index = parent[index];
            }

            return path;
        }

        private static void Print(Stack<int> path)
        {
            Console.WriteLine($"Shortest path length is: {path.Count - 1}");
            Console.WriteLine(string.Join(" ", path));
        }

        private static List<int>[] ReadGraph(int n, int e)
        {
            var result = new List<int>[n + 1];

            for (int i = 1; i < result.Length; i++)
            {
                result[i] = new List<int>();
            }

            for (int i = 0; i < e; i++)
            {
                var edge = Console.ReadLine()
                     .Split()
                     .Select(int.Parse)
                     .ToArray();

                var source = edge[0];
                var destination = edge[1];

                result[source].Add(destination);
            }

            return result;
        }
    }
}
