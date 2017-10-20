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
			simple.Train(new int[] {1, 1}, 1, 100);
		}
	}
}