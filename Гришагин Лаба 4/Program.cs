using System;
using System.Collections.Generic;
using System.Linq;

namespace Гришагин_Лаба_4
{
    internal class Program
    {
        static double S(double[] sumMeans)
        {
            return sumMeans.Select(x => x * x).Sum();
        }

        static double R(double[] sumMeans, int iCount, int jCount)
        {
            return (12 * S(sumMeans)) / (Math.Pow(iCount, 2) * (Math.Pow(jCount, 3) - jCount));
        }

        static double[] GetSumRanks(Matrix matrix, int size)
        {
            var result = new double[size];

            for (int i = 0; i < size; i++)
            {
                result[i] = matrix.GetColumn(i).Sum();
            }

            return result;
        }

        static double GetSumMean(double sumRank, int iCount, int jCount)
        {
            return sumRank - ((double)((iCount + 1) * jCount) / 2);
        }

        static double[] GetSumMeans(double[] sumRanks, int iCount, int jCount)
        {
            var result = new double[iCount];

            for (int i = 0; i < iCount; i++)
            {
                result[i] = GetSumMean(sumRanks[i], iCount, jCount);
            }

            return result;
        }

        static Dictionary<string, double> Solution(Matrix matrix)
        {
            Dictionary<string, double> result = new Dictionary<string, double>();

            double[] SumRanksAll = GetSumRanks(matrix, matrix.GetColumnCount());
            double[] SumMeansAll = GetSumMeans(SumRanksAll, matrix.GetColumnCount(), matrix.GetRowCount());
            double RAll = R(SumMeansAll, matrix.GetRowCount(), matrix.GetColumnCount());
            result.Add("r_all", RAll);

            double[] rArray = new double[matrix.GetColumnCount()];
            for (int i = 0; i < matrix.GetColumnCount(); i++)
            {
                Matrix newMatrix = matrix.GetMatrixWithounRow(i);
                double[] SumRanksI = GetSumRanks(newMatrix, newMatrix.GetColumnCount());
                double[] SumMeansI = GetSumMeans(SumRanksI, newMatrix.GetColumnCount(), newMatrix.GetRowCount());
                double RI = R(SumMeansI, newMatrix.GetRowCount(), newMatrix.GetColumnCount());
                rArray[i] = RI;
            }
            result.Add("r_i_max", rArray.Max());
            result.Add("index_r_i_max", Array.IndexOf(rArray, rArray.Max()));

            return result;
        }

        static void Main(string[] args)
        {
            var test = new double[,] {
                {1, 2, 3, 7, 5, 6, 4, 8, 10, 9 },
                {1, 3, 2, 4, 5, 6, 7, 8, 9, 10 },
                {1, 4, 3, 2, 5 , 6, 7, 8, 10, 9 },
                {4, 2, 3, 1, 5, 6, 9, 8, 7, 10 },
                {2, 5, 3, 4, 1, 6, 7, 8, 10, 9 },
                {1, 2, 3, 4,6, 5, 7 ,8, 9 ,10 },
                {4, 2, 5, 3, 7, 6, 1, 8, 10, 9 }
            };

            Matrix TestMatrix = new Matrix(test);

            Dictionary<string, double> solution = Solution(TestMatrix);
            Console.ReadKey();
        }
    }
}
