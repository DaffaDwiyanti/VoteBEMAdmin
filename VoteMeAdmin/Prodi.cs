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
    public partial class Prodi : Form
    {
        //try
        //    {

        //          MessageBox.Show("Berhasil");
        //    }
        //    catch (Exception e)
        //    {
        //        MessageBox.Show("gagal" + e);
        //    }

    Koneksi konn = new Koneksi();
        public void Simpan()
        {
            try
            {
                SqlConnection conn = konn.getConnection();
                conn.Open();
                string sql = "INSERT INTO Prodi Values('" + txtIDJ.Text + "','" + txtIDP.Text + "','" + txtNama.Text + "')";

                SqlCommand com = new SqlCommand(sql, conn);
                com.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Berhasil");
            }
            catch (Exception e)
            {
                MessageBox.Show("gagal" +e);
            }
        }


        public void Hapus()
        {
            try
            {
                SqlConnection conn = konn.getConnection();
                conn.Open();
                string sql = "DELETE FROM Prodi WHERE ID_prodi='" + txtIDP.Text + "'";

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
                string sql = "UPDATE Prodi SET ID_jur='" + txtIDJ.Text + "', ID_prodi='" + txtIDP.Text + "', Nama='" + txtNama.Text + "' WHERE ID_prodi='" + txtIDP.Text + "'";

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
        public Prodi()
        {
            InitializeComponent();
        }

        private void Prodi_Load(object sender, EventArgs e)
        {

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
