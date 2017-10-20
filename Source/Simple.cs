using System;
using System.Diagnostics;
using System.Runtime.InteropServices.WindowsRuntime;

namespace perceptron.Source
{
	public class Simple
	{
		private float[] weights;
		private float outputLayer;
		private const float learningRate = 0.1f;
		private float threshold = 0.5f;

		public Simple()
		{
			weights = new float[2];
			outputLayer = 0f;
		}

		public void Step()
		{
		}

		public void Train(int[] input, int desiredValue, int stepCount)
		{
			for (int step = 0; step < stepCount; step++)
			{
				float sum = 0f;
				for (int i = 0; i < weights.Length; i++)
				{
					sum += input[i] * weights[i];
				}

				int output = sum >= threshold ? 1 : 0;
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
				Console.WriteLine("Weight{0}: {1}", i, weights[i]);
			}
		}
	}
}