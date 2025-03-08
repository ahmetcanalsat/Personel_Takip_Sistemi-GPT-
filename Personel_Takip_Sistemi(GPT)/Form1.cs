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

namespace Personel_Takip_Sistemi_GPT_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection(@"Data Source=DESKTOP-9V0QTA2\MSSQL2022;Initial Catalog=DB_PERSONEL_TAKIP;Integrated Security=True");

        void VeriYazdir()
        {
            // VERİLERİ DataGridView İÇERİSİNDE GÖSTERME
            baglan.Open();
            SqlDataAdapter da = new SqlDataAdapter("Execute VeriListele", baglan);
            DataTable dt = new DataTable();
            da.Fill(dt);
            baglan.Close();
            dataGridView1.DataSource = dt;
        }
        void DepartmanCagir()
        {
            // DEPARTMANLARI ComboBox'da GÖSTERME
            SqlCommand dprtmn_Cagir = new SqlCommand("SELECT * FROM TBL_DEPARTMENT", baglan);
            SqlDataAdapter dprtmn_da = new SqlDataAdapter(dprtmn_Cagir);
            DataTable dprtmn_dt = new DataTable();
            dprtmn_da.Fill(dprtmn_dt);
            cmb_persDepartman.ValueMember = "ID";
            cmb_persDepartman.DisplayMember = "AD";
            cmb_persDepartman.DataSource = dprtmn_dt;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            VeriYazdir();
            DepartmanCagir();
            cmb_persCinsiyet.Items.Add("Erkek");
            cmb_persCinsiyet.Items.Add("Kadın");
        }

        void PersonelEkle()
        {
            string cinsiyet = cmb_persCinsiyet.SelectedItem.ToString();
            byte SQLCinsiyet = 1;
            switch (cinsiyet)
            {
                case "Erkek":
                    SQLCinsiyet = 1;
                    break;
                case "Kadın":
                    SQLCinsiyet = 0;
                    break;
                default:
                    MessageBox.Show("HATALI CİNSİYET GİRDİSİ", "UYARI", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                    break;
            }
            try
            {
                baglan.Open();
                SqlCommand pers_Ekle = new SqlCommand("INSERT INTO TBL_EMPLOYEE(AD,SOYAD,DEPARTMAN,CINSIYET) VALUES (@p1,@p2,@p3,@p4)", baglan);
                pers_Ekle.Parameters.AddWithValue("@p1", txt_persAd.Text.ToUpper());
                pers_Ekle.Parameters.AddWithValue("@p2", txt_persSoyad.Text.ToUpper());
                pers_Ekle.Parameters.AddWithValue("@p3", cmb_persDepartman.SelectedValue.ToString().ToUpper());
                pers_Ekle.Parameters.AddWithValue("@p4", SQLCinsiyet);
                pers_Ekle.ExecuteNonQuery();
                baglan.Close();
                MessageBox.Show("Personel başarıyla sisteme eklendi.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                VeriYazdir();
            }
            catch (Exception ex)
            {
                MessageBox.Show("HATA OLUŞTU: " + ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (baglan.State == ConnectionState.Open) // BAĞLANTININ AÇIK OLUP OLMADIĞINI KONTROL EDER.
                {
                    baglan.Close();
                }
            }

        }

        private void btn_persEkle_Click(object sender, EventArgs e)
        {
            PersonelEkle();
        }
    }
}
