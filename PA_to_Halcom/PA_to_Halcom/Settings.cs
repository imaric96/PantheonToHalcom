using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PA_to_Halcom
{
    public partial class Settings : Form
    {
        private bool Ugasi = true;
        private string sqlConnection = System.Configuration.ConfigurationManager.ConnectionStrings["SQL"].ConnectionString;
        private string firma = System.Configuration.ConfigurationManager.AppSettings["Firma"];
        private SqlConnectionStringBuilder builder;

        public Settings()
        {
            InitializeComponent();
            builder = new System.Data.SqlClient.SqlConnectionStringBuilder(sqlConnection);

            txtServer.Text = "(local)";
            txtBaza.Text = "IME_BAZE";
            txtKorisnickoIme.Text = "sa";
            //txtLozinka.Text = builder.Password;
            txtNazivFirme.Text = firma;
        }

        public Settings(bool gasi)
        {
            Ugasi = gasi;
            InitializeComponent();
            builder = new System.Data.SqlClient.SqlConnectionStringBuilder(sqlConnection);
            txtServer.Text = builder.DataSource;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
            }
            catch
            {
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
            txtBaza.Text = builder.InitialCatalog;
            txtKorisnickoIme.Text = builder.UserID;
            txtLozinka.Text = builder.Password;
            txtNazivFirme.Text = firma;
        }

        private bool Test()
        {
            try
            {
                string strCon =
        "Data Source=" + txtServer.Text + ";" +
        "Initial Catalog=" + txtBaza.Text + ";" +
        "User id=" + txtKorisnickoIme.Text + ";" +
        "Password=" + txtLozinka.Text + ";";
                using (SqlConnection connection = new SqlConnection(strCon))
                {
                    connection.Open();
                    if (connection.State == ConnectionState.Open)
                    {
                        return true;
                    }
                    connection.Close();
                    if (connection.State == ConnectionState.Closed)
                    {
                        return false;
                    }
                    else
                        return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void BtnTest_Click(object sender, EventArgs e)
        {
            if (Test() == true)
                MessageBox.Show("Veza je uspešno ostvarena!", "Povezano", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Neuspešno povezivanje sa serverom!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void BtnTestNaziv_Click(object sender, EventArgs e)
        {
            if (Test() == true)
            {
                string strCon =
"Data Source=" + txtServer.Text + ";" +
"Initial Catalog=" + txtBaza.Text + ";" +
"User id=" + txtKorisnickoIme.Text + ";" +
"Password=" + txtLozinka.Text + ";";

                using (SqlConnection conn = new SqlConnection(strCon))
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM SUBJEKT WHERE ([NAZIV] = @firma)", conn);
                    cmd.Parameters.AddWithValue("@firma", txtNazivFirme.Text);
                    try
                    {
                        conn.Open();
                        Console.WriteLine(cmd.CommandText);
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            MessageBox.Show("Subjekat je pronađen!", "Povezano", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            throw new Exception();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Uneti subjekat ne postoji u šifarniku, pokušajte ponovo! ", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            else
                MessageBox.Show("Neuspešno povezivanje sa serverom!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void BtnPotvrdi_Click(object sender, EventArgs e)
        {
            if (Test() == true)
            {
                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var connectionStringsSection = (ConnectionStringsSection)config.GetSection("connectionStrings");
                var appSetings = (AppSettingsSection)config.GetSection("appSettings");

                connectionStringsSection.ConnectionStrings["SQL"].ConnectionString = "Data Source=" + txtServer.Text + ";Initial Catalog=" + txtBaza.Text + ";Integrated Security=False;Persist Security Info=False;User ID=" + txtKorisnickoIme.Text + ";Password=" + txtLozinka.Text;
                connectionStringsSection.ConnectionStrings["SQL"].ConnectionString = System.Net.WebUtility.HtmlDecode(connectionStringsSection.ConnectionStrings["SQL"].ConnectionString);
                appSetings.Settings["Firma"].Value = txtNazivFirme.Text;

                Console.WriteLine(connectionStringsSection.ConnectionStrings["SQL"].ConnectionString);
                config.Save();

                ConfigurationManager.RefreshSection("connectionStrings");
                ConfigurationManager.RefreshSection("appSettings");
                Ugasi = false;
                this.DialogResult = DialogResult.OK;
                this.Close();
                Application.Restart();
                Environment.Exit(0);
            }
            else
                MessageBox.Show("Neuspešno povezivanje na server!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Settings_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Ugasi == true)
                Application.Exit();
        }

        private void ProveriIzmene()
        {
            //if (builder.DataSource.ToString().Trim().Equals(txtServer.Text.Trim()) && builder.InitialCatalog.ToString().Trim().Equals(cmbBaza.Text.Trim()) && builder.UserID.ToString().Trim().Equals(txtKorisnickoIme.Text.Trim()) && builder.Password.ToString().Trim().Equals(txtLozinka.Text.Trim()))
            //    btnPotvrdi.Enabled = false;
            //else
            //    btnPotvrdi.Enabled = true;
        }

        private void TxtServer_KeyPress(object sender, KeyPressEventArgs e)
        {
            ProveriIzmene();
        }
    }
}