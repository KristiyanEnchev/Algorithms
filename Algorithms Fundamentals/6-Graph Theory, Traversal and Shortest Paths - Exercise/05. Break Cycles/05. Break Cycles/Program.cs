using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Break_Cycles
{
    public class Edge
    {
        public string Start { get; set; }
        public string ChildNode { get; set; }
    }

    class Program
    {
        private static SortedDictionary<string, List<string>> graph;
        private static List<Edge> edges;
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            graph = new SortedDictionary<string, List<string>>();
            edges = new List<Edge>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(" -> ");
                var node = input[0];
                var children = input[1].Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

                graph[node] = children;

                foreach (var child in children)
                {
                    edges.Add(new Edge { Start = node, ChildNode = child });
                }
            }

            edges = edges.OrderBy(x => x.Start)
                .ThenBy(x => x.ChildNode)
                .ToList();

            var edgesToRemove = new List<Edge>();
            var reverse = new List<Edge>();

            foreach (var edge in edges)
            {
                if (reverse.Any(x => x.Start == edge.Start && x.ChildNode == edge.ChildNode))
                {
                    continue;
                }
                graph[edge.Start].Remove(edge.ChildNode);
                graph[edge.ChildNode].Remove(edge.Start);

                if (BFS(edge.Start, edge.ChildNode))
                {
                    edgesToRemove.Add(edge);
                    var oposite = new Edge { Start = edge.ChildNode, ChildNode = edge.Start};
                    reverse.Add(oposite);
                }
                else
                {
                    graph[edge.Start].Add(edge.ChildNode);
                    graph[edge.ChildNode].Add(edge.Start);
                }
            }

            Console.WriteLine($"Edges to remove: {edgesToRemove.Count}");
            foreach (var edge in edgesToRemove)
            {
                Console.WriteLine($"{edge.Start} - {edge.ChildNode}");
            }
        }

        private static bool BFS(string start, string destination)
        {
            var queue = new Queue<string>();
            queue.Enqueue(start);
            var visited = new HashSet<string>{start};

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                if (node == destination)
                {
                    return true;
                }

                foreach (var child in graph[node])
                {
                    if (visited.Contains(child))
                    {
                        continue;
                    }
                    visited.Add(child);
                    queue.Enqueue(child);
                }
            }

            return false;
        }
    }
}
