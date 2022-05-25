using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Road_Reconstruction
{
    public class Edge
    {
        public int Start { get; set; }
        public int Child { get; set; }

        public override string ToString()
        {
            return $"{Start} {Child}";
        }
    }
    class Program
    {
        private static List<int>[] graph;
        private static List<Edge> edges;
        private static bool[] visited;
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var e = int.Parse(Console.ReadLine());

            graph = new List<int>[n];
            edges = new List<Edge>();

            for (int node = 0; node < graph.Length; node++)
            {
                graph[node] = new List<int>();
            }

            for (int i = 0; i < e; i++)
            {
                var parts = Console.ReadLine()
                    .Split(" - ")
                    .Select(int.Parse)
                    .ToArray();

                var firstNode = parts[0];
                var secondNode = parts[1];

                graph[firstNode].Add(secondNode);
                graph[secondNode].Add(firstNode);

                edges.Add(new Edge { Start = firstNode, Child = secondNode });
            }
            Console.WriteLine("Important streets:");
            foreach (var edge in edges)
            {
                graph[edge.Start].Remove(edge.Child);
                graph[edge.Child].Remove(edge.Start);

                visited = new bool[graph.Length];
                DFS(0);

                if (visited.Contains(false))
                {
                    var newEdge = new Edge { Start = Math.Min(edge.Start, edge.Child), Child = Math.Max(edge.Start, edge.Child) };
                    Console.WriteLine(newEdge);
                }

                graph[edge.Start].Add(edge.Child);
                graph[edge.Child].Add(edge.Start);
            }
        }

        private static void DFS(int node)
        {
            if (visited[node])
            {
                return;
            }

            visited[node] = true;

            foreach (var child in graph[node])
            {
                DFS(child);
            }
        }
    }
}
