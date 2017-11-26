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
			throw new System.NotImplementedException();
		}

		public double Use(int[] input)
		{
			throw new System.NotImplementedException();
		}
	}
}