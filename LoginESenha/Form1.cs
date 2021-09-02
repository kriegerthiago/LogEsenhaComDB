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
    public partial class frmRegistro : Form
    {
        public frmRegistro()
        {
            InitializeComponent();

           
        }

        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=db_users.mdb");
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataAdapter da = new OleDbDataAdapter();


        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "" && txtSenha.Text == "" && txtConfSenha.Text == "") 
            {
                MessageBox.Show("Os Campos de Usuário e Senha estão vazios", "Falha em registrar-se", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtSenha.Text == txtConfSenha.Text)
            {
                con.Open();

                string register = "INSERT INTO tbl_users VALUES ('" + txtUsuario.Text + "','" + txtSenha.Text+ "' )";
                cmd = new OleDbCommand(register, con);
                cmd.ExecuteNonQuery();
                con.Close();

                txtUsuario.Text = "";
                txtSenha.Text = "";
                txtConfSenha.Text = "";

                MessageBox.Show("Sua Conta Foi Registrada Com Sucesso!", "Sucesso!", MessageBoxButtons.OK);


            }
            else
            {
                MessageBox.Show("Senhas não conferem, tente novamente","Senha Incorreta", MessageBoxButtons.OK);
                txtConfSenha.Text = "";
                txtSenha.Text = "";
                txtSenha.Focus();

            }
        }

        private void frmRegistro_Load(object sender, EventArgs e)
        {

        }

        private void checkboxSenha_CheckedChanged(object sender, EventArgs e)
        {
            if (checkboxSenha.Checked)
            {
                txtSenha.PasswordChar = '\0';
               txtConfSenha.PasswordChar = '\0';


            }
            else
            {
                txtSenha.PasswordChar = '•';
                txtConfSenha.PasswordChar = '•';
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtUsuario.Text = "";
            txtSenha.Text = "";
            txtConfSenha.Text = "";
            txtUsuario.Focus();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            new frmLogin().Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        Point lastPoint;

        private void frmRegistro_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void frmRegistro_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }
    }
    }

