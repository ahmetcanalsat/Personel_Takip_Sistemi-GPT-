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
            dataGridView1.Columns["ID"].Visible = false;
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
            cmb_persCinsiyet.Items.Add("ERKEK");
            cmb_persCinsiyet.Items.Add("KADIN");
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
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_persAd.Text = dataGridView1.Rows[e.RowIndex].Cells["AD"].Value.ToString().ToUpper();
            txt_persSoyad.Text = dataGridView1.Rows[e.RowIndex].Cells["SOYAD"].Value.ToString().ToUpper();

            // Departman ismini al ve ComboBox'ta seçili yap
            string secilenDepartman = dataGridView1.Rows[e.RowIndex].Cells["DEPARTMAN"].Value.ToString();
            cmb_persDepartman.SelectedValue = cmb_persDepartman.Items
                .Cast<DataRowView>()
                .FirstOrDefault(item => item["AD"].ToString() == secilenDepartman)?["ID"];

            // Cinsiyet bilgisini güncelle
            string cinsiyetStr = dataGridView1.Rows[e.RowIndex].Cells["CINSIYET"].Value.ToString().Trim();
            SetCinsiyetComboBox(cinsiyetStr);
        }

        // **Cinsiyet ComboBox'ını güncelleyen metod**
        private void SetCinsiyetComboBox(string cinsiyetStr)
        {
            int index = cmb_persCinsiyet.FindStringExact(cinsiyetStr.ToUpper());

            cmb_persCinsiyet.SelectedIndex = (index >= 0) ? index : -1;
        }
        void PersBilgiGuncelle()
        {
            baglan.Open();
            int calisan_ID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ID"].Value);
            string cinsiyet = cmb_persCinsiyet.SelectedItem.ToString();
            byte SQLCinsiyet = 1;
            switch (cinsiyet)
            {
                case "ERKEK":
                    SQLCinsiyet = 1;
                    break;
                case "KADIN":
                    SQLCinsiyet = 0;
                    break;
                default:
                    MessageBox.Show("HATALI CİNSİYET GİRDİSİ", "UYARI", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                    break;
            }
            SqlCommand persGuncelle = new SqlCommand("UPDATE TBL_EMPLOYEE SET AD=@p1, SOYAD=@p2, DEPARTMAN=@p3, CINSIYET=@p4 WHERE ID=@p5", baglan);
            persGuncelle.Parameters.AddWithValue("@p1", txt_persAd.Text.ToUpper());
            persGuncelle.Parameters.AddWithValue("@p2", txt_persSoyad.Text.ToUpper());
            persGuncelle.Parameters.AddWithValue("@p3", cmb_persDepartman.SelectedItem);
            persGuncelle.Parameters.AddWithValue("@p4", SQLCinsiyet);
            persGuncelle.Parameters.AddWithValue("@p5", calisan_ID);
            persGuncelle.ExecuteNonQuery();
            baglan.Close();
            MessageBox.Show("PERSONEL BAŞARIYLA GÜNCELLENDİ", "BİLGİLENDİRME", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn_Guncelle_Click(object sender, EventArgs e)
        {
            PersBilgiGuncelle();
        }
    }
}
