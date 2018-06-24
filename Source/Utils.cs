using System;
using System.Collections.Generic;

namespace perceptron.Source
{
	public static class Utils
	{
		public static readonly List<int[]> TrainingInputSet = new List<int[]>
		{
			new[] {0, 0},
			new[] {0, 1},
			new[] {1, 0},
			new[] {1, 1}
		};

		public static int[] OutputAnd = {0, 0, 0, 1};
		public static int[] OutputOr = {0, 1, 1, 1};
		public static readonly int[] OutputXor = {0, 1, 1, 0};

		public static int StepF(double x, double threshold)
		{
			return x > threshold ? 1 : 0;
		}

		public static double SigmoidF(double x)
		{
			return 1 / (1 + Math.Exp(-x));
		}

		public static double DerivativeSigmoidF(double x)
		{
			return SigmoidF(x) * (1 - SigmoidF(x));
		}
	}
}