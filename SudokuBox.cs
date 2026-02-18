using System;
using System.Collections.Generic;
using System.Text;

namespace SudokuGame
{
    internal class SudokuBox
    {
        private Point location { get; set; } // X for row, Y for column

        private int box_size { get; set; } = AppSettings.BOX_SIZE;

        private Dictionary<Point, int> values_dict { get; set; } = new Dictionary<Point, int>();

        private HashSet<int> MissingValues { get; set; } = new HashSet<int>();

        public SudokuBox(Point location)
        {
            this.location = location;
            for (int i = 1; i <= AppSettings.ROW_COL_SIZE; i++)
            {
                MissingValues.Add(i);
            }
        }

        public void insertValue(Point location, int value)
        {
            values_dict[location] = value;
            MissingValues.Remove(value);

        }

        public void removeValue(Point location)
        {
            if(values_dict.TryGetValue(location, out var value))
            {
                MissingValues.Add(value);
                values_dict.Remove(location);
            }
            
        }
    }
}
