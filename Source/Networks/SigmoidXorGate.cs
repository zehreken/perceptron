using System;

namespace perceptron.Source
{
	public class SigmoidXorGate : INeuralNetwork
	{
		private readonly double[,] _inputWeights;
		private readonly double[] _hiddenWeights;
		private const double LearningRate = 0.1;
		private readonly double[] _hiddenBias;
		private readonly double _outputBias;
		private const double Threshold = 0.5;

		public SigmoidXorGate()
		{
			_inputWeights = new double[,] {{1, 1}, {1, 1}};
			_hiddenWeights = new double[] {1, -1};
			_hiddenBias = new double[] {-0.5, -1.5};
			_outputBias = -0.2;
		}

		public bool Train(int[] input, int desiredValue)
		{
			double sum0 = input[0] * _inputWeights[0, 0] + input[1] * _inputWeights[1, 0] + _hiddenBias[0]; // first hidden node
			double h0Input = Utils.SigmoidF(sum0);

			double sum1 = input[0] * _inputWeights[0, 1] + input[1] * _inputWeights[1, 1] + _hiddenBias[1]; // second hidden node
			double h1Input = Utils.SigmoidF(sum1);

			double sumH = h0Input * _hiddenWeights[0] + h1Input * _hiddenWeights[1] + _outputBias;
			double res = Utils.SigmoidF(sumH);

			int output = res > Threshold ? 1 : 0;
			
			Console.WriteLine(res + " " + output);
			Console.WriteLine(ToString());
			Console.WriteLine("-----------------------------------");
			
			bool correct = output == desiredValue;

			if (!correct)
			{
				if (input[0] > 0)
				{
					_inputWeights[0, 0] += (res - h0Input) * LearningRate;
					_inputWeights[0, 1] += (res - h0Input) * LearningRate;
				}

				if (input[1] > 0)
				{
					_inputWeights[1, 0] += (res - h1Input) * LearningRate;
					_inputWeights[1, 1] += (res - h1Input) * LearningRate;
				}

				if (h0Input > 0)
				{
					_hiddenWeights[0] += (desiredValue - res) * LearningRate;
				}

				if (h1Input > 0)
				{
					_hiddenWeights[1] += (desiredValue - res) * LearningRate;
				}
			}

			return correct;
		}

		public double Use(int[] input)
		{
			double sum0 = input[0] * _inputWeights[0, 0] + input[1] * _inputWeights[1, 0] + _hiddenBias[0]; // first hidden node
			double h0Input = Utils.SigmoidF(sum0);

			double sum1 = input[0] * _inputWeights[0, 1] + input[1] * _inputWeights[1, 1] + _hiddenBias[1]; // second hidden node
			double h1Input = Utils.SigmoidF(sum1);

			double sumH = h0Input * _hiddenWeights[0] + h1Input * _hiddenWeights[1] + _outputBias;
			double res = Utils.SigmoidF(sumH);

			int output = res > Threshold ? 1 : 0;
			return output;
		}

		public override string ToString()
		{
			string s = "inputWeights0_0: " + _inputWeights[0, 0];
			s += "\ninputWeights0_1: " + _inputWeights[0, 1];
			s += "\ninputWeights1_0: " + _inputWeights[1, 0];
			s += "\ninputWeights1_1: " + _inputWeights[1, 1];
			s += "\nhiddenWeights0: " + _hiddenWeights[0];
			s += "\nhiddenWeights1: " + _hiddenWeights[1];
			s += "\nhiddenBias0: " + _hiddenBias[0];
			s += "\nhiddenBias1: " + _hiddenBias[1];
			s += "\noutputBias: " + _outputBias;

			return s;
		}
	}
}