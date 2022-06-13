namespace N_Quenn_Puzzle
{
    public class Puzzle
    {
        public int SetQueen(int queenAmount)
        {
            var resultAmount = 0;
            var queen = "Q";
            var space = ".";
            var queenLocations = new int?[queenAmount];

            var ShowResult = () =>
            {
                var resultStr = new List<string>
                {
                    $"Solution{resultAmount}"
                };

                foreach (var queenIndex in queenLocations)
                {
                    var itemResult = new List<string>();
                    for (int i = 0; i < queenAmount; i++)
                    {
                        itemResult.Add(i == queenIndex ? queen : space);
                    }

                    resultStr.Add(string.Join("\t", itemResult));
                }

                Console.WriteLine(string.Join("\n", resultStr));
            };

            var CheckForSlashes = (int row, int col) =>
            {
                for (int i = 1; i < row + 1; i++)
                {
                    var topRowCol = queenLocations[row - i];

                    if (col - i == topRowCol || col + i == topRowCol)
                    {
                        return false;
                    }
                }

                return true;
            };

            var CanPlacedQueen = (int row, int col) =>
            {
                var topRow = row - 1;
                var topQueenIndex = queenLocations[topRow];

                var unablePlacedConditions = new List<Func<bool>>
                {
                    () => queenLocations.Contains(col),
                    () => !CheckForSlashes(row, col)
                };

                return !unablePlacedConditions.Any(f => f());
            };

            if (queenAmount == 1)
            {
                resultAmount++;
                Console.WriteLine("Q");
                return resultAmount; ;
            }            

            for (int row = 0; row < queenAmount; row++)
            {
                int rowIndex = queenLocations[row] == null ? 0 : Convert.ToInt32(queenLocations[row] + 1);

                if (row == 0 && rowIndex == queenAmount)
                {
                    break;
                }

                for (int colIndex = rowIndex; colIndex <= queenAmount; colIndex++)
                {
                    if (colIndex == queenAmount)
                    {
                        queenLocations[row] = null;
                        row -= 2;
                        break;
                    }
                    else if (row == 0)
                    {
                        queenLocations[row] = colIndex;
                        break;
                    }
                    else if (CanPlacedQueen(row, colIndex))
                    {
                        queenLocations[row] = colIndex;

                        if (row + 1 != queenAmount)
                        {
                            break;
                        }
                        else if (row + 1 == queenAmount)
                        {
                            resultAmount++;
                            ShowResult();
                        }
                    }
                }

            }

            return resultAmount;
        }

    }

    
}
