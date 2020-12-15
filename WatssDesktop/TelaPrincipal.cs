using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WatssDesktop
{
    public partial class TelaPrincipal : Form
    {
        private Login FormLogin;
        private Mensagens FormMensagens;
        private MeusDados FormMeusDados;
        private int childFormNumber = 0;

        public TelaPrincipal()
        {
            InitializeComponent();
            FormMensagens = new Mensagens();
            FormMensagens.MdiParent = this;
            FormMensagens.SincronizarAutomaticamente();
            FormMensagens.Show();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
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
        //--------------Controle 
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
                FormLogin.Visible = true;
            }
            else
            {
                FormLogin.Visible = true;
            }
        }
        //--------------Fim Controle
        internal void PegaFormLogin(Login login)
        {
            this.FormLogin = login;
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

        private  void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
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

        private async void btnMensagens_Click(object sender, EventArgs e)
        {
            InvisibleAllWindowsChid();
            if (FormMensagens == null)
            {
                FormMensagens = new Mensagens();
                FormMensagens.MdiParent = this;
                FormMensagens.Show();
            }
            else
            {
                FormMensagens.WindowState = FormWindowState.Maximized;
                FormMensagens.Visible = true;
            }
        }
        
        private void InvisibleAllWindowsChid()
        {
            if(FormMensagens != null)
            {
                FormMensagens.Visible = false;
            }
            if(FormMeusDados != null)
            {
                FormMeusDados.Visible = false;
            }
        }

        private void btnMeusDados_Click(object sender, EventArgs e)
        {
            InvisibleAllWindowsChid();
            if(FormMeusDados == null)
            {
                FormMeusDados = new MeusDados();
                FormMeusDados.MdiParent = this;
                FormMeusDados.Show();
            }
            else
            {
                FormMeusDados.WindowState = FormWindowState.Maximized;
                FormMeusDados.Visible = true;
            }
        }

        private void Fechar_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            FormLogin.Visible = true;
        }
    }
}
