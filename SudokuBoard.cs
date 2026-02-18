using SudokuGame;
using System;
using System.Collections.Generic;
using System.Text;

namespace WinFormsApp1
{
    internal class SudokuBoard
    {

        private Dictionary<int, SudokuRow> RowsDictionary { get; set; } = new Dictionary<int, SudokuRow>();

        private Dictionary<int, SudokuColumn> ColumnsDictionary { get; set; } = new Dictionary<int, SudokuColumn>();

        private Dictionary<Point, SudokuBox> BoxDictionary { get; set; } = new Dictionary<Point, SudokuBox>();
        public SudokuBoard()
        {
            for (int i = 1; i <= AppSettings.ROW_COL_SIZE; i++)
            {
                RowsDictionary.Add(i, new SudokuRow(i));
                ColumnsDictionary.Add(i, new SudokuColumn(i));
            }

            for (int i = 1; i <= AppSettings.BOX_SIZE; i++)
            {
                for (int j = 1; j <= AppSettings.BOX_SIZE; j++)
                {
                    BoxDictionary.Add(new Point(i, j), new SudokuBox(new Point(i, j)));
                }
            }

        }

        public void insertValue(int row_index, int col_index, int value)
        {
            if (row_index >= 1 && row_index <= AppSettings.ROW_COL_SIZE && col_index >= 1 && col_index <= AppSettings.ROW_COL_SIZE)
            {
                RowsDictionary[row_index].AddValue(value, col_index);
                ColumnsDictionary[col_index].AddValue(value, row_index);
            }
        }

        public void removeValue(int row_index, int col_index)
        {
            if (row_index >= 1 && row_index <= AppSettings.ROW_COL_SIZE && col_index >= 1 && col_index <= AppSettings.ROW_COL_SIZE)
            {
                RowsDictionary[row_index].RemoveValue(col_index);
                ColumnsDictionary[col_index].RemoveValue(row_index);
            }
        }

        public int getValue(int row_index, int col_index)
        {
            if (row_index >= 1 && row_index <= AppSettings.ROW_COL_SIZE && col_index >= 1 && col_index <= AppSettings.ROW_COL_SIZE)
            {
                return RowsDictionary[row_index].getValue(col_index);
            }
            return 0;

        }
    }
}
