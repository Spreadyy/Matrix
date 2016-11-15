using System;

namespace Matrix
{
    public struct Matrix
    {
        private readonly double[,] Values;

        public Matrix(double[,] values)
        {
            if (values == null)
            {
                throw new ArgumentNullException("values may not be null");
            }
            Values = values;
        }

        public string[,] GetStringValues()
        {
            var stringValues = new string[RowCount(),ColumnCount()];
            for (int row = 0; row < RowCount(); row++)
            {
                for (int column = 0; column < ColumnCount(); column++)
                {
                    stringValues[row, column] = Values[row, column].ToString();
                }
            }
            return stringValues;
        }

        public static Matrix operator +(Matrix left, Matrix right)
        {
            if (left.RowCount() != right.RowCount() ||
                left.ColumnCount() != right.ColumnCount())
            {
                throw new ArgumentException("To calculate the sum of two matrixes they need to have the same row and column count.");
            }

            var newValues = new double[left.RowCount(), left.ColumnCount()];
            for (int row = 0; row < left.RowCount(); row++)
            {
                for (int column = 0; column < left.ColumnCount(); column++)
                {
                    newValues[row, column] = left.Values[row, column] + right.Values[row, column];
                }
            }

            return new Matrix(newValues);
        }

        public static Matrix operator *(Matrix left, Matrix right)
        {
            if (left.ColumnCount() != right.RowCount())
            {
                throw new ArgumentException("To calculate the product of two matrixes the left matrix needs to have as many columns as the right matrix has rows.");
            }

            var newValues = new double[left.RowCount(), right.ColumnCount()];
            for (int leftRow = 0; leftRow < left.RowCount(); leftRow++)
            {
                for (int rightCol = 0; rightCol < right.ColumnCount(); rightCol++)
                {
                    double sum = 0;
                    for (int i = 0; i < left.ColumnCount(); i++)
                    {
                        sum += left.Values[leftRow, i] * right.Values[i, rightCol];
                    }

                    newValues[leftRow, rightCol] = sum;
                }
            }

            return new Matrix(newValues);
        }

        public int RowCount()
        {
            return Values.GetLength(0);
        }

        public int ColumnCount()
        {
            return Values.GetLength(1);
        }
    }
}
