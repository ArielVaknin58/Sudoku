using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WinFormsApp1;

namespace SudokuGame
{
    public partial class Form2 : Form
    {
        private TableLayoutPanel table;

        private SudokuBoard board = new SudokuBoard();
        public Form2()
        {
            InitializeComponent();
            CreateDynamicTable(9,9);

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void cell_losefocus_event(object sender, EventArgs e)
        {
            TextBox cell = sender as TextBox;
            if (cell != null)
            {
                TableLayoutPanelCellPosition pos = table.GetPositionFromControl(cell);
                int r = pos.Row;
                int c = pos.Column;

                table.Controls.Remove(cell);

                // Re-calculate the margins so the Sudoku lines stay visible
                int top = 1, left = 1;
                if (r % 3 == 0 && r != 0) top = 4;
                if (c % 3 == 0 && c != 0) left = 4;

                Label newLabel = new Label
                {
                    Text = cell.Text,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Fill,
                    BackColor = Color.White,
                    Font = new Font("Arial", 12, FontStyle.Bold),
                    Margin = new Padding(left, top, 0, 0) // Keep the borders!
                };

                newLabel.Click += label_Click; // Re-attach click event!

                // Note the order: Column (c) then Row (r)
                table.Controls.Add(newLabel, c, r);
                if (string.IsNullOrWhiteSpace(cell.Text))
                {
                    int current_value = board.getValue(r + 1, c + 1);
                    newLabel.Text = current_value == 0 ? "" : current_value.ToString();
                }
                else if ((int.TryParse(cell.Text, out int value) && value >= 1 && value <= 9))
                {                  
                    newLabel.Text = value.ToString(); // Update the label with the new value
                }
                else if(!(value >= 1 && value <= 9))
                {
                    newLabel.Text = "";
                }
                cell.Dispose(); // Clean up memory

            }
        }

        private void label_Click(object sender, EventArgs e)
        {
            Label clickedLabel = sender as Label;
            if (clickedLabel != null)
            {
                clickedLabel.Focus();
                TableLayoutPanelCellPosition pos = table.GetPositionFromControl(clickedLabel);

                // 3. Now you have the coordinates!
                int row = pos.Row;
                int col = pos.Column;
                if(int.TryParse(clickedLabel.Text, out int current_value) && current_value >= 1 && current_value <= AppSettings.ROW_COL_SIZE)
                {
                    board.insertValue(row + 1, col + 1, current_value); // Update the board with the new value
                }
                //MessageBox.Show($"You clicked cell: Row {row}, Column {col}");
                table.Controls.Remove(clickedLabel);
                TextBox textBox = new TextBox
                {
                    Dock = DockStyle.Fill,
                    TextAlign = HorizontalAlignment.Center, // Better for Sudoku
                    Font = new Font("Arial", 12, FontStyle.Bold)
                };
                textBox.Leave += cell_losefocus_event;
                table.Controls.Add(textBox, col, row);
                textBox.Focus(); // Automatically puts the cursor in the box
                textBox.SelectAll();
            }

        }

        public void CreateDynamicTable(int rows, int cols)
        {
            // 1. Initialize the Table
            table = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = cols,
                RowCount = rows,
                BackColor = Color.Black, // This becomes the "Border" color
                CellBorderStyle = TableLayoutPanelCellBorderStyle.None // Use Margins for borders instead
            };
            table.Click += (s, e) => { table.Focus(); };
            this.Padding = new Padding(20);

            for (int i = 0; i < cols; i++)
            {
                table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / cols));
            }
            for (int i = 0; i < rows; i++)
            {
                table.RowStyles.Add(new RowStyle(SizeType.Percent, 100f / rows));
            }

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    // Logic for Sudoku 3x3 Thick Borders
                    // We increase the margin on the top and left of every 3rd cell
                    int top = 1, left = 1, right = 0, bottom = 0;
            
                    if (r % 3 == 0 && r != 0) top = 4;  
                    if (c % 3 == 0 && c != 0) left = 4; 

                    var label = new Label
                    {
                        Text = "",
                        TextAlign = ContentAlignment.MiddleCenter,
                        Dock = DockStyle.Fill,
                        TabStop = true, 
                        BackColor = Color.White,
                        Margin = new Padding(left, top, right, bottom),
                        Font = new Font("Arial", 12, FontStyle.Bold)
                    };
                    label.Click += label_Click;
                    table.Controls.Add(label, c, r);
                }
            }

            this.Controls.Add(table);
        }
    }
}
