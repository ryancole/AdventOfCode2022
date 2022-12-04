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
                { "C", MoveName.Scissors }
            };

            var neededOutcome = new Dictionary<string, OutcomeName>
            {
                { "X", OutcomeName.Lose },
                { "Y", OutcomeName.Draw },
                { "Z", OutcomeName.Win }
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
                var strategy = new Tuple<MoveName, OutcomeName>(moveName[round[0]], neededOutcome[round[1]]);

                switch (strategy.Item2)
                {
                    case OutcomeName.Win:
                        score += outcomeScore["win"] + moveScore[counters[strategy.Item1]];
                        break;

                    case OutcomeName.Lose:
                        if (strategy.Item1 == MoveName.Rock)
                        {
                            score += outcomeScore["lose"] + moveScore[MoveName.Scissors];
                        }
                        else if (strategy.Item1 == MoveName.Paper)
                        {
                            score += outcomeScore["lose"] + moveScore[MoveName.Rock];
                        }
                        else if (strategy.Item1 == MoveName.Scissors)
                        {
                            score += outcomeScore["lose"] + moveScore[MoveName.Paper];
                        }
                        break;

                    case OutcomeName.Draw:
                        score += outcomeScore["draw"] + moveScore[strategy.Item1];
                        break;
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

        private enum OutcomeName
        {
            Win,
            Lose,
            Draw
        }
    }
}
