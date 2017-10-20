using System;

namespace perceptron.Source
{
	public class SimplePerceptron
	{
		private float[] weights;
		private float outputLayer;
		private const float learningRate = 0.1f;
		private float threshold = 0.5f;

		public SimplePerceptron()
		{
			weights = new float[2];
			outputLayer = 0f;
		}

		public void Step()
		{
		}

		public void Train(int[] input, int desiredValue, int stepCount)
		{
			int output = 0;
			for (int step = 0; step < stepCount; step++)
			{
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
				else
				{
					break;
				}
			}

			for (int i = 0; i < weights.Length; i++)
			{
				Console.WriteLine("Weight{0}: {1}, Output: {2}", i, weights[i], output);
			}
		}
	}
}