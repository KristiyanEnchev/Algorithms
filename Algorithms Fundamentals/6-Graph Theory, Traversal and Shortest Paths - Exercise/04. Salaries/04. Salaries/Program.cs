using System;
using System.Collections.Generic;

namespace _04._Salaries
{
    class Program
    {
        private static List<int>[] graph;
        private static Dictionary<int, int> visited;
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            graph = ReadGraph(n);
            visited = new Dictionary<int, int>();

            var salary = 0;

            for (int node = 0; node < graph.Length; node++)
            {
                salary += DFS(node);
            }

            Console.WriteLine(salary);
        }

        private static int DFS(int node)
        {
            if (visited.ContainsKey(node))
            {
                return visited[node];
            }

            var salary = 0;

            if (graph[node].Count == 0)
            {
                return salary = 1;
            }
            else
            {
                foreach (var child in graph[node])
                {
                    salary += DFS(child);
                }
            }

            visited[node] = salary;

            return salary;
        }

        private static List<int>[] ReadGraph(int n)
        {
            graph = new List<int>[n];

            for (int node = 0; node < n; node++)
            {
                graph[node] = new List<int>();
                var element = Console.ReadLine();

                for (int child = 0; child < element.Length; child++)
                {
                    if (element[child] == 'Y')
                    {
                        graph[node].Add(child);
                    }
                }
            }

            return graph;
        }
    }
}
