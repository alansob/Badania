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
        public static Form1 instance;
        public Form1()
        {
            InitializeComponent();
            instance = this;
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
                //otwarcie Forma 2
                Form2 form = new Form2();
                form.Show();
            }
            Form2.instance.lab1.Text = textBox1.Text;
            Form2.instance.lab5.Text = textBox2.Text;
            Form2.instance.lab6.Text = dateTimePicker1.Text;

            string I = textBox1.Text;
            string B = textBox2.Text;
            string D = dateTimePicker1.Text;

            Form2.instance.lab1.Text = I + ", " + B + "   " + D;

            if(textBox1.Text == "")
            {
                isOpen = true;
            }
        }

        //Sprawdzenie danych
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Uzupełnij wszystkie pola!", "Błędne dane", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            if (textBox1.Text != "" && textBox2.Text != "")
            {
                MessageBox.Show("Dane się zgadzają", "komunikat", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
