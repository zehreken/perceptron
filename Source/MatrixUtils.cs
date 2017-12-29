using System;
using System.Collections;

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

//		public static T[,] Multiply<T>(T[,] a, T[,] b) where T : struct, IConvertible
//		{
//			if (a.GetLength(1) != b.GetLength(0))
//				throw new Exception("Matrix dimensions are not suitable for multiplication");
//			
//			T[,] product = new T[a.GetLength(0), b.GetLength(1)];
//			for (int i = 0; i < a.GetLength(0); i++)
//			{
//				for (int j = 0; j < a.GetLength(1); j++)
//				{
//					for (int k = 0; k < b.GetLength(1); k++)
//					{
//						product[i, k] = a[i, j] * b[j, k];
//					}
//				}
//			}
//			return matrix;
//		}

		public static double[,] Multiply(double[,] a, double[,] b)
		{
			if (a.GetLength(1) != b.GetLength(0))
				throw new Exception("Matrix dimensions are not suitable for multiplication");
			
			var product = new double[a.GetLength(0), b.GetLength(1)];
			for (int i = 0; i < a.GetLength(0); i++)
			{
				for (int j = 0; j < a.GetLength(1); j++)
				{
					for (int k = 0; k < b.GetLength(1); k++)
					{
						product[i, k] += a[i, j] * b[j, k];
					}
				}
			}
			
			return product;
		}

		public static double[,] Multiply(double[,] a, double b)
		{
			var product = new double[a.GetLength(0), a.GetLength(1)];
			for (int i = 0; i < a.GetLength(0); i++)
			{
				for (int j = 0; j < a.GetLength(1); j++)
				{
					product[i, j] = a[i, j] * b;
				}
			}

			return product;
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