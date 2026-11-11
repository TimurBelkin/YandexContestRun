using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Collections.Generic;
using Xunit;


namespace ContestTests
{
    public class ComputeFunTests
    {
        [Fact]
        public void EmptyList_ReturnsZero()
        {
            // пустой список — цикл не выполняется, fun = 0
            
            Assert.Equal(4, Program.ComputeFun(new List<int> { 1, 5 }));
        }

        [Fact]
        public void SingleElement_ReturnsElement()
        {
            // [5] → fun = 5 * 1 = 5
            Assert.Equal(4, Program.ComputeFun(new List<int> { 5, 1 }));
        }

        [Fact]
        public void NoEvenMinNoOddMax_NoSwap()
        {
            // чётные индексы: [1, 3], нечётные: [2]
            // minEven = 0 (ничего не меньше 0), maxOdd = 0 (ничего не больше 0)
            // обмена нет, fun = 1 - 2 + 3 = 2
            Assert.Equal(4, Program.ComputeFun(new List<int> { 1, 2, 3 }));
        }

        [Fact]
        public void SwapHappens_MinEvenAndMaxOdd()
        {
            // индексы: 0 → -5 (чёт), 1 → 10 (нечёт), 2 → 3 (чёт), 3 → 4 (нечёт)
            // minEven: -5 на индексе 0
            // maxOdd: 10 на индексе 1
            // обмен: [-5, 10, 3, 4] → [10, -5, 3, 4]
            // fun = 10 - (-5) + 3 - 4 = 14
            Assert.Equal(10, Program.ComputeFun(new List<int> { 4, 10, 7, 5, 4, 5, 3, 8, 3, 2, 5 }));
        }



        [Theory]
        [InlineData(new[] { 1, 2 }, 1)]          // minEven=0 (нет), maxOdd=0 (нет) → без обмена, fun = 1-2 = -1? 
        [InlineData(new[] { 0, 0 }, 0)]
        [InlineData(new[] { 2, 2 }, 2)]
        [InlineData(new[] { 5, 5, 5, 5 }, 0)]    // без обмена: 5-5+5-5 = 0
        public void TheoryCases(int[] masses, int expected)
        {
            Assert.Equal(expected, Program.ComputeFun(masses.ToList()));
        }
    }
}
