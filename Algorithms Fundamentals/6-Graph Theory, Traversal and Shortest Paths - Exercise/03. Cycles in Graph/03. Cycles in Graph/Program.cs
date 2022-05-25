using System;
using System.Collections.Generic;

namespace _03._Cycles_in_Graph
{
    class Program
    {
        private static Dictionary<string, List<string>> graph;
        private static HashSet<string> visited;
        private static HashSet<string> cycles;

        static void Main(string[] args)
        {
            graph = new Dictionary<string, List<string>>();
            visited = new HashSet<string>();
            cycles = new HashSet<string>();

            var command = Console.ReadLine();
            while (command != "End")
            {
                var parts = command.Split("-", StringSplitOptions.RemoveEmptyEntries);
                var start = parts[0];
                var destination = parts[1];

                if (!graph.ContainsKey(start))
                {
                    graph[start] = new List<string>();
                }

                if (!graph.ContainsKey(destination))
                {
                    graph[destination] = new List<string>();
                }

                graph[start].Add(destination);
                command = Console.ReadLine();
            }

            try
            {
                foreach (var node in graph.Keys)
                {
                    DFS(node);
                }

                Console.WriteLine("Acyclic: Yes");
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("Acyclic: No");
            }

        }

        private static void DFS(string node)
        {
            if (cycles.Contains(node))
            {
                throw new InvalidOperationException();
            }

            if (visited.Contains(node))
            {
                return;
            }

            visited.Add(node);
            cycles.Add(node);

            foreach (var child in graph[node])
            {
                DFS(child);
            }

            cycles.Remove(node);
        }
    }
}
