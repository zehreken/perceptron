using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Channels;
using perceptron.Source;

namespace perceptron
{
	internal class Program
	{
		public static void Main(string[] args)
		{
//			TrainAndUseAndGate();
//			TrainAndUseOrGate();
//			TrainAndUseAndGateSigmoid();
//			TrainAndUseOrGateSigmoid();
			TrainAndUseAndGateBiased();
			TrainAndUseOrGateBiased();
//			TrainAndUseXorGate();
		}

		private static void TrainAndUseAndGate()
		{
			Console.WriteLine("Step AND Gate");
			var trainingInputSet = new List<int[]>
			{
				new[] {0, 0},
				new[] {0, 1},
				new[] {1, 0},
				new[] {1, 1}
			};
			var trainingOutputSet = new[] {0, 0, 0, 1};
			var andGate = new StepPerceptron();

			var random = new Random(0);
			for (int i = 0; i < 100; i++)
			{
				int rnd = random.Next(0, 4);
				andGate.Step(trainingInputSet[rnd], trainingOutputSet[rnd]);
			}
			Console.WriteLine(andGate.Use(new[] {0, 0}));
			Console.WriteLine(andGate.Use(new[] {0, 1}));
			Console.WriteLine(andGate.Use(new[] {1, 0}));
			Console.WriteLine(andGate.Use(new[] {1, 1}));
		}

		private static void TrainAndUseOrGate()
		{
			Console.WriteLine("Step OR Gate");
			var trainingInputSet = new List<int[]>
			{
				new[] {0, 0},
				new[] {0, 1},
				new[] {1, 0},
				new[] {1, 1}
			};
			var trainingOutputSet = new[] {0, 1, 1, 1};
			var orGate = new StepPerceptron();

			var random = new Random(0);
			for (int i = 0; i < 1000; i++)
			{
				int rnd = random.Next(0, 4);
				orGate.Step(trainingInputSet[rnd], trainingOutputSet[rnd]);
			}
			Console.WriteLine(orGate.Use(new[] {0, 0}));
			Console.WriteLine(orGate.Use(new[] {0, 1}));
			Console.WriteLine(orGate.Use(new[] {1, 0}));
			Console.WriteLine(orGate.Use(new[] {1, 1}));
		}

		private static void TrainAndUseAndGateSigmoid()
		{
			Console.WriteLine("Sigmoid AND Gate");
			var trainingInputSet = new List<int[]>
			{
				new[] {0, 0},
				new[] {0, 1},
				new[] {1, 0},
				new[] {1, 1}
			};
			var trainingOutputSet = new[] {0, 0, 0, 1};
			var andGate = new SigmoidPerceptron();

			var random = new Random(0);
			for (int i = 0; i < 100000; i++)
			{
				int rnd = random.Next(0, 4);
				rnd = 3;
				andGate.Step(trainingInputSet[rnd], trainingOutputSet[rnd]);
			}
			Console.WriteLine(andGate.Use(new[] {0, 0}));
			Console.WriteLine(andGate.Use(new[] {0, 1}));
			Console.WriteLine(andGate.Use(new[] {1, 0}));
			Console.WriteLine(andGate.Use(new[] {1, 1}));
		}

		private static void TrainAndUseOrGateSigmoid()
		{
			Console.WriteLine("Sigmoid OR Gate");
			var trainingInputSet = new List<int[]>
			{
				new[] {0, 0},
				new[] {0, 1},
				new[] {1, 0},
				new[] {1, 1}
			};
			var trainingOutputSet = new[] {0, 1, 1, 1};
			var orGate = new SigmoidPerceptron();

			var random = new Random(0);
			for (int i = 0; i < 6000; i++)
			{
				int rnd = random.Next(0, 4);
				orGate.Step(trainingInputSet[rnd], trainingOutputSet[rnd]);
			}
			Console.WriteLine(orGate.Use(new[] {0, 0}));
			Console.WriteLine(orGate.Use(new[] {0, 1}));
			Console.WriteLine(orGate.Use(new[] {1, 0}));
			Console.WriteLine(orGate.Use(new[] {1, 1}));
		}

		private static void TrainAndUseAndGateBiased()
		{
			Console.WriteLine("Biased AND Gate");
			var trainingInputSet = new List<int[]>
			{
				new[] {0, 0},
				new[] {0, 1},
				new[] {1, 0},
				new[] {1, 1}
			};
			var trainingOutputSet = new[] {0, 0, 0, 1};
			var andGate = new BiasedPerceptron();
			
			var random = new Random(0);
			for (int i = 0; i < 1000; i++)
			{
				int rnd = random.Next(0, 4);
				andGate.Step(trainingInputSet[rnd], trainingOutputSet[rnd]);
			}
			Console.WriteLine(andGate.Use(new[] {0, 0}));
			Console.WriteLine(andGate.Use(new[] {0, 1}));
			Console.WriteLine(andGate.Use(new[] {1, 0}));
			Console.WriteLine(andGate.Use(new[] {1, 1}));
		}

		private static void TrainAndUseOrGateBiased()
		{
			Console.WriteLine("Biased OR Gate");
			var trainingInputSet = new List<int[]>
			{
				new[] {0, 0},
				new[] {0, 1},
				new[] {1, 0},
				new[] {1, 1}
			};
			var trainingOutputSet = new[] {0, 1, 1, 1};
			var orGate = new BiasedPerceptron();
			
			var random = new Random(0);
			for (int i = 0; i < 1000; i++)
			{
				int rnd = random.Next(0, 4);
				orGate.Step(trainingInputSet[rnd], trainingOutputSet[rnd]);
			}
			Console.WriteLine(orGate.Use(new[] {0, 0}));
			Console.WriteLine(orGate.Use(new[] {0, 1}));
			Console.WriteLine(orGate.Use(new[] {1, 0}));
			Console.WriteLine(orGate.Use(new[] {1, 1}));
		}

		private static void TrainAndUseXorGate()
		{
			Console.WriteLine("XOR Gate");
			var trainingInputSet = new List<int[]>
			{
				new[] {0, 0},
				new[] {0, 1},
				new[] {1, 0},
				new[] {1, 1}
			};
			var trainingOutputSet = new[] {0, 1, 1, 0};
			var xorGate = new XorGate();

			var random = new Random(0);
			for (int i = 0; i < 100000; i++)
			{
				int rnd = random.Next(0, 4);
				xorGate.Step(trainingInputSet[rnd], trainingOutputSet[rnd], i);
			}
			Console.WriteLine(xorGate.Use(new[] {0, 0}));
			Console.WriteLine(xorGate.Use(new[] {0, 1}));
			Console.WriteLine(xorGate.Use(new[] {1, 0}));
			Console.WriteLine(xorGate.Use(new[] {1, 1}));
		}
	}
}