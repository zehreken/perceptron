namespace perceptron.Source
{
	public class StepPerceptron : INeuralNetwork
	{
		private readonly double[] _weights;
		private const double LearningRate = 0.1;
		private const double Threshold = 0.5;

		public StepPerceptron()
		{
			_weights = new double[2];
		}

		public bool Train(int[] input, int desiredValue)
		{
			double sum = 0;
			for (int i = 0; i < _weights.Length; i++)
			{
				sum += input[i] * _weights[i];
			}

			var output = Utils.StepF(sum, Threshold);
			bool isCorrect = output == desiredValue;

			if (!isCorrect)
			{
				for (int i = 0; i < _weights.Length; i++)
				{
					if (input[i] > 0)
					{
						_weights[i] += (desiredValue - output) * LearningRate;
					}
				}
			}

			return isCorrect;
		}

		public double Use(int[] input)
		{
			double sum = 0;
			for (int i = 0; i < _weights.Length; i++)
			{
				sum += input[i] * _weights[i];
			}

			var output = Utils.StepF(sum, Threshold);
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