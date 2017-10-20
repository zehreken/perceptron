namespace perceptron.Source
{
	public class Simple
	{
		private float[] weights;
		private float outputLayer;
		private const float learningRate = 0.1f;
		private float threshold = 0.5f;

		public Simple()
		{
			weights = new float[2];
			outputLayer = 0f;
		}

		public void Step()
		{
			
		}

		public void Train(int[] input, int desiredValue)
		{
			float sum = 0f;
			for (int i = 0; i < weights.Length; i++)
			{
				sum += input[i] * weights[i];
			}

			if (sum >= threshold)
			{
				
			}
		}
	}
}