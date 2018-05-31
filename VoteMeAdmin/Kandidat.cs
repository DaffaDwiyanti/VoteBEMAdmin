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
                FileStream fs = new FileStream(txtFoto.Text, FileMode.Open, FileAccess.Read);
                byte[] image = new byte[fs.Length];
                fs.Read(image, 0, Convert.ToInt32(fs.Length));

                SqlConnection conn = konn.getConnection();
                using (conn)
                {
                    conn.Open();
                    string sql = "insert into Kandidat Values(@Nomor, @NIM, @Visi, @Misi, @Foto)";
                    SqlCommand com = new SqlCommand(sql, conn);
                    using (com)
                    {
                        com.Parameters.AddWithValue("@Nomor", txtNomor.Text);
                        com.Parameters.AddWithValue("@NIM", txtNIM.Text);
                        com.Parameters.AddWithValue("@Visi", txtVisi.Text);
                        com.Parameters.AddWithValue("@Misi", txtMisi.Text);
                        com.Parameters.AddWithValue("@Foto", image);
                        //SqlParameter foto = new SqlParameter("@Foto", SqlDbType.VarBinary, image.Length, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Current, image);
                        com.ExecuteNonQuery();
                    }

                    conn.Close();

                    MessageBox.Show("Berhasil");
                }


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
                FileStream fs = new FileStream(txtFoto.Text, FileMode.Open, FileAccess.Read);
                byte[] image = new byte[fs.Length];
                fs.Read(image, 0, Convert.ToInt32(fs.Length));

                SqlConnection conn = konn.getConnection();
                using (conn)
                {
                    conn.Open();
                    string sql = "UPDATE Kandidat SET NIM= @NIM, Visi= @Visi, Misi= @Misi, Foto= @Foto WHERE Nomor= @Nomor";

                    SqlCommand com = new SqlCommand(sql, conn);
                    using (com)
                    {
                        com.Parameters.AddWithValue("@Nomor", txtNomor.Text);
                        com.Parameters.AddWithValue("@NIM", txtNIM.Text);
                        com.Parameters.AddWithValue("@Visi", txtVisi.Text);
                        com.Parameters.AddWithValue("@Misi", txtMisi.Text);
                        com.Parameters.AddWithValue("@Foto", image);
                        com.ExecuteNonQuery();
                    }

                    conn.Close();

                    MessageBox.Show("Berhasil");
                }


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
                txtFoto.Text = fileName;
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

        private void txtFoto_TextChanged(object sender, EventArgs e)
        {
            string path = txtFoto.Text;
            pictureBox1.Image = Image.FromFile(@path);
        }
    }
}
