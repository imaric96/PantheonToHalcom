namespace PA_to_Halcom
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnPodesavanje = new System.Windows.Forms.ToolStripMenuItem();
            this.btnProgram = new System.Windows.Forms.ToolStripMenuItem();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbBanka = new System.Windows.Forms.ComboBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblBaza = new System.Windows.Forms.ToolStripStatusLabel();
            this.ProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.lblUkupnoZapisa = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnUkloniNasuBanku = new System.Windows.Forms.Button();
            this.btnIzvoz = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.btnPreuzmiPodatke = new System.Windows.Forms.Button();
            this.dateTimePickerDO = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerOD = new System.Windows.Forms.DateTimePicker();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnFilter = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn30dana = new System.Windows.Forms.Button();
            this.btn7dana = new System.Windows.Forms.Button();
            this.btn1dan = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnUkloniFirmu = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbFilterFirma = new System.Windows.Forms.ComboBox();
            this.btnUkloniBanku = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbFilterBanka = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.dodaj = new System.Windows.Forms.ToolStripMenuItem();
            this.ukloni = new System.Windows.Forms.ToolStripMenuItem();
            this.btnStampaj = new System.Windows.Forms.Button();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.statusStrip1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPodesavanje
            // 
            this.btnPodesavanje.Name = "btnPodesavanje";
            this.btnPodesavanje.Size = new System.Drawing.Size(174, 26);
            this.btnPodesavanje.Text = "Podešavanja";
            this.btnPodesavanje.Click += new System.EventHandler(this.BtnPodesavanje_Click);
            // 
            // btnProgram
            // 
            this.btnProgram.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnPodesavanje});
            this.btnProgram.Name = "btnProgram";
            this.btnProgram.Size = new System.Drawing.Size(80, 24);
            this.btnProgram.Text = "Program";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 17);
            this.label3.TabIndex = 11;
            this.label3.Text = "Naša banka:";
            // 
            // cmbBanka
            // 
            this.cmbBanka.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBanka.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cmbBanka.FormattingEnabled = true;
            this.cmbBanka.Location = new System.Drawing.Point(120, 33);
            this.cmbBanka.Name = "cmbBanka";
            this.cmbBanka.Size = new System.Drawing.Size(384, 24);
            this.cmbBanka.TabIndex = 3;
            this.cmbBanka.SelectedIndexChanged += new System.EventHandler(this.CmbBanka_SelectedIndexChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblBaza,
            this.ProgressBar,
            this.lblUkupnoZapisa});
            this.statusStrip1.Location = new System.Drawing.Point(0, 664);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1150, 31);
            this.statusStrip1.TabIndex = 18;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblBaza
            // 
            this.lblBaza.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.lblBaza.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.lblBaza.Name = "lblBaza";
            this.lblBaza.Padding = new System.Windows.Forms.Padding(0, 0, 4, 0);
            this.lblBaza.Size = new System.Drawing.Size(240, 25);
            this.lblBaza.Text = "BAZA PODATAKA:  PROMET_TEST";
            // 
            // ProgressBar
            // 
            this.ProgressBar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.ProgressBar.Margin = new System.Windows.Forms.Padding(5, 3, 1, 3);
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(200, 25);
            this.ProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            // 
            // lblUkupnoZapisa
            // 
            this.lblUkupnoZapisa.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedOuter;
            this.lblUkupnoZapisa.Name = "lblUkupnoZapisa";
            this.lblUkupnoZapisa.Size = new System.Drawing.Size(121, 25);
            this.lblUkupnoZapisa.Text = "Ukupno: 0 zapisa";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnUkloniNasuBanku);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.cmbBanka);
            this.groupBox3.Location = new System.Drawing.Point(12, 108);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1126, 76);
            this.groupBox3.TabIndex = 16;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Izbor racuna";
            // 
            // btnUkloniNasuBanku
            // 
            this.btnUkloniNasuBanku.ForeColor = System.Drawing.Color.Red;
            this.btnUkloniNasuBanku.Location = new System.Drawing.Point(510, 30);
            this.btnUkloniNasuBanku.Name = "btnUkloniNasuBanku";
            this.btnUkloniNasuBanku.Size = new System.Drawing.Size(33, 29);
            this.btnUkloniNasuBanku.TabIndex = 12;
            this.btnUkloniNasuBanku.TabStop = false;
            this.btnUkloniNasuBanku.Text = "X";
            this.btnUkloniNasuBanku.UseVisualStyleBackColor = true;
            this.btnUkloniNasuBanku.Click += new System.EventHandler(this.BtnUkloniNasuBanku_Click);
            // 
            // btnIzvoz
            // 
            this.btnIzvoz.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIzvoz.Location = new System.Drawing.Point(989, 630);
            this.btnIzvoz.Name = "btnIzvoz";
            this.btnIzvoz.Size = new System.Drawing.Size(149, 29);
            this.btnIzvoz.TabIndex = 7;
            this.btnIzvoz.Text = "Izvoz za HALKOM";
            this.btnIzvoz.UseVisualStyleBackColor = true;
            this.btnIzvoz.Click += new System.EventHandler(this.BtnIzvoz_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToResizeRows = false;
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView.Location = new System.Drawing.Point(12, 272);
            this.dataGridView.MultiSelect = false;
            this.dataGridView.Name = "dataGridView";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridView.RowTemplate.Height = 24;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(1126, 350);
            this.dataGridView.TabIndex = 12;
            this.dataGridView.TabStop = false;
            this.dataGridView.Sorted += new System.EventHandler(this.DataGridView_Sorted);
            this.dataGridView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DataGridView_MouseClick);
            // 
            // btnPreuzmiPodatke
            // 
            this.btnPreuzmiPodatke.Location = new System.Drawing.Point(432, 20);
            this.btnPreuzmiPodatke.Name = "btnPreuzmiPodatke";
            this.btnPreuzmiPodatke.Size = new System.Drawing.Size(138, 29);
            this.btnPreuzmiPodatke.TabIndex = 2;
            this.btnPreuzmiPodatke.Text = "Preuzmi podatke";
            this.btnPreuzmiPodatke.UseVisualStyleBackColor = true;
            this.btnPreuzmiPodatke.Click += new System.EventHandler(this.Button1_Click);
            // 
            // dateTimePickerDO
            // 
            this.dateTimePickerDO.CustomFormat = "dd.MM.yyyy";
            this.dateTimePickerDO.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerDO.Location = new System.Drawing.Point(262, 22);
            this.dateTimePickerDO.MaxDate = new System.DateTime(2030, 12, 31, 0, 0, 0, 0);
            this.dateTimePickerDO.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dateTimePickerDO.Name = "dateTimePickerDO";
            this.dateTimePickerDO.Size = new System.Drawing.Size(164, 22);
            this.dateTimePickerDO.TabIndex = 1;
            this.dateTimePickerDO.ValueChanged += new System.EventHandler(this.DateTimePickerDO_ValueChanged);
            // 
            // dateTimePickerOD
            // 
            this.dateTimePickerOD.CustomFormat = "dd.MM.yyyy";
            this.dateTimePickerOD.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerOD.Location = new System.Drawing.Point(120, 22);
            this.dateTimePickerOD.MaxDate = new System.DateTime(2030, 12, 31, 0, 0, 0, 0);
            this.dateTimePickerOD.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dateTimePickerOD.Name = "dateTimePickerOD";
            this.dateTimePickerOD.Size = new System.Drawing.Size(136, 22);
            this.dateTimePickerOD.TabIndex = 0;
            this.dateTimePickerOD.ValueChanged += new System.EventHandler(this.DateTimePickerOD_ValueChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnProgram});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip1.Size = new System.Drawing.Size(1150, 28);
            this.menuStrip1.TabIndex = 17;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(0, 67);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1117, 76);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Datum računa:";
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(840, 32);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(78, 29);
            this.btnFilter.TabIndex = 6;
            this.btnFilter.Text = "Pretraži";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.BtnFilter_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btn30dana);
            this.groupBox1.Controls.Add(this.btn7dana);
            this.groupBox1.Controls.Add(this.btn1dan);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnPreuzmiPodatke);
            this.groupBox1.Controls.Add(this.dateTimePickerDO);
            this.groupBox1.Controls.Add(this.dateTimePickerOD);
            this.groupBox1.Location = new System.Drawing.Point(12, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1126, 63);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Prikaz u intervalu";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(796, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 17);
            this.label2.TabIndex = 12;
            this.label2.Text = "Poslednjih:";
            // 
            // btn30dana
            // 
            this.btn30dana.Location = new System.Drawing.Point(1035, 21);
            this.btn30dana.Name = "btn30dana";
            this.btn30dana.Size = new System.Drawing.Size(75, 29);
            this.btn30dana.TabIndex = 11;
            this.btn30dana.TabStop = false;
            this.btn30dana.Text = "1 mesec";
            this.btn30dana.UseVisualStyleBackColor = true;
            this.btn30dana.Click += new System.EventHandler(this.Btn30dana_Click);
            // 
            // btn7dana
            // 
            this.btn7dana.Location = new System.Drawing.Point(957, 21);
            this.btn7dana.Name = "btn7dana";
            this.btn7dana.Size = new System.Drawing.Size(75, 29);
            this.btn7dana.TabIndex = 10;
            this.btn7dana.TabStop = false;
            this.btn7dana.Text = "7 dana";
            this.btn7dana.UseVisualStyleBackColor = true;
            this.btn7dana.Click += new System.EventHandler(this.Btn7dana_Click);
            // 
            // btn1dan
            // 
            this.btn1dan.Location = new System.Drawing.Point(879, 21);
            this.btn1dan.Name = "btn1dan";
            this.btn1dan.Size = new System.Drawing.Size(75, 29);
            this.btn1dan.TabIndex = 9;
            this.btn1dan.TabStop = false;
            this.btn1dan.Text = "1 dan";
            this.btn1dan.UseVisualStyleBackColor = true;
            this.btn1dan.Click += new System.EventHandler(this.Btn1dan_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnUkloniFirmu);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.cmbFilterFirma);
            this.groupBox4.Controls.Add(this.btnFilter);
            this.groupBox4.Controls.Add(this.btnUkloniBanku);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.cmbFilterBanka);
            this.groupBox4.Location = new System.Drawing.Point(13, 190);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1125, 76);
            this.groupBox4.TabIndex = 17;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Filtriraj po";
            // 
            // btnUkloniFirmu
            // 
            this.btnUkloniFirmu.ForeColor = System.Drawing.Color.Red;
            this.btnUkloniFirmu.Location = new System.Drawing.Point(789, 31);
            this.btnUkloniFirmu.Name = "btnUkloniFirmu";
            this.btnUkloniFirmu.Size = new System.Drawing.Size(33, 29);
            this.btnUkloniFirmu.TabIndex = 15;
            this.btnUkloniFirmu.TabStop = false;
            this.btnUkloniFirmu.Text = "X";
            this.btnUkloniFirmu.UseVisualStyleBackColor = true;
            this.btnUkloniFirmu.Click += new System.EventHandler(this.BtnUkloniFirmu_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(461, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 17);
            this.label5.TabIndex = 14;
            this.label5.Text = "Firmi:";
            // 
            // cmbFilterFirma
            // 
            this.cmbFilterFirma.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterFirma.FormattingEnabled = true;
            this.cmbFilterFirma.Location = new System.Drawing.Point(509, 34);
            this.cmbFilterFirma.Name = "cmbFilterFirma";
            this.cmbFilterFirma.Size = new System.Drawing.Size(274, 24);
            this.cmbFilterFirma.TabIndex = 5;
            // 
            // btnUkloniBanku
            // 
            this.btnUkloniBanku.ForeColor = System.Drawing.Color.Red;
            this.btnUkloniBanku.Location = new System.Drawing.Point(399, 31);
            this.btnUkloniBanku.Name = "btnUkloniBanku";
            this.btnUkloniBanku.Size = new System.Drawing.Size(33, 29);
            this.btnUkloniBanku.TabIndex = 12;
            this.btnUkloniBanku.TabStop = false;
            this.btnUkloniBanku.Text = "X";
            this.btnUkloniBanku.UseVisualStyleBackColor = true;
            this.btnUkloniBanku.Click += new System.EventHandler(this.BtnUkloniFilter_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(58, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 17);
            this.label4.TabIndex = 11;
            this.label4.Text = "Banci:";
            // 
            // cmbFilterBanka
            // 
            this.cmbFilterBanka.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterBanka.FormattingEnabled = true;
            this.cmbFilterBanka.Location = new System.Drawing.Point(119, 34);
            this.cmbFilterBanka.Name = "cmbFilterBanka";
            this.cmbFilterBanka.Size = new System.Drawing.Size(274, 24);
            this.cmbFilterBanka.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(15, 634);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(44, 20);
            this.panel1.TabIndex = 19;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel2.BackColor = System.Drawing.Color.PeachPuff;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Location = new System.Drawing.Point(200, 634);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(44, 20);
            this.panel2.TabIndex = 20;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(60, 636);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(131, 17);
            this.label6.TabIndex = 21;
            this.label6.Text = "- Knjižno odobrenje";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(245, 636);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(259, 17);
            this.label7.TabIndex = 22;
            this.label7.Text = "- Prazno polje ili neispravan broj računa";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "txt";
            this.saveFileDialog1.Filter = "txt ekstenzija (*.txt)|*.txt";
            this.saveFileDialog1.Title = "Sačuvaj platne naloge";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dodaj,
            this.ukloni});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(146, 52);
            // 
            // dodaj
            // 
            this.dodaj.Name = "dodaj";
            this.dodaj.Size = new System.Drawing.Size(145, 24);
            this.dodaj.Text = "Dodaj sve";
            this.dodaj.Click += new System.EventHandler(this.Dodaj_Click);
            // 
            // ukloni
            // 
            this.ukloni.Name = "ukloni";
            this.ukloni.Size = new System.Drawing.Size(145, 24);
            this.ukloni.Text = "Ukloni sve";
            this.ukloni.Click += new System.EventHandler(this.Ukloni_Click);
            // 
            // btnStampaj
            // 
            this.btnStampaj.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStampaj.Location = new System.Drawing.Point(834, 630);
            this.btnStampaj.Name = "btnStampaj";
            this.btnStampaj.Size = new System.Drawing.Size(149, 29);
            this.btnStampaj.TabIndex = 23;
            this.btnStampaj.Text = "Štampaj";
            this.btnStampaj.UseVisualStyleBackColor = true;
            this.btnStampaj.Click += new System.EventHandler(this.BtnStampaj_Click);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Document = this.printDocument1;
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1150, 695);
            this.Controls.Add(this.btnStampaj);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnIzvoz);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1168, 742);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PA TO HALCOM";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStripMenuItem btnPodesavanje;
        private System.Windows.Forms.ToolStripMenuItem btnProgram;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbBanka;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnIzvoz;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button btnPreuzmiPodatke;
        private System.Windows.Forms.DateTimePicker dateTimePickerDO;
        private System.Windows.Forms.DateTimePicker dateTimePickerOD;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStripStatusLabel lblBaza;
        private System.Windows.Forms.Button btn30dana;
        private System.Windows.Forms.Button btn7dana;
        private System.Windows.Forms.Button btn1dan;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripProgressBar ProgressBar;
        private System.Windows.Forms.ToolStripStatusLabel lblUkupnoZapisa;
        private System.Windows.Forms.Button btnUkloniNasuBanku;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnUkloniBanku;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbFilterBanka;
        private System.Windows.Forms.Button btnUkloniFirmu;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbFilterFirma;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dodaj;
        private System.Windows.Forms.ToolStripMenuItem ukloni;
        private System.Windows.Forms.Button btnStampaj;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
    }
}

