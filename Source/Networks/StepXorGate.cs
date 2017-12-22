using System;

namespace perceptron.Source
{
	public class StepXorGate : INeuralNetwork
	{
		private double[,] inputWeights;
		private double[] hiddenWeights;
		private const float learningRate = 0.1f;
		private double threshold = 0.5;
		private double[] hiddenBias;
		private double outputBias;
		private double errorMargin = 0.001;

		public StepXorGate()
		{
			inputWeights = new double[2, 2];
			hiddenWeights = new double[2];
			hiddenBias = new double[2];
		}

		public bool Train(int[] input, int desiredValue)
		{
			double output;

			double sum0 = input[0] * inputWeights[0, 0] + input[1] * inputWeights[1, 0] + hiddenBias[0];
			double h0input = Utility.StepF(sum0, 0.5);

			double sum1 = input[0] * inputWeights[0, 1] + input[1] * inputWeights[1, 1] + hiddenBias[1];
			double h1input = Utility.StepF(sum1, 0.5);

			double sum = h0input * hiddenWeights[0] + h1input * hiddenWeights[1] + outputBias;
			output = Utility.StepF(sum, 0.5);

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
				}
				if (h1input > 0)
				{
					hiddenWeights[1] += (desiredValue - output) * learningRate;
				}
				hiddenBias[0] += (desiredValue - output) * learningRate;
				hiddenBias[1] += (desiredValue - output) * learningRate;
				outputBias += (desiredValue - output) * learningRate;
			}

			return correct;
		}

		public double Use(int[] input)
		{
			double output;
			double sum0 = input[0] * inputWeights[0, 0] + input[1] * inputWeights[1, 0] + hiddenBias[0];
			double h0input = Utility.StepF(sum0, 0.5);

			double sum1 = input[0] * inputWeights[0, 1] + input[1] * inputWeights[1, 1] * hiddenBias[1];
			double h1input = Utility.StepF(sum1, 0.5);

			double sum = h0input * hiddenWeights[0] + h1input * hiddenWeights[1] + outputBias;
			output = Utility.StepF(sum, 0.5);

			return output;
		}

		public override String ToString()
		{
			string s = "inputWeights0_0: " + inputWeights[0, 0];
			s += "\ninputWeights0_1: " + inputWeights[0, 1];
			s += "\ninputWeights1_0: " + inputWeights[1, 0];
			s += "\ninputWeights1_1: " + inputWeights[1, 1];
			s += "\nhiddenBias0: " + hiddenBias[0];
			s += "\nhiddenBias1: " + hiddenBias[1];
			s += "\noutputBias: " + outputBias;

			return s;
		}
	}
}