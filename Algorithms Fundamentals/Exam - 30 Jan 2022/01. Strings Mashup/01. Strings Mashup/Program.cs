using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Strings_Mashup
{
    class Program
    {
        private static char[] elements;
        private static int lengths;
        private static char[] variations;
        private static List<string> some;
        static void Main(string[] args)
        {
            elements = Console.ReadLine().ToCharArray();
            lengths = int.Parse(Console.ReadLine());
            variations = new char[lengths];
            some = new List<string>();

            Variations(0, 0);
            some = some.OrderBy(x => x).ToList();
            Console.WriteLine(string.Join(Environment.NewLine, some));
        }

        private static void Variations(int permutationsIndex, int startIndex)
        {
            if (permutationsIndex >= variations.Length)
            {
                var str = string.Empty;
                foreach (var item in variations.OrderBy(x => x))
                {
                    str += item;
                }
                some.Add(str);
                return;
            }

            for (int i = startIndex; i < elements.Length; i++)
            {
                variations[permutationsIndex] = elements[i];
                Variations(permutationsIndex + 1, i);
            }
        }
    }
}
