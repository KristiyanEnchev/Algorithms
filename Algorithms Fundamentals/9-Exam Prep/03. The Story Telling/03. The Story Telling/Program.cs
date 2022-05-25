using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._The_Story_Telling
{
    class Program
    {
        private static Dictionary<string, List<string>> story;
        private static HashSet<string> visited;
        private static Stack<string> fullStory;
        static void Main(string[] args)
        {
            visited = new HashSet<string>();
            fullStory = new Stack<string>();
            story = ReadGraph();

            foreach (var node in story.Keys)
            {
                if (!visited.Contains(node))
                {
                    DFS(node);
                }
            }

            Console.WriteLine(string.Join(" ", fullStory));
        }

        private static Dictionary<string, List<string>> ReadGraph()
        {
            story = new Dictionary<string, List<string>>();
            var input = Console.ReadLine();
            while (input != "End")
            {
                var parts = input.Split("->", StringSplitOptions.RemoveEmptyEntries);
                var start = parts[0].Trim();

                if (parts.Length == 1)
                {
                    story[start] = new List<string>();
                    input = Console.ReadLine();
                    continue;
                }

                if (!story.ContainsKey(start))
                {
                    story[start] = new List<string>();
                }

                var children = parts[1].Trim().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

                story[start] = children;

                input = Console.ReadLine();
            }

            return story;
        }

        private static void DFS(string node)
        {
            if (visited.Contains(node))
            {
                return;
            }

            foreach (var child in story[node])
            {
                DFS(child);
            }

            visited.Add(node);
            fullStory.Push(node);
        }
    }
}
