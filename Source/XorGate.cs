using System;

namespace perceptron.Source
{
	public class XorGate : INeuralNetwork
	{
		private double[,] inputWeights;
		private double[] hiddenWeights;
		private const float learningRate = 0.1f;
		private double threshold = 0.5;
		private double[] hiddenBias;
		private double outputBias;
		private double errorMargin = 0.001;
		
		public XorGate()
		{
			inputWeights = new double[2, 2];
			hiddenWeights = new double[2];
			hiddenBias = new double[2];
		}

		public bool Train(int[] input, int desiredValue)
		{
			double output;
			
			double sum0 = input[0] * inputWeights[0, 0] + input[1] * inputWeights[1, 0] + hiddenBias[0]; // first hidden node
			double h0input = Utility.SigmoidF(sum0);
			h0input = Math.Abs(desiredValue - h0input) < errorMargin ? 1 : 0;
			
			double sum1 = input[0] * inputWeights[0, 1] + input[1] * inputWeights[1, 1] + hiddenBias[1]; // second hidden node
			double h1input = Utility.SigmoidF(sum1);
			h1input = Math.Abs(desiredValue - h1input) < errorMargin ? 1 : 0;
			
			double sum = h0input * hiddenWeights[0] + h1input * hiddenWeights[1] + outputBias;
			output = Math.Abs(desiredValue - Utility.SigmoidF(sum)) < errorMargin ? 1 : 0;
//			output = Utility.SigmoidF(sum);
			bool correct = Math.Abs(desiredValue - output) < errorMargin;;

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

//			if (step % 5000 == 0)
//			{
//				Console.WriteLine("Step {0} =====", step);
//				Console.WriteLine("Error: {0:0.0000}, Desired: {1}, Output: {2:0.0000}", desiredValue - output, desiredValue, output);
//				Console.WriteLine("h0input: {0}, h1input: {1}", h0input, h1input);
//			}

			return correct;
		}

		public double Use(int[] input)
		{
			double output;
			double sum0 = input[0] * inputWeights[0, 0] + input[1] * inputWeights[1, 0] + hiddenBias[0]; // first hidden node
			double h0input = Utility.SigmoidF(sum0);
			
			double sum1 = input[0] * inputWeights[0, 1] + input[1] * inputWeights[1, 1] + hiddenBias[1]; // second hidden node
			double h1input = Utility.SigmoidF(sum1);
			
			double sum = h0input * hiddenWeights[0] + h1input * hiddenWeights[1] + outputBias;
			output = Utility.SigmoidF(sum);
			bool correct = Math.Abs(1 - output) < errorMargin;
			output = correct ? 1 : 0;

			return output;
		}

		public override string ToString()
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