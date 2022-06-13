using N_Quenn_Puzzle;

var puzzle = new Puzzle();
var resultAmount = puzzle.SetQueen(8);

Console.WriteLine($"總共{resultAmount}筆答案");
Console.ReadLine();