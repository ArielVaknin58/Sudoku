using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SudokuGame
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            CreateDynamicTable(9,9);
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        public void CreateDynamicTable(int rows, int cols)
{
    // 1. Initialize the Table
    TableLayoutPanel table = new TableLayoutPanel
    {
        Dock = DockStyle.Fill,
        ColumnCount = cols,
        RowCount = rows,
        BackColor = Color.Black, // This becomes the "Border" color
        CellBorderStyle = TableLayoutPanelCellBorderStyle.None // Use Margins for borders instead
    };

    // Add a nice margin around the whole grid via the Form's padding
    this.Padding = new Padding(20);

    // 2. Define equal Column and Row sizes
    for (int i = 0; i < cols; i++)
    {
        table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / cols));
    }
    for (int i = 0; i < rows; i++)
    {
        table.RowStyles.Add(new RowStyle(SizeType.Percent, 100f / rows));
    }

    // 3. Fill the table with Labels
    for (int r = 0; r < rows; r++)
    {
        for (int c = 0; c < cols; c++)
        {
            // Logic for Sudoku 3x3 Thick Borders
            // We increase the margin on the top and left of every 3rd cell
            int top = 1, left = 1, right = 0, bottom = 0;
            
            if (r % 3 == 0 && r != 0) top = 4;  // Thick horizontal line
            if (c % 3 == 0 && c != 0) left = 4; // Thick vertical line

            var label = new Label
            {
                Text = "", // Start empty for the game
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                Margin = new Padding(left, top, right, bottom),
                Font = new Font("Arial", 12, FontStyle.Bold)
            };

            // CRITICAL: Add the label to the table!
            table.Controls.Add(label, c, r);
        }
    }

    // 4. Finalize
    this.Controls.Add(table);
}
    }
}
