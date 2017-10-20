using System;

namespace perceptron.Source
{
	public class SimplePerceptron
	{
		private float[] weights;
		private const float learningRate = 0.1f;
		private float threshold = 0.5f;

		public SimplePerceptron()
		{
			weights = new float[2];
		}

		public bool Step(int[] input, int desiredValue)
		{
			int output = 0;
			float sum = 0f;
			for (int i = 0; i < weights.Length; i++)
			{
				sum += input[i] * weights[i];
			}

			output = sum >= threshold ? 1 : 0;
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
			float sum = 0f;
			for (int i = 0; i < weights.Length; i++)
			{
				sum += input[i] * weights[i];
			}

			output = sum >= threshold ? 1 : 0;
			return output;
		}
	}
}