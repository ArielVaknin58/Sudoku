using SudokuGame;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace WinFormsApp1
{
    internal class SudokuRow
    {
        private int RowIndex { get; set; }
        private Dictionary<int,int> values { get; set; } = new Dictionary<int,int>();

        private HashSet<int> MissingValues { get; set; } = new HashSet<int>();

        private int[] ints = new int[AppSettings.ROW_COL_SIZE + 1];
        public SudokuRow(int rowIndex)
        {
            RowIndex = rowIndex;
            for (int i = 1; i <= AppSettings.ROW_COL_SIZE; i++)
            {
                MissingValues.Add(i);        
            }
        }

        public void AddValue(int value, int col_index)
        {
            values[col_index] = value;
            ints[col_index] = value;
            MissingValues.Remove(value);
        }

        public void RemoveValue(int col_index) 
        {
            if(values.TryGetValue(col_index,out int value))
            {
                values.Remove(col_index);
                ints[col_index] = 0;
                MissingValues.Add(value);
            }              
        }

        public int getValue(int col_index)
        {
            if (values.TryGetValue(col_index, out int value))
            {
                return value;
            }
            return 0;
        }
    }
}
