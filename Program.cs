using System;
using System.Collections.Generic;
using perceptron.Source;

namespace perceptron
{
	internal class Program
	{
		public static void Main(string[] args)
		{
			var simple = new Simple();
			simple.Train(new int[] {0, 1}, 0, 100);
		}
	}
}