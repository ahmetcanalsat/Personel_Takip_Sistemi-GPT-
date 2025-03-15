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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
            dataGridView1.Columns[0].Visible = false;
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
            VeriYazdir();
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
            try
            {
                baglan.Open();

                // Çalışan ID'sini al
                int calisan_ID;
                if (!int.TryParse(dataGridView1.SelectedRows[0].Cells["ID"].Value.ToString(), out calisan_ID))
                {
                    MessageBox.Show("Çalışan ID geçersiz.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Cinsiyet bilgisini al
                int SQLCinsiyet = -1; // Varsayılan değer
                if (cmb_persCinsiyet.SelectedItem != null)
                {
                    string cinsiyet = cmb_persCinsiyet.SelectedItem.ToString();
                    SQLCinsiyet = (cinsiyet == "ERKEK") ? 1 : (cinsiyet == "KADIN" ? 0 : -1);

                    if (SQLCinsiyet == -1)
                    {
                        MessageBox.Show("HATALI CİNSİYET GİRDİSİ", "UYARI", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                        return; // Hata durumunda fonksiyondan çık
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen bir cinsiyet seçin!", "UYARI", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                    return; // Hata durumunda fonksiyondan çık
                }

                // Departman ID'sini al
                int departmanID;
                if (!int.TryParse(cmb_persDepartman.SelectedValue.ToString(), out departmanID))
                {
                    MessageBox.Show("Departman ID geçersiz.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // SQL sorgusunu hazırla ve parametreleri ekle
                SqlCommand persGuncelle = new SqlCommand("UPDATE TBL_EMPLOYEE SET AD=@p1, SOYAD=@p2, DEPARTMAN=@p3, CINSIYET=@p4 WHERE ID=@p5", baglan);
                persGuncelle.Parameters.AddWithValue("@p1", txt_persAd.Text.ToUpper());
                persGuncelle.Parameters.AddWithValue("@p2", txt_persSoyad.Text.ToUpper());
                persGuncelle.Parameters.AddWithValue("@p3", departmanID);
                persGuncelle.Parameters.AddWithValue("@p4", SQLCinsiyet);
                persGuncelle.Parameters.AddWithValue("@p5", calisan_ID);

                // Sorguyu çalıştır
                persGuncelle.ExecuteNonQuery();

                MessageBox.Show("PERSONEL BAŞARIYLA GÜNCELLENDİ", "BİLGİLENDİRME", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("HATA OLUŞTU: " + ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (baglan.State == ConnectionState.Open)
                {
                    baglan.Close();
                }
            }
        }

        private void btn_Guncelle_Click(object sender, EventArgs e)
        {
            PersBilgiGuncelle();
            VeriYazdir();
        }
    }
}
