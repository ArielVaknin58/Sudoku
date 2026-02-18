using System;
using System.Collections.Generic;
using System.Text;

namespace SudokuGame
{
    internal class AppSettings
    {
        public static int ROW_COL_SIZE = 9; // Has to be a square of some integer

        public static int BOX_SIZE { get; set; } = (int)(Math.Sqrt(AppSettings.ROW_COL_SIZE));

    }
}
