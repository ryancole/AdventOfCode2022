namespace AventOfCode.Days
{
    internal class Day3
    {
        public static void Run()
        {
            var input = File.ReadAllLines("days\\3\\input.txt");

            var sum = 0;

            foreach (var line in input)
            {
                var totalItemCount = line.Length;
                var compartmentCount = totalItemCount / 2;

                var compartment1 = line.Take(compartmentCount);
                var compartment2 = line.Skip(compartmentCount);

                var duplicateItem = compartment1.First(m => compartment2.Contains(m));
                int duplicateItemAscii = duplicateItem;

                var priority = 0;

                // upper case
                if (duplicateItemAscii >= 65 && duplicateItemAscii <= 90)
                {
                    priority = (duplicateItemAscii - 65) + 27;
                }

                // lower case
                else if (duplicateItemAscii >= 97 && duplicateItemAscii <= 122)
                {
                    priority = (duplicateItemAscii - 97) + 1;
                }

                sum += priority;
            }

            Console.WriteLine(sum);
        }
    }
}
