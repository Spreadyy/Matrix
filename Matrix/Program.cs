using System;
using ConsoleTables.Core;

namespace Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            Matrix m1 = new Matrix(new double[,]{
                { 3.14, 2.41 },
                { 1.56, 21.4 }
            });
            Matrix m2 = new Matrix(new double[,]{
                { 23.1, 4.13 },
                { 8.52, 41.4 }
            });

            PrintTable(m1.GetStringValues());
            PrintTable(m2.GetStringValues());
            PrintTable((m1 + m2).GetStringValues());
            PrintTable((m1 * m2).GetStringValues());
            Console.ReadLine();
        }

        static void PrintTable(string[,] table)
        {
            ConsoleTable consoleTable = new ConsoleTable();
            for (int row = 0; row < table.GetLength(0); row++)
            {
                int rowLength = table.GetLength(1);
                var rowArr = new string[rowLength];
                for (int column = 0; column < rowLength; column++)
                {
                    rowArr[column] = table[row, column];
                }
                if (row == 0)
                {
                    consoleTable.AddColumn(rowArr);
                }
                else
                {
                    consoleTable.AddRow(rowArr);
                }
            }
            consoleTable.Write(Format.Alternative);
        }
    }
}
