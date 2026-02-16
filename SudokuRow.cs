using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace WinFormsApp1
{
    internal class SudokuRow
    {
        public int RowIndex { get; set; }
        public Dictionary<int,int> values { get; set; } = new Dictionary<int,int>();

        public HashSet<int> MissingValues { get; set; } = new HashSet<int>();

        public int[] ints = new int[10];
        public SudokuRow(int rowIndex)
        {
            RowIndex = rowIndex;
            for (int i = 1; i <= 9; i++)
            {
                MissingValues.Add(i);        
            }
        }

        public void AddValue(int value, int col_index)
        {
            values.Add(col_index, value);
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
    }
}
