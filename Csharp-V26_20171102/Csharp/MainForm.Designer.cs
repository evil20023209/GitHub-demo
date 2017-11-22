namespace Csharp
{
    partial class MainForm
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.TextAnnotation textAnnotation1 = new System.Windows.Forms.DataVisualization.Charting.TextAnnotation();
            System.Windows.Forms.DataVisualization.Charting.TextAnnotation textAnnotation2 = new System.Windows.Forms.DataVisualization.Charting.TextAnnotation();
            System.Windows.Forms.DataVisualization.Charting.TextAnnotation textAnnotation3 = new System.Windows.Forms.DataVisualization.Charting.TextAnnotation();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.Label_Status = new System.Windows.Forms.Label();
            this.label_rsb = new System.Windows.Forms.Label();
            this.label_Oscillscope = new System.Windows.Forms.Label();
            this.TextBox_measpow = new System.Windows.Forms.TextBox();
            this.Label_measpow = new System.Windows.Forms.Label();
            this.TextBox_exppow = new System.Windows.Forms.TextBox();
            this.Label_exppower = new System.Windows.Forms.Label();
            this.TextBox_current = new System.Windows.Forms.TextBox();
            this.TextBox_load = new System.Windows.Forms.TextBox();
            this.Label_load = new System.Windows.Forms.Label();
            this.label_E200 = new System.Windows.Forms.Label();
            this.button_RSB_connect = new System.Windows.Forms.Button();
            this.comboBox_RSB = new System.Windows.Forms.ComboBox();
            this.Label_OSpicture = new System.Windows.Forms.Label();
            this.PictureBox_OSpicture = new System.Windows.Forms.PictureBox();
            this.Button_OSconnect = new System.Windows.Forms.Button();
            this.ComboBox_oscillscope = new System.Windows.Forms.ComboBox();
            this.Button_E200_connect = new System.Windows.Forms.Button();
            this.ComboBox_E200 = new System.Windows.Forms.ComboBox();
            this.RadioButton_connect_manual = new System.Windows.Forms.RadioButton();
            this.RadioButton_connect_auto = new System.Windows.Forms.RadioButton();
            this.GroupBox_mode = new System.Windows.Forms.GroupBox();
            this.radioButton_Clearall = new System.Windows.Forms.RadioButton();
            this.radioButton_Selectall = new System.Windows.Forms.RadioButton();
            this.checkedListBox_mode = new System.Windows.Forms.CheckedListBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label_imformation2 = new System.Windows.Forms.Label();
            this.button_clear_engineer = new System.Windows.Forms.Button();
            this.label_mode = new System.Windows.Forms.Label();
            this.RichTextBox_infor_engineer = new System.Windows.Forms.RichTextBox();
            this.GroupBox_report = new System.Windows.Forms.GroupBox();
            this.label_calibration_times = new System.Windows.Forms.Label();
            this.button_CalibData = new System.Windows.Forms.Button();
            this.button_reportdata = new System.Windows.Forms.Button();
            this.chart_calibration_times_report = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.comboBox_mode_report = new System.Windows.Forms.ComboBox();
            this.GroupBox_Connection = new System.Windows.Forms.GroupBox();
            this.Label_current = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.Button_start = new System.Windows.Forms.Button();
            this.chart_cabration_run_chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.GroupBox_value = new System.Windows.Forms.GroupBox();
            this.Label_voltage = new System.Windows.Forms.Label();
            this.TextBox_vlotage = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label_precent = new System.Windows.Forms.Label();
            this.textBox_timer = new System.Windows.Forms.TextBox();
            this.label_timer = new System.Windows.Forms.Label();
            this.label_100 = new System.Windows.Forms.Label();
            this.progressBar_Calib = new System.Windows.Forms.ProgressBar();
            this.RichTextBox_infor_user = new System.Windows.Forms.RichTextBox();
            this.button_clear_user = new System.Windows.Forms.Button();
            this.Button_pause = new System.Windows.Forms.Button();
            this.Button_status = new System.Windows.Forms.Button();
            this.Button_stop = new System.Windows.Forms.Button();
            this.Label_informations = new System.Windows.Forms.Label();
            this.label_0 = new System.Windows.Forms.Label();
            this.groupBox_function = new System.Windows.Forms.GroupBox();
            this.radioButton_calibration = new System.Windows.Forms.RadioButton();
            this.radioButton_verify = new System.Windows.Forms.RadioButton();
            this.tabPage_help = new System.Windows.Forms.TabPage();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox_email2 = new System.Windows.Forms.PictureBox();
            this.pictureBox_tel2 = new System.Windows.Forms.PictureBox();
            this.pictureBox_ad2 = new System.Windows.Forms.PictureBox();
            this.label_us = new System.Windows.Forms.Label();
            this.textBox_us = new System.Windows.Forms.TextBox();
            this.pictureBox_email = new System.Windows.Forms.PictureBox();
            this.pictureBox_tel = new System.Windows.Forms.PictureBox();
            this.pictureBox_add = new System.Windows.Forms.PictureBox();
            this.label_web = new System.Windows.Forms.Label();
            this.label_taiwan = new System.Windows.Forms.Label();
            this.textBox_head = new System.Windows.Forms.TextBox();
            this.label_contact_us = new System.Windows.Forms.Label();
            this.serialPort_E200 = new System.IO.Ports.SerialPort(this.components);
            this.timer_Calibration = new System.Windows.Forms.Timer(this.components);
            this.timer_Detect_serial_port = new System.Windows.Forms.Timer(this.components);
            this.serialPort_RSB = new System.IO.Ports.SerialPort(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_OSpicture)).BeginInit();
            this.GroupBox_mode.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.GroupBox_report.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart_calibration_times_report)).BeginInit();
            this.GroupBox_Connection.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart_cabration_run_chart)).BeginInit();
            this.GroupBox_value.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox_function.SuspendLayout();
            this.tabPage_help.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_email2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_tel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_ad2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_email)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_tel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_add)).BeginInit();
            this.SuspendLayout();
            // 
            // Label_Status
            // 
            this.Label_Status.AutoSize = true;
            this.Label_Status.Font = new System.Drawing.Font("Georgia", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Status.Location = new System.Drawing.Point(910, 624);
            this.Label_Status.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label_Status.Name = "Label_Status";
            this.Label_Status.Size = new System.Drawing.Size(114, 35);
            this.Label_Status.TabIndex = 45;
            this.Label_Status.Text = "Status :";
            // 
            // label_rsb
            // 
            this.label_rsb.AutoSize = true;
            this.label_rsb.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_rsb.Location = new System.Drawing.Point(9, 198);
            this.label_rsb.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_rsb.Name = "label_rsb";
            this.label_rsb.Size = new System.Drawing.Size(91, 29);
            this.label_rsb.TabIndex = 12;
            this.label_rsb.Text = "R.S.B : ";
            // 
            // label_Oscillscope
            // 
            this.label_Oscillscope.AutoSize = true;
            this.label_Oscillscope.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Oscillscope.Location = new System.Drawing.Point(4, 148);
            this.label_Oscillscope.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Oscillscope.Name = "label_Oscillscope";
            this.label_Oscillscope.Size = new System.Drawing.Size(166, 29);
            this.label_Oscillscope.TabIndex = 11;
            this.label_Oscillscope.Text = "Oscilloscope : ";
            // 
            // TextBox_measpow
            // 
            this.TextBox_measpow.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBox_measpow.Location = new System.Drawing.Point(272, 140);
            this.TextBox_measpow.Margin = new System.Windows.Forms.Padding(4);
            this.TextBox_measpow.Name = "TextBox_measpow";
            this.TextBox_measpow.ReadOnly = true;
            this.TextBox_measpow.Size = new System.Drawing.Size(192, 34);
            this.TextBox_measpow.TabIndex = 13;
            // 
            // Label_measpow
            // 
            this.Label_measpow.AutoSize = true;
            this.Label_measpow.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_measpow.Location = new System.Drawing.Point(14, 144);
            this.Label_measpow.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label_measpow.Name = "Label_measpow";
            this.Label_measpow.Size = new System.Drawing.Size(248, 29);
            this.Label_measpow.TabIndex = 12;
            this.Label_measpow.Text = "Measured Power(W) :";
            // 
            // TextBox_exppow
            // 
            this.TextBox_exppow.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBox_exppow.Location = new System.Drawing.Point(272, 96);
            this.TextBox_exppow.Margin = new System.Windows.Forms.Padding(4);
            this.TextBox_exppow.Name = "TextBox_exppow";
            this.TextBox_exppow.ReadOnly = true;
            this.TextBox_exppow.Size = new System.Drawing.Size(192, 34);
            this.TextBox_exppow.TabIndex = 11;
            // 
            // Label_exppower
            // 
            this.Label_exppower.AutoSize = true;
            this.Label_exppower.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_exppower.Location = new System.Drawing.Point(14, 100);
            this.Label_exppower.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label_exppower.Name = "Label_exppower";
            this.Label_exppower.Size = new System.Drawing.Size(241, 29);
            this.Label_exppower.TabIndex = 10;
            this.Label_exppower.Text = "Expected Power(W) :";
            // 
            // TextBox_current
            // 
            this.TextBox_current.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBox_current.Location = new System.Drawing.Point(272, 228);
            this.TextBox_current.Margin = new System.Windows.Forms.Padding(4);
            this.TextBox_current.Name = "TextBox_current";
            this.TextBox_current.ReadOnly = true;
            this.TextBox_current.Size = new System.Drawing.Size(192, 34);
            this.TextBox_current.TabIndex = 5;
            // 
            // TextBox_load
            // 
            this.TextBox_load.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBox_load.Location = new System.Drawing.Point(272, 49);
            this.TextBox_load.Margin = new System.Windows.Forms.Padding(4);
            this.TextBox_load.Name = "TextBox_load";
            this.TextBox_load.ReadOnly = true;
            this.TextBox_load.Size = new System.Drawing.Size(192, 34);
            this.TextBox_load.TabIndex = 1;
            // 
            // Label_load
            // 
            this.Label_load.AutoSize = true;
            this.Label_load.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_load.Location = new System.Drawing.Point(14, 56);
            this.Label_load.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label_load.Name = "Label_load";
            this.Label_load.Size = new System.Drawing.Size(146, 29);
            this.Label_load.TabIndex = 0;
            this.Label_load.Text = "Load(ohm) :";
            // 
            // label_E200
            // 
            this.label_E200.AutoSize = true;
            this.label_E200.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_E200.Location = new System.Drawing.Point(8, 101);
            this.label_E200.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_E200.Name = "label_E200";
            this.label_E200.Size = new System.Drawing.Size(105, 29);
            this.label_E200.TabIndex = 10;
            this.label_E200.Text = "ES300 : ";
            // 
            // button_RSB_connect
            // 
            this.button_RSB_connect.BackColor = System.Drawing.SystemColors.Control;
            this.button_RSB_connect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_RSB_connect.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_RSB_connect.Location = new System.Drawing.Point(399, 192);
            this.button_RSB_connect.Margin = new System.Windows.Forms.Padding(4);
            this.button_RSB_connect.Name = "button_RSB_connect";
            this.button_RSB_connect.Size = new System.Drawing.Size(184, 46);
            this.button_RSB_connect.TabIndex = 9;
            this.button_RSB_connect.Text = "Disconnect";
            this.button_RSB_connect.UseVisualStyleBackColor = true;
            this.button_RSB_connect.Click += new System.EventHandler(this.button_RSB_connect_Click);
            // 
            // comboBox_RSB
            // 
            this.comboBox_RSB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboBox_RSB.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_RSB.FormattingEnabled = true;
            this.comboBox_RSB.Items.AddRange(new object[] {
            "KeySight - 2024A",
            "KeySight - DSOX4024A",
            "LeCroy"});
            this.comboBox_RSB.Location = new System.Drawing.Point(168, 194);
            this.comboBox_RSB.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox_RSB.Name = "comboBox_RSB";
            this.comboBox_RSB.Size = new System.Drawing.Size(223, 37);
            this.comboBox_RSB.TabIndex = 8;
            // 
            // Label_OSpicture
            // 
            this.Label_OSpicture.AutoSize = true;
            this.Label_OSpicture.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_OSpicture.Location = new System.Drawing.Point(585, 29);
            this.Label_OSpicture.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label_OSpicture.Name = "Label_OSpicture";
            this.Label_OSpicture.Size = new System.Drawing.Size(147, 29);
            this.Label_OSpicture.TabIndex = 7;
            this.Label_OSpicture.Text = "OS. Picture :";
            // 
            // PictureBox_OSpicture
            // 
            this.PictureBox_OSpicture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PictureBox_OSpicture.Cursor = System.Windows.Forms.Cursors.Help;
            this.PictureBox_OSpicture.Location = new System.Drawing.Point(590, 61);
            this.PictureBox_OSpicture.Margin = new System.Windows.Forms.Padding(4);
            this.PictureBox_OSpicture.Name = "PictureBox_OSpicture";
            this.PictureBox_OSpicture.Size = new System.Drawing.Size(286, 184);
            this.PictureBox_OSpicture.TabIndex = 6;
            this.PictureBox_OSpicture.TabStop = false;
            // 
            // Button_OSconnect
            // 
            this.Button_OSconnect.BackColor = System.Drawing.SystemColors.Control;
            this.Button_OSconnect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Button_OSconnect.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_OSconnect.Location = new System.Drawing.Point(399, 142);
            this.Button_OSconnect.Margin = new System.Windows.Forms.Padding(4);
            this.Button_OSconnect.Name = "Button_OSconnect";
            this.Button_OSconnect.Size = new System.Drawing.Size(184, 46);
            this.Button_OSconnect.TabIndex = 5;
            this.Button_OSconnect.Text = "Disconnect";
            this.Button_OSconnect.UseVisualStyleBackColor = true;
            this.Button_OSconnect.Click += new System.EventHandler(this.Button_OSconnect_Click);
            // 
            // ComboBox_oscillscope
            // 
            this.ComboBox_oscillscope.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ComboBox_oscillscope.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboBox_oscillscope.FormattingEnabled = true;
            this.ComboBox_oscillscope.Items.AddRange(new object[] {
            "KeySight - 2024A",
            "KeySight - 4024A",
            "LeCroy"});
            this.ComboBox_oscillscope.Location = new System.Drawing.Point(168, 144);
            this.ComboBox_oscillscope.Margin = new System.Windows.Forms.Padding(4);
            this.ComboBox_oscillscope.Name = "ComboBox_oscillscope";
            this.ComboBox_oscillscope.Size = new System.Drawing.Size(223, 37);
            this.ComboBox_oscillscope.TabIndex = 4;
            // 
            // Button_E200_connect
            // 
            this.Button_E200_connect.BackColor = System.Drawing.SystemColors.Control;
            this.Button_E200_connect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Button_E200_connect.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_E200_connect.Location = new System.Drawing.Point(399, 86);
            this.Button_E200_connect.Margin = new System.Windows.Forms.Padding(4);
            this.Button_E200_connect.Name = "Button_E200_connect";
            this.Button_E200_connect.Size = new System.Drawing.Size(184, 46);
            this.Button_E200_connect.TabIndex = 3;
            this.Button_E200_connect.Text = "Disconnect";
            this.Button_E200_connect.UseVisualStyleBackColor = true;
            this.Button_E200_connect.Click += new System.EventHandler(this.Button_E200_connect_Click);
            // 
            // ComboBox_E200
            // 
            this.ComboBox_E200.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ComboBox_E200.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboBox_E200.FormattingEnabled = true;
            this.ComboBox_E200.Location = new System.Drawing.Point(168, 91);
            this.ComboBox_E200.Margin = new System.Windows.Forms.Padding(4);
            this.ComboBox_E200.Name = "ComboBox_E200";
            this.ComboBox_E200.Size = new System.Drawing.Size(223, 37);
            this.ComboBox_E200.TabIndex = 2;
            // 
            // RadioButton_connect_manual
            // 
            this.RadioButton_connect_manual.AutoSize = true;
            this.RadioButton_connect_manual.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RadioButton_connect_manual.Font = new System.Drawing.Font("Georgia", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RadioButton_connect_manual.Location = new System.Drawing.Point(6, 54);
            this.RadioButton_connect_manual.Margin = new System.Windows.Forms.Padding(4);
            this.RadioButton_connect_manual.Name = "RadioButton_connect_manual";
            this.RadioButton_connect_manual.Size = new System.Drawing.Size(137, 39);
            this.RadioButton_connect_manual.TabIndex = 1;
            this.RadioButton_connect_manual.TabStop = true;
            this.RadioButton_connect_manual.Text = "manual";
            this.RadioButton_connect_manual.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.RadioButton_connect_manual.UseVisualStyleBackColor = true;
            this.RadioButton_connect_manual.CheckedChanged += new System.EventHandler(this.RadioButton_connect_manual_CheckedChanged);
            // 
            // RadioButton_connect_auto
            // 
            this.RadioButton_connect_auto.AutoSize = true;
            this.RadioButton_connect_auto.Checked = true;
            this.RadioButton_connect_auto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RadioButton_connect_auto.Font = new System.Drawing.Font("Georgia", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RadioButton_connect_auto.Location = new System.Drawing.Point(168, 54);
            this.RadioButton_connect_auto.Margin = new System.Windows.Forms.Padding(4);
            this.RadioButton_connect_auto.Name = "RadioButton_connect_auto";
            this.RadioButton_connect_auto.Size = new System.Drawing.Size(95, 39);
            this.RadioButton_connect_auto.TabIndex = 0;
            this.RadioButton_connect_auto.TabStop = true;
            this.RadioButton_connect_auto.Text = "auto";
            this.RadioButton_connect_auto.UseVisualStyleBackColor = true;
            this.RadioButton_connect_auto.CheckedChanged += new System.EventHandler(this.RadioButton_connect_auto_CheckedChanged);
            // 
            // GroupBox_mode
            // 
            this.GroupBox_mode.Controls.Add(this.radioButton_Clearall);
            this.GroupBox_mode.Controls.Add(this.radioButton_Selectall);
            this.GroupBox_mode.Controls.Add(this.checkedListBox_mode);
            this.GroupBox_mode.Font = new System.Drawing.Font("Georgia", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBox_mode.Location = new System.Drawing.Point(425, 265);
            this.GroupBox_mode.Margin = new System.Windows.Forms.Padding(4);
            this.GroupBox_mode.Name = "GroupBox_mode";
            this.GroupBox_mode.Padding = new System.Windows.Forms.Padding(4);
            this.GroupBox_mode.Size = new System.Drawing.Size(483, 180);
            this.GroupBox_mode.TabIndex = 36;
            this.GroupBox_mode.TabStop = false;
            this.GroupBox_mode.Text = "Calibration Mode";
            // 
            // radioButton_Clearall
            // 
            this.radioButton_Clearall.AutoSize = true;
            this.radioButton_Clearall.Font = new System.Drawing.Font("Georgia", 18F);
            this.radioButton_Clearall.Location = new System.Drawing.Point(186, 42);
            this.radioButton_Clearall.Margin = new System.Windows.Forms.Padding(4);
            this.radioButton_Clearall.Name = "radioButton_Clearall";
            this.radioButton_Clearall.Size = new System.Drawing.Size(153, 39);
            this.radioButton_Clearall.TabIndex = 30;
            this.radioButton_Clearall.Text = "Clear all ";
            this.radioButton_Clearall.UseVisualStyleBackColor = true;
            this.radioButton_Clearall.CheckedChanged += new System.EventHandler(this.radioButton_Clearall_CheckedChanged);
            // 
            // radioButton_Selectall
            // 
            this.radioButton_Selectall.AutoSize = true;
            this.radioButton_Selectall.Checked = true;
            this.radioButton_Selectall.Font = new System.Drawing.Font("Georgia", 18F);
            this.radioButton_Selectall.Location = new System.Drawing.Point(8, 42);
            this.radioButton_Selectall.Margin = new System.Windows.Forms.Padding(4);
            this.radioButton_Selectall.Name = "radioButton_Selectall";
            this.radioButton_Selectall.Size = new System.Drawing.Size(156, 39);
            this.radioButton_Selectall.TabIndex = 29;
            this.radioButton_Selectall.TabStop = true;
            this.radioButton_Selectall.Text = "Select all";
            this.radioButton_Selectall.UseVisualStyleBackColor = true;
            this.radioButton_Selectall.CheckedChanged += new System.EventHandler(this.radioButton_Selectall_CheckedChanged);
            // 
            // checkedListBox_mode
            // 
            this.checkedListBox_mode.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.checkedListBox_mode.CheckOnClick = true;
            this.checkedListBox_mode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkedListBox_mode.Font = new System.Drawing.Font("Georgia", 13F);
            this.checkedListBox_mode.FormattingEnabled = true;
            this.checkedListBox_mode.Items.AddRange(new object[] {
            "PURE",
            "BLEND1",
            "BLEND2",
            "PINPOINT",
            "SPRAY",
            "BIPOLAR"});
            this.checkedListBox_mode.Location = new System.Drawing.Point(9, 88);
            this.checkedListBox_mode.Margin = new System.Windows.Forms.Padding(4);
            this.checkedListBox_mode.MultiColumn = true;
            this.checkedListBox_mode.Name = "checkedListBox_mode";
            this.checkedListBox_mode.Size = new System.Drawing.Size(456, 58);
            this.checkedListBox_mode.TabIndex = 27;
            this.checkedListBox_mode.SelectedIndexChanged += new System.EventHandler(this.checkedListBox_mode_SelectedIndexChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.label_imformation2);
            this.tabPage2.Controls.Add(this.button_clear_engineer);
            this.tabPage2.Controls.Add(this.label_mode);
            this.tabPage2.Controls.Add(this.RichTextBox_infor_engineer);
            this.tabPage2.Controls.Add(this.GroupBox_report);
            this.tabPage2.Location = new System.Drawing.Point(4, 27);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage2.Size = new System.Drawing.Size(2487, 1235);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Debug Function";
            // 
            // label_imformation2
            // 
            this.label_imformation2.AutoSize = true;
            this.label_imformation2.Font = new System.Drawing.Font("Georgia", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_imformation2.Location = new System.Drawing.Point(16, 48);
            this.label_imformation2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_imformation2.Name = "label_imformation2";
            this.label_imformation2.Size = new System.Drawing.Size(278, 46);
            this.label_imformation2.TabIndex = 66;
            this.label_imformation2.Text = "Informations :";
            // 
            // button_clear_engineer
            // 
            this.button_clear_engineer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_clear_engineer.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_clear_engineer.Location = new System.Drawing.Point(401, 826);
            this.button_clear_engineer.Margin = new System.Windows.Forms.Padding(4);
            this.button_clear_engineer.Name = "button_clear_engineer";
            this.button_clear_engineer.Size = new System.Drawing.Size(198, 40);
            this.button_clear_engineer.TabIndex = 64;
            this.button_clear_engineer.Text = "Clear";
            this.button_clear_engineer.UseVisualStyleBackColor = true;
            this.button_clear_engineer.Click += new System.EventHandler(this.button_clear_engineer_Click);
            // 
            // label_mode
            // 
            this.label_mode.AutoSize = true;
            this.label_mode.Font = new System.Drawing.Font("Georgia", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_mode.Location = new System.Drawing.Point(674, 324);
            this.label_mode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_mode.Name = "label_mode";
            this.label_mode.Size = new System.Drawing.Size(130, 35);
            this.label_mode.TabIndex = 60;
            this.label_mode.Text = "MODE : ";
            // 
            // RichTextBox_infor_engineer
            // 
            this.RichTextBox_infor_engineer.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichTextBox_infor_engineer.HideSelection = false;
            this.RichTextBox_infor_engineer.Location = new System.Drawing.Point(25, 99);
            this.RichTextBox_infor_engineer.Margin = new System.Windows.Forms.Padding(4);
            this.RichTextBox_infor_engineer.Name = "RichTextBox_infor_engineer";
            this.RichTextBox_infor_engineer.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.RichTextBox_infor_engineer.Size = new System.Drawing.Size(573, 719);
            this.RichTextBox_infor_engineer.TabIndex = 61;
            this.RichTextBox_infor_engineer.Text = "";
            this.RichTextBox_infor_engineer.WordWrap = false;
            this.RichTextBox_infor_engineer.TextChanged += new System.EventHandler(this.RichTextBox_infor_engineer_TextChanged);
            // 
            // GroupBox_report
            // 
            this.GroupBox_report.Controls.Add(this.label_calibration_times);
            this.GroupBox_report.Controls.Add(this.button_CalibData);
            this.GroupBox_report.Controls.Add(this.button_reportdata);
            this.GroupBox_report.Controls.Add(this.chart_calibration_times_report);
            this.GroupBox_report.Controls.Add(this.comboBox_mode_report);
            this.GroupBox_report.Font = new System.Drawing.Font("Georgia", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBox_report.Location = new System.Drawing.Point(641, 48);
            this.GroupBox_report.Margin = new System.Windows.Forms.Padding(4);
            this.GroupBox_report.Name = "GroupBox_report";
            this.GroupBox_report.Padding = new System.Windows.Forms.Padding(4);
            this.GroupBox_report.Size = new System.Drawing.Size(954, 819);
            this.GroupBox_report.TabIndex = 65;
            this.GroupBox_report.TabStop = false;
            this.GroupBox_report.Text = "Report";
            // 
            // label_calibration_times
            // 
            this.label_calibration_times.AutoSize = true;
            this.label_calibration_times.Font = new System.Drawing.Font("Georgia", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_calibration_times.Location = new System.Drawing.Point(10, 225);
            this.label_calibration_times.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_calibration_times.Name = "label_calibration_times";
            this.label_calibration_times.Size = new System.Drawing.Size(519, 46);
            this.label_calibration_times.TabIndex = 67;
            this.label_calibration_times.Text = "Calinration Times Per Mode";
            // 
            // button_CalibData
            // 
            this.button_CalibData.Font = new System.Drawing.Font("Georgia", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_CalibData.Location = new System.Drawing.Point(288, 71);
            this.button_CalibData.Margin = new System.Windows.Forms.Padding(4);
            this.button_CalibData.Name = "button_CalibData";
            this.button_CalibData.Size = new System.Drawing.Size(268, 49);
            this.button_CalibData.TabIndex = 61;
            this.button_CalibData.Text = "Calibration Data";
            this.button_CalibData.UseVisualStyleBackColor = true;
            this.button_CalibData.Click += new System.EventHandler(this.button_CalibData_Click);
            // 
            // button_reportdata
            // 
            this.button_reportdata.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_reportdata.Font = new System.Drawing.Font("Georgia", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_reportdata.Location = new System.Drawing.Point(19, 71);
            this.button_reportdata.Margin = new System.Windows.Forms.Padding(4);
            this.button_reportdata.Name = "button_reportdata";
            this.button_reportdata.Size = new System.Drawing.Size(240, 49);
            this.button_reportdata.TabIndex = 50;
            this.button_reportdata.Text = "Report Datas";
            this.button_reportdata.UseVisualStyleBackColor = true;
            this.button_reportdata.Click += new System.EventHandler(this.button_reportdata_Click);
            // 
            // chart_calibration_times_report
            // 
            this.chart_calibration_times_report.BackColor = System.Drawing.SystemColors.Control;
            chartArea1.AxisX.Interval = 20D;
            chartArea1.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea1.AxisX.IsLabelAutoFit = false;
            chartArea1.AxisX.Maximum = 200D;
            chartArea1.AxisX.Minimum = 10D;
            chartArea1.AxisX.Title = "Watt";
            chartArea1.AxisX.TitleAlignment = System.Drawing.StringAlignment.Far;
            chartArea1.AxisX.TitleFont = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisX.TitleForeColor = System.Drawing.Color.Blue;
            chartArea1.AxisY.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea1.AxisY.Maximum = 40D;
            chartArea1.AxisY.Minimum = 0D;
            chartArea1.AxisY.Title = "Times";
            chartArea1.AxisY.TitleAlignment = System.Drawing.StringAlignment.Far;
            chartArea1.AxisY.TitleFont = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisY.TitleForeColor = System.Drawing.Color.Blue;
            chartArea1.Name = "ChartArea1";
            this.chart_calibration_times_report.ChartAreas.Add(chartArea1);
            legend1.AutoFitMinFontSize = 5;
            legend1.BackColor = System.Drawing.Color.White;
            legend1.BackImageAlignment = System.Windows.Forms.DataVisualization.Charting.ChartImageAlignmentStyle.TopRight;
            legend1.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            legend1.IsTextAutoFit = false;
            legend1.Name = "Legend1";
            legend1.Position.Auto = false;
            legend1.Position.Height = 15F;
            legend1.Position.Width = 26F;
            legend1.Position.X = 74F;
            legend1.TableStyle = System.Windows.Forms.DataVisualization.Charting.LegendTableStyle.Tall;
            this.chart_calibration_times_report.Legends.Add(legend1);
            this.chart_calibration_times_report.Location = new System.Drawing.Point(39, 330);
            this.chart_calibration_times_report.Margin = new System.Windows.Forms.Padding(4);
            this.chart_calibration_times_report.Name = "chart_calibration_times_report";
            this.chart_calibration_times_report.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            series1.BorderWidth = 3;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Color = System.Drawing.Color.Red;
            series1.IsValueShownAsLabel = true;
            series1.Label = "#VAL{G3}";
            series1.Legend = "Legend1";
            series1.Name = "Calibration Times";
            series1.SmartLabelStyle.CalloutLineColor = System.Drawing.Color.Red;
            this.chart_calibration_times_report.Series.Add(series1);
            this.chart_calibration_times_report.Size = new System.Drawing.Size(895, 489);
            this.chart_calibration_times_report.TabIndex = 57;
            this.chart_calibration_times_report.Text = "chart_calibration_times_report";
            // 
            // comboBox_mode_report
            // 
            this.comboBox_mode_report.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.comboBox_mode_report.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboBox_mode_report.Font = new System.Drawing.Font("Georgia", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_mode_report.FormattingEnabled = true;
            this.comboBox_mode_report.Items.AddRange(new object[] {
            "PURE",
            "BLEND1",
            "BLEND2",
            "SPRAY",
            "PINPOINT",
            "BIPOLAR"});
            this.comboBox_mode_report.Location = new System.Drawing.Point(174, 276);
            this.comboBox_mode_report.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox_mode_report.Name = "comboBox_mode_report";
            this.comboBox_mode_report.Size = new System.Drawing.Size(233, 43);
            this.comboBox_mode_report.TabIndex = 59;
            this.comboBox_mode_report.SelectedIndexChanged += new System.EventHandler(this.comboBox_mode_report_SelectedIndexChanged);
            // 
            // GroupBox_Connection
            // 
            this.GroupBox_Connection.Controls.Add(this.label_rsb);
            this.GroupBox_Connection.Controls.Add(this.label_Oscillscope);
            this.GroupBox_Connection.Controls.Add(this.label_E200);
            this.GroupBox_Connection.Controls.Add(this.button_RSB_connect);
            this.GroupBox_Connection.Controls.Add(this.comboBox_RSB);
            this.GroupBox_Connection.Controls.Add(this.Label_OSpicture);
            this.GroupBox_Connection.Controls.Add(this.PictureBox_OSpicture);
            this.GroupBox_Connection.Controls.Add(this.Button_OSconnect);
            this.GroupBox_Connection.Controls.Add(this.ComboBox_oscillscope);
            this.GroupBox_Connection.Controls.Add(this.Button_E200_connect);
            this.GroupBox_Connection.Controls.Add(this.ComboBox_E200);
            this.GroupBox_Connection.Controls.Add(this.RadioButton_connect_manual);
            this.GroupBox_Connection.Controls.Add(this.RadioButton_connect_auto);
            this.GroupBox_Connection.Font = new System.Drawing.Font("Georgia", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBox_Connection.Location = new System.Drawing.Point(14, 4);
            this.GroupBox_Connection.Margin = new System.Windows.Forms.Padding(4);
            this.GroupBox_Connection.Name = "GroupBox_Connection";
            this.GroupBox_Connection.Padding = new System.Windows.Forms.Padding(4);
            this.GroupBox_Connection.Size = new System.Drawing.Size(886, 261);
            this.GroupBox_Connection.TabIndex = 35;
            this.GroupBox_Connection.TabStop = false;
            this.GroupBox_Connection.Text = "Connection";
            // 
            // Label_current
            // 
            this.Label_current.AutoSize = true;
            this.Label_current.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_current.Location = new System.Drawing.Point(14, 231);
            this.Label_current.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label_current.Name = "Label_current";
            this.Label_current.Size = new System.Drawing.Size(256, 29);
            this.Label_current.TabIndex = 4;
            this.Label_current.Text = "Measured Current(A) :";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage_help);
            this.tabControl1.Location = new System.Drawing.Point(0, 1);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(2495, 1266);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.Button_start);
            this.tabPage1.Controls.Add(this.GroupBox_mode);
            this.tabPage1.Controls.Add(this.chart_cabration_run_chart);
            this.tabPage1.Controls.Add(this.GroupBox_value);
            this.tabPage1.Controls.Add(this.pictureBox1);
            this.tabPage1.Controls.Add(this.label_precent);
            this.tabPage1.Controls.Add(this.textBox_timer);
            this.tabPage1.Controls.Add(this.label_timer);
            this.tabPage1.Controls.Add(this.label_100);
            this.tabPage1.Controls.Add(this.progressBar_Calib);
            this.tabPage1.Controls.Add(this.RichTextBox_infor_user);
            this.tabPage1.Controls.Add(this.button_clear_user);
            this.tabPage1.Controls.Add(this.Button_pause);
            this.tabPage1.Controls.Add(this.Button_status);
            this.tabPage1.Controls.Add(this.Button_stop);
            this.tabPage1.Controls.Add(this.Label_informations);
            this.tabPage1.Controls.Add(this.label_0);
            this.tabPage1.Controls.Add(this.Label_Status);
            this.tabPage1.Controls.Add(this.GroupBox_Connection);
            this.tabPage1.Controls.Add(this.groupBox_function);
            this.tabPage1.Location = new System.Drawing.Point(4, 27);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(2487, 1235);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Main Function";
            // 
            // Button_start
            // 
            this.Button_start.BackColor = System.Drawing.SystemColors.Control;
            this.Button_start.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Button_start.Font = new System.Drawing.Font("Georgia", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_start.Location = new System.Drawing.Point(14, 724);
            this.Button_start.Margin = new System.Windows.Forms.Padding(4);
            this.Button_start.Name = "Button_start";
            this.Button_start.Size = new System.Drawing.Size(291, 128);
            this.Button_start.TabIndex = 61;
            this.Button_start.Text = "START";
            this.Button_start.UseVisualStyleBackColor = true;
            this.Button_start.Click += new System.EventHandler(this.Button_start_Click);
            // 
            // chart_cabration_run_chart
            // 
            textAnnotation1.AnchorAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            textAnnotation1.AnchorOffsetY = 20D;
            textAnnotation1.ClipToChartArea = "ChartArea1";
            textAnnotation1.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            textAnnotation1.ForeColor = System.Drawing.Color.Green;
            textAnnotation1.Name = "a0";
            textAnnotation1.SmartLabelStyle.AllowOutsidePlotArea = System.Windows.Forms.DataVisualization.Charting.LabelOutsidePlotAreaStyle.Yes;
            textAnnotation1.SmartLabelStyle.IsOverlappedHidden = false;
            textAnnotation1.SmartLabelStyle.MaxMovingDistance = 0D;
            textAnnotation1.SmartLabelStyle.MovingDirection = System.Windows.Forms.DataVisualization.Charting.LabelAlignmentStyles.TopLeft;
            textAnnotation1.Text = "a0";
            textAnnotation1.TextStyle = System.Windows.Forms.DataVisualization.Charting.TextStyle.Frame;
            textAnnotation1.X = 90D;
            textAnnotation1.Y = 20D;
            textAnnotation1.YAxisName = "ChartArea1\\rY";
            textAnnotation2.AnchorAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            textAnnotation2.AnchorOffsetY = 20D;
            textAnnotation2.ClipToChartArea = "ChartArea1";
            textAnnotation2.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            textAnnotation2.ForeColor = System.Drawing.Color.Green;
            textAnnotation2.Name = "a1";
            textAnnotation2.SmartLabelStyle.AllowOutsidePlotArea = System.Windows.Forms.DataVisualization.Charting.LabelOutsidePlotAreaStyle.Yes;
            textAnnotation2.SmartLabelStyle.IsOverlappedHidden = false;
            textAnnotation2.SmartLabelStyle.MaxMovingDistance = 0D;
            textAnnotation2.SmartLabelStyle.MovingDirection = System.Windows.Forms.DataVisualization.Charting.LabelAlignmentStyles.BottomRight;
            textAnnotation2.Text = "a1";
            textAnnotation2.TextStyle = System.Windows.Forms.DataVisualization.Charting.TextStyle.Frame;
            textAnnotation2.X = 90D;
            textAnnotation2.Y = 10D;
            textAnnotation2.YAxisName = "ChartArea1\\rY";
            textAnnotation3.Font = new System.Drawing.Font("Georgia", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            textAnnotation3.ForeColor = System.Drawing.Color.Fuchsia;
            textAnnotation3.Name = "TextAnnotation1";
            textAnnotation3.Text = "  ";
            textAnnotation3.X = 60D;
            textAnnotation3.Y = 75D;
            this.chart_cabration_run_chart.Annotations.Add(textAnnotation1);
            this.chart_cabration_run_chart.Annotations.Add(textAnnotation2);
            this.chart_cabration_run_chart.Annotations.Add(textAnnotation3);
            this.chart_cabration_run_chart.BackColor = System.Drawing.SystemColors.Control;
            chartArea2.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea2.AxisX.IsLabelAutoFit = false;
            chartArea2.AxisX.Maximum = 20D;
            chartArea2.AxisX.Minimum = 0D;
            chartArea2.AxisX.Title = "Times";
            chartArea2.AxisX.TitleAlignment = System.Drawing.StringAlignment.Far;
            chartArea2.AxisX.TitleFont = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea2.AxisX.TitleForeColor = System.Drawing.Color.Blue;
            chartArea2.AxisY.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea2.AxisY.LabelStyle.Format = "N0";
            chartArea2.AxisY.Maximum = 25D;
            chartArea2.AxisY.Minimum = -5D;
            chartArea2.AxisY.Title = "Watt";
            chartArea2.AxisY.TitleAlignment = System.Drawing.StringAlignment.Far;
            chartArea2.AxisY.TitleFont = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea2.AxisY.TitleForeColor = System.Drawing.Color.Blue;
            chartArea2.Name = "ChartArea1";
            chartArea2.Position.Auto = false;
            chartArea2.Position.Height = 100F;
            chartArea2.Position.Width = 100F;
            this.chart_cabration_run_chart.ChartAreas.Add(chartArea2);
            this.chart_cabration_run_chart.Cursor = System.Windows.Forms.Cursors.No;
            legend2.AutoFitMinFontSize = 5;
            legend2.BackColor = System.Drawing.Color.White;
            legend2.BackImageAlignment = System.Windows.Forms.DataVisualization.Charting.ChartImageAlignmentStyle.TopRight;
            legend2.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            legend2.IsTextAutoFit = false;
            legend2.Name = "Legend1";
            legend2.TableStyle = System.Windows.Forms.DataVisualization.Charting.LegendTableStyle.Tall;
            this.chart_cabration_run_chart.Legends.Add(legend2);
            this.chart_cabration_run_chart.Location = new System.Drawing.Point(916, 151);
            this.chart_cabration_run_chart.Margin = new System.Windows.Forms.Padding(4);
            this.chart_cabration_run_chart.Name = "chart_cabration_run_chart";
            this.chart_cabration_run_chart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Range;
            series2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            series2.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series2.LabelForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            series2.Legend = "Legend1";
            series2.Name = "Accuracy";
            series2.SmartLabelStyle.CalloutLineAnchorCapStyle = System.Windows.Forms.DataVisualization.Charting.LineAnchorCapStyle.Diamond;
            series2.SmartLabelStyle.CalloutLineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            series2.SmartLabelStyle.Enabled = false;
            series2.SmartLabelStyle.IsMarkerOverlappingAllowed = true;
            series2.SmartLabelStyle.MovingDirection = System.Windows.Forms.DataVisualization.Charting.LabelAlignmentStyles.Left;
            series2.YValuesPerPoint = 2;
            series3.BorderWidth = 3;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Color = System.Drawing.Color.Red;
            series3.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series3.LabelForeColor = System.Drawing.Color.Red;
            series3.Legend = "Legend1";
            series3.Name = "Expection";
            series3.SmartLabelStyle.CalloutLineAnchorCapStyle = System.Windows.Forms.DataVisualization.Charting.LineAnchorCapStyle.Diamond;
            series3.SmartLabelStyle.Enabled = false;
            series3.SmartLabelStyle.IsOverlappedHidden = false;
            series4.BorderWidth = 2;
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.Color = System.Drawing.Color.Blue;
            series4.IsValueShownAsLabel = true;
            series4.Label = "#VAL{G3}";
            series4.LabelForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            series4.LabelFormat = "N2";
            series4.Legend = "Legend1";
            series4.MarkerBorderColor = System.Drawing.Color.White;
            series4.MarkerColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            series4.MarkerSize = 10;
            series4.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            series4.Name = "Measurement";
            series4.SmartLabelStyle.AllowOutsidePlotArea = System.Windows.Forms.DataVisualization.Charting.LabelOutsidePlotAreaStyle.Yes;
            series4.SmartLabelStyle.CalloutLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            series4.SmartLabelStyle.IsMarkerOverlappingAllowed = true;
            series4.SmartLabelStyle.IsOverlappedHidden = false;
            series4.SmartLabelStyle.MaxMovingDistance = 0D;
            this.chart_cabration_run_chart.Series.Add(series2);
            this.chart_cabration_run_chart.Series.Add(series3);
            this.chart_cabration_run_chart.Series.Add(series4);
            this.chart_cabration_run_chart.Size = new System.Drawing.Size(718, 469);
            this.chart_cabration_run_chart.TabIndex = 60;
            this.chart_cabration_run_chart.Text = "chart1";
            // 
            // GroupBox_value
            // 
            this.GroupBox_value.Controls.Add(this.TextBox_measpow);
            this.GroupBox_value.Controls.Add(this.Label_measpow);
            this.GroupBox_value.Controls.Add(this.TextBox_exppow);
            this.GroupBox_value.Controls.Add(this.Label_exppower);
            this.GroupBox_value.Controls.Add(this.TextBox_current);
            this.GroupBox_value.Controls.Add(this.TextBox_load);
            this.GroupBox_value.Controls.Add(this.Label_load);
            this.GroupBox_value.Controls.Add(this.Label_current);
            this.GroupBox_value.Controls.Add(this.Label_voltage);
            this.GroupBox_value.Controls.Add(this.TextBox_vlotage);
            this.GroupBox_value.Font = new System.Drawing.Font("Georgia", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBox_value.Location = new System.Drawing.Point(425, 436);
            this.GroupBox_value.Margin = new System.Windows.Forms.Padding(4);
            this.GroupBox_value.Name = "GroupBox_value";
            this.GroupBox_value.Padding = new System.Windows.Forms.Padding(4);
            this.GroupBox_value.Size = new System.Drawing.Size(475, 271);
            this.GroupBox_value.TabIndex = 46;
            this.GroupBox_value.TabStop = false;
            this.GroupBox_value.Text = "Value";
            // 
            // Label_voltage
            // 
            this.Label_voltage.AutoSize = true;
            this.Label_voltage.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_voltage.Location = new System.Drawing.Point(14, 188);
            this.Label_voltage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label_voltage.Name = "Label_voltage";
            this.Label_voltage.Size = new System.Drawing.Size(253, 29);
            this.Label_voltage.TabIndex = 2;
            this.Label_voltage.Text = "Measured Voltage(V) :";
            // 
            // TextBox_vlotage
            // 
            this.TextBox_vlotage.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBox_vlotage.Location = new System.Drawing.Point(272, 184);
            this.TextBox_vlotage.Margin = new System.Windows.Forms.Padding(4);
            this.TextBox_vlotage.Name = "TextBox_vlotage";
            this.TextBox_vlotage.ReadOnly = true;
            this.TextBox_vlotage.Size = new System.Drawing.Size(192, 34);
            this.TextBox_vlotage.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(908, 8);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(722, 126);
            this.pictureBox1.TabIndex = 59;
            this.pictureBox1.TabStop = false;
            // 
            // label_precent
            // 
            this.label_precent.AutoSize = true;
            this.label_precent.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_precent.Location = new System.Drawing.Point(1251, 799);
            this.label_precent.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_precent.Name = "label_precent";
            this.label_precent.Size = new System.Drawing.Size(48, 29);
            this.label_precent.TabIndex = 58;
            this.label_precent.Text = "0%";
            // 
            // textBox_timer
            // 
            this.textBox_timer.Font = new System.Drawing.Font("Georgia", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_timer.Location = new System.Drawing.Point(1208, 664);
            this.textBox_timer.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_timer.Name = "textBox_timer";
            this.textBox_timer.ReadOnly = true;
            this.textBox_timer.Size = new System.Drawing.Size(422, 98);
            this.textBox_timer.TabIndex = 55;
            this.textBox_timer.Text = "00 : 00 : 00";
            this.textBox_timer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label_timer
            // 
            this.label_timer.AutoSize = true;
            this.label_timer.Font = new System.Drawing.Font("Georgia", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_timer.Location = new System.Drawing.Point(1201, 624);
            this.label_timer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_timer.Name = "label_timer";
            this.label_timer.Size = new System.Drawing.Size(112, 35);
            this.label_timer.TabIndex = 54;
            this.label_timer.Text = "Timer :";
            // 
            // label_100
            // 
            this.label_100.AutoSize = true;
            this.label_100.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_100.Location = new System.Drawing.Point(1569, 851);
            this.label_100.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_100.Name = "label_100";
            this.label_100.Size = new System.Drawing.Size(59, 24);
            this.label_100.TabIndex = 42;
            this.label_100.Text = "100%";
            // 
            // progressBar_Calib
            // 
            this.progressBar_Calib.Cursor = System.Windows.Forms.Cursors.No;
            this.progressBar_Calib.Location = new System.Drawing.Point(916, 771);
            this.progressBar_Calib.Margin = new System.Windows.Forms.Padding(4);
            this.progressBar_Calib.Name = "progressBar_Calib";
            this.progressBar_Calib.Size = new System.Drawing.Size(714, 71);
            this.progressBar_Calib.TabIndex = 51;
            // 
            // RichTextBox_infor_user
            // 
            this.RichTextBox_infor_user.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichTextBox_infor_user.Location = new System.Drawing.Point(14, 436);
            this.RichTextBox_infor_user.Margin = new System.Windows.Forms.Padding(4);
            this.RichTextBox_infor_user.Name = "RichTextBox_infor_user";
            this.RichTextBox_infor_user.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.RichTextBox_infor_user.Size = new System.Drawing.Size(394, 215);
            this.RichTextBox_infor_user.TabIndex = 50;
            this.RichTextBox_infor_user.Text = "";
            this.RichTextBox_infor_user.TextChanged += new System.EventHandler(this.RichTextBox_infor_user_TextChanged);
            // 
            // button_clear_user
            // 
            this.button_clear_user.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_clear_user.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_clear_user.Location = new System.Drawing.Point(220, 668);
            this.button_clear_user.Margin = new System.Windows.Forms.Padding(4);
            this.button_clear_user.Name = "button_clear_user";
            this.button_clear_user.Size = new System.Drawing.Size(198, 40);
            this.button_clear_user.TabIndex = 41;
            this.button_clear_user.Text = "Clear";
            this.button_clear_user.UseVisualStyleBackColor = true;
            this.button_clear_user.Click += new System.EventHandler(this.button_clear_user_Click);
            // 
            // Button_pause
            // 
            this.Button_pause.BackColor = System.Drawing.SystemColors.Control;
            this.Button_pause.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Button_pause.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.Button_pause.Font = new System.Drawing.Font("Georgia", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_pause.Location = new System.Drawing.Point(312, 724);
            this.Button_pause.Margin = new System.Windows.Forms.Padding(4);
            this.Button_pause.Name = "Button_pause";
            this.Button_pause.Size = new System.Drawing.Size(291, 128);
            this.Button_pause.TabIndex = 40;
            this.Button_pause.Text = "PAUSE";
            this.Button_pause.UseVisualStyleBackColor = true;
            this.Button_pause.Click += new System.EventHandler(this.Button_pause_Click);
            // 
            // Button_status
            // 
            this.Button_status.BackColor = System.Drawing.Color.White;
            this.Button_status.Cursor = System.Windows.Forms.Cursors.No;
            this.Button_status.Font = new System.Drawing.Font("Georgia", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_status.Location = new System.Drawing.Point(916, 664);
            this.Button_status.Margin = new System.Windows.Forms.Padding(4);
            this.Button_status.Name = "Button_status";
            this.Button_status.Size = new System.Drawing.Size(284, 100);
            this.Button_status.TabIndex = 44;
            this.Button_status.Text = "NONE";
            this.Button_status.UseVisualStyleBackColor = false;
            // 
            // Button_stop
            // 
            this.Button_stop.BackColor = System.Drawing.SystemColors.Control;
            this.Button_stop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Button_stop.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.Button_stop.Font = new System.Drawing.Font("Georgia", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_stop.Location = new System.Drawing.Point(611, 724);
            this.Button_stop.Margin = new System.Windows.Forms.Padding(4);
            this.Button_stop.Name = "Button_stop";
            this.Button_stop.Size = new System.Drawing.Size(289, 128);
            this.Button_stop.TabIndex = 43;
            this.Button_stop.Text = "STOP";
            this.Button_stop.UseVisualStyleBackColor = true;
            this.Button_stop.Click += new System.EventHandler(this.Button_stop_Click);
            // 
            // Label_informations
            // 
            this.Label_informations.AutoSize = true;
            this.Label_informations.Font = new System.Drawing.Font("Georgia", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_informations.Location = new System.Drawing.Point(14, 381);
            this.Label_informations.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label_informations.Name = "Label_informations";
            this.Label_informations.Size = new System.Drawing.Size(278, 46);
            this.Label_informations.TabIndex = 37;
            this.Label_informations.Text = "Informations :";
            // 
            // label_0
            // 
            this.label_0.AutoSize = true;
            this.label_0.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_0.Location = new System.Drawing.Point(912, 851);
            this.label_0.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_0.Name = "label_0";
            this.label_0.Size = new System.Drawing.Size(38, 24);
            this.label_0.TabIndex = 38;
            this.label_0.Text = "0%";
            // 
            // groupBox_function
            // 
            this.groupBox_function.Controls.Add(this.radioButton_calibration);
            this.groupBox_function.Controls.Add(this.radioButton_verify);
            this.groupBox_function.Font = new System.Drawing.Font("Georgia", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_function.Location = new System.Drawing.Point(9, 272);
            this.groupBox_function.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox_function.Name = "groupBox_function";
            this.groupBox_function.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox_function.Size = new System.Drawing.Size(400, 105);
            this.groupBox_function.TabIndex = 66;
            this.groupBox_function.TabStop = false;
            this.groupBox_function.Text = "Function";
            // 
            // radioButton_calibration
            // 
            this.radioButton_calibration.AutoSize = true;
            this.radioButton_calibration.Checked = true;
            this.radioButton_calibration.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton_calibration.Location = new System.Drawing.Point(44, 56);
            this.radioButton_calibration.Margin = new System.Windows.Forms.Padding(4);
            this.radioButton_calibration.Name = "radioButton_calibration";
            this.radioButton_calibration.Size = new System.Drawing.Size(152, 33);
            this.radioButton_calibration.TabIndex = 64;
            this.radioButton_calibration.TabStop = true;
            this.radioButton_calibration.Text = "Calibration";
            this.radioButton_calibration.UseVisualStyleBackColor = true;
            this.radioButton_calibration.CheckedChanged += new System.EventHandler(this.radioButton_calibration_CheckedChanged);
            // 
            // radioButton_verify
            // 
            this.radioButton_verify.AutoSize = true;
            this.radioButton_verify.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton_verify.Location = new System.Drawing.Point(231, 56);
            this.radioButton_verify.Margin = new System.Windows.Forms.Padding(4);
            this.radioButton_verify.Name = "radioButton_verify";
            this.radioButton_verify.Size = new System.Drawing.Size(159, 33);
            this.radioButton_verify.TabIndex = 65;
            this.radioButton_verify.Text = "Verification";
            this.radioButton_verify.UseVisualStyleBackColor = true;
            this.radioButton_verify.CheckedChanged += new System.EventHandler(this.radioButton_verify_CheckedChanged);
            // 
            // tabPage_help
            // 
            this.tabPage_help.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage_help.Controls.Add(this.textBox6);
            this.tabPage_help.Controls.Add(this.textBox5);
            this.tabPage_help.Controls.Add(this.textBox4);
            this.tabPage_help.Controls.Add(this.textBox3);
            this.tabPage_help.Controls.Add(this.textBox2);
            this.tabPage_help.Controls.Add(this.textBox1);
            this.tabPage_help.Controls.Add(this.pictureBox3);
            this.tabPage_help.Controls.Add(this.pictureBox2);
            this.tabPage_help.Controls.Add(this.pictureBox_email2);
            this.tabPage_help.Controls.Add(this.pictureBox_tel2);
            this.tabPage_help.Controls.Add(this.pictureBox_ad2);
            this.tabPage_help.Controls.Add(this.label_us);
            this.tabPage_help.Controls.Add(this.textBox_us);
            this.tabPage_help.Controls.Add(this.pictureBox_email);
            this.tabPage_help.Controls.Add(this.pictureBox_tel);
            this.tabPage_help.Controls.Add(this.pictureBox_add);
            this.tabPage_help.Controls.Add(this.label_web);
            this.tabPage_help.Controls.Add(this.label_taiwan);
            this.tabPage_help.Controls.Add(this.textBox_head);
            this.tabPage_help.Controls.Add(this.label_contact_us);
            this.tabPage_help.Location = new System.Drawing.Point(4, 27);
            this.tabPage_help.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage_help.Name = "tabPage_help";
            this.tabPage_help.Size = new System.Drawing.Size(2487, 1235);
            this.tabPage_help.TabIndex = 2;
            this.tabPage_help.Text = "Help";
            // 
            // textBox6
            // 
            this.textBox6.BackColor = System.Drawing.SystemColors.Control;
            this.textBox6.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox6.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox6.Location = new System.Drawing.Point(136, 782);
            this.textBox6.Margin = new System.Windows.Forms.Padding(4);
            this.textBox6.Name = "textBox6";
            this.textBox6.ReadOnly = true;
            this.textBox6.Size = new System.Drawing.Size(221, 27);
            this.textBox6.TabIndex = 66;
            this.textBox6.Text = "info@newdean.com";
            // 
            // textBox5
            // 
            this.textBox5.BackColor = System.Drawing.SystemColors.Control;
            this.textBox5.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox5.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox5.Location = new System.Drawing.Point(136, 695);
            this.textBox5.Margin = new System.Windows.Forms.Padding(4);
            this.textBox5.Multiline = true;
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(288, 58);
            this.textBox5.TabIndex = 65;
            this.textBox5.Text = "TEL: (+1) (925) 280.8388\r\nFAX: (+1) (925) 280.1788 ";
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.SystemColors.Control;
            this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox4.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox4.Location = new System.Drawing.Point(136, 626);
            this.textBox4.Margin = new System.Windows.Forms.Padding(4);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(661, 27);
            this.textBox4.TabIndex = 64;
            this.textBox4.Text = "1990 N. California Blvd. Suite 1040 Walnut Creek, CA 94596";
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.SystemColors.Control;
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Location = new System.Drawing.Point(136, 420);
            this.textBox3.Margin = new System.Windows.Forms.Padding(4);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(259, 40);
            this.textBox3.TabIndex = 63;
            this.textBox3.Text = "info@newdean.com.tw";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.Control;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(136, 332);
            this.textBox2.Margin = new System.Windows.Forms.Padding(4);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(316, 65);
            this.textBox2.TabIndex = 62;
            this.textBox2.Text = "TEL: (+886) (2) 2268-1726\r\nFAX: (+886) (2) 2268-3800 ";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Control;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(136, 264);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(992, 27);
            this.textBox1.TabIndex = 61;
            this.textBox1.Text = "12F., No.51, Sec. 4, Chong Yang Rd. Tu Cheng District, New Taipei City 23675 Taiw" +
    "an R.O.C.";
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.White;
            this.pictureBox3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox3.BackgroundImage")));
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox3.Location = new System.Drawing.Point(872, 18);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(722, 126);
            this.pictureBox3.TabIndex = 60;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(1256, 154);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(339, 244);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 37;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox_email2
            // 
            this.pictureBox_email2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_email2.Image")));
            this.pictureBox_email2.Location = new System.Drawing.Point(85, 782);
            this.pictureBox_email2.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox_email2.Name = "pictureBox_email2";
            this.pictureBox_email2.Size = new System.Drawing.Size(39, 40);
            this.pictureBox_email2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_email2.TabIndex = 33;
            this.pictureBox_email2.TabStop = false;
            // 
            // pictureBox_tel2
            // 
            this.pictureBox_tel2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_tel2.Image")));
            this.pictureBox_tel2.Location = new System.Drawing.Point(85, 695);
            this.pictureBox_tel2.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox_tel2.Name = "pictureBox_tel2";
            this.pictureBox_tel2.Size = new System.Drawing.Size(39, 40);
            this.pictureBox_tel2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_tel2.TabIndex = 32;
            this.pictureBox_tel2.TabStop = false;
            // 
            // pictureBox_ad2
            // 
            this.pictureBox_ad2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_ad2.Image")));
            this.pictureBox_ad2.Location = new System.Drawing.Point(85, 626);
            this.pictureBox_ad2.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox_ad2.Name = "pictureBox_ad2";
            this.pictureBox_ad2.Size = new System.Drawing.Size(39, 41);
            this.pictureBox_ad2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_ad2.TabIndex = 31;
            this.pictureBox_ad2.TabStop = false;
            // 
            // label_us
            // 
            this.label_us.AutoSize = true;
            this.label_us.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.label_us.Font = new System.Drawing.Font("Georgia", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_us.Location = new System.Drawing.Point(79, 572);
            this.label_us.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_us.Name = "label_us";
            this.label_us.Size = new System.Drawing.Size(327, 31);
            this.label_us.TabIndex = 30;
            this.label_us.Text = "New Deantronics, Ltd.\r\n";
            // 
            // textBox_us
            // 
            this.textBox_us.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_us.Font = new System.Drawing.Font("Georgia", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_us.Location = new System.Drawing.Point(22, 512);
            this.textBox_us.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_us.Name = "textBox_us";
            this.textBox_us.Size = new System.Drawing.Size(1194, 35);
            this.textBox_us.TabIndex = 29;
            this.textBox_us.Text = "  U.S. Office";
            // 
            // pictureBox_email
            // 
            this.pictureBox_email.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_email.Image")));
            this.pictureBox_email.Location = new System.Drawing.Point(85, 420);
            this.pictureBox_email.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox_email.Name = "pictureBox_email";
            this.pictureBox_email.Size = new System.Drawing.Size(39, 40);
            this.pictureBox_email.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_email.TabIndex = 27;
            this.pictureBox_email.TabStop = false;
            // 
            // pictureBox_tel
            // 
            this.pictureBox_tel.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_tel.Image")));
            this.pictureBox_tel.Location = new System.Drawing.Point(85, 332);
            this.pictureBox_tel.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox_tel.Name = "pictureBox_tel";
            this.pictureBox_tel.Size = new System.Drawing.Size(39, 40);
            this.pictureBox_tel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_tel.TabIndex = 25;
            this.pictureBox_tel.TabStop = false;
            // 
            // pictureBox_add
            // 
            this.pictureBox_add.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_add.Image")));
            this.pictureBox_add.Location = new System.Drawing.Point(85, 264);
            this.pictureBox_add.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox_add.Name = "pictureBox_add";
            this.pictureBox_add.Size = new System.Drawing.Size(39, 41);
            this.pictureBox_add.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_add.TabIndex = 23;
            this.pictureBox_add.TabStop = false;
            // 
            // label_web
            // 
            this.label_web.AutoSize = true;
            this.label_web.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label_web.Font = new System.Drawing.Font("Georgia", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_web.ForeColor = System.Drawing.Color.Blue;
            this.label_web.Location = new System.Drawing.Point(22, 105);
            this.label_web.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_web.Name = "label_web";
            this.label_web.Size = new System.Drawing.Size(315, 18);
            this.label_web.TabIndex = 22;
            this.label_web.Text = "http://www.newdean.com.tw/ND/index.aspx";
            this.label_web.Click += new System.EventHandler(this.label_web_click);
            // 
            // label_taiwan
            // 
            this.label_taiwan.AutoSize = true;
            this.label_taiwan.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.label_taiwan.Font = new System.Drawing.Font("Georgia", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_taiwan.Location = new System.Drawing.Point(79, 205);
            this.label_taiwan.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_taiwan.Name = "label_taiwan";
            this.label_taiwan.Size = new System.Drawing.Size(370, 31);
            this.label_taiwan.TabIndex = 21;
            this.label_taiwan.Text = " Nwe Deantronics Taiwan";
            // 
            // textBox_head
            // 
            this.textBox_head.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_head.Font = new System.Drawing.Font("Georgia", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_head.Location = new System.Drawing.Point(22, 154);
            this.textBox_head.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_head.Name = "textBox_head";
            this.textBox_head.Size = new System.Drawing.Size(1194, 35);
            this.textBox_head.TabIndex = 20;
            this.textBox_head.Text = "  Headquarters and Manufacturing Facility";
            // 
            // label_contact_us
            // 
            this.label_contact_us.AutoSize = true;
            this.label_contact_us.Font = new System.Drawing.Font("Georgia", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_contact_us.ForeColor = System.Drawing.Color.DarkBlue;
            this.label_contact_us.Location = new System.Drawing.Point(10, 18);
            this.label_contact_us.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_contact_us.Name = "label_contact_us";
            this.label_contact_us.Size = new System.Drawing.Size(320, 69);
            this.label_contact_us.TabIndex = 19;
            this.label_contact_us.Text = "Contact Us";
            // 
            // serialPort_E200
            // 
            this.serialPort_E200.BaudRate = 115200;
            this.serialPort_E200.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort_E200_DataReceived);
            // 
            // timer_Calibration
            // 
            this.timer_Calibration.Tick += new System.EventHandler(this.timer_Calibration_Tick);
            // 
            // timer_Detect_serial_port
            // 
            this.timer_Detect_serial_port.Interval = 2000;
            this.timer_Detect_serial_port.Tick += new System.EventHandler(this.timer_Detect_serial_port_Tick);
            // 
            // serialPort_RSB
            // 
            this.serialPort_RSB.BaudRate = 115200;
            this.serialPort_RSB.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort_RSB_DataReceived);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1685, 916);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Georgia", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "ES300 Calibration System - V26";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_OSpicture)).EndInit();
            this.GroupBox_mode.ResumeLayout(false);
            this.GroupBox_mode.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.GroupBox_report.ResumeLayout(false);
            this.GroupBox_report.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart_calibration_times_report)).EndInit();
            this.GroupBox_Connection.ResumeLayout(false);
            this.GroupBox_Connection.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart_cabration_run_chart)).EndInit();
            this.GroupBox_value.ResumeLayout(false);
            this.GroupBox_value.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox_function.ResumeLayout(false);
            this.groupBox_function.PerformLayout();
            this.tabPage_help.ResumeLayout(false);
            this.tabPage_help.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_email2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_tel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_ad2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_email)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_tel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_add)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Label Label_Status;
        private System.Windows.Forms.Label label_rsb;
        private System.Windows.Forms.Label label_Oscillscope;
        internal System.Windows.Forms.TextBox TextBox_measpow;
        internal System.Windows.Forms.Label Label_measpow;
        internal System.Windows.Forms.TextBox TextBox_exppow;
        internal System.Windows.Forms.Label Label_exppower;
        internal System.Windows.Forms.TextBox TextBox_current;
        internal System.Windows.Forms.TextBox TextBox_load;
        internal System.Windows.Forms.Label Label_load;
        private System.Windows.Forms.Label label_E200;
        internal System.Windows.Forms.Button button_RSB_connect;
        internal System.Windows.Forms.ComboBox comboBox_RSB;
        internal System.Windows.Forms.Label Label_OSpicture;
        internal System.Windows.Forms.PictureBox PictureBox_OSpicture;
        internal System.Windows.Forms.Button Button_OSconnect;
        internal System.Windows.Forms.ComboBox ComboBox_oscillscope;
        internal System.Windows.Forms.Button Button_E200_connect;
        internal System.Windows.Forms.ComboBox ComboBox_E200;
        internal System.Windows.Forms.RadioButton RadioButton_connect_manual;
        internal System.Windows.Forms.RadioButton RadioButton_connect_auto;
        internal System.Windows.Forms.GroupBox GroupBox_mode;
        private System.Windows.Forms.CheckedListBox checkedListBox_mode;
        private System.Windows.Forms.TabPage tabPage2;
        internal System.Windows.Forms.GroupBox GroupBox_Connection;
        private System.Windows.Forms.Timer timer_timer;
        internal System.Windows.Forms.Label Label_current;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label_precent;
        private System.Windows.Forms.TextBox textBox_timer;
        private System.Windows.Forms.Label label_timer;
        private System.Windows.Forms.Label label_100;
        private System.Windows.Forms.ProgressBar progressBar_Calib;
        internal System.Windows.Forms.RichTextBox RichTextBox_infor_user;
        internal System.Windows.Forms.Button button_clear_user;
        internal System.Windows.Forms.Button Button_pause;
        internal System.Windows.Forms.Button Button_status;
        internal System.Windows.Forms.Button Button_stop;
        internal System.Windows.Forms.Label Label_informations;
        internal System.Windows.Forms.GroupBox GroupBox_value;
        internal System.Windows.Forms.Label Label_voltage;
        internal System.Windows.Forms.TextBox TextBox_vlotage;
        private System.Windows.Forms.Label label_0;
        private System.IO.Ports.SerialPort serialPort_E200;
        private System.Windows.Forms.Timer timer_Calibration;
        internal System.Windows.Forms.Button button_clear_engineer;
        internal System.Windows.Forms.RichTextBox RichTextBox_infor_engineer;
        private System.Windows.Forms.GroupBox GroupBox_report;
        internal System.Windows.Forms.Button button_reportdata;
        private System.Windows.Forms.Label label_mode;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_calibration_times_report;
        internal System.Windows.Forms.ComboBox comboBox_mode_report;
        private System.Windows.Forms.Button button_CalibData;
        private System.Windows.Forms.Timer timer_Detect_serial_port;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_cabration_run_chart;
        internal System.Windows.Forms.Button Button_start;
        private System.Windows.Forms.TabPage tabPage_help;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox_email2;
        private System.Windows.Forms.PictureBox pictureBox_tel2;
        private System.Windows.Forms.PictureBox pictureBox_ad2;
        private System.Windows.Forms.Label label_us;
        private System.Windows.Forms.TextBox textBox_us;
        private System.Windows.Forms.PictureBox pictureBox_email;
        private System.Windows.Forms.PictureBox pictureBox_tel;
        private System.Windows.Forms.PictureBox pictureBox_add;
        private System.Windows.Forms.Label label_web;
        private System.Windows.Forms.Label label_taiwan;
        private System.Windows.Forms.TextBox textBox_head;
        private System.Windows.Forms.Label label_contact_us;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        internal System.Windows.Forms.Label label_calibration_times;
        internal System.Windows.Forms.Label label_imformation2;
        private System.Windows.Forms.GroupBox groupBox_function;
        private System.Windows.Forms.RadioButton radioButton_calibration;
        private System.Windows.Forms.RadioButton radioButton_verify;
        private System.IO.Ports.SerialPort serialPort_RSB;
        private System.Windows.Forms.RadioButton radioButton_Clearall;
        private System.Windows.Forms.RadioButton radioButton_Selectall;

    }
}

