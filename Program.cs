using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;
using perceptron.Source;

namespace perceptron
{
	internal class Program
	{
		public static void Main(string[] args)
		{
//			OrderTrainAndUseANN(new StepPerceptron(), Utils.trainingInputSet, Utils.outputAND, 100);
//			RandomTrainAndUseANN(new StepPerceptron(), Utils.trainingInputSet, Utils.outputAND, 100);
//			ReverseTrainAndUseANN(new StepPerceptron(), Utils.trainingInputSet, Utils.outputAND, 100);
//			AssertTrainAndUseAnn(new StepPerceptron(), Utils.trainingInputSet, Utils.outputAND, 100);

//			OrderTrainAndUseANN(new StepPerceptron(), Utils.trainingInputSet, Utils.outputOR, 100);
//			RandomTrainAndUseANN(new StepPerceptron(), Utils.trainingInputSet, Utils.outputOR, 100);
//			ReverseTrainAndUseANN(new StepPerceptron(), Utils.trainingInputSet, Utils.outputOR, 100);
//			AssertTrainAndUseAnn(new StepPerceptron(), Utils.trainingInputSet, Utils.outputOR, 100);

//			RandomTrainAndUseANN(new BiasedPerceptron(), Utils.trainingInputSet, Utils.outputAND, 100);
//			RandomTrainAndUseANN(new BiasedPerceptron(), Utils.trainingInputSet, Utils.outputOR, 100);

//			RandomTrainAndUseANN(new SigmoidXorGate(), Utils.trainingInputSet, Utils.outputXOR, 100);
//			OrderTrainAndUseANN(new SigmoidXorGate(), Utils.trainingInputSet, Utils.outputXOR, 100);
//			
//			AssertTrainAndUseAnn(new SigmoidXorGate(), Utils.trainingInputSet, Utils.outputXOR, 1000);

//			AssertTrainAndUseAnn(new StepXorGate(), Utils.trainingInputSet, Utils.outputXOR, 100);
			
			var random = new Random(0);
			var gsp = new GenericStepPerceptronNoHidden(2);
			for (int i = 0; i < 100; i++)
			{
				int rnd = random.Next(0, 4);
//				gsp.Train(, outputSet[rnd]);
			s

//			UseANN(ann, trainingInputSet);

			MatrixTests.Test();
		}

		private static void RandomTrainAndUseANN(INeuralNetwork ann, List<int[]> trainingInputSet, int[] outputSet, int stepCount)
		{
			var random = new Random(0);
			for (int i = 0; i < stepCount; i++)
			{
				int rnd = random.Next(0, 4);
				ann.Train(trainingInputSet[rnd], outputSet[rnd]);
			}

			UseANN(ann, trainingInputSet);
		}

		private static void OrderTrainAndUseANN(INeuralNetwork ann, List<int[]> trainingInputSet, int[] outputSet, int stepCount)
		{
			for (int i = 0; i < stepCount; i++)
			{
				int index = i / (stepCount / 4);
				ann.Train(trainingInputSet[index], outputSet[index]);
			}

			UseANN(ann, trainingInputSet);
		}

		private static void ReverseTrainAndUseANN(INeuralNetwork ann, List<int[]> trainingInputSet, int[] outputSet, int stepCount)
		{
			for (int i = stepCount - 1; i >= 0; i--)
			{
				int index = i / (stepCount / 4);
				ann.Train(trainingInputSet[index], outputSet[index]);
			}

			UseANN(ann, trainingInputSet);
		}

		private static void AssertTrainAndUseAnn(INeuralNetwork ann, List<int[]> trainingInputSet, int[] outputSet, int maxStepCount)
		{
			int index = 0;
			for (int i = 0; i < maxStepCount; i++)
			{
				if (ann.Train(trainingInputSet[index], outputSet[index]))
				{
					Console.WriteLine("step: {0}\t index: {1}\t output:{2}", i, index, outputSet[index]);
					index++;
					if (index == trainingInputSet.Count)
					{
						break;
					}
				}
			}

			UseANN(ann, trainingInputSet);
		}

		private static void UseANN(INeuralNetwork ann, List<int[]> trainingInputSet)
		{
			Console.WriteLine("Trained Network --------------------------------------------------------");
			for (int i = 0; i < trainingInputSet.Count; i++)
			{
				Console.WriteLine(ann.Use(trainingInputSet[i]));
			}

			Console.WriteLine(ann);
		}
	}
}