using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;

namespace LoginESenha
{
    public partial class Contato : Form
    {
        public Contato()
        {
            InitializeComponent();
        }

        private void txtEmail_Enter(object sender, EventArgs e)
        {
            if (txtEmail.Text == " Email")
            {
                txtEmail.Clear();
                txtEmail.ForeColor = Color.FromArgb(83, 179, 233);
            }
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            if (txtEmail.Text == "")
            {
              txtEmail.ForeColor = Color.FromArgb(200,200,200);
                txtEmail.Text = " Email";
            }
        }

        private void txtAssunto_Enter(object sender, EventArgs e)
        {
            if (txtAssunto.Text == " Assunto")
            {
                txtEmail.Clear();
                txtEmail.ForeColor = Color.FromArgb(83, 179, 233);
            }
        }

        private void txtAssunto_Leave(object sender, EventArgs e)
        {
            if (txtAssunto.Text == "")
            {
                txtAssunto.ForeColor = Color.FromArgb(200, 200, 200);
                txtAssunto.Text = " Assunto";
            }
        }

        private void txtMensagem_Enter(object sender, EventArgs e)
        {
            if (txtMensagem.Text == " Mensagem")
            {
                txtMensagem.Clear();
                txtMensagem.ForeColor = Color.FromArgb(83, 179, 233);
            }
        }

        private void txtMensagem_Leave(object sender, EventArgs e)
        {
            if (txtMensagem.Text == "")
            {
                txtMensagem.ForeColor = Color.FromArgb(200, 200, 200);
                txtMensagem.Text = " Mensagem";
            }
        }

        private void btnMandarEmail_Click(object sender, EventArgs e)
        {
            string to, from, pass, messageBody;

            MailMessage mensagem = new MailMessage();
            to = txtEmail.Text;
            from = "neurojosnel1@gmail.com";
            pass = "";
            messageBody = txtMensagem.Text;
            mensagem.To.Add(to);
            mensagem.From = new MailAddress(from);
            mensagem.Body = "From : " + "<br> Mensagem : " + messageBody;
            mensagem.Subject = txtAssunto.Text;
            mensagem.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.EnableSsl = true;
            smtp.Port = 587;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(from, pass);

            try
            {
                smtp.Send(mensagem);
                DialogResult code = MessageBox.Show("Email Enviado!", "Sucesso!", MessageBoxButtons.OK);


                if (code == DialogResult.OK)
                {
                    txtAssunto.Clear();
                    txtEmail.Clear();
                    txtMensagem.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lblVoltar_Click(object sender, EventArgs e)
        {
            new Dashboard().Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Contato_Load(object sender, EventArgs e)
        {

        }


        Point lastPoint;

        private void Contato_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void Contato_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }
    }
}
