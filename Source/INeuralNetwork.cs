namespace perceptron.Source
{
	public interface INeuralNetwork
	{
		bool Train(int[] input, int desiredValue);
		double Use(int[] input);
	}
}