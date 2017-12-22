using System;

namespace perceptron.Source
{
	public static class MatrixUtils
	{
		public static T[,] Transpose<T>(this T[,] matrix)
		{
			T[,] transposed = new T[matrix.GetLength(1), matrix.GetLength(0)];
			for (int i = 0; i < matrix.GetLength(0); i++)
			{
				for (int j = 0; j < matrix.GetLength(1); j++)
				{
					transposed[j, i] = matrix[i, j];
				}
			}

			return transposed;
		}

		public static string Printable<T>(this T[,] matrix)
		{
			string s = "";
			for (int i = 0; i < matrix.GetLength(0); i++)
			{
				for (int j = 0; j < matrix.GetLength(1); j++)
				{
					s += matrix[i, j] + " ";
				}
				s += "\n";
			}
			
			return s;
		}
	}
}