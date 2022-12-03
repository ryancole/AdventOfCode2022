namespace AventOfCode.Days
{
    internal class Day2
    {
        public static void Run()
        {
            var lines = File.ReadAllLines("days\\2\\input.txt");

            // map our letters to move names
            var moveName = new Dictionary<string, MoveName>
            {
                { "A", MoveName.Rock },
                { "B", MoveName.Paper },
                { "C", MoveName.Scissors },
                { "X", MoveName.Rock },
                { "Y", MoveName.Paper },
                { "Z", MoveName.Scissors },
            };

            // each move is mapped to a score
            var moveScore = new Dictionary<MoveName, int>
            {
                { MoveName.Rock, 1 },
                { MoveName.Paper, 2 },
                { MoveName.Scissors, 3 }
            };

            // each outcome it mapped to a score
            var outcomeScore = new Dictionary<string, int>
            {
                { "win", 6 },
                { "lose", 0 },
                { "draw", 3 }
            };

            // these are the real counters in the game, not the elf-provided
            // suggestions
            var counters = new Dictionary<MoveName, MoveName>
            {
                { MoveName.Rock, MoveName.Paper },
                { MoveName.Paper, MoveName.Scissors },
                { MoveName.Scissors, MoveName.Rock }
            };

            var score = 0;

            foreach (var line in lines)
            {
                // parse line
                var round = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                var strategy = new Tuple<MoveName, MoveName>(moveName[round[0]], moveName[round[1]]);

                // grab moves
                var theirs = strategy.Item1;
                var mine = strategy.Item2;

                // draw is easy to determine
                if (strategy.Item1 == strategy.Item2)
                {
                    score += outcomeScore["draw"] + moveScore[strategy.Item2];
                    continue;
                }

                // they chose rock
                else if (strategy.Item1 == MoveName.Rock && strategy.Item2 == MoveName.Paper)
                {
                    score += outcomeScore["win"] + moveScore[strategy.Item2];
                    continue;
                }
                else if (strategy.Item1 == MoveName.Rock && strategy.Item2 == MoveName.Scissors)
                {
                    score += outcomeScore["lose"] + moveScore[strategy.Item2];
                    continue;
                }

                // they chose paper
                else if (strategy.Item1 == MoveName.Paper && strategy.Item2 == MoveName.Rock)
                {
                    score += outcomeScore["lose"] + moveScore[strategy.Item2];
                    continue;
                }
                else if (strategy.Item1 == MoveName.Paper && strategy.Item2 == MoveName.Scissors)
                {
                    score += outcomeScore["win"] + moveScore[strategy.Item2];
                    continue;
                }

                // they chose scissors
                else if (strategy.Item1 == MoveName.Scissors && strategy.Item2 == MoveName.Rock)
                {
                    score += outcomeScore["win"] + moveScore[strategy.Item2];
                    continue;
                }
                else if (strategy.Item1 == MoveName.Scissors && strategy.Item2 == MoveName.Paper)
                {
                    score += outcomeScore["lose"] + moveScore[strategy.Item2];
                    continue;
                }
            }

            Console.WriteLine(score);
        }

        private enum MoveName
        {
            Rock,
            Paper,
            Scissors
        }
    }
}
