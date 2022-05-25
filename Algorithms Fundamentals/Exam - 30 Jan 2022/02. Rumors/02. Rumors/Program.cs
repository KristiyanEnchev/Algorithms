using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Rumors
{
    class Program
    {
        private static Dictionary<int, List<int>> graph;
        private static List<string> paths;
        private static HashSet<int> visited;

        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var e = int.Parse(Console.ReadLine());

            visited = new HashSet<int>();
            paths = new List<string>();

            graph = new Dictionary<int, List<int>>();

            for (int node = 1; node < n + 1; node++)
            {
                graph[node] = new List<int>();
            }

            for (int i = 0; i < e; i++)
            {
                var connections = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToList();

                var node = connections[0];
                var to = connections[1];

                graph[node].Add(to);
            }

            var target = int.Parse(Console.ReadLine());

            GeneratePaths(n);
            ;
        }

        private static void GeneratePaths(int numberNodes)
        {
            for (int i = 1; i < numberNodes - 1; i++)
            {
                var path = new List<int>();
                AddPaths(i, path);
            }
        }

        private static void AddPaths(int start, List<int> path)
        {
            if (path.Contains(start))
            {
                return;
            }

            path.Add(start);

            foreach (var child in graph[start])
            {
                AddPaths(child, path);

                if (graph[child].Count == 0)
                {
                    paths.Add(string.Join(" ", path));
                }

                var last = path.Last();
                path.Remove(last);
            }

        }
    }
}
