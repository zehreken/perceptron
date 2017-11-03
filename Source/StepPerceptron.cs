namespace perceptron.Source
{
	public class StepPerceptron : INeuralNetwork
	{
		private double[] weights;
		private const double learningRate = 0.1;
		private const double threshold = 0.5f;

		public StepPerceptron()
		{
			weights = new double[2];
		}

		public bool Train(int[] input, int desiredValue)
		{
			int output;
			double sum = 0;
			for (int i = 0; i < weights.Length; i++)
			{
				sum += input[i] * weights[i];
			}

			output = Utility.StepF(sum, threshold);
			bool correct = output == desiredValue;

			if (!correct)
			{
				for (int i = 0; i < weights.Length; i++)
				{
					if (input[i] > 0)
					{
						weights[i] += (desiredValue - output) * learningRate;
					}
				}
			}

			return correct;
		}

		public double Use(int[] input)
		{
			int output;
			double sum = 0;
			for (int i = 0; i < weights.Length; i++)
			{
				sum += input[i] * weights[i];
			}

			output = Utility.StepF(sum, threshold);
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