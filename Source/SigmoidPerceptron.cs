using System;
using System.CodeDom;

namespace perceptron.Source
{
	public class SigmoidPerceptron : INeuralNetwork
	{
		private double[] weights;
		private const double learningRate = 0.1;
		private const double errorMargin = 0.01;

		public SigmoidPerceptron()
		{
			weights = new double[2];
		}

		public void Train(int[] input, int desiredValue)
		{
			double output;
			double sum = 0;
			for (int i = 0; i < weights.Length; i++)
			{
				sum += input[i] * weights[i];
			}

			output = Utility.SigmoidF(sum);
			bool correct = Math.Abs(desiredValue - output) < errorMargin;
			Console.WriteLine("{0}, {1}, {2}", desiredValue, input[0], input[1]);
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
				Console.WriteLine("{0}, {1}, {2}, {3}", sum, output, weights[0], weights[1]);
			}
			Console.WriteLine("--------------------------------------------------------");
		}

		public double Use(int[] input)
		{
			double output;
			double sum = 0;
			for (int i = 0; i < weights.Length; i++)
			{
				sum += input[i] * weights[i];
			}

			output = Utility.SigmoidF(sum);
			bool correct = Math.Abs(1 - output) < errorMargin;
			output = correct ? 1 : 0;
//			Console.WriteLine("{0}, {1}", sum, output);
			return (int) output;
		}
		
		public override string ToString()
		{
			string s = "weight0: " + weights[0];
			s += "\nweight1: " + weights[1];

			return s;
		}
	}
}