using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Path_Finder
{
    class Program
    {
        private static Dictionary<int, List<int>> graph;
        static void Main(string[] args)
        {
            var nodes = int.Parse(Console.ReadLine());
            graph = ReadGraph(nodes);

            var pathsToCheck = int.Parse(Console.ReadLine());

            CheckPaths(pathsToCheck);
        }

        private static void CheckPaths(int pathsToCheck)
        {
            for (int i = 0; i < pathsToCheck; i++)
            {
                var path = Console.ReadLine().Split().Select(int.Parse).ToList();

                if (BFS(path[0], path[path.Count - 1], path, 0))
                {
                    Console.WriteLine("yes");
                    continue;
                }
                Console.WriteLine("no");
            }
        }

        private static bool BFS(int start, int destination, List<int> path, int index)
        {
            var queue = new Queue<int>();
            queue.Enqueue(start);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                if (graph[node].Contains(path[index + 1]))
                {
                    queue.Enqueue(path[index + 1]);

                    if (path[index + 1] == destination)
                    {
                        return true;
                    }

                    index++;
                }
            }

            return false;
        }

        private static Dictionary<int, List<int>> ReadGraph(int nodes)
        {
            graph = new Dictionary<int, List<int>>();

            for (int node = 0; node < nodes; node++)
            {
                var line = Console.ReadLine();

                if (!graph.ContainsKey(node))
                {
                    graph[node] = new List<int>();
                }

                if (!string.IsNullOrEmpty(line))
                {
                    var children = line.Split().Select(int.Parse).ToList();
                    graph[node] = children;
                }
            }

            return graph;
        }
    }
}
