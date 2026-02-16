using System;
using System.Collections.Generic;
using System.Text;

namespace WinFormsApp1
{
    internal class SudokuBoard
    {

        public Dictionary<int, SudokuRow> RowsDictionary { get; set; } = new Dictionary<int, SudokuRow>();

        public Dictionary<int, SudokuColumn> ColumnsDictionary { get; set; } = new Dictionary<int, SudokuColumn>();
        public SudokuBoard()
        {
                for (int i = 1; i <= 9; i++)
                {
                    RowsDictionary.Add(i, new SudokuRow(i));
                    ColumnsDictionary.Add(i, new SudokuColumn(i));
                }

        }

        public void insertValue(int row_index, int col_index, int value)
        {
            if(row_index >= 1 && row_index <= 9 && col_index >= 1 && col_index <= 9)
            {
                RowsDictionary[row_index].AddValue(value, col_index);
                ColumnsDictionary[col_index].AddValue(value, row_index);
            }       
        }

        public void removeValue(int row_index, int col_index)
        {
            if (row_index >= 1 && row_index <= 9 && col_index >= 1 && col_index <= 9)
            {
                RowsDictionary[row_index].RemoveValue(col_index);
                ColumnsDictionary[col_index].RemoveValue(row_index);
            }
        }

    }
}
