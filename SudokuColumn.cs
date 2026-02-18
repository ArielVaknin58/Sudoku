using SudokuGame;
using System;
using System.Collections.Generic;
using System.Text;

namespace WinFormsApp1
{
    internal class SudokuColumn
    {
        private int ColumnIndex { get; set; }
        private Dictionary<int, int> values { get; set; } = new Dictionary<int, int>();

        private HashSet<int> MissingValues { get; set; } = new HashSet<int>();

        private int[] ints = new int[AppSettings.ROW_COL_SIZE + 1];
        public SudokuColumn(int colIndex)
        {
            ColumnIndex = colIndex;
            for (int i = 1; i <= AppSettings.ROW_COL_SIZE; i++)
            {
                MissingValues.Add(i);
            }
        }

        public void AddValue(int value, int row_index)
        {
            values.Add(row_index, value);
            ints[row_index] = value;
            MissingValues.Remove(value);
        }

        public void RemoveValue(int row_index)
        {
            if (values.TryGetValue(row_index, out int value))
            {
                values.Remove(row_index);
                ints[row_index] = 0;
                MissingValues.Add(value);
            }
        }
    }
}
