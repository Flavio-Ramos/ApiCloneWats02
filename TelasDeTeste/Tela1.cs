using System;
using System.Windows.Forms;

namespace TelasDeTeste
{
    public partial class Tela1 : Form
    {
        private int childFormNumber = 0;
        private LoginTeste LoginTeste;
        private Form1 objForm1;
        private Tela2 objTela2;
        private Tela3 objTela3;
        public Tela1()
        {
            InitializeComponent();

        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }
        public bool ClosedByXButtonOrAltF4 { get; private set; }
        private const int SC_CLOSE = 0xF060;
        private const int WM_SYSCOMMAND = 0x0112;
        protected override void WndProc(ref Message msg)
        {
            if (msg.Msg == WM_SYSCOMMAND && msg.WParam.ToInt32() == SC_CLOSE)
                ClosedByXButtonOrAltF4 = true;
            base.WndProc(ref msg);
        }
        protected override void OnShown(EventArgs e)
        {
            ClosedByXButtonOrAltF4 = false;
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (ClosedByXButtonOrAltF4)
            {
                LoginTeste.Visible = true;
            }
            else
            {
                LoginTeste.Visible = true;
            }
        }

        internal void pegaTelaLogin(LoginTeste loginTeste)
        {
            this.LoginTeste = loginTeste;
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void Tela2_Click(object sender, EventArgs e)
        {
            InvisibleAllForms();
            if (objTela2 == null)
            {
                objTela2 = new Tela2();
                objTela2.MdiParent = this;
                objTela2.Show();
            }
            else
            {
                objTela2.Visible = true;
            }
            
        }

        private void Tela3_Click(object sender, EventArgs e)
        {
            InvisibleAllForms();
            if (objTela3 == null)
            {
                objTela3 = new Tela3();
                objTela3.MdiParent = this;
                objTela3.Show();
            }
            else
            {
                objTela3.Visible = true;
            }
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            InvisibleAllForms();
            if (objForm1 == null)
            {
                objForm1 = new Form1();
                objForm1.MdiParent = this;
                objForm1.Show();
            }
            else
            {
                objForm1.Visible = true;
            }
            
        }

        private void InvisibleAllForms()
        {
            if (this.objForm1 != null)
            {
                objForm1.Visible = false;
                //this.objForm1 = null;
            }
            if(this.objTela2 != null)
            {
                this.objTela2.Visible = false;
                //this.objTela2 = null;
            }
            if(this.objTela3 != null)
            {
                this.objTela3.Visible = false;
                //this.objTela3 = null;
            }
        }



        private void Tela1_Load(object sender, EventArgs e)
        {

        }
    }
}
