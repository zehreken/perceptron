using System;
using System.CodeDom;

namespace perceptron.Source
{
	public class SigmoidPerceptron : INeuralNetwork
	{
		private double[] weights;
		private double learningRate = 0.1;
		private const double errorMargin = 0.01;

		public SigmoidPerceptron(double learningRate = 0.1)
		{
			this.learningRate = learningRate;
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
//			bool correct = desiredValue == (output > 0.5 ? 1 : 0);
			Console.WriteLine("sum: {0:0.00} output: {1:0.00} w0: {2:0.00} w1: {3:0.00} desired: {4:0.00} i0: {5:0.00} i1: {6:0.00}", sum, output, weights[0], weights[1], desiredValue, input[0], input[1]);
			if (!correct)
			{
				for (int i = 0; i < weights.Length; i++)
				{
					if (input[i] > 0)
					{
						weights[i] += (desiredValue - output) * learningRate;
					}
				}
//				Console.WriteLine("{0}, {1}, {2}, {3}", sum, output, weights[0], weights[1]);
			}
//			Console.WriteLine("--------------------------------------------------------");
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
//			output = output > 0.5 ? 1 : 0;
			return output;
		}

		public override string ToString()
		{
			string s = "weight0: " + weights[0];
			s += "\nweight1: " + weights[1];

			return s;
		}
	}
}