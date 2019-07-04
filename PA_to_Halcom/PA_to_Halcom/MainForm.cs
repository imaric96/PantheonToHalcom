using Dapper;
using DGVPrinterHelper;
using PA_to_Halcom.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace PA_to_Halcom
{
    public partial class MainForm : Form
    {
        private DataTable table;
        private DataTable tableNaseBanke = new DataTable();
        private DataTable tableFilterBanke = new DataTable();
        private DataTable tableFilterFirme = new DataTable();
        private List<SUBJEKTBANKA> nasaFirma = new List<SUBJEKTBANKA>();
        private string dateFormat = "MM/dd/yyyy"; // DD.MM.YYYY za SQL -----  YYYY-MM-DD
        private string vrsteDokumenata;
        private string sqlConnection;
        private string firma;
        private List<string> podaci = new List<string>();

        public MainForm()
        {
            if (IsServerConnected() == false)
            {
                try
                {
                    var Settings = new Settings();
                    Settings.BringToFront();
                    Settings.Activate();
                    Console.WriteLine(false);
                    if (Settings.ShowDialog() == DialogResult.OK)
                        Inicijalizuj();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Došlo je do greške: " + ex, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
                Inicijalizuj();
        }

        private void Inicijalizuj()
        {
            vrsteDokumenata = System.Configuration.ConfigurationManager.AppSettings["VrsteDokumenata"];
            sqlConnection = System.Configuration.ConfigurationManager.ConnectionStrings["SQL"].ConnectionString;
            firma = System.Configuration.ConfigurationManager.AppSettings["Firma"];
            InitializeComponent();
            KreirajTabelu();
            KreirajTabeluNaseBanke();
            KreirajTabeluFilterBanke();
            KreirajTabeluFilterFirme();

            IsTableEmpty();
            PopuniNaseBanke();

            typeof(DataGridView).InvokeMember("DoubleBuffered",
            BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty,
            null, this.dataGridView, new object[] { true });

            SqlConnectionStringBuilder builder = new System.Data.SqlClient.SqlConnectionStringBuilder(sqlConnection);
            lblBaza.Text = "BAZA PODATAKA: " + builder.DataSource + "/" + builder.InitialCatalog;

        }

        private void PreuzmiPodatke()
        {
            ProgressBar.Enabled = true;
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                using (SqlConnection conn = new SqlConnection(sqlConnection))
                {
                    table.Clear();
                    conn.Open();
                    var upit = conn.Query<PROMET>(
                            "SELECT P.KLJUC, P.DATUM, P.DATUMVAL, LTRIM(RTRIM(P.PREJEMNIK)) PREJEMNIK, " +
                            "       LTRIM(RTRIM(P.IZDAJATELJ)) IZDAJATELJ, LTRIM(RTRIM(P.DOKUMENT1)) DOKUMENT1, LTRIM(RTRIM(P.DATDOKUM1)) DATDOKUM1, LTRIM(RTRIM(P.ZAPLACILO)) ZAPLACILO, " +
                            "       LTRIM(RTRIM(SB.BANKA)) BANKA, LTRIM(RTRIM(SB.RACUN1)) RACUN1, LTRIM(RTRIM(PO.NAZIV)) NAZIV " +
                            "FROM PROMET P " +
                            "   LEFT JOIN SUBJEKTBANKA SB ON P.IZDAJATELJ = SB.SUBJEKT AND SB.RACUN23 = 'S' " +
                            "   LEFT JOIN SUBJEKT S ON SB.SUBJEKT = S.NAZIV " +
                            "   LEFT JOIN POSTA PO ON PO.POSTA = S.POSTA " +
                            "WHERE P.DATUM >= '" + dateTimePickerOD.Value.ToString(dateFormat) + "' " +
                            "   AND P.DATUM <= '" + dateTimePickerDO.Value.ToString(dateFormat) + "' " +
                            "   AND P.POSLDOG in (" + vrsteDokumenata + ") " +
                            "ORDER BY P.KLJUC").ToList();
                    int brojac = 1;

                    foreach (PROMET s in upit)
                    {
                        table.Rows.Add(s.KLJUC, Convert.ToDateTime(s.DATUM).ToShortDateString(), Convert.ToDateTime(s.DATUMVAL).ToShortDateString(), s.PREJEMNIK, s.IZDAJATELJ, s.DOKUMENT1, Convert.ToDateTime(s.DATDOKUM1).ToShortDateString(), Math.Round(Convert.ToDecimal(s.ZAPLACILO), 2), s.BANKA, s.RACUN1, s.NAZIV);

                        ProgressBar.Value = (brojac++ * 100) / upit.Count;
                        int percent = (int)(((double)ProgressBar.Value / (double)ProgressBar.Maximum) * 100);
                        ProgressBar.ProgressBar.CreateGraphics().DrawString(percent.ToString() + "%", new Font("Segoe UI", 8, FontStyle.Regular), Brushes.Black, new PointF(ProgressBar.Width / 2 - 10, ProgressBar.Height / 2 - 7));
                    }
                    lblUkupnoZapisa.Text = "Ukupno: " + table.Rows.Count + " zapisa";

                    //FIKSNO
                    this.dataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    this.dataGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    this.dataGridView.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    //FIKSNO
                    //MENJA SE
                    this.dataGridView.Columns[4].MinimumWidth = 125;
                    this.dataGridView.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    this.dataGridView.Columns[5].MinimumWidth = 125;
                    this.dataGridView.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    //MENJA SE
                    //FIKSNO
                    this.dataGridView.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    this.dataGridView.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    this.dataGridView.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    this.dataGridView.Columns[8].DefaultCellStyle.Font = new System.Drawing.Font(dataGridView.Font.Name, dataGridView.Font.Size, FontStyle.Bold);
                    this.dataGridView.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    this.dataGridView.Columns[8].DefaultCellStyle.Format = "N2";
                    //FIKSNO
                    //MENJA SE
                    this.dataGridView.Columns[9].MinimumWidth = 170;
                    this.dataGridView.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    this.dataGridView.Columns[10].MinimumWidth = 130;
                    this.dataGridView.Columns[10].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    this.dataGridView.Columns[12].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    this.dataGridView.Columns[12].Width = 100;
                    //MENJA SE

                    //this.dataGridView.Columns[8].DefaultCellStyle.Format = "N2";

                    dataGridView.DataSource = table;
                    dataGridView.Refresh();

                    //dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
                }
            }
            catch
            {
                // obradi greske
            }
            finally
            {
                Cursor.Current = Cursors.Default;
                ProgressBar.Enabled = false;
            }
        }

        private void KreirajTabelu()
        {
            table = new DataTable();
            table.Columns.Add("KLJUC");
            table.Columns.Add("DATUM");
            table.Columns.Add("DATUMVAL");
            table.Columns.Add("PREJEMNIK");
            table.Columns.Add("IZDAJATELJ");
            table.Columns.Add("DOKUMENT1");
            table.Columns.Add("DATDOKUM1");
            table.Columns.Add("ZAPLACILO");
            table.Columns.Add("BANKA");
            table.Columns.Add("RACUN1");
            table.Columns.Add("NAZIV");

            table.Columns["KLJUC"].ColumnName = "Broj dokumenta";
            table.Columns["DATUM"].ColumnName = "Datum";
            table.Columns["DATUMVAL"].ColumnName = "Valuta";
            table.Columns["PREJEMNIK"].ColumnName = "Primalac";
            table.Columns["IZDAJATELJ"].ColumnName = "Dobavljač";
            table.Columns["DOKUMENT1"].ColumnName = "Dok.dobav.";
            table.Columns["DATDOKUM1"].ColumnName = "Datum dok.";
            table.Columns["ZAPLACILO"].DataType = typeof(Decimal);
            table.Columns["ZAPLACILO"].ColumnName = "Za plaćanje";

            table.Columns["BANKA"].ColumnName = "Banka";
            table.Columns["RACUN1"].ColumnName = "Račun";
            table.Columns["NAZIV"].ColumnName = "Mesto";

            dataGridView.DataSource = table;
            dataGridView.Columns["Mesto"].Visible = false;

            DataGridViewCheckBoxColumn checkBox = new DataGridViewCheckBoxColumn();
            checkBox.ValueType = typeof(bool);
            checkBox.Name = "Export";
            checkBox.HeaderText = "Plati";
            dataGridView.Columns.Add(checkBox);
            dataGridView.ReadOnly = false;
            dataGridView.Columns["Broj dokumenta"].ReadOnly = true;
            dataGridView.Columns["Datum"].ReadOnly = true;
            dataGridView.Columns["Valuta"].ReadOnly = true;
            dataGridView.Columns["Primalac"].ReadOnly = true;
            dataGridView.Columns["Dobavljač"].ReadOnly = true;
            dataGridView.Columns["Dok.dobav."].ReadOnly = true;
            dataGridView.Columns["Datum dok."].ReadOnly = true;

            dataGridView.Columns["Za plaćanje"].ReadOnly = true;
            dataGridView.Columns["Banka"].ReadOnly = true;
            dataGridView.Columns["Račun"].ReadOnly = true;
            dataGridView.Columns["Export"].ReadOnly = false;
        }

        private void KreirajTabeluNaseBanke()
        {
            tableNaseBanke = new DataTable();
            tableNaseBanke.Columns.Add("BANKA");
            tableNaseBanke.Columns.Add("RACUN");
            tableNaseBanke.Columns.Add("MESTO");
            tableNaseBanke.Columns.Add("BANKARACUN");
        }

        private void KreirajTabeluFilterBanke()
        {
            tableFilterBanke = new DataTable();
            tableFilterBanke.Columns.Add("KLJUC");
            tableFilterBanke.Columns.Add("DATUM");
            tableFilterBanke.Columns.Add("DATUMVAL");
            tableFilterBanke.Columns.Add("PREJEMNIK");
            tableFilterBanke.Columns.Add("IZDAJATELJ");
            tableFilterBanke.Columns.Add("DOKUMENT1");
            tableFilterBanke.Columns.Add("DATDOKUM1");
            tableFilterBanke.Columns.Add("ZAPLACILO");
            tableFilterBanke.Columns["ZAPLACILO"].DataType = typeof(Decimal);
            tableFilterBanke.Columns.Add("BANKA");
            tableFilterBanke.Columns.Add("RACUN1");
            tableFilterBanke.Columns.Add("NAZIV");
        }

        private void KreirajTabeluFilterFirme()
        {
            tableFilterBanke = new DataTable();
            tableFilterBanke.Columns.Add("KLJUC");
            tableFilterBanke.Columns.Add("DATUM");
            tableFilterBanke.Columns.Add("DATUMVAL");
            tableFilterBanke.Columns.Add("PREJEMNIK");
            tableFilterBanke.Columns.Add("IZDAJATELJ");
            tableFilterBanke.Columns.Add("DOKUMENT1");
            tableFilterBanke.Columns.Add("DATDOKUM1");
            tableFilterBanke.Columns.Add("ZAPLACILO");
            tableFilterBanke.Columns["ZAPLACILO"].DataType = typeof(Decimal);
            tableFilterBanke.Columns.Add("BANKA");
            tableFilterBanke.Columns.Add("RACUN1");
            tableFilterBanke.Columns.Add("NAZIV");
        }

        private void IsZaPlacanjeNegative()
        {
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                DataGridViewCell cellZaPlacanje = row.Cells[8]; //["Za plaćanje"];
                DataGridViewCell cellExport = row.Cells["Export"];
                DataGridViewCheckBoxCell chkCell = cellExport as DataGridViewCheckBoxCell;
                double broj = Convert.ToDouble(cellZaPlacanje.Value);

                if (broj <= 0.00)
                {
                    chkCell.Value = false;
                    chkCell.FlatStyle = FlatStyle.Flat;
                    chkCell.Style.ForeColor = Color.Gainsboro;
                    cellExport.ReadOnly = true;
                    row.DefaultCellStyle.BackColor = Color.Gainsboro;
                }
            }
        }

        private void IsRacunEmpty()
        {
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                DataGridViewCell cellZaPlacanje = row.Cells[8];
                DataGridViewCell cellRacun = row.Cells[10];
                DataGridViewCell cellExport = row.Cells["Export"];
                DataGridViewCheckBoxCell chkCell = cellExport as DataGridViewCheckBoxCell;

                if ((cellRacun.Value == null || cellRacun.Value.ToString().Trim().Equals("") || cellRacun.Value.ToString().Trim().Length != 18) && Convert.ToDouble(cellZaPlacanje.Value) >= 0.00)
                {
                    chkCell.Value = false;
                    chkCell.FlatStyle = FlatStyle.Flat;
                    chkCell.Style.ForeColor = Color.Gainsboro;

                    cellExport.ReadOnly = true;

                    cellRacun.Style.BackColor = Color.PeachPuff;
                    row.Cells[9].Style.BackColor = Color.PeachPuff;
                }
            }
        }

        private void IsTableEmpty()
        {
            if (table.Rows.Count > 0 && cmbBanka.SelectedIndex != -1)
            {
                btnUkloniBanku.Enabled = true;
                cmbFilterBanka.Enabled = true;
                btnUkloniFirmu.Enabled = true;
                cmbFilterFirma.Enabled = true;
                btnFilter.Enabled = true;
                btnStampaj.Enabled = true;
                btnIzvoz.Enabled = true;
            }
            else if (table.Rows.Count > 0 && cmbBanka.SelectedIndex == -1)
            {
                btnUkloniBanku.Enabled = true;
                cmbFilterBanka.Enabled = true;
                btnUkloniFirmu.Enabled = true;
                cmbFilterFirma.Enabled = true;
                btnFilter.Enabled = true;
                btnStampaj.Enabled = true;
                btnIzvoz.Enabled = false;
            }
            else
            {
                btnUkloniBanku.Enabled = false;
                cmbFilterBanka.Enabled = false;
                btnUkloniFirmu.Enabled = false;
                cmbFilterFirma.Enabled = false;
                btnFilter.Enabled = false;
                btnStampaj.Enabled = false;
                btnIzvoz.Enabled = false;
            }
        }

        private void PopuniNaseBanke()
        {
            using (SqlConnection conn = new SqlConnection(sqlConnection))
            {
                conn.Open();
                var upit = conn.Query<SUBJEKTBANKA>(@"SELECT IsNull(SB.SUBJEKT, '') SUBJEKT, IsNull( SB.BANKA, '') BANKA, IsNull(SB.RACUN1, '') RACUN1 ,IsNull(P.NAZIV, '') NAZIV FROM SUBJEKTBANKA SB LEFT JOIN SUBJEKT S ON SB.SUBJEKT = S.NAZIV LEFT JOIN POSTA P ON S.POSTA = P.POSTA WHERE SUBJEKT = '" + firma + "' AND RACUN23 = 'S' ORDER BY BANKA ASC").ToList();
                foreach (SUBJEKTBANKA s in upit)
                {
                    if (s.BANKA.Trim().Equals("") == false && s.RACUN1.Trim().Equals("") == false)
                    {
                        tableNaseBanke.Rows.Add(s.BANKA, s.RACUN1, s.NAZIV, s.BANKA.Trim() + " - " + s.RACUN1.Trim());
                        nasaFirma.Add(s);
                    }
                }
                cmbBanka.DataSource = tableNaseBanke;
                cmbBanka.ValueMember = "RACUN";
                cmbBanka.DisplayMember = "BANKARACUN";
                cmbBanka.ResetText();
                cmbBanka.SelectedIndex = -1;
                conn.Close();
            }
        }

        private void PopuniFilterBanke()

        {
            tableFilterBanke.Clear();
            using (SqlConnection conn = new SqlConnection(sqlConnection))
            {
                conn.Open();
                var upit = conn.Query<PROMET>(@"SELECT DISTINCT(ISNULL(SB.BANKA, '')) BANKA FROM PROMET P LEFT JOIN SUBJEKTBANKA SB ON P.IZDAJATELJ = SB.SUBJEKT WHERE P.DATUM >= '" + dateTimePickerOD.Value.ToString(dateFormat) + "' AND P.DATUM <= '" + dateTimePickerDO.Value.ToString(dateFormat) + "' AND P.POSLDOG in (" + vrsteDokumenata + ")").ToList();
                foreach (PROMET s in upit)
                {
                    if (s.BANKA.Trim().Equals("") == false)
                        tableFilterBanke.Rows.Add(s.KLJUC, s.DATUM, s.DATUMVAL, s.PREJEMNIK, s.IZDAJATELJ, s.DOKUMENT1, s.DATDOKUM1, s.ZAPLACILO, s.BANKA, s.RACUN1);
                }
                cmbFilterBanka.DataSource = tableFilterBanke;
                cmbFilterBanka.ValueMember = "KLJUC";
                cmbFilterBanka.DisplayMember = "BANKA";
                cmbFilterBanka.ResetText();
                cmbFilterBanka.SelectedIndex = -1;
                conn.Close();
            }
        }

        private void PopuniFilterFirme()
        {
            tableFilterFirme.Clear();
            cmbFilterFirma.Items.Clear();
            foreach (DataRow row in table.Rows)
            {
                if (cmbFilterFirma.Items.Count > 0)
                {
                    Boolean upisi = true;
                    foreach (String s in cmbFilterFirma.Items)
                    {
                        if (s.Equals(row["Dobavljač"].ToString()))
                        {
                            upisi = false;
                            break;
                        }
                    }
                    if (upisi == true)
                        cmbFilterFirma.Items.Add(row["Dobavljač"].ToString());
                }
                else
                    cmbFilterFirma.Items.Add(row["Dobavljač"].ToString());
                //Console.WriteLine(row.ItemArray);
            }
            //cmbFilterFirma.DataSource = tableFilterFirme;
            //cmbFilterFirma.ValueMember = "Izdavač";
            //cmbFilterFirma.DisplayMember = "Izdavač";
            cmbFilterFirma.Sorted = true;
            cmbFilterFirma.ResetText();
            cmbFilterFirma.SelectedIndex = -1;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            PreuzmiPodatke();
            PopuniFilterBanke();
            PopuniFilterFirme();
            IsTableEmpty();
            IsRacunEmpty();
            IsZaPlacanjeNegative();
        }

        private void DateTimePickerDO_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePickerDO.Value < dateTimePickerOD.Value)
                dateTimePickerOD.Value = dateTimePickerDO.Value;
        }

        private void DateTimePickerOD_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePickerOD.Value > dateTimePickerDO.Value)
                dateTimePickerDO.Value = dateTimePickerOD.Value;
        }

        private void BtnIzborBanke_Click(object sender, EventArgs e)
        {
        }

        private void Btn1dan_Click(object sender, EventArgs e)
        {
            dateTimePickerDO.Value = DateTime.Now;
            dateTimePickerOD.Text = DateTime.Parse(dateTimePickerDO.Text).AddDays(-1).ToString();
        }

        private void Btn7dana_Click(object sender, EventArgs e)
        {
            dateTimePickerDO.Value = DateTime.Now;
            dateTimePickerOD.Text = DateTime.Parse(dateTimePickerDO.Text).AddDays(-7).ToString();
        }

        private void Btn30dana_Click(object sender, EventArgs e)
        {
            dateTimePickerDO.Value = DateTime.Now;
            dateTimePickerOD.Text = DateTime.Parse(dateTimePickerDO.Text).AddMonths(-1).ToString();
        }

        private void BtnUkloniNasuBanku_Click(object sender, EventArgs e)
        {
            cmbBanka.ResetText();
            cmbBanka.SelectedIndex = -1;
        }

        private void BtnUkloniFilter_Click(object sender, EventArgs e)
        {
            cmbFilterBanka.ResetText();
            cmbFilterBanka.SelectedIndex = -1;
        }

        private void BtnFilter_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (cmbFilterBanka.SelectedItem != null || cmbFilterFirma.SelectedItem != null)
            {
                DataTable filtrirano = new DataTable();
                filtrirano.Columns.Add("KLJUC");
                filtrirano.Columns.Add("DATUM");
                filtrirano.Columns.Add("DATUMVAL");
                filtrirano.Columns.Add("PREJEMNIK");
                filtrirano.Columns.Add("IZDAJATELJ");
                filtrirano.Columns.Add("DOKUMENT1");
                filtrirano.Columns.Add("DATDOKUM1");
                filtrirano.Columns.Add("ZAPLACILO");
                filtrirano.Columns["ZAPLACILO"].DataType = typeof(Decimal);
                filtrirano.Columns.Add("BANKA");
                filtrirano.Columns.Add("RACUN1");
                filtrirano.Columns.Add("NAZIV");

                filtrirano.Columns["KLJUC"].ColumnName = "Broj dokumenta";
                filtrirano.Columns["DATUM"].ColumnName = "Datum";
                filtrirano.Columns["DATUMVAL"].ColumnName = "Valuta";
                filtrirano.Columns["PREJEMNIK"].ColumnName = "Primalac";
                filtrirano.Columns["IZDAJATELJ"].ColumnName = "Dobavljač";
                filtrirano.Columns["DOKUMENT1"].ColumnName = "Dok.dobav.";
                filtrirano.Columns["DATDOKUM1"].ColumnName = "Datum dok.";
                filtrirano.Columns["ZAPLACILO"].ColumnName = "Za plaćanje";
                filtrirano.Columns["BANKA"].ColumnName = "Banka";
                filtrirano.Columns["RACUN1"].ColumnName = "Račun";
                filtrirano.Columns["NAZIV"].ColumnName = "Mesto";

                foreach (DataRow row in table.Rows)
                {
                    if (cmbFilterBanka.SelectedItem != null && cmbFilterFirma.SelectedItem == null)
                    {
                        if (row["Banka"].ToString().Trim().Equals(cmbFilterBanka.Text.ToString().Trim()))
                            filtrirano.Rows.Add(row.ItemArray);
                        continue;
                    }
                    else if (cmbFilterBanka.SelectedItem == null && cmbFilterFirma.SelectedItem != null)
                    {
                        if (row["Dobavljač"].ToString().Trim().Equals(cmbFilterFirma.Text.ToString().Trim()))
                            filtrirano.Rows.Add(row.ItemArray);
                        continue;
                    }
                    else if (cmbFilterBanka.SelectedItem != null && cmbFilterFirma.SelectedItem != null)
                    {
                        if (row["Banka"].ToString().Trim().Equals(cmbFilterBanka.Text.ToString().Trim()) && row["Dobavljač"].ToString().Trim().Equals(cmbFilterFirma.Text.ToString().Trim()))
                            filtrirano.Rows.Add(row.ItemArray);
                        continue;
                    }
                }
                lblUkupnoZapisa.Text = "Ukupno: " + filtrirano.Rows.Count + " zapisa";
                dataGridView.DataSource = filtrirano;
                dataGridView.Columns["Mesto"].Visible = false;
                dataGridView.Refresh();
            }
            else
            {
                dataGridView.DataSource = table;
                dataGridView.Refresh();
                lblUkupnoZapisa.Text = "Ukupno: " + table.Rows.Count + " zapisa";
            }
            IsRacunEmpty();
            IsZaPlacanjeNegative();
            Cursor.Current = Cursors.Default;
        }

        private void BtnPodesavanje_Click(object sender, EventArgs e)
        {
            Settings f = new Settings(false);
            f.ShowDialog();
        }

        private void BtnUkloniFirmu_Click(object sender, EventArgs e)
        {
            cmbFilterFirma.ResetText();
            cmbFilterFirma.SelectedIndex = -1;
        }

        private void DataGridView_Sorted(object sender, EventArgs e)
        {
            IsRacunEmpty();
            IsZaPlacanjeNegative();
        }

        private void BtnIzvoz_Click(object sender, EventArgs e)
        {
            bool selektovan = false;
            dataGridView.EndEdit();
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                DataGridViewCell cellExport = row.Cells["Export"];
                DataGridViewCheckBoxCell chkCell = cellExport as DataGridViewCheckBoxCell;

                if (chkCell.Value == null)
                    chkCell.Value = false;

                if (chkCell.ReadOnly == false && chkCell.Value.ToString().Trim().Equals("True"))
                    selektovan = true;
            }
            if (selektovan == true)
                Stampaj();
            else
                MessageBox.Show("Pre izvoza morate da izaberete barem jedan nalog!", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void Stampaj()
        {
            podaci.Clear();
            string adresnaStavka = "";
            string sabirnaStavka = "";
            bool viseDatuma = false;
            decimal suma = 0;
            int brojPlatnihNaloga = 0;

            List<String> datumi = new List<string>();

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (row.Cells["Export"].Value != null && row.Cells["Export"].Value.ToString().ToLower().Trim() != "false")
                {
                    string red = "";
                    brojPlatnihNaloga++;
                    DateTime valutaPlacanja = DateTime.Parse(row.Cells[3].Value.ToString());
                    datumi.Add(valutaPlacanja.ToString("ddMMyy"));
                    if (viseDatuma == false)
                    {
                        foreach (String datum in datumi)
                        {
                            if (datum.Trim().Equals(valutaPlacanja.ToString("ddMMyy")) == false)
                            {
                                viseDatuma = true;
                                break;
                            }
                        }
                    }
                    red = NapraviString(row.Cells[10].Value.ToString(), 1, 18); // 1. BROJ RACUNA
                    red += NapraviString(row.Cells[5].Value.ToString(), 19, 35); // 2. NAZIV PRIMAOCA
                    red += NapraviString(row.Cells[11].Value.ToString(), 54, 10); // 4. MESTO
                    red += new String('0', 1); ; // 5. "0" - REZERVISANO POLJE
                    red += new String(' ', 2); // 6. MODEL ZADUZENJA
                    red += new String(' ', 23); // 7. REFERENCA ZADUZENJA
                    red += NapraviString(row.Cells[6].Value.ToString(), 90, 36); // 8. SVRHA PLACANJA
                    red += new String('0', 5); // 9. "0000" - REZERVISANO POLJE
                    red += new String(' ', 1); // 10. " " - REZERVISANO POLJE
                    red += new String('2', 1); // 11. "2" - OBLIK PLACANJA
                    red += new String('2', 1) + new String('0', 1); // 12. "20" - SIFRA PLACANJA
                    red += new String(' ', 1); // 13. " " - OBLIK PLACANJA
                    red += new String(' ', 1); ; // 14. " " - REZERVISANO POLJE
                    suma += Convert.ToDecimal(row.Cells[8].Value.ToString());
                    red += NapraviString(row.Cells[8].Value.ToString(), 137, 13, true); // 15. IZNOS NALOGA
                    red += new String(' ', 2); ; // 16. MODEL ODOBRENJA
                    red += new String(' ', 23); // 17. REFERENCA ODOBRENJA
                    red += valutaPlacanja.ToString("ddMMyy"); // 18. DATUM VALUTE
                    red += new String('0', 1); ; // 19. "0" - TIP (NALOG ZA PRENOS)
                    red += new String('1', 1); ; // 20. "1" - TIP STAVKE

                    podaci.Add(red);
                }
            }
            //KREIRANJE PRVOG REDA
            adresnaStavka = NapraviString(cmbBanka.SelectedValue.ToString(), 1, 18); // 1. BROJ RACUNA
            adresnaStavka += NapraviString(firma, 19, 35); // 2. NAZIV
            foreach (SUBJEKTBANKA s in nasaFirma)
            {
                if (s.RACUN1.Trim().Equals(cmbBanka.SelectedValue.ToString().Trim()))
                {
                    adresnaStavka += NapraviString(s.NAZIV, 54, 10); // 3. MESTO
                    break;
                }
            }
            //if (viseDatuma == false)
            // adresnaStavka += datumi[0]; // 4. DATUM VALUTE
            //else
            adresnaStavka += dateTimePickerOD.Value.ToString("ddMMyy"); // 4. DATUM VALUTE (TRENUTNI DATUM)
            //adresnaStavka += new String(' ', 6); // 4. DATUM VALUTE (PRAZNO)
            adresnaStavka += new String(' ', 98); ; // 5. " " - REZERVISANO POLJE
            adresnaStavka += "MULTI E-BANK"; // 6. "MULTI E-BANK" - REZERVISANO POLJE
            adresnaStavka += new String('0', 1); ; // 7. "0" - ADRESNA STAVKA
            //KREIRANJE PRVOG REDA

            //KREIRANJE DRUGOG REDA
            sabirnaStavka = NapraviString(cmbBanka.SelectedValue.ToString(), 1, 18); // 1. BROJ RACUNA
            sabirnaStavka += NapraviString(firma, 19, 35); // 2. NAZIV
            foreach (SUBJEKTBANKA s in nasaFirma)
            {
                if (s.RACUN1.Trim().Equals(cmbBanka.SelectedValue.ToString().Trim()))
                {
                    sabirnaStavka += NapraviString(s.NAZIV, 54, 10); // 3. MESTO
                    break;
                }
            }

            sabirnaStavka += NapraviString(suma.ToString(), 64, 15, true); // 4. ZBIR
            string brojPlatnihNalogaFormatiran = brojPlatnihNaloga.ToString().PadLeft(5, '0');
            sabirnaStavka += brojPlatnihNalogaFormatiran; // 5. BROJ PLATNIH NALOGA
            sabirnaStavka += new String(' ', 96); ; // 5. " " - REZERVISANO POLJE
            sabirnaStavka += new String('9', 1); ; // 7. "9" - SABIRNA STAVKA
            //KREIRANJE DRUGOG REDA

            podaci.Reverse();
            podaci.Add(sabirnaStavka);
            podaci.Add(adresnaStavka);
            podaci.Reverse();

            saveFileDialog1.FileName = "HalkomNalozi_" + DateTime.Now.ToString("ddMMyyyy");
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(saveFileDialog1.FileName))
                    foreach (string linija in podaci)
                        file.WriteLine(linija);
            }
        }

        private string NapraviString(string kolona, int pocetak, int duzina, bool nule = false)
        {
            string formatiranString = kolona.Trim().ToUpper();
            if (nule == true) // DODAVANJE NULA UMESTO SPEJSOVA I BRISANJE ZAREZA
            {
                string broj = Convert.ToDecimal(formatiranString).ToString("0.00", CultureInfo.InvariantCulture);
                string[] delovi = broj.Split('.');
                formatiranString = delovi[0] + delovi[1];
                formatiranString = formatiranString.PadLeft(duzina, '0');
            }
            else //RAD SA SPEJSOVIMA
            {
                formatiranString = formatiranString.Replace('Š', 'S').Replace('š', 's').Replace('Đ', 'D').Replace('đ', 'd').
                    Replace('Ć', 'C').Replace('ć', 'c').Replace('Č', 'C').Replace('č', 'c').Replace('Ž', 'Z').Replace('Ž', 'z');

                if (formatiranString.Length > duzina)
                    formatiranString = formatiranString.Substring(0, duzina);
                formatiranString = formatiranString.PadRight(duzina);
            }

            return formatiranString;
        }

        private void CmbBanka_SelectedIndexChanged(object sender, EventArgs e)
        {
            IsTableEmpty();
        }

        private void DataGridView_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && dataGridView.Rows.Count > 0)
                contextMenuStrip1.Show(dataGridView, new Point(e.X, e.Y));
        }

        private void Dodaj_Click(object sender, EventArgs e)
        {
            dataGridView.EndEdit();
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                DataGridViewCell cellExport = row.Cells["Export"];
                DataGridViewCheckBoxCell chkCell = cellExport as DataGridViewCheckBoxCell;

                if (chkCell.Value == null)
                    chkCell.Value = false;

                if (chkCell.ReadOnly == false)
                    chkCell.Value = true;
            }
        }

        private void Ukloni_Click(object sender, EventArgs e)
        {
            dataGridView.EndEdit();
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                DataGridViewCell cellExport = row.Cells["Export"];
                DataGridViewCheckBoxCell chkCell = cellExport as DataGridViewCheckBoxCell;

                if (chkCell.Value == null)
                    chkCell.Value = false;

                if (chkCell.ReadOnly == false)
                    chkCell.Value = false;
            }
        }

        public bool IsServerConnected()
        {
            Cursor.Current = Cursors.WaitCursor;
            bool testConnection = false;
            try
            {
                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var connectionStringsSection = (ConnectionStringsSection)config.GetSection("connectionStrings");
                using (SqlConnection connection = new SqlConnection(connectionStringsSection.ConnectionStrings["SQL"].ConnectionString))
                {
                    connection.Open();
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                        testConnection = true;
                    }
                    else if (connection.State == ConnectionState.Closed)
                    {
                        testConnection = false;
                    }
                }
                return testConnection;
            }
            catch (Exception)
            {
                return testConnection;
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
        private void BtnStampaj_Click(object sender, EventArgs e)
        {
            TabelaStampaj();
            DGVPrinter stampac = new DGVPrinter();
            
            stampac.PageSettings.Landscape = true;
            stampac.Title = "Izvoz računa";
            stampac.TitleSpacing = 5;
            stampac.SubTitle = dateTimePickerOD.Value.ToShortDateString() + " - " + dateTimePickerDO.Value.ToShortDateString();
            stampac.SubTitleSpacing = 15;
            stampac.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            stampac.PageNumbers = true;
            stampac.PageNumberInHeader = false;
            stampac.PorportionalColumns = true;
            stampac.HeaderCellAlignment = StringAlignment.Center;
            stampac.Footer = "Vector-IT";
            stampac.FooterSpacing = 15;
            
            stampac.HideColumns.Add("Export");
            stampac.HideColumns.Add("Datum dok.");
            stampac.PageText = "Strana ";

            stampac.PrintPreviewNoDisplay(dataGridView);
            //stampac.PrintPreviewDataGridView(dataGridView);
            //stampac.PrintDataGridView(dataGridView);
            TabelaStampajReset();
        }
        private void TabelaStampaj()
        {
            //this.dataGridView.Columns[4].MinimumWidth = 2;
            //this.dataGridView.Columns[5].MinimumWidth = 2;
            //this.dataGridView.Columns[9].MinimumWidth = 2;
            //this.dataGridView.Columns[10].MinimumWidth = 2;
            //FIKSNO
            this.dataGridView.Font = new Font("Microsoft Sans Serif", 7);
            this.dataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridView.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridView.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridView.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridView.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridView.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridView.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridView.Columns[8].DefaultCellStyle.Font = new System.Drawing.Font(dataGridView.Font.Name, dataGridView.Font.Size, FontStyle.Bold);
            this.dataGridView.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridView.Columns[10].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridView.Font = new Font("Microsoft Sans Serif", 7);


        }
        private void TabelaStampajReset()
        {
            this.dataGridView.Font = new Font("Microsoft Sans Serif", 8);
            //FIKSNO
            this.dataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridView.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            //FIKSNO
            //MENJA SE
            this.dataGridView.Columns[4].MinimumWidth = 125;
            this.dataGridView.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridView.Columns[5].MinimumWidth = 125;
            this.dataGridView.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //MENJA SE
            //FIKSNO
            this.dataGridView.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridView.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridView.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridView.Columns[8].DefaultCellStyle.Font = new System.Drawing.Font(dataGridView.Font.Name, dataGridView.Font.Size, FontStyle.Bold);
            //FIKSNO
            //MENJA SE
            this.dataGridView.Columns[9].MinimumWidth = 170;
            this.dataGridView.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridView.Columns[10].MinimumWidth = 130;
            this.dataGridView.Columns[10].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //MENJA SE
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}