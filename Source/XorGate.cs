using System;

namespace perceptron.Source
{
	public class XorGate
	{
		private float[,] inputWeights;
		private float[] hiddenWeights;
		private const float learningRate = 0.1f;
		private float threshold = 0.5f;
		
		public XorGate()
		{
			inputWeights = new float[2, 2];
			hiddenWeights = new float[2];
		}

		public void Train(int[] input, int desiredValue, int stepCount)
		{
			int output = 0;
			for (int step = 0; step < stepCount; step++)
			{
				float sum0 = input[0] * inputWeights[0, 0] + input[1] * inputWeights[1, 0]; // first hidden node
				int h0input = sum0 >= threshold ? 1 : 0;	

				float sum1 = input[0] * inputWeights[0, 1] + input[1] * inputWeights[1, 1]; // second hidden node
				int h1input = sum1 >= threshold ? 1 : 0;

				float sum = h0input * hiddenWeights[0] + h1input * hiddenWeights[1];
				output = sum >= threshold ? 1 : 0;
				bool correct = output == desiredValue;

				if (!correct)
				{
					if (input[0] > 0)
					{
						inputWeights[0, 0] += (desiredValue - h0input) * learningRate;
						inputWeights[0, 1] += (desiredValue - h0input) * learningRate;
					}
					if (input[1] > 0)
					{
						inputWeights[1, 0] += (desiredValue - h1input) * learningRate;
						inputWeights[1, 1] += (desiredValue - h1input) * learningRate;
					}
					if (h0input > 0)
					{
						hiddenWeights[0] += (desiredValue - h0input) * learningRate;
					}
					if (h1input > 0)
					{
						hiddenWeights[1] += (desiredValue - h1input) * learningRate;
					}
				}
				else
				{
					break;
				}
			}
			
			Console.WriteLine("Output: {0}", output);
		}
	}
}