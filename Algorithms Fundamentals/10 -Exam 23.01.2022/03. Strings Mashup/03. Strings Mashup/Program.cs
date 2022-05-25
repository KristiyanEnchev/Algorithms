namespace _03._Strings_Mashup
{
    using System;
    using System.Collections.Generic;
    class Program
    {
        private static string str1;
        private static List<char> variations;

        static void Main(string[] args)
        {
            str1 = Console.ReadLine();
            variations = new List<char>(str1);

            Variations(0);
        }

        private static void Variations(int pemutationIndex)
        {
            if (pemutationIndex >= variations.Count)
            {
                Console.WriteLine(string.Join("", variations));
                return;
            }

            Variations(pemutationIndex + 1);

            if (char.IsLetter(variations[pemutationIndex]))
            {
                variations[pemutationIndex] = Swap(variations, pemutationIndex);
                Variations(pemutationIndex + 1);
                variations[pemutationIndex] = Swap(variations, pemutationIndex);
            }
        }

        private static char Swap(List<char> elements, int index)
        {
            return char.IsLower(elements[index]) ? char.ToUpper(elements[index]) : char.ToLower(elements[index]);
        }
    }
}
