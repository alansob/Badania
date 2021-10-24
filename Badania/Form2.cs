using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Badania
{
    public partial class Form2 : Form
    {
        public static Form2 instance;
        public Form2()
        {
            InitializeComponent();
            instance = this;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool isOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if(f.Text == "Form1")
                {
                    isOpen = true;
                }
            }

            if (isOpen == false)
            {
                Form1 F1 = new Form1(this);
                F1.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string[] lines = File.ReadAllLines(@"C:\Users\Alan\Desktop\kolejka.txt");
            string[] values;

            for (int i = 0; i < lines.Length; i++)
            {
                values = lines[i].ToString().Split('/');
                string[] row = new string[values.Length];

                for (int j = 0; j < values.Length; j++)
                {
                    row[j] = values[j].Trim();
                }
                dataGridView1.Rows.Add(row);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TextWriter writer = new StreamWriter(@'')
        }
    }
}