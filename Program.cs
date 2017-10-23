using System;
using perceptron.Source;

namespace perceptron
{
	internal class Program
	{
		public static void Main(string[] args)
		{
			TrainAndUseAndGate();
			TrainAndUseOrGate();
			TrainAndUseAndGateSigmoid();
			TrainAndUseOrGateSigmoid();
//			TrainAndUseXorGate();
		}

		private static void TrainAndUseAndGate()
		{
			Console.WriteLine("Step AND Gate");
			var andGate = new StepPerceptron();
			andGate.Train(new [] {0, 0}, 0, 100);
			andGate.Train(new [] {0, 1}, 0, 100);
			andGate.Train(new [] {1, 0}, 0, 100);
			andGate.Train(new [] {1, 1}, 1, 100);
			Console.WriteLine(andGate.Use(new[] {0, 0}));
			Console.WriteLine(andGate.Use(new[] {0, 1}));
			Console.WriteLine(andGate.Use(new[] {1, 0}));
			Console.WriteLine(andGate.Use(new[] {1, 1}));
		}
		
		private static void TrainAndUseOrGate()
		{
			Console.WriteLine("Step OR Gate");
			var orGate = new StepPerceptron();
			orGate.Train(new [] {0, 0}, 0, 100);
			orGate.Train(new [] {0, 1}, 1, 100);
			orGate.Train(new [] {1, 0}, 1, 100);
			orGate.Train(new [] {1, 1}, 1, 100);
			Console.WriteLine(orGate.Use(new[] {0, 0}));
			Console.WriteLine(orGate.Use(new[] {0, 1}));
			Console.WriteLine(orGate.Use(new[] {1, 0}));
			Console.WriteLine(orGate.Use(new[] {1, 1}));
		}

		private static void TrainAndUseAndGateSigmoid()
		{
			Console.WriteLine("Sigmoid AND Gate");
			var andGate = new SigmoidPerceptron();
			andGate.Train(new [] {0, 0}, 0, 1000);
			andGate.Train(new [] {0, 1}, 0, 1000);
			andGate.Train(new [] {1, 0}, 0, 1000);
			andGate.Train(new [] {1, 1}, 1, 1000);
			Console.WriteLine(andGate.Use(new[] {0, 0}));
			Console.WriteLine(andGate.Use(new[] {0, 1}));
			Console.WriteLine(andGate.Use(new[] {1, 0}));
			Console.WriteLine(andGate.Use(new[] {1, 1}));
		}

		private static void TrainAndUseOrGateSigmoid()
		{
			Console.WriteLine("Sigmoid OR Gate");
			var orGate = new SigmoidPerceptron();
			orGate.Train(new [] {0, 0}, 0, 10000);
			orGate.Train(new [] {0, 1}, 1, 10000);
			orGate.Train(new [] {1, 0}, 1, 10000);
			orGate.Train(new [] {1, 1}, 1, 10000);
			Console.WriteLine(orGate.Use(new[] {0, 0}));
			Console.WriteLine(orGate.Use(new[] {0, 1}));
			Console.WriteLine(orGate.Use(new[] {1, 0}));
			Console.WriteLine(orGate.Use(new[] {1, 1}));
		}

		private static void TrainAndUseXorGate()
		{
			Console.WriteLine("XOR Gate");
			var xorGate = new XorGate();
//			xorGate.Train(new [] {0, 0}, 0, 10000);
			xorGate.Train(new [] {1, 0}, 1, 10000);
			xorGate.Train(new [] {0, 1}, 1, 10000);
			xorGate.Train(new [] {1, 1}, 0, 10000);
			Console.WriteLine(xorGate.Use(new [] {0, 0}));
			Console.WriteLine(xorGate.Use(new [] {1, 0}));
			Console.WriteLine(xorGate.Use(new [] {0, 1}));
			Console.WriteLine(xorGate.Use(new [] {1, 1}));
		}
	}
}