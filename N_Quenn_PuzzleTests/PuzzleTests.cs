using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace N_Quenn_Puzzle.Tests
{
    [TestClass()]
    public class PuzzleTests
    {
        [TestMethod()]
        public void SetQueenTest()
        {
            var puzzle = new Puzzle();
            var datas = GetPuzzleDatas();

            foreach (var data in datas)
            {
                var actaul = puzzle.SetQueen(data.queenAmount);
                Assert.AreEqual(data.expected, actaul);
            }

        }

        private List<(int queenAmount, int expected)> GetPuzzleDatas()
        {
            return new List<(int queenAmount, int expected)>
            {
                {(1,1)},
                {(2,0)},
                {(3,0)},
                {(4,2)},
                {(5,10)},
                {(6,4)},
                {(7,40)},
                {(8,92)},
                {(9,352)},
                {(10,724)},
                {(11,2680)},
                {(12,14200)},
                {(13,73712)},
                {(14,365596)},
            };
        }
    }
}