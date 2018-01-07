namespace perceptron.Source
{
	public class GenericStepPerceptron : INeuralNetwork
	{
		private double[,] weights;
		
		public GenericStepPerceptron(int inputNeuronCount, int hiddenNeuronCount)
		{
			weights = new double[inputNeuronCount, hiddenNeuronCount];
		}
		
		public bool Train(int[] input, int desiredValue)
		{
			int output;
			double sum = 0;

			return default(bool);
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