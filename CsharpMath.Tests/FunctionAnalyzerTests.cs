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

    }
}
