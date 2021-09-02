using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Data.OleDb;

namespace LoginESenha
{
    public partial class Dashboard : Form
    {

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
            );



        public Dashboard()
        {
            InitializeComponent();

                    Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0,0, Width, Height, 25,25));

            pnlNav.Height = btnDashboard.Height;
            pnlNav.Top = btnDashboard.Top;
            pnlNav.Left = btnDashboard.Left;
            btnDashboard.BackColor = Color.FromArgb(46, 51, 73);


        }

        private void Dashboard_Load(object sender, EventArgs e)
        {

        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnDashboard.Height;
            pnlNav.Top = btnDashboard.Top;
            pnlNav.Left = btnDashboard.Left;
            btnDashboard.BackColor = Color.FromArgb(46, 51, 73);



        }

        private void btnAnalise_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnAnalise.Height;
            pnlNav.Top = btnAnalise.Top;
            pnlNav.Left = btnAnalise.Left;
            btnAnalise.BackColor = Color.FromArgb(46, 51, 73);
        }

        private void btnCalendario_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnCalendario.Height;
            pnlNav.Top = btnCalendario.Top;
            pnlNav.Left = btnCalendario.Left;
            btnCalendario.BackColor = Color.FromArgb(46, 51, 73);
        }

        private void btnContato_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnContato.Height;
            pnlNav.Top = btnContato.Top;
            pnlNav.Left = btnContato.Left;
            btnContato.BackColor = Color.FromArgb(46, 51, 73);
            new Contato().Show();
            this.Hide();
        }

        private void btnConfigurar_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnConfigurar.Height;
            pnlNav.Top = btnConfigurar.Top;
            pnlNav.Left = btnConfigurar.Left;
            btnConfigurar.BackColor = Color.FromArgb(46, 51, 73);
        }

        private void btnDashboard_Leave(object sender, EventArgs e)
        {
            btnDashboard.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void btnAnalise_Leave(object sender, EventArgs e)
        {
            btnAnalise.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void btnCalendario_Leave(object sender, EventArgs e)
        {
            btnCalendario.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void btnContato_Leave(object sender, EventArgs e)
        {
            btnContato.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void btnConfigurar_Leave(object sender, EventArgs e)
        {
            btnConfigurar.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            

            new frmLogin().Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.facebook.com");
        }
        Point lastPoint;
        private void Dashboard_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void Dashboard_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }
    }
}
