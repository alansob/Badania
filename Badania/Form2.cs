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

        //nie mozna otworzyc formow kilka razy
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

        //Import z pliku .txt, działa
        private void button2_Click(object sender, EventArgs e)
        {
            string[] lines = File.ReadAllLines(@"C:\Users\Alan\Desktop\kolejka.txt");
            string[] values;

            for (int i = 0; i < lines.Length; i++)
            {
                values = lines[i].ToString().Split('|');
                string[] row = new string[values.Length];

                for (int j = 0; j < values.Length; j++)
                {
                    row[j] = values[j].Trim();
                }
                dataGridView1.Rows.Add(row);
            }
        }

        //Eksport do pliku .txt, działa
        private void button3_Click(object sender, EventArgs e)
        {
            TextWriter writer = new StreamWriter(@"C:\Users\Alan\Desktop\kolejka.txt");
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                for(int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    writer.Write("\t" + dataGridView1.Rows[i].Cells[j].Value.ToString() + "\t" + "|");
                }
                writer.WriteLine("|");
            }
            writer.Close();
            MessageBox.Show("Eksport udany", "komunikat", MessageBoxButtons.OK, MessageBoxIcon.Information); 
        }
    }
}