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
    public partial class Tela3 : Form
    {
        public Tela3()
        {
            InitializeComponent();
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.MdiParent = this;
            form1.Show();
        }

        private void Tela1_Click(object sender, EventArgs e)
        {
            Tela1 tela1 = new Tela1();
            tela1.MdiParent = this;
            tela1.Show();
        }

        private void Tela2_Click(object sender, EventArgs e)
        {
            Tela2 tela2 = new Tela2();
            tela2.MdiParent = this;
            tela2.Show();
        }
    }
}
