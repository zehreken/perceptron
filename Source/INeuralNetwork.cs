namespace perceptron.Source
{
	public interface INeuralNetwork
	{
		void Train(int[] input, int desiredValue);
		double Use(int[] input);
	}
}