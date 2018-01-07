using System;

namespace perceptron.Source
{
	public class GenericStepPerceptronNoHidden : INeuralNetwork
	{
		private double[,] weights;
		
		public GenericStepPerceptronNoHidden(int inputNeuronCount)
		{
			if (inputNeuronCount <= 1)
				throw new Exception("Input neuron count should be greater than 1");
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