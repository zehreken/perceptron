using System;
using System.Collections.Generic;

namespace perceptron.Source
{
	public static class Utils
	{
		public static List<int[]> trainingInputSet = new List<int[]>
		{
			new[] {0, 0},
			new[] {0, 1},
			new[] {1, 0},
			new[] {1, 1}
		};

		public static int[] outputAND = {0, 0, 0, 1};
		public static int[] outputOR = {0, 1, 1, 1};
		public static int[] outputXOR = {0, 1, 1, 0};

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