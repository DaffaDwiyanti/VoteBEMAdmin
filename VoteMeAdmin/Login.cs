using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace VoteMeAdmin
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        int mouseX = 0, mouseY = 0;
        bool mouseDown;

        // Define the CS_DROPSHADOW constant
        private const int CS_DROPSHADOW = 0x00020000;

        // Override the CreateParams property
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }

        private void close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void upperPanel_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
        }

        private void upperPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                mouseX = MousePosition.X - 200;
                mouseY = MousePosition.Y - 40;
                this.SetDesktopLocation(mouseX, mouseY);
            }
        }

        private void upperPanel_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        public bool dologin(string ID, string Password)
        {
            Koneksi con = new Koneksi();
            SqlConnection sqcon = con.getConnection();

            using (sqcon)
            {
                sqcon.Open();
                string com = "select COUNT (*) from admin where username = @uname AND password = @pwd";
                SqlCommand sqcomm = new SqlCommand(com, sqcon);
                int result = 0;
                using (sqcomm)
                {
                    sqcomm.Parameters.AddWithValue("@pwd", Password);
                    sqcomm.Parameters.AddWithValue("@uname", ID);

                    result = (int)sqcomm.ExecuteScalar();
                    if (result > 0)
                        return true;
                    else
                        return false;
                }
                sqcon.Close();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            bool status = dologin(txtUname.Text, txtPass.Text);
            

            if (status != true)
                lblVal.Visible = true;
            else
            {
                Kandidat kd = new Kandidat();
                kd.Show();
                this.Hide();
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
