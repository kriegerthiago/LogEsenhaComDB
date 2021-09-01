using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace LoginESenha
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();

        }

        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=db_users.mdb");
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataAdapter da = new OleDbDataAdapter();

        private void checkboxSenha_CheckedChanged(object sender, EventArgs e)
        {
            if (checkboxSenha.Checked)
            {
                txtSenha.PasswordChar = '\0';
              
                

            }
            else
            {
                txtSenha.PasswordChar = '•';
                
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtUsuario.Text = "";
            txtSenha.Text = "";
           
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            con.Open();
            string login = "SELECT * FROM tbl_users WHERE usuario= '"+txtUsuario.Text+"' and senha= '"+txtSenha.Text+"' ";
            cmd = new OleDbCommand(login, con);
            OleDbDataReader dr = cmd.ExecuteReader();

            if (dr.Read() == true)
            {
                new Dashboard().Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuário ou Senha Inválido. Tente Novamente", "Senha Incorreta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsuario.Text = "";
                txtSenha.Text = "";
                txtUsuario.Focus();
            }




        }

        private void lblRegistro_Click(object sender, EventArgs e)
        {
            new frmRegistro().Show();
            this.Hide();
        }
    }
}
