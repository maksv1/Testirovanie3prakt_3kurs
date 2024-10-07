using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Diskriminant.Test
{
    [TestClass]
    public class MathOperationsTests
    {
        private static double[][] rootsTestCases;
        private static double[] percentageTestCase;

        [ClassInitialize]
        public static void Initialize(TestContext context)
        {
            rootsTestCases = new double[][]
            {
            new double[] {1, 1, 1},
            new double[] {1, 2, 1},
            new double[] {1, -3, 2}
            };

            percentageTestCase = new double[] { 200.0, 15.0 };
        }

        [TestMethod]
        public void TestFindRoots_DiscriminantLessThanZero()
        {
            double[] coefficients = rootsTestCases[0];
            double a = coefficients[0];
            double b = coefficients[1];
            double c = coefficients[2];

            double[] expectedRoots = new double[0]; 
            double[] actualRoots = MathOperations.FindRoots(a, b, c);

            CollectionAssert.AreEqual(expectedRoots, actualRoots, "D < 0: Ожидается, что корней нет");
        }

        [TestMethod]
        public void TestFindRoots_DiscriminantEqualsZero_AllItemsAreUnique()
        {
            double[] coefficients = rootsTestCases[1];
            double a = coefficients[0];
            double b = coefficients[1];
            double c = coefficients[2];

            double[] actualRoots = MathOperations.FindRoots(a, b, c);

            CollectionAssert.AllItemsAreUnique(actualRoots, "D = 0: Ожидается один уникальный корень");
        }

        [TestMethod]
        public void TestFindRoots_DiscriminantGreaterThanZero_AreEquivalent()
        {
            double[] coefficients = rootsTestCases[2];
            double a = coefficients[0];
            double b = coefficients[1];
            double c = coefficients[2];

            double[] expectedRoots = new double[] { 1, 2 };
            double[] actualRoots = MathOperations.FindRoots(a, b, c);

            CollectionAssert.AreEquivalent(expectedRoots, actualRoots, "D > 0: Ожидаются два эквивалентных корня");
        }

        [TestMethod]
        public void TestCalculatePercentage_WithDelta()
        {
            double number = 100;
            double percentage = 10;
            double expectedResult = 9.9999; 
            double delta = 0.0001;

            double actualResult = MathOperations.CalculatePercentage(number, percentage);

            Assert.AreEqual(expectedResult, actualResult, delta, "Ожидается вычисление процента с допустимой погрешностью");
        }
    }
}
