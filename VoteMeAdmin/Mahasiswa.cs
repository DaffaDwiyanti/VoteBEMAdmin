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
    public partial class Mahasiswa : Form
    {

        Koneksi konn = new Koneksi();
        public void Simpan()
        {
            SqlConnection conn = konn.getConnection();
            conn.Open();
            string sql = "insert into Mahasiswa Values('" + txtNIM.Text + "','" + txtNama.Text + "', '" + txtTempatLahir.Text + "','" + dtpTanggal.Text + "','" + txtJurusan.Text + "','" + txtProdi.Text + "','" + txtPassword.Text + "')";

            SqlCommand com = new SqlCommand(sql, conn);
            com.ExecuteNonQuery();
            conn.Close();
        }


        public void Hapus()
        {
            SqlConnection conn = konn.getConnection();
            conn.Open();
            string sql = "DELETE FROM Mahasiswa WHERE NIM='" + txtNIM.Text + "'";

            SqlCommand com = new SqlCommand(sql, conn);
            com.ExecuteNonQuery();
            conn.Close();
        }


        public void Update()
        {
            SqlConnection conn = konn.getConnection();
            conn.Open();
            string sql = "UPDATE Mahasiswa SET Nama'" + txtNama.Text + "',Tempat_Lahir='" + txtTempatLahir.Text + "',Tanggal_Lahir='" + dtpTanggal.Text + "',Jurusan='" + txtJurusan.Text + "',Prodi='" + txtProdi.Text + "',Password='" + txtPassword.Text + "' WHERE NIM='" + txtNIM.Text + "'";

            SqlCommand com = new SqlCommand(sql, conn);
            com.ExecuteNonQuery();
            conn.Close();
        }

        public Mahasiswa()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
