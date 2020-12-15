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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void ChamaTela1_Click(object sender, EventArgs e)
        {
            
            //this.Close();
        }

        private void Tela1_Click(object sender, EventArgs e)
        {
            Tela1 tela1 = new Tela1();
            tela1.Show();
        }

        private void Tela2_Click(object sender, EventArgs e)
        {
            Tela2 tela2 = new Tela2();
            tela2.Show();
        }

        private void Tela3_Click(object sender, EventArgs e)
        {
            Tela3 tela3 = new Tela3();
            tela3.Show();
        }
    }
}
