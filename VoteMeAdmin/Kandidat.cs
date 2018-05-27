using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Drawing.Imaging;

namespace VoteMeAdmin
{
    public partial class Kandidat : Form
    {
        string targetGambar;
        Koneksi konn = new Koneksi();
        public void Simpan()
        {
            try
            {
                SqlConnection conn = konn.getConnection();
                conn.Open();
                string sql = "insert into Kandidat Values('" + txtNomor.Text + "','" + txtNIM.Text + "','" + txtVisi.Text + "','" + txtMisi.Text + "','" + targetGambar + "')";

                SqlCommand com = new SqlCommand(sql, conn);
                com.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Berhasil");
            }
            catch (Exception e)
            {
                MessageBox.Show("gagal" + e);
            }
        }


        public void Hapus()
        {
            try
            {
                SqlConnection conn = konn.getConnection();
                conn.Open();
                string sql = "DELETE FROM Kandidat WHERE Nomor='" + txtNomor.Text + "'";

                SqlCommand com = new SqlCommand(sql, conn);
                com.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Berhasil");
            }
            catch (Exception e)
            {
                MessageBox.Show("gagal" + e);
            }
        }


        public void Update()
        {
            try
            {
                SqlConnection conn = konn.getConnection();
                conn.Open();
                string sql = "UPDATE Kandidat SET NIM='" + txtNIM.Text + "', Visi='" + txtVisi.Text + "', Misi='" + txtMisi.Text + "', Foto='" + txtFoto.Text + "' WHERE Nomor='" + txtNomor.Text + "'";

                SqlCommand com = new SqlCommand(sql, conn);
                com.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Berhasil");
            }
            catch (Exception e)
            {
                MessageBox.Show("gagal" + e);
            }
        }

        public Kandidat()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var fileName = openFileDialog1.FileName;
                targetGambar = Path.Combine("C://Users/Hacim/source/repos/VoteMeAdmin/CDN/", Path.GetFileName(fileName));
                System.IO.File.Copy(fileName, targetGambar);
                if (pictureBox1.Image != null)
                {
                    pictureBox1.Image.Dispose();
                    pictureBox1.Image = Image.FromFile(targetGambar);
                }
                txtFoto.Text = targetGambar;
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Simpan();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Hapus();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Update();
        }
    }
}
