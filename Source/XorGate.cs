using System;
using System.Net;

namespace perceptron.Source
{
	public class XorGate
	{
		private double[,] inputWeights;
		private double[] hiddenWeights;
		private const float learningRate = 0.1f;
		private double threshold = 0.5;
		private double[] hiddenBias;
		private double outputBias;
		private double error = 0.001;
		
		public XorGate()
		{
			inputWeights = new double[2, 2];
			hiddenWeights = new double[2];
			hiddenBias = new double[2];
		}

		public bool Step(int[] input, int desiredValue, int step)
		{
			double output;
			double sum0 = input[0] * inputWeights[0, 0] + input[1] * inputWeights[1, 0] + hiddenBias[0]; // first hidden node
			double h0input = Utility.Sigmoid(sum0);
			
			double sum1 = input[0] * inputWeights[0, 1] + input[1] * inputWeights[1, 1] + hiddenBias[1]; // second hidden node
			double h1input = Utility.Sigmoid(sum1);
			
			double sum = h0input * hiddenWeights[0] + h1input * hiddenWeights[1] + outputBias;
//			output = Math.Abs(desiredValue - Sigmoid(sum)) < error ? 1 : 0;
			output = Utility.Sigmoid(sum);
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
				}
			}

			if (step % 1000 == 0)
			{
				Console.WriteLine("Step {0} =====", step);
				Console.WriteLine("Error: {0:0.0000}, Desired: {1}, Output: {2:0.0000}", desiredValue - output, desiredValue, output);
				Console.WriteLine("h0input: {0}, h1input: {1}", h0input, h1input);
			}

			return correct;
		}
		
		public void Train(int[] input, int desiredValue, int stepCount)
		{
			for (int step = 0; step < stepCount; step++)
			{
				if (Step(input, desiredValue, step))
				{
					break;
				}
			}
			Console.WriteLine("===== End of training =====");
		}

		public double Use(int[] input)
		{
			double output;
			double sum0 = input[0] * inputWeights[0, 0] + input[1] * inputWeights[1, 0] + hiddenBias[0]; // first hidden node
			double h0input = Utility.Sigmoid(sum0);
			
			double sum1 = input[0] * inputWeights[0, 1] + input[1] * inputWeights[1, 1] + hiddenBias[1]; // second hidden node
			double h1input = Utility.Sigmoid(sum1);
			
			double sum = h0input * hiddenWeights[0] + h1input * hiddenWeights[1] + outputBias;
			output = Utility.Sigmoid(sum);

			return output;
		}
	}
}