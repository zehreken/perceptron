using System;
using System.Collections.Generic;
using perceptron.Source;

namespace perceptron
{
	internal class Program
	{
		public static void Main(string[] args)
		{
			TrainAndUseANN(new StepPerceptron(), Utility.trainingInputSet, Utility.outputAND);
			TrainAndUseANN(new StepPerceptron(), Utility.trainingInputSet, Utility.outputOR);
			
			TrainAndUseANN(new SigmoidPerceptron(), Utility.trainingInputSet, Utility.outputOR);
			TrainAndUseANN(new SigmoidPerceptron(), Utility.trainingInputSet, Utility.outputOR);
			
			TrainAndUseANN(new BiasedPerceptron(), Utility.trainingInputSet, Utility.outputOR);
			TrainAndUseANN(new BiasedPerceptron(), Utility.trainingInputSet, Utility.outputOR);
			
			TrainAndUseANN(new XorGate(), Utility.trainingInputSet, Utility.outputXOR);
		}

		private static void TrainAndUseANN(INeuralNetwork ann, List<int[]> trainingInputSet, int[] outputSet)
		{
			var random = new Random(0);
			for (int i = 0; i < 100; i++)
			{
				int rnd = random.Next(0, 4);
				ann.Train(trainingInputSet[rnd], outputSet[rnd]);
			}
			for (int i = 0; i < trainingInputSet.Count; i++)
			{
				Console.WriteLine(ann.Use(trainingInputSet[i]));
			}
			Console.WriteLine(ann);
		}
	}
}