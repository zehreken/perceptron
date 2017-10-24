using System;

namespace perceptron.Source
{
	public class SigmoidPerceptron
	{
		private double[] weights;
		private const double learningRate = 0.1;
		private const double errorMargin = 0.01;

		public SigmoidPerceptron()
		{
			weights = new double[2];
		}

		public bool Step(int[] input, int desiredValue)
		{
			double output;
			double sum = 0;
			for (int i = 0; i < weights.Length; i++)
			{
				sum += input[i] * weights[i];
			}

			output = Utility.SigmoidF(sum);
			bool correct = Math.Abs(desiredValue - output) < errorMargin;
			Console.WriteLine("{0}, {1}, {2}, {3}", sum, output, weights[0], weights[1]);

			if (!correct)
			{
				for (int i = 0; i < weights.Length; i++)
				{
					if (input[i] > 0)
					{
						weights[i] += (desiredValue - output) * learningRate;
					}
				}
			}

			return correct;
		}

		public void Train(int[] input, int desiredValue, int stepCount)
		{
			for (int step = 0; step < stepCount; step++)
			{
				if (Step(input, desiredValue))
				{
					break;
				}
			}
		}

		public int Use(int[] input)
		{
			double output;
			double sum = 0;
			for (int i = 0; i < weights.Length; i++)
			{
				sum += input[i] * weights[i];
			}

			output = Utility.SigmoidF(sum);
			Console.WriteLine("{0}, {1}", sum, output);
			return (int) output;
		}
	}
}