using System;

namespace perceptron.Source
{
	public static class Utility
	{
		public static int Step(double x, double threshold)
		{
			return x > threshold ? 1 : 0;
		}

		public static double Sigmoid(double x)
		{
			return 1 / (1 + Math.Pow(Math.E, -x));
		}
	}
}