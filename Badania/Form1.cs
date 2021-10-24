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
    public class Pacjent
    {
        public Pacjent Następny;
        public object Value;
    }

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            date.Text = DateTime.Now.ToString("dd/MM/yyyy");

            //time.Text = DateTime.Now.ToString("HH/mm/ss");
            timer1.Start();
        }

        //aktualny czas
        private void timer1_Tick(object sender, EventArgs e)
        {
            time.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        //messageBoxy
        private void button_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Potrzebne jest twoje imię", "Błędne dane", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            if (textBox2.Text == "")
            {
                MessageBox.Show("Wypełnij cały formularz!", "Błędne dane", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
