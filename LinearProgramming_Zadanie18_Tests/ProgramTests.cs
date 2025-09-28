using System.Numerics;

namespace LinearProgramming_Zadanie18_Tests
{
    public class ProgramTests
    {
        [Test]
        public void Test1()
        {
            var numbers = new int[] { 3, 4, 5 };
            BigInteger expected = 60;
            var result = LinearProgramming_Zadanie18.LinearProgramming_Zadanie18.Solve(expected, numbers);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Value.selectedNumbers, Is.EquivalentTo(numbers));
            Assert.That(result.Value.product, Is.EqualTo(expected));
        }

        [Test]
        public void Test2()
        {
            var numbers = new int[] { 1, 1, 2, 3, 4, 5 };
            BigInteger expected = 120;
            var result = LinearProgramming_Zadanie18.LinearProgramming_Zadanie18.Solve(expected, numbers);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Value.selectedNumbers, Is.EquivalentTo(numbers));
            Assert.That(result.Value.product, Is.EqualTo(expected));
        }

        [Test]
        public void Test3()
        {
            var numbers = new int[] { 2, 3, 4, 5 };
            BigInteger expected = 120;
            var result = LinearProgramming_Zadanie18.LinearProgramming_Zadanie18.Solve(expected, numbers);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Value.selectedNumbers, Is.EquivalentTo(numbers));
            Assert.That(result.Value.product, Is.EqualTo(expected));
        }

        [Test]
        public void Test4_NoSolution()
        {
            var numbers = new int[] { 2, 3, 5 };
            BigInteger expected = 120;
            var result = LinearProgramming_Zadanie18.LinearProgramming_Zadanie18.Solve(expected, numbers);

            Assert.That(result, Is.Null);
        }
        
        [Test]
        public void Test6_RepeatedNumbers()
        {
            var numbers = new int[] { 2, 2, 3, 3, 5 };
            BigInteger expected = 2 * 3 * 5;
            var result = LinearProgramming_Zadanie18.LinearProgramming_Zadanie18.Solve(expected, numbers);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Value.product, Is.EqualTo(expected));
        }

        [Test]
        public void Test7_AllNumbersNeeded()
        {
            var numbers = new int[] { 2, 3, 4 };
            BigInteger expected = 24;
            var result = LinearProgramming_Zadanie18.LinearProgramming_Zadanie18.Solve(expected, numbers);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Value.product, Is.EqualTo(expected));
            Assert.That(result.Value.selectedNumbers, Is.EquivalentTo(numbers));
        }
        
        [Test]
        public void Test9_MultipleCombinations()
        {
            var numbers = new int[] { 1, 2, 3, 6 };
            BigInteger expected = 6;
            var result = LinearProgramming_Zadanie18.LinearProgramming_Zadanie18.Solve(expected, numbers);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Value.product, Is.EqualTo(expected));
            Assert.That(result.Value.selectedNumbers, Is.EquivalentTo(new List<int> {1,6}));
        }
    }
}
