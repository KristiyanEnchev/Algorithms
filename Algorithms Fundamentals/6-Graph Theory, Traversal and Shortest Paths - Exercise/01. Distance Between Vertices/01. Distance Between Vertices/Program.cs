using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Distance_Between_Vertices
{
    class Program
    {
        private static Dictionary<int, List<int>> graph;

        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var e = int.Parse(Console.ReadLine());

            graph = ReadGraph(n);

            for (int i = 0; i < e; i++)
            {
                var pair = Console.ReadLine()
                    .Split("-", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                var start = pair[0];
                var destination = pair[1];

                var steps = BFS(start, destination);

                Console.WriteLine($"{{{start}, {destination}}} -> {steps}");
            }
        }

        private static int BFS(int start, int destination)
        {
            var queue = new Queue<int>();
            queue.Enqueue(start);

            var visited = new HashSet<int> {start};
            var parent = new Dictionary<int, int>{{start, -1 }};

            while (queue.Count > 0)
            {
                var currentNode = queue.Dequeue();

                if (currentNode == destination)
                {
                    var steps = GetPath(parent, destination);
                    return steps;
                }

                foreach (var child in graph[currentNode])
                {
                    if (visited.Contains(child))
                    {
                        continue;
                    }

                    queue.Enqueue(child);
                    visited.Add(child);
                    parent[child] = currentNode;
                }
            }

            return -1;
        }

        private static int GetPath(Dictionary<int, int> parent, int destination)
        {
            var steps = 0;
            var node = destination;

            while (node != -1)
            {
                node = parent[node];
                steps += 1;
            }

            return steps - 1;
        }

        private static Dictionary<int, List<int>> ReadGraph(int n)
        {
            var result = new Dictionary<int, List<int>>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine()
                     .Split(":", StringSplitOptions.RemoveEmptyEntries);

                var node = int.Parse(input[0]);

                if (input.Length == 1)
                {
                    result[node] = new List<int>();
                }
                else
                {
                    var children = input[1]
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToList();

                    result[node] = children;
                }
            }

            return result;
        }
    }
}
