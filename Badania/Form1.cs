using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Badania 
{
    public partial class Form1 : Form
    {
        Form2 F2;
        public static Form1 instance;
        public Form1(Form2 f2)
        {
            InitializeComponent();
            instance = this;
            this.F2 = f2;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //aktualna data
            date.Text = DateTime.Now.ToString("dd/MM/yyyy");
            timer1.Start();
        }

        //aktualny czas
        private void timer1_Tick(object sender, EventArgs e)
        {
            time.Text = DateTime.Now.ToString("HH:mm");
        }

        private void button_Click(object sender, EventArgs e)
        {
            F2.dataGridView1.Rows.Add(textBox1.Text, textBox2.Text, dateTimePicker1.Text);

            //nie mozna otworzyc formow kilka razy
            bool isOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "Form2")
                {
                    isOpen = true;
                    f.BringToFront();
                    break;
                }
            }

            if (isOpen == false)
            {
                Form2 form = new Form2();
                form.Show();
            }

            if(textBox1.Text == "")
            {
                isOpen = true;
            }
        }

        //Sprawdzenie danych
        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Uzupełnij wszystkie pola!", "Błędne dane", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Dane się zgadzają", "komunikat", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // usuwanie z kolejki 
        private void button2_Click(object sender, EventArgs e)
        {
            int rowIndex = F2.dataGridView1.CurrentCell.RowIndex;
            F2.dataGridView1.Rows.RemoveAt(rowIndex);
        }
    }
}
