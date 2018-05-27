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

namespace VoteMeAdmin
{
    public partial class Jurusan : Form
    {
        Koneksi konn = new Koneksi();
        public void Simpan()
        {
            try
            {
                SqlConnection conn = konn.getConnection();
                conn.Open();
                string sql = "insert into Jurusan Values('" + txtIDJ.Text + "','" + txtJurusan.Text + "')";

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
                string sql = "DELETE FROM Jurusan WHERE ID='" + txtIDJ.Text + "'";

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
                string sql = "UPDATE Jurusan SET Nama='" + txtJurusan.Text + "' WHERE ID='" + txtIDJ.Text + "'";

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

        public Jurusan()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Simpan();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hapus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Update();
        }
    }
}
