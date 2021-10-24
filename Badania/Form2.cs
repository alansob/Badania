using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Badania
{
    public partial class Form2 : Form
    {
        public static Form2 instance;
        public Label lab1;
        public Label lab5;
        public Label lab6;
        public Form2()
        {
            InitializeComponent();
            instance = this;
            lab1 = label1;
            lab5 = label5;
            lab6 = label6;
        }
    }
}
