using System;
using System.Collections.Generic;
using perceptron.Source;

namespace perceptron
{
	internal class Program
	{
		public static void Main(string[] args)
		{
//			Console.WriteLine(Utility.SigmoidF(1));
//			RandomTrainAndUseANN(new StepPerceptron(), Utility.trainingInputSet, Utility.outputAND, 100);
//			RandomTrainAndUseANN(new StepPerceptron(), Utility.trainingInputSet, Utility.outputOR, 100);

//			TrainAndUseANN(new SigmoidPerceptron(), Utility.trainingInputSet, Utility.outputAND, 10000);
//			TrainAndUseANN(new SigmoidPerceptron(), Utility.trainingInputSet, Utility.outputOR, 10000);
//			RandomTrainAndUseANN(new SigmoidPerceptron(), Utility.trainingInputSet, Utility.outputOR, 10000);

//			RandomTrainAndUseANN(new BiasedPerceptron(), Utility.trainingInputSet, Utility.outputAND, 100);
//			RandomTrainAndUseANN(new BiasedPerceptron(), Utility.trainingInputSet, Utility.outputOR, 100);

//			RandomTrainAndUseANN(new XorGate(), Utility.trainingInputSet, Utility.outputXOR, 100);
			TrainAndUseANN(new XorGate(), Utility.trainingInputSet, Utility.outputXOR, 100);
		}

		private static void RandomTrainAndUseANN(INeuralNetwork ann, List<int[]> trainingInputSet, int[] outputSet, int stepCount)
		{
			var random = new Random(0);
			for (int i = 0; i < stepCount; i++)
			{
				int rnd = random.Next(0, 4);
				ann.Train(trainingInputSet[rnd], outputSet[rnd]);
			}
			Console.WriteLine("Trained Network --------------------------------------------------------");
			for (int i = 0; i < trainingInputSet.Count; i++)
			{
				Console.WriteLine(ann.Use(trainingInputSet[i]));
			}
			Console.WriteLine(ann);
		}

		private static void TrainAndUseANN(INeuralNetwork ann, List<int[]> trainingInputSet, int[] outputSet, int stepCount)
		{
			for (int i = 0; i < stepCount; i++)
			{
				int index = i / (stepCount / 4);
				ann.Train(trainingInputSet[index], outputSet[index]);
			}
			Console.WriteLine("Trained Network --------------------------------------------------------");
			for (int i = 0; i < trainingInputSet.Count; i++)
			{
				Console.WriteLine(ann.Use(trainingInputSet[i]));
			}
			Console.WriteLine(ann);
		}
	}
}