using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Cinema
{
    class Program
    {
        private static List<string> names;
        private static string[] seats;
        private static bool[] usedSeats;

        static void Main(string[] args)
        {
            names = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            seats = new string[names.Count];
            usedSeats = new bool[names.Count];

            var command = Console.ReadLine();
            while (command != "generate")
            {
                var parts = command.Split(" - ");
                var name = parts[0];
                var seat = int.Parse(parts[1]);

                seats[seat - 1] = name;
                usedSeats[seat - 1] = true;
                names.Remove(name);

                command = Console.ReadLine();
            }

            Permute(0);
        }

        private static void Permute(int index)
        {
            if (index >= names.Count)
            {
                PrintPermutation();
                return;
            }

            Permute(index + 1);

            for (int i = index + 1; i < names.Count; i++)
            {
                Swap(index, i);
                Permute(index + 1);
                Swap(index, i);
            }
        }

        private static void PrintPermutation()
        {
            var newIndex = 0;
            for (int i = 0; i < seats.Length; i++)
            {
                if (usedSeats[i])
                {
                    continue;
                }

                seats[i] = names[newIndex++];
            }

            Console.WriteLine(string.Join(" ", seats));
        }

        private static void Swap(int first, int second)
        {
            var temp = names[first];
            names[first] = names[second];
            names[second] = temp;
        }
    }
}
