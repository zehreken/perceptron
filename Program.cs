using System;
using System.Collections.Generic;
using perceptron.Source;

namespace perceptron
{
	internal class Program
	{
		public static void Main(string[] args)
		{
			var simple = new SimplePerceptron();
			simple.Train(new [] {1, 1}, 1, 100);
			
			
			var xorGate = new XorGate();
			xorGate.Train(new [] {0, 0}, 1, 1000);
		}
	}
}