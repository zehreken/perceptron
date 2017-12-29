using System;

namespace perceptron.Source
{
	public static class MatrixTests
	{
		public static void Test()
		{
			var test = new double[2, 3];
			double temp = 1;
			for (int i = 0; i < test.GetLength(0); i++)
			{
				for (int j = 0; j < test.GetLength(1); j++)
				{
					test[i, j] = temp++;
				}
			}
			Console.WriteLine(test.Printable());
			Console.WriteLine(test.Transpose().Printable());
			
			Console.WriteLine(test.Printable());
			Console.WriteLine(MatrixUtils.Multiply(test.Transpose(), 3).Printable());

			Console.WriteLine(MatrixUtils.Multiply(test, test.Transpose()).Printable());
		}
	}
}