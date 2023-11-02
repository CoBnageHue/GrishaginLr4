using System.Linq;

namespace Гришагин_Лаба_4
{
    class Matrix
    {
        private double[,] matrix;

        public Matrix(double[,] matrix)
        {
            this.matrix = matrix;
        }

        public double[,] GetMatrix()
        {
            return this.matrix;
        }

        public double[] GetRow(int i)
        {
            return Enumerable.Range(0, this.matrix.GetLength(1))
                .Select(x => matrix[i, x])
                .ToArray();
        }

        public double[] GetColumn(int j)
        {
            return Enumerable.Range(0, this.matrix.GetLength(0))
                .Select(x => matrix[x, j])
                .ToArray();
        }

        public void SetElement(int i, int j, double value)
        {
            this.matrix[i, j] = value;
        }

        public double GetElement(int i, int j)
        {
            return this.matrix[i, j];
        }

        public int GetColumnCount()
        {
            return this.matrix.GetLength(1);
        }

        public int GetRowCount()
        {
            return this.matrix.GetLength(0);
        }

        public Matrix GetMatrixWithounRow(int rowIndex)
        {
            double[,] newMatrix = new double[this.matrix.GetLength(0) - 1, this.matrix.GetLength(1)];
            var t = this.matrix.GetLength(0);
            var f = this.matrix.GetLength(1);
            int index = 0;
            for (int i = 0; i < this.matrix.GetLength(0); i++)
            {
                if (rowIndex == i)
                {
                    continue;
                }
                for (int j = 0; j < this.matrix.GetLength(1); j++)
                {
                    newMatrix[index, j] = this.matrix[i, j];W

                }
                index++;
            }

            return new Matrix(newMatrix);
        }
    }

}
