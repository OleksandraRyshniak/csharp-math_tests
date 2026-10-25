using csharp_math.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace CsharpMath.Tests
{
    public class FunctionAnalyzerTests
    {
        private readonly FunctionAnalyzer _analyzer = new();

        [Fact]
        public void QuadraticFunction_Derivative_IsCorrect()
        {
            var result = _analyzer.Compute("x^2 - 4*x + 3");

            double actual = result.EvaluateDerivative(3);

            Assert.Equal(2, actual, 3);
        }


        [Fact]
        public void QuadraticFunction_Roots_AreCorrect()
        {
            var result = _analyzer.Compute("x^2 - 4*x + 3");

            Assert.Equal(2, result.ZeroPoints.Count);
            Assert.Equal(1, result.ZeroPoints[0].X, 3);
            Assert.Equal(3, result.ZeroPoints[1].X, 3);
        }


        [Theory]
        [InlineData(-2, 12)]
        [InlineData(0, 0)]
        [InlineData(2, 12)]
        public void CubicFunction_Derivative_IsCorrect(
            double x, double expected)
        {
            var result = _analyzer.Compute("x^3");

            double actual = result.EvaluateDerivative(x);

            Assert.Equal(expected, actual, 3);
        }


        [Theory]
        [InlineData(-5, 3)]
        [InlineData(0, 3)]
        [InlineData(5, 3)]
        public void LinearFunction_Derivative_IsCorrect(
            double x, double expected)
        {
            var result = _analyzer.Compute("3*x + 2");

            double actual = result.EvaluateDerivative(x);

            Assert.Equal(expected, actual, 3);
        }

        [Fact]
        public void QuadraticFunction_WithoutRealRoots_ReturnsEmptyList()
        {
            var result = _analyzer.Compute("x^2 + 1");

            Assert.Empty(result.ZeroPoints);
        }

        [Fact]
        public void QuadraticFunction_WithDoubleRoot_ReturnsOneRoot()
        {
            var result = _analyzer.Compute("x^2");

            Assert.Single(result.ZeroPoints);
            Assert.Equal(0, result.ZeroPoints[0].X, 3);
        }

        [Fact]
        public void ConstantFunction_Derivative_IsZero()
        {
            var result = _analyzer.Compute("5");

            Assert.Equal(0, result.EvaluateDerivative(2), 3);
        }

        [Fact]
        public void LinearFunction_HasOneRoot()
        {
            var result = _analyzer.Compute("2*x - 6");

            Assert.Single(result.ZeroPoints);
            Assert.Equal(3, result.ZeroPoints[0].X, 3);
        }

        [Theory]
        [InlineData(-3)]
        [InlineData(0)]
        [InlineData(4)]
        public void LinearFunction_Derivative_IsTwo(double x)
        {
            var result = _analyzer.Compute("2*x + 5");

            Assert.Equal(2, result.EvaluateDerivative(x), 3);
        }


        [Fact]
        public void NegativeQuadraticFunction_Derivative_IsCorrect()
        {
            var result = _analyzer.Compute("-x^2");

            Assert.Equal(-4, result.EvaluateDerivative(2), 3);
        }

        [Fact]
        public void ConstantFunction_HasNoRoots()
        {
            var result = _analyzer.Compute("5");

            Assert.Empty(result.ZeroPoints);
        }

        [Fact]
        public void ZeroFunction_Derivative_IsZero()
        {
            var result = _analyzer.Compute("0");

            Assert.Equal(0, result.EvaluateDerivative(3), 3);
        }



    }
}
