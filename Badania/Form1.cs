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
        //poprawa kolejki, nie działa w pełni
        public class Badany
        {
            public Badany Next;
            public string Imie { get; set; }
            public string nazwaBadania { get; set; }
            public string dataBadania { get; set; }

            public Badany(string sImie, string sNazwaBadania, string sDataBadania)
            {
                Imie = sImie;
                nazwaBadania = sNazwaBadania;
                dataBadania = sDataBadania;
            }
        }

        public class ListaBadanych
        {
            private Badany head;
            private Badany current;
            public int Count;

            public ListaBadanych()
            {
                head = null;
                current = head;
                Count = 0;
            }

            public void AddPatient(string sImie, string sNazwaBadania, string sDataBadania)
            {
                Badany newBadany = new Badany(sImie, sNazwaBadania, sDataBadania);
                newBadany.Next = null;
                if (head == null)
                {
                    head = newBadany;
                }
                if (current == null)
                {
                    current = newBadany;
                }
                else
                {
                    current.Next = newBadany;
                    current = newBadany;
                }
                Count++;
            }


            public void DeletePatient(string sImie, string sNazwaBadania, string sDataBadania)
            {
                Badany temp = head;
                Badany p;

                do
                {
                    if (temp.Imie == sImie && temp.nazwaBadania == sNazwaBadania && temp.dataBadania == sDataBadania)
                    {
                        p = head;
                        head = head.Next;
                        p.Next = null;
                        return;
                    }
                    temp = temp.Next;
                } while (temp.Next == null);
            }
        }

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
