using System;

namespace perceptron.Source
{
	public class XorGate
	{
		private double[,] inputWeights;
		private double[] hiddenWeights;
		private const float learningRate = 0.02f;
		private double threshold = 0.5;
		private double[] hiddenBias;
		private double outputBias;
		
		public XorGate()
		{
			inputWeights = new double[2, 2];
			hiddenWeights = new double[2];
			hiddenBias = new double[2];
		}

		public bool Step(int[] input, int desiredValue)
		{
			double output = 0;
			double sum0 = input[0] * inputWeights[0, 0] + input[1] * inputWeights[1, 0] + hiddenBias[0]; // first hidden node
//			int h0input = sum0 >= threshold ? 1 : 0;
			double h0input = Sigmoid(sum0);
			
			double sum1 = input[0] * inputWeights[0, 1] + input[1] * inputWeights[1, 1] + hiddenBias[1]; // second hidden node
//			int h1input = sum1 >= threshold ? 1 : 0;
			double h1input = Sigmoid(sum1);
			
			double sum = h0input * hiddenWeights[0] + h1input * hiddenWeights[1] + outputBias;
			output = Sigmoid(sum);
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
					hiddenWeights[0] += (desiredValue - output) * learningRate;
					hiddenBias[0] += (desiredValue - output);
				}
				if (h1input > 0)
				{
					hiddenWeights[1] += (desiredValue - output) * learningRate;
					hiddenBias[1] += (desiredValue - output);
				}
			}
			
			Console.WriteLine("output: {0}, h0input: {1}, h1input: {2}, desired: {3}", output, h0input, h1input, desiredValue);
			Console.WriteLine("{0}, {1}, {2}, {3}", inputWeights[0, 0], inputWeights[0, 1], inputWeights[1, 0], inputWeights[1, 1] );
			Console.WriteLine("{0}, {1}, {2}, {3}", hiddenWeights[0], hiddenWeights[1], hiddenBias[0], hiddenBias[1]);
			Console.WriteLine("=====");

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

		public double Use(int[] input)
		{
			double output = 0;
			double sum0 = input[0] * inputWeights[0, 0] + input[1] * inputWeights[1, 0] + hiddenBias[0]; // first hidden node
//			int h0input = sum0 >= threshold ? 1 : 0;
			double h0input = Sigmoid(sum0);
			
			double sum1 = input[0] * inputWeights[0, 1] + input[1] * inputWeights[1, 1] + hiddenBias[1]; // second hidden node
//			int h1input = sum1 >= threshold ? 1 : 0;
			double h1input = Sigmoid(sum1);
			
			double sum = h0input * hiddenWeights[0] + h1input * hiddenWeights[1] + outputBias;
			output = Sigmoid(sum);

			return output;
		}

		private double Sigmoid(double x)
		{
			return 1 / (1 + Math.Pow(Math.E, -x));
		}
	}
}