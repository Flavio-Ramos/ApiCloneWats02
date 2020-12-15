using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TelasDeTeste
{
    public partial class Tela2 : Form
    {
        public Tela2()
        {
            InitializeComponent();
        }

        private void Tela1_Click(object sender, EventArgs e)
        {
            Tela1 tela1 = new Tela1();
            tela1.Show();
        }

        private void Tela3_Click(object sender, EventArgs e)
        {
            Tela3 tela3 = new Tela3();
            tela3.Show();
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
        }
    }
}
