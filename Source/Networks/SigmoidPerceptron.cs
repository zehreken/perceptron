using System;

namespace perceptron.Source
{
	public class SigmoidPerceptron : INeuralNetwork
	{
		private readonly double[] _weights;
		private readonly double _learningRate;
		private const double ErrorMargin = 0.01;

		public SigmoidPerceptron(double learningRate = 0.1)
		{
			_learningRate = learningRate;
			_weights = new double[2];
		}

		public bool Train(int[] input, int desiredValue)
		{
			double sum = 0;
			for (int i = 0; i < _weights.Length; i++)
			{
				sum += input[i] * _weights[i];
			}

			var output = Utils.SigmoidF(sum) > 0.5 ? 1 : 0;
			bool correct = desiredValue == output;
			Console.WriteLine("sum: {0:0.00} |output: {1:0.00} |w0: {2:0.00} |w1: {3:0.00} |desired: {4:0.00} |i0: {5:0.00} |i1: {6:0.00}", sum, output, _weights[0], _weights[1], desiredValue, input[0], input[1]);
			if (!correct)
			{
				for (int i = 0; i < _weights.Length; i++)
				{
					if (input[i] > 0)
					{
						_weights[i] += (desiredValue - output) * _learningRate;
					}
				}
			}
			return correct;
		}

		public double Use(int[] input)
		{
			double sum = 0;
			for (int i = 0; i < _weights.Length; i++)
			{
				sum += input[i] * _weights[i];
			}

			var output = Utils.SigmoidF(sum);
			bool correct = Math.Abs(1 - output) < ErrorMargin;
			output = correct ? 1 : 0;
//			output = output > 0.5 ? 1 : 0;
			return output;
		}

		public override string ToString()
		{
			string s = "weight0: " + _weights[0];
			s += "\nweight1: " + _weights[1];

			return s;
		}
	}
}