namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            submitbtn = new Button();
            textBox1 = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(123, 129);
            label1.Name = "label1";
            label1.Size = new Size(192, 32);
            label1.TabIndex = 0;
            label1.Text = "enter your name";
            label1.Click += label1_Click;
            // 
            // submitbtn
            // 
            submitbtn.Location = new Point(212, 234);
            submitbtn.Name = "submitbtn";
            submitbtn.Size = new Size(358, 46);
            submitbtn.TabIndex = 1;
            submitbtn.Text = "submit";
            submitbtn.UseVisualStyleBackColor = true;
            submitbtn.Click += submitbtn_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(369, 129);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(256, 39);
            textBox1.TabIndex = 2;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Info;
            ClientSize = new Size(800, 450);
            Controls.Add(textBox1);
            Controls.Add(submitbtn);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button submitbtn;
        private TextBox textBox1;
    }
}
