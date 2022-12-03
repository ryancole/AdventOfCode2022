namespace AventOfCode.Days
{
    internal static class Day1
    {
        public static void Run()
        {
            var input = File.ReadAllLines("days\\1\\input.txt");

            var elves = new Dictionary<int, int>();

            var currentElf = 1;

            foreach (var line in input)
            {
                // move to next elf
                if (string.IsNullOrWhiteSpace(line))
                {
                    currentElf += 1;
                    continue;
                }

                // init array for current elf
                else if (elves.ContainsKey(currentElf) == false)
                {
                    elves[currentElf] = 0;
                }

                var calories = int.Parse(line);

                // add calories to current elv
                elves[currentElf] += calories;
            }

            var sorted = elves.OrderByDescending(m => m.Value);
        }
    }
}
