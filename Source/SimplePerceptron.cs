using System;

namespace perceptron.Source
{
	public class SimplePerceptron
	{
		private double[] weights;
		private const double learningRate = 0.1;
		private double threshold = 0.5f;

		public SimplePerceptron()
		{
			weights = new double[2];
		}

		public bool Step(int[] input, int desiredValue)
		{
			int output = 0;
			double sum = 0;
			for (int i = 0; i < weights.Length; i++)
			{
				sum += input[i] * weights[i];
			}

			output = Utility.StepF(sum, threshold);
			bool correct = output == desiredValue;

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
			int output = 0;
			double sum = 0f;
			for (int i = 0; i < weights.Length; i++)
			{
				sum += input[i] * weights[i];
			}

			output = Utility.StepF(sum, threshold);
			return output;
		}
	}
}