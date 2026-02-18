using SudokuGame;
using System.Xml.Linq;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.Trim();
        }

        private void submitbtn_Click(object sender, EventArgs e)
        {
            string userName = textBox1.Text;

            // 2. Check if it's empty
            if (string.IsNullOrWhiteSpace(userName))
            {
                MessageBox.Show("Please enter a name first!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                // 3. Show a personalized greeting
                MessageBox.Show($"Hello, {userName}! Welcome to WinForms development.", "Success");

                // 4. Change the label text as well
                label1.Text = $"Last user: {userName}";
            }

            Form2 form2 = new Form2();
            form2.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
