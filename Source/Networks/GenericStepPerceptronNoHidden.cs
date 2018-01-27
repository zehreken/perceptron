using System;
namespace perceptron.Source
{
	public class GenericStepPerceptronNoHidden : INeuralNetwork
	{
		private double[,] weights;
		private const double learningRate = 0.1;
		private const double threshold = 0.5;

		public GenericStepPerceptronNoHidden(int inputNeuronCount)
		{
			if (inputNeuronCount <= 1)
				throw new Exception("Input neuron count should be greater than 1");
			
			weights = new double[inputNeuronCount, 1];
		}

		public bool Train(int[] input, int desiredValue)
		{
			return default(bool);
		}

		// REVIEW: input matrix has 1 column
		public bool Train(double[,] input, double desiredValue)
		{
			double output;
			double sum = MatrixUtils.Sum(MatrixUtils.Multiply(weights, input));

			output = Utils.StepF(sum, threshold);
			bool correct = output == desiredValue;

			if (!correct)
			{
				for (int i = 0; i < input.Length; i++)
				{
					if (input[i, 0] > 0)
					{
						weights[i, 1] += (desiredValue - output) * learningRate;
					}
				}
			}

			return correct;
		}

		public double Use(int[] input)
		{
			return default(double);
		}

		public override string ToString()
		{
			return default(string);
		}
	}
}