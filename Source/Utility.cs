using System;

namespace perceptron.Source
{
	public static class Utility
	{
		public static int StepF(double x, double threshold)
		{
			return x > threshold ? 1 : 0;
		}

		public static double SigmoidF(double x)
		{
			return 1 / (1 + Math.Exp(-x));
		}
	}
}