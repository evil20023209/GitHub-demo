using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;
using System.IO;
using System.Globalization;
using Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.Diagnostics;
using System.Windows.Forms.DataVisualization.Charting;
using System.Timers;

namespace Csharp
{
    public partial class MainForm : Form
    {
        IScope ScopeCtrl;//
        double double_measure_voltage; //
        double double_measure_voltage_first; //
        double double_measure_current; //
        double double_measure_current_first; //
        double double_measure_power;//
        double double_measure_power_first;//
        int int_expect_power;//
        int int_expect_power_max;//
        double double_power_diff;//
        double double_power_diff_first;//
        double double_power_percentage;//
        double double_power_percentage_first;//
        double double_CalibData;//
        //double[,] double_array_CalibData = new double[6, 20];//更改矩陣大小[6, 20]->[6, 30] 使300W校正能正常執行  Sean.Lin 20171006   
        double[,] double_array_CalibData = new double[6, 30];
        int int_Runtimes;//
        int int_Runtimes_max = 50;//
        uint uint_voltage_channel = 1;//
        uint uint_current_channel = 2;//
        double double_power_percentage_high = 10;// 
        //double double_power_percentage_low = 0;//Modify the lower limit . Sean.Lin_20171018
        double double_power_percentage_low = -10;
        int int_excel_select_mode;//
        bool bool_measure_first;//

        int int_hour = 0;
        int int_minute = 0;
        int int_second = 0;
        int int_timer_counter = 0;

        FileStream txt_user;
        FileStream txt_engineer;
        string string_file_path;
        string string_file_txt_user;
        string string_file_txt_engineer;

        Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
        Workbook workbook;
        double double_accacptable_area_max;
        double double_accacptable_area_min;

        //int[,] int_report = new int[7, 201];    //int_report[mode,watt] = times   //更改矩陣大小new int[7, 201]->new int[7, 301] 使300W校正能正常執行 Sean.Lin 20171006
        int[,] int_report = new int[7, 301];                               

        System.Timers.Timer timer_timer1 = new System.Timers.Timer();

        bool bool_connected_E200 = false;
        bool bool_connected_RSB = false;
        bool stopjudgment = false;  //防止停止輸出後，持續判斷的問題 Sean.Lin20171030

        public MainForm()
        {
            InitializeComponent();
            ComboBox_E200.Enabled = false;
            ComboBox_oscillscope.Enabled = false;
            comboBox_RSB.Enabled = false;

            ComboBox_E200.Items.AddRange(System.IO.Ports.SerialPort.GetPortNames());
            serialPort_E200.DataReceived += new SerialDataReceivedEventHandler(serialPort_E200_DataReceived);

            comboBox_RSB.Items.AddRange(System.IO.Ports.SerialPort.GetPortNames());
            serialPort_RSB.DataReceived += new SerialDataReceivedEventHandler(serialPort_RSB_DataReceived);

            for (int i = 0; i < checkedListBox_mode.Items.Count; i++)
            {
                checkedListBox_mode.SetItemChecked(i, true);
            }

            RichTextBox_infor_engineer.AppendText(DateTime.Now.ToString("G") + "\n");
            RichTextBox_infor_user.AppendText(DateTime.Now.ToString("G") + "\n");

            string_file_path = System.IO.Directory.GetCurrentDirectory();                                                                 //creat a directory with mm.dd.yy hr.min.sec AM 
            string strint_new_file = DateTime.Now.ToString("G", CultureInfo.CreateSpecificCulture("en-us"));
            strint_new_file = strint_new_file.Replace(":", ".");
            strint_new_file = strint_new_file.Replace("/", ".");
            string_file_path = System.IO.Path.Combine(string_file_path, strint_new_file);

            RichTextBox_infor_engineer.AppendText(string_file_path + "\n");
            System.IO.Directory.CreateDirectory(string_file_path);

            string_file_txt_user = string_file_path + "\\user_Calibration_Data.txt";                                                             //create two TXT files to save text in RichTextBox_infor_engineer & RichTextBox_infor_user
            txt_user = new FileStream(string_file_txt_user, FileMode.Create);
            txt_user.Close();

            string_file_txt_engineer = string_file_path + "\\engineer_Calibration_Data.txt";
            txt_engineer = new FileStream(string_file_txt_engineer, FileMode.Create);
            txt_engineer.Close();


            workbook = excel.Application.Workbooks.Add(true);
           

            chart_cabration_run_chart.ChartAreas[0].AxisX.Maximum = int_Runtimes_max;
            //chart_cabration_run_chart.ChartAreas[0].AxisY.Minimum = 5; //更動Chart的初始最大值與最小值 20171102_Sean.Lin
            //chart_cabration_run_chart.ChartAreas[0].AxisY.Maximum = 15; //20171102_Sean.Lin
            this.chart_cabration_run_chart.ChartAreas[0].AxisY.LabelStyle.Format = "N1";
            chart_cabration_run_chart.ChartAreas[0].AxisY.Minimum = 10 - 10 * 0.3; //初始從10開始
            chart_cabration_run_chart.ChartAreas[0].AxisY.Maximum = 10 + 10 * 0.3;

            //chart_cabration_run_chart.Series[0].Points.AddXY(0, 10, 10 + 10 * double_power_percentage_high * 0.01); //更動Chart的初始可接受範圍 20171102_Sean.Lin
            //chart_cabration_run_chart.Series[0].Points.AddXY(int_Runtimes_max, 10, 10 + 10 * double_power_percentage_high * 0.01); //20171102_Sean.Lin
            chart_cabration_run_chart.Series[0].Points.AddXY(0, 10 + 10 * double_power_percentage_low * 0.01, 10 + 10 * double_power_percentage_high * 0.01);
            chart_cabration_run_chart.Series[0].Points.AddXY(int_Runtimes_max, 10 + 10 * double_power_percentage_low * 0.01, 10 + 10 * double_power_percentage_high * 0.01);

            chart_cabration_run_chart.Series[1].Points.AddXY(0, 10);
            chart_cabration_run_chart.Series[1].Points.AddXY(int_Runtimes_max, 10);
            ((TextAnnotation)chart_cabration_run_chart.Annotations[0]).Text = Convert.ToString(10 + 10 * double_power_percentage_high * 0.01);
            ((TextAnnotation)chart_cabration_run_chart.Annotations[0]).Y = chart_cabration_run_chart.Series[0].Points[0].YValues[1] + 0.5;

            ((TextAnnotation)chart_cabration_run_chart.Annotations[1]).Text = Convert.ToString(10 + 10 * double_power_percentage_low * 0.01);
            ((TextAnnotation)chart_cabration_run_chart.Annotations[1]).Y = chart_cabration_run_chart.Series[0].Points[0].YValues[0] + 0.5;

            chart_cabration_run_chart.Series[0].Color = Color.FromArgb(192, 255, 255, 100);

            label_precent.BackColor = Color.Transparent;//
            PictureBox_OSpicture.SizeMode = PictureBoxSizeMode.Zoom;//

            RadioButton_connect_auto.Checked = true;//
            Button_start.Enabled = true;//
            Button_pause.Enabled = false;//
            Button_stop.Enabled = false;//

            timer_timer1.Elapsed += new ElapsedEventHandler(timer_timer1_Tick);
            timer_Detect_serial_port.Start();

        }
        //**********************************************************************************************************************
        //
        // Copyright (C) 2017, ND CO.,LTD. Taiwan  All Rights Reserved
        //
        //! @fn : button_clear_user_click
        //
        //! @author : Sean.Lin
        //
        //! @date : 2017.10.24
        //
        //! @brief : clear Richtxtbox_infor_user and other data .
        //
        //! @param :
        //
        //! @return :
        //
        //**********************************************************************************************************************
        private void button_clear_user_Click(object sender, EventArgs e)
        {
            RichTextBox_infor_user.Text = "";
            TextBox_load.Text = ""; //Sean.Lin_20171024
            TextBox_exppow.Text = "";
            TextBox_measpow.Text = "";
            TextBox_vlotage.Text = "";
            TextBox_current.Text = "";
            chart_cabration_run_chart.Series[2].Points.Clear();
            ((TextAnnotation)chart_cabration_run_chart.Annotations[2]).Text = "";
            textBox_timer.Text = "00" + " : " + "00" + " : " + "00";
            progressBar_Calib.Value = 0;
            label_precent.Text = Convert.ToString(progressBar_Calib.Value / 10) + "%";
            Button_status.Text = "NONE";
            Button_status.BackColor = Color.White;
        }
        //**********************************************************************************************************************
        //
        // Copyright (C) 2017, ND CO.,LTD. Taiwan  All Rights Reserved
        //
        //! @fn : button_clear_engineer
        //
        //! @author : Lynn.Wei
        //
        //! @date : 2017.07.14
        //
        //! @brief : clear Richtxtbox_infor_engineer
        //
        //! @param : int_mode, int_line, int_colum, string_txt
        //
        //! @return :
        //
        //**********************************************************************************************************************
        private void button_clear_engineer_Click(object sender, EventArgs e)
        {
            RichTextBox_infor_engineer.Text = "";
        }
        //**********************************************************************************************************************
        //
        // Copyright (C) 2017, ND CO.,LTD. Taiwan  All Rights Reserved
        //
        //! @fn : calibration_run_chart
        //
        //! @author : Lynn.Wei
        //
        //! @date : 2017.07.14
        //
        //! @brief : add points on calibration_run_chart
        //
        //! @param : int_exp_watt, int_meas_watt, int int_times
        //
        //! @return :
        //
        //**********************************************************************************************************************

        private void calibration_run_chart(double double_meas_watt, int int_times)
        {
            //if double_meas_watt out AxisY of calibration_run_chart, reset the max and min number of AxisY
            if (double_meas_watt > chart_cabration_run_chart.ChartAreas[0].AxisY.Maximum)
            {
                chart_cabration_run_chart.ChartAreas[0].AxisY.Maximum = double_meas_watt;
            }
            else if (double_meas_watt < chart_cabration_run_chart.ChartAreas[0].AxisY.Minimum)
            {
                chart_cabration_run_chart.ChartAreas[0].AxisY.Minimum = double_meas_watt;
            }

            chart_cabration_run_chart.ChartAreas[0].AxisX.Maximum = int_Runtimes_max;

            //add point
            chart_cabration_run_chart.Series[2].Points.AddXY(int_times, Math.Round(double_meas_watt, 2));

        }
        //**********************************************************************************************************************
        //
        // Copyright (C) 2017, ND CO.,LTD. Taiwan  All Rights Reserved
        //
        //! @fn : comboBox_mode_report_SelectedIndexChanged
        //
        //! @author : Sean.Lin
        //
        //! @date : 2017.10.12
        //
        //! @brief : 01. if select a index in comboBox_mode_report, chart_calibration_times_report will show the corresponding chart
        //           02. 更改E300對應各模式之瓦數
        //
        //! @param :
        //
        //! @return :
        //
        //**********************************************************************************************************************
        private void comboBox_mode_report_SelectedIndexChanged(object sender, EventArgs e)
        {
            chart_calibration_times_report.Series[0].Points.Clear();
            switch (comboBox_mode_report.SelectedItem.ToString())                //calicate the steps of prograss bar
            {
                case "PURE":
                    //calibration_times_report(200, 0, int_report); 更改E300對應各模式之瓦數  Sean.Lin_20171006 
                    calibration_times_report(300, 0, int_report);
                    break;
                case "BLEND1":
                    //calibration_times_report(150, 0, int_report); 更改E300對應各模式之瓦數  Sean.Lin_20171006
                    calibration_times_report(250, 1, int_report);
                    break;
                case "BLEND2":
                    //calibration_times_report(150, 0, int_report); 更改E300對應各模式之瓦數  Sean.Lin_20171006
                    calibration_times_report(250, 2, int_report);
                    break;
                case "SPRAY":
                    //calibration_times_report(80, 0, int_report); 更改E300對應各模式之瓦數  Sean.Lin_20171006
                    calibration_times_report(100, 3, int_report);
                    break;
                case "PINPOINT":
                    //calibration_times_report(100, 0, int_report); 更改E300對應各模式之瓦數  Sean.Lin_20171006
                    calibration_times_report(120, 4, int_report);
                    break;
                case "BIPOLAR":
                    //calibration_times_report(60, 0, int_report); 更改E300對應各模式之瓦數  Sean.Lin_20171006
                    calibration_times_report(80, 5, int_report);
                    break;
            }
        }
        private void calibration_times_report(int int_max_watt, int int_mode, int[,] int_report)
        {
            chart_calibration_times_report.ChartAreas[0].AxisX.Maximum = int_max_watt;
            chart_calibration_times_report.ChartAreas[0].AxisY.Maximum = 1;

            for (int i = 10; i <= int_max_watt; i = i + 10)
            {
                if (int_report[int_mode, i] > chart_calibration_times_report.ChartAreas[0].AxisY.Maximum)
                {
                    chart_calibration_times_report.ChartAreas[0].AxisY.Maximum = int_report[int_mode, i];
                }
                chart_calibration_times_report.Series[0].Points.AddXY(i, int_report[int_mode, i]);
            }
        }
        //**********************************************************************************************************************
        //
        // Copyright (C) 2017, ND CO.,LTD. Taiwan  All Rights Reserved
        //
        //! @fn : button_reportdata_Click
        //
        //! @author : Lynn.Wei
        //
        //! @date : 2017.07.18
        //
        //! @brief : Call an external application (excel) to show the calibration data
        //
        //! @param :
        //
        //! @return :
        //
        //**********************************************************************************************************************
        private void button_reportdata_Click(object sender, EventArgs e)
        {
            string string_excel_file_path = string_file_path + "\\Calibration Data.xlsx";
            if (!File.Exists(string_excel_file_path))
            {
                MessageBox.Show("檔案不存在");
            }
            else
            {
                Process.Start(string_excel_file_path);
            }
        }
        //**********************************************************************************************************************
        //
        // Copyright (C) 2017, ND CO.,LTD. Taiwan  All Rights Reserved
        //
        //! @fn : RadioButton_connect_manual_CheckedChanged
        //
        //! @author : Lynn.Wei
        //
        //! @date :2017.07.06
        //
        //! @brief :if choose manual mode, able  ComboBox_COMport & ComboBox_oscillscope & Combobox_RSB
        //
        //! @param :
        //
        //! @return :
        //
        //**********************************************************************************************************************
        private void RadioButton_connect_manual_CheckedChanged(object sender, EventArgs e)
        {
            ComboBox_E200.Enabled = true;
            ComboBox_oscillscope.Enabled = true;
            comboBox_RSB.Enabled = true;

            Button_start.Enabled = true;//
            Button_pause.Enabled = false;//
            Button_stop.Enabled = false;//
        }
        //**********************************************************************************************************************
        //
        // Copyright (C) 2017, ND CO.,LTD. Taiwan  All Rights Reserved
        //
        //! @fn : RadioButton_connect_auto_CheckedChanged
        //
        //! @author : Lynn.Wei
        //
        //! @date :2017.07.06
        //
        //! @brief :if choose auto mode, enable  ComboBox_COMport & ComboBox_oscillscope
        //
        //! @param :
        //
        //! @return :
        //
        //**********************************************************************************************************************
        private void RadioButton_connect_auto_CheckedChanged(object sender, EventArgs e)
        {
            ComboBox_E200.Enabled = false;
            ComboBox_oscillscope.Enabled = false;
            comboBox_RSB.Enabled = false;

            Button_start.Enabled = true;//
            Button_pause.Enabled = false;//
            Button_stop.Enabled = false;//
        }
        //**********************************************************************************************************************
        //
        // Copyright (C) 2017, ND CO.,LTD. Taiwan  All Rights Reserved
        //
        //! @fn : Excel
        //
        //! @author : Lynn.Wei
        //
        //! @date : 2017.07.14
        //
        //! @brief : put callibration datas into excel
        //
        //! @param : int_mode, int_line, int_colum, string_txt
        //
        //! @return :
        //
        //**********************************************************************************************************************
        private void Excel(int int_calubrate_times_count, int int_line, int int_colum, string string_txt)
        {
            workbook.Sheets[int_calubrate_times_count].cells[int_line, int_colum] = string_txt;
        }
        //**********************************************************************************************************************
        //
        // Copyright (C) 2017, ND CO.,LTD. Taiwan  All Rights Reserved
        //
        //! @fn : serialPort_E200_DataReceived
        //
        //! @author : Sean.Lin
        //
        //! @date : 2017.07.11
        //
        //! @brief : 01. when serialPort_E200 received data, call UpdateUI() to put received data into RichTextBox_infor
        //           02. 根據瓦數提升至300W做矩陣大小的更動
        //
        //! @param : 
        //
        //! @return :
        //
        //**********************************************************************************************************************
        string string_recrived_E200 = "";
        string string_mode_watt = "";
        string string_mode_voltage = "";

        string string_sub_string = "";
        string string_calib_data = "";
        string string_sub_calib_data_mode = "";

        bool bool_start_calibration = false;
        //double[,] double_ary_E200_calibrate_data = new double[6, 20];//根據瓦數提升至300W做矩陣大小的更動 Sean.Lin_20171019 
        double[,] double_ary_E200_calibrate_data = new double[6, 30];

        private void serialPort_E200_DataReceived(Object sender, SerialDataReceivedEventArgs e)
        {

            SerialPort sp = (SerialPort)sender;
            string_recrived_E200 = string_recrived_E200 + sp.ReadExisting();

            MethodInvoker mi = new MethodInvoker(this.UpdateUI);
            this.BeginInvoke(mi, null);

            if (bool_start_calibration == true)
            {
                if (string_recrived_E200.IndexOf("MPU:[") != -1 && string_recrived_E200.IndexOf("]") != -1)      //make sure the received data come from E200
                {
                    if (string_recrived_E200.IndexOf("MODE_WATT") != -1)                     //received data include "MODE_WATT"
                    {
                        string_mode_watt = string_recrived_E200.Substring(string_recrived_E200.IndexOf("=") + 1, string_recrived_E200.IndexOf("]") - 1 - string_recrived_E200.IndexOf("="));  //string_received_value equals to the value between "=" and "]"

                        if (string_recrived_E200.Length > string_recrived_E200.IndexOf("]") + 1)
                        {
                            MethodInvoker mi1 = new MethodInvoker(this.UpdateUI1);
                            this.BeginInvoke(mi1, null);
                        }
                        else
                        {
                            string_mode_voltage = Convert.ToString(0);
                        }
                    }
                }

            }
            if (string_recrived_E200.IndexOf("CALIB_DATA") != -1)
            {
                if (string_recrived_E200.IndexOf("CALIB_DATA") > 6)
                {
                    string_calib_data = string_recrived_E200.Substring(string_recrived_E200.IndexOf("CALIB_DATA"), string_recrived_E200.Length - string_recrived_E200.IndexOf("CALIB_DATA") + 1 + 6);
                }
                else
                {
                    string_calib_data = string_recrived_E200;
                }
                if (string_calib_data.IndexOf("]") != -1)
                {
                    MethodInvoker mi2 = new MethodInvoker(this.UpdateUI2);
                    this.BeginInvoke(mi2, null);
                }

            }
        }
        //**********************************************************************************************************************
        //
        // Copyright (C) 2017, ND CO.,LTD. Taiwan  All Rights Reserved
        //
        //! @fn : serialPort_E200_DataReceived
        //
        //! @author : Sean.Lin
        //
        //! @date : 2017.10.19
        //
        //! @brief : 01. when serialPort_E200 received data, call UpdateUI() to put received data from serialPort_E200 into RichTextBox_infor .
        //           02. 根據瓦數提升至300W int_mode_time 做更動。
        //
        //! @param : 
        //
        //! @return :
        //
        //**********************************************************************************************************************
        string string_test = "test";
        private void UpdateUI()
        {
            if (string_test != string_recrived_E200) //避免重複讀取相同內容
            {
                if (string_recrived_E200.IndexOf(string_test) != -1)
                {
                    string_recrived_E200 = string_recrived_E200.Substring(string_recrived_E200.IndexOf(string_test) + 1, string_recrived_E200.Length - string_recrived_E200.IndexOf(string_test) - 1);
                }
                RichTextBox_infor_engineer.AppendText("Received E200-> " + string_recrived_E200 + "\n");
            }
            string_test = string_recrived_E200;
        }

        //擷取mode vlotage
        private void UpdateUI1()
        {
            if (string_recrived_E200.Length > 10)
            {
                string_sub_string = string_recrived_E200.Substring(string_recrived_E200.Length - 10, 10);  //string_sub_string equal's to the 10 letters before the end of string_recrived_E200
                string_mode_voltage = string_sub_string.Substring(4, 5);
            }
            else
                string_mode_voltage = Convert.ToString(0);
        }

        // 擷取calibration data
        private void UpdateUI2()
        {
            string_sub_calib_data_mode = string_calib_data.Substring(string_calib_data.IndexOf("_") + 6, string_calib_data.IndexOf("=") - 1 - string_calib_data.IndexOf("_") - 5);
            RichTextBox_infor_engineer.AppendText("here  " + string_sub_calib_data_mode + "\n");
            int int_mode_time = 0;
            int int_mode = 0;
            switch (string_sub_calib_data_mode)
            {
                case "PURE":
                    int_mode = 0;
                    //int_mode_time = 20;////根據瓦數提升至300W做更動 Sean.Lin_20171019 
                    int_mode_time = 30;
                    break;
                case "BLEND1":
                    int_mode = 1;
                    //int_mode_time = 15;
                    int_mode_time = 25;
                    break;
                case "BLEND2":
                    int_mode = 2;
                    //int_mode_time = 15;
                    int_mode_time = 25;
                    break;
                case "SPRAY":
                    int_mode = 3;
                    //int_mode_time = 8;
                    int_mode_time = 10;
                    break;
                case "PINPOINT":
                    int_mode = 4;
                    //int_mode_time = 10;
                    int_mode_time = 12;
                    break;
                case "BIPOLAR":
                    int_mode = 5;
                    //int_mode_time = 6;
                    int_mode_time = 8;
                    break;

            }
            for (int count = 0; count < int_mode_time; count++)
            {
                RichTextBox_infor_engineer.AppendText(string_calib_data.Substring(string_calib_data.IndexOf("=") + 1 + count * 5, 4) + "\n");
                double_ary_E200_calibrate_data[int_mode, count] = Convert.ToDouble(string_calib_data.Substring(string_calib_data.IndexOf("=") + 1 + count * 5, 4));
            }
        }
        
        //**********************************************************************************************************************
        //
        // Copyright (C) 2017, ND CO.,LTD. Taiwan  All Rights Reserved
        //
        //! @fn : Button_E200_connect_Click
        //
        //! @author : Lynn.Wei
        //
        //! @date : 2017.07.06
        //
        //! @brief : automatically connect COM port and E200 by calling Connect_COM()
        //
        //! @param : 
        //
        //! @return :
        //
        //**********************************************************************************************************************
        private void Button_E200_connect_Click(object sender, EventArgs e)
        {
            //disconnect
            if (bool_connected_E200)
            {
                serialPort_E200.Close();
                Button_E200_connect.Text = "Disconnect";
                ComboBox_E200.Text = "";
                bool_connected_E200 = false;
                timer_Detect_serial_port.Start();

                RichTextBox_infor_user.AppendText("Disconnect E200.\n");
                RichTextBox_infor_engineer.AppendText("Disconnect E200.\n");
            }
            //before connecting
            else
            {
                bool bool_auto;

                if (RadioButton_connect_manual.Checked)
                    bool_auto = false;
                else
                    bool_auto = true;
                if (ComboBox_E200.SelectedItem == null && bool_auto == false && ComboBox_E200.Text == "")   //manual, but not choose a COM port
                {
                    RichTextBox_infor_engineer.AppendText("Choose a COM Port.\n");
                    RichTextBox_infor_user.AppendText("Choose a COM Port.\n\n");
                    MessageBox.Show("Please choose a COM port of the E200.");
                    timer_Detect_serial_port.Start();
                    return;
                }
                if (ComboBox_E200.Items.Count == 0)   //ComboBox_COMport is empty
                {
                    RichTextBox_infor_engineer.AppendText("No COM Port is exists.\n");
                    RichTextBox_infor_user.AppendText("No COM Port is exists.\n");
                    MessageBox.Show("No COM Port is exists.");
                    Button_E200_connect.Text = "Disconnect";
                    timer_Detect_serial_port.Start();
                    return;
                }

                //connecting
                ComboBox_E200.Enabled = false;          //flase to chose COM port if connecting
                Button_E200_connect.Enabled = false;        //flase to click Button if connecting
                String string_E200_connected_port = "non";
                if (bool_auto)
                {
                    string[] string_COMportname = new string[ComboBox_E200.Items.Count];      // the size of string_COMportname = item-numbers of ComboBox_COMport
                    ComboBox_E200.Items.CopyTo(string_COMportname, 0);                    //copy items in ComboBox_COMport to string array

                    for (int int_count = 0; int_count <= ComboBox_E200.Items.Count - 1; int_count++)
                    {
                        if (Connect_E200_COM(string_COMportname[int_count]))
                        {
                            bool_connected_E200 = true;
                            string_E200_connected_port = string_COMportname[int_count];
                            break;
                        }

                    }

                }
                else
                {
                    string string_COMportname = ComboBox_E200.Text;
                    string_E200_connected_port = ComboBox_E200.Text;
                    if (Connect_E200_COM(string_COMportname))                      //如果正確連接E200，跳出迴圈
                    {
                        bool_connected_E200 = true;
                    }
                }


                //after connecting

                Button_E200_connect.Enabled = true;

                if (!bool_auto)
                {
                    ComboBox_E200.Enabled = true;
                }
                if(!bool_connected_E200)
                {
                    MessageBox.Show("False to connect E200.");
                }
            }

        }

        //**********************************************************************************************************************
        //
        // Copyright (C) 2017, ND CO.,LTD. Taiwan  All Rights Reserved
        //
        //! @fn : Connect_E200_COM
        //
        //! @author : Lynn.Wei
        //
        //! @date : 2017.07.06
        //
        //! @brief : called by Button_E200_connect_Click, automatically connect COM port and E200
        //
        //! @param : string_COMportname
        //
        //! @return : true or false
        //
        //**********************************************************************************************************************

        private bool Connect_E200_COM(string string_COMportname)
        {
            if (string_COMportname == comboBox_RSB.Text) //當RSB已經連接此com port，直接跳出，避免時間浪費
                return false;
            Button_E200_connect.Text = "Opening...";
            RichTextBox_infor_engineer.AppendText("\n" + "Connecting " + string_COMportname + "...\n");
            serialPort_E200.Close();
            try
            {
                serialPort_E200.PortName = (string_COMportname);
                serialPort_E200.Open();
            }
            catch (Exception ex_open_port)                                           //show exception
            {
                RichTextBox_infor_engineer.AppendText("False to open port" + string_COMportname + ".\n");
                RichTextBox_infor_engineer.AppendText(ex_open_port.Message + "\n");

                RichTextBox_infor_user.AppendText("False to open port" + string_COMportname + ".\n");

                Button_E200_connect.Text = "Disconnect";
                return false;
            }
            RichTextBox_infor_engineer.AppendText("Connected " + string_COMportname + ".\n");
            RichTextBox_infor_user.AppendText("Connected " + string_COMportname + ".\n");

            if (serialPort_E200.IsOpen)                                     //make sure if connected is E200
            {
                RichTextBox_infor_engineer.AppendText("Connecting E200...\n");
                string_recrived_E200 = "";

                try
                {
                    E200_transmit("MODE", "WATT", "0");
                    E200_transmit("MODE", "PURE", "0");
                }
                catch (Exception ex_connect_E200)
                {
                    RichTextBox_infor_engineer.AppendText(ex_connect_E200.Message + "\n");
                    RichTextBox_infor_engineer.AppendText("False to connect E200.\n\n");
                    Button_E200_connect.Text = "Disconnect";
                    return false;
                }

                Thread.Sleep(1000);
                System.Windows.Forms.Application.DoEvents();

                if (string_recrived_E200 == "" || string_recrived_E200 == " ")                                                                //do not receive signal
                {
                    RichTextBox_infor_engineer.AppendText("Do not receive return signal.\n");
                    RichTextBox_infor_engineer.AppendText("False to connect E200.\n\n");
                    RichTextBox_infor_user.AppendText("False to connect E200.\n\n");
                    Button_E200_connect.Text = "Disconnect";
                    return false;

                }
                else if (string_recrived_E200.IndexOf("MPU") < 0)                                      //recived signals, but not from E200
                {
                    RichTextBox_infor_engineer.AppendText("Return signal is not from E200. \n");
                    RichTextBox_infor_engineer.AppendText("False to connect E200.\n\n");
                    RichTextBox_infor_user.AppendText("False to connect E200.\n\n");
                    Button_E200_connect.Text = "Disconnect";
                    return false;
                }
                Button_E200_connect.Text = "Connected";
                E200_transmit("MODE", "DISABLE", "0");
                ComboBox_E200.Text = string_COMportname;
                RichTextBox_infor_engineer.AppendText("Connected E200.\n");
                RichTextBox_infor_user.AppendText("Connectecd E200.\n");
                return true;
            }
            else
            {
                RichTextBox_infor_engineer.AppendText("false to Connect" + string_COMportname + ".\n");
                return false;
            }

        }


        //**********************************************************************************************************************
        //
        // Copyright (C) 2017, ND CO.,LTD. Taiwan  All Rights Reserved
        //
        //! @fn : E_200
        //
        //! @author : Lynn.Wei
        //
        //! @date : 2017.07.10
        //
        //! @brief : send messages to E200
        //
        //! @param : string_Command_type, string_Commend_symbol, string_value
        //
        //! @return :
        //
        //**********************************************************************************************************************
        public void E200_transmit(string string_Command_type, string string_Commend_symbol, string string_value)
        {
            string string_send_E200 = "PC:[" + string_Command_type + "_" + string_Commend_symbol + "=" + string_value + "]";
            // RichTextBox RichTextBox_infor_engineer = new RichTextBox();
            RichTextBox_infor_engineer.AppendText("Sent E200 -> " + string_send_E200 + "\n");
            try
            {
                //SerialPort serialPort_E200 = new SerialPort();
                serialPort_E200.Write(string_send_E200 + 0);
            }
            catch (Exception ex)
            {
                RichTextBox_infor_engineer.AppendText(Convert.ToString(ex));
                
                ForceStop("FAIL", Color.Red);
                Button_E200_connect.PerformClick();
                MessageBox.Show("E200 transmit error.");
            }
        }
        //**********************************************************************************************************************
        //
        // Copyright (C) 2017, ND CO.,LTD. Taiwan  All Rights Reserved
        //
        //! @fn : timer_timer1_Tick
        //
        //! @author : Lynn.Wei
        //
        //! @date : 2017.07.10
        //
        //! @brief : a dynamic timer to count time
        //
        //! @param :
        //
        //! @return :
        //
        //**********************************************************************************************************************
        string string_hour;
        string string_minute;
        string string_second;
        private void timer_timer1_Tick(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.DoEvents();

            int_timer_counter = int_timer_counter + 1;
            int_hour = int_timer_counter / 3600;
            int_minute = (int_timer_counter - int_hour * 3600) / 60;
            int_second = (int_timer_counter - int_hour * 3600 - int_minute * 60);

            if (int_hour < 10)
                string_hour = 0 + Convert.ToString(int_hour);
            else
                string_hour = Convert.ToString(int_hour);

            if (int_minute < 10)
                string_minute = 0 + Convert.ToString(int_minute);
            else
                string_minute = Convert.ToString(int_minute);

            if (int_second < 10)
                string_second = 0 + Convert.ToString(int_second);
            else
                string_second = Convert.ToString(int_second);

            MethodInvoker mi1 = new MethodInvoker(this.Updatetimer);
            this.BeginInvoke(mi1, null);

        }
        private void Updatetimer()
        {
            textBox_timer.Text = string_hour + " : " + string_minute + " : " + string_second;
        }
        //**********************************************************************************************************************
        //
        // Copyright (C) 2017, ND CO.,LTD. Taiwan  All Rights Reserved
        //
        //! @fn     :   Button_OSconnect_Click
        //
        //! @author :   Grace.Lee
        //
        //! @date   :   2017.07.10
        //
        //! @brief  :   After you select "manual" or "auto" and press the "connect OS" button, PC will connect to the correct oscilloscope through USB.
        //              At the same time, the picture of the oscilloscope will show on C# interface. 
        //
        //! @param  :   NONE
        //
        //! @return :   TYPE eScopeType: choose oscilloscope type
        //
        //**********************************************************************************************************************
        bool bool_OS_connect = false;
        private void Button_OSconnect_Click(object sender, EventArgs e)
        {
            TYPE eScopeType = TYPE.NONE;

            if (bool_OS_connect)
            {
                ComboBox_oscillscope.Text = "";
                PictureBox_OSpicture.Image = null;
                Label_OSpicture.Text = "OS. Picture :";
            }

            if (RadioButton_connect_auto.Checked == true)
            {
                if (ScopeCtrl == null)
                {
                    if (Button_OSconnect.Text == "Disconnect")
                    {
                        Button_OSconnect.Enabled = false;
                        Button_OSconnect.Text = "Openning";
                        try
                        {
                            ScopeCtrl = new Keysight();
                            eScopeType = TYPE.KEYSIGHT_4024A;
                            ScopeCtrl.Connect(eScopeType);
                            ScopeCtrl.Init();

                            PictureBox_OSpicture.Image = Csharp.Properties.Resources.keysight_4024A;
                            Label_OSpicture.Text = "OS. Picture :\n KeySight - 4024A ";
                            ComboBox_oscillscope.Text = "KeySight - 4024A ";
                            Button_OSconnect.Text = "Connected";
                            RichTextBox_infor_engineer.AppendText("OS connected. \n");
                            RichTextBox_infor_user.AppendText("OS connected. \n");
                            bool_OS_connect = true;
                        }
                        catch
                        {
                            try
                            {
                                ScopeCtrl = new Keysight();
                                eScopeType = TYPE.KEYSIGHT_2024A;
                                ScopeCtrl.Connect(eScopeType);
                                ScopeCtrl.Init();

                                PictureBox_OSpicture.Image = Csharp.Properties.Resources.keysight_2024A;
                                Label_OSpicture.Text = "OS. Picture :\n KeySight - 2024A";
                                ComboBox_oscillscope.Text = "KeySight - 2024A ";
                                Button_OSconnect.Text = "Connected";
                                RichTextBox_infor_engineer.AppendText("OS connected. \n");
                                RichTextBox_infor_user.AppendText("OS connected. \n");
                                bool_OS_connect = true;
                            }
                            catch
                            {
                                try
                                {
                                    ScopeCtrl = new Lecroy();
                                    eScopeType = TYPE.LECROY;
                                    ScopeCtrl.Connect(eScopeType);
                                    ScopeCtrl.Init();

                                    PictureBox_OSpicture.Image = Csharp.Properties.Resources.lecroy;
                                    Label_OSpicture.Text = "OS. Picture :\n LeCroy";
                                    ComboBox_oscillscope.Text = "LeCroy ";
                                    Button_OSconnect.Text = "Connected";
                                    RichTextBox_infor_engineer.AppendText("OS connected. \n");
                                    RichTextBox_infor_user.AppendText("OS connected. \n");
                                    bool_OS_connect = true;
                                }
                                catch(Exception ex)
                                {
                                    Button_OSconnect.Text = "Disconnect";
                                    ScopeCtrl = null;
                                    MessageBox.Show("Please check you connect the right oscilloscope.\n OS type : KeySight - 2024A , KeySight - 4024A , LeCroy - 3024", "OS connection errror");
                                    RichTextBox_infor_user.AppendText("Oscilloscope Conect Error  \n");
                                    RichTextBox_infor_engineer.AppendText(Convert.ToString(ex) + " \n");
                                    bool_OS_connect = false;
                                }
                            }
                        }
                    }
                    Button_OSconnect.Enabled = true;
                }
                else
                {
                    Button_OSconnect.Enabled = false;
                    ScopeCtrl.Disconnect();

                    Button_OSconnect.Text = "Disconnect";

                    ScopeCtrl = null;
                    bool_OS_connect = false;
                    Button_OSconnect.Enabled = true;
                }
            }
            else if (RadioButton_connect_manual.Checked == true)
            {
                if (ScopeCtrl == null)
                {
                    switch (ComboBox_oscillscope.SelectedIndex)
                    {
                        case 0:
                            ScopeCtrl = new Keysight();
                            eScopeType = TYPE.KEYSIGHT_2024A;
                            Label_OSpicture.Text = "OS. Picture :\n KeySight - 2024A";
                            PictureBox_OSpicture.Image = Csharp.Properties.Resources.keysight_2024A;
                            break;
                        case 1:
                            ScopeCtrl = new Keysight();
                            eScopeType = TYPE.KEYSIGHT_4024A;
                            Label_OSpicture.Text = "OS. Picture :\n  KeySight - 4024A";
                            PictureBox_OSpicture.Image = Csharp.Properties.Resources.keysight_4024A;
                            break;
                        case 2:
                            ScopeCtrl = new Lecroy();
                            eScopeType = TYPE.LECROY;
                            Label_OSpicture.Text = "OS. Picture :\n  LeCroy";
                            PictureBox_OSpicture.Image = Csharp.Properties.Resources.lecroy;
                            break;

                    }
                }
                if (Button_OSconnect.Text != "Connected")
                {
                    button_CalibData.Enabled = false;
                    Button_OSconnect.Text = "Openning";
                    try
                    {
                        ScopeCtrl.Connect(eScopeType);
                        ScopeCtrl.Init();

                        Button_OSconnect.Text = "Connected";
                        RichTextBox_infor_engineer.AppendText("OS connected. \n");
                        bool_OS_connect = true;
                    }

                    catch(Exception ex)
                    {
                        Button_OSconnect.Text = "Disconnect";

                        ScopeCtrl = null;

                        RichTextBox_infor_engineer.AppendText(Convert.ToString(ex) + " \n");
                        if (ComboBox_oscillscope.SelectedItem == null)
                        {
                            MessageBox.Show("Please choose an oscilloscope type.", "OS connection errror");
                            RichTextBox_infor_user.AppendText("Please choose an oscilloscope type. \n");
                            bool_OS_connect = false;
                        }
                        else
                        {
                            MessageBox.Show("Please connect the right oscilloscope.", "OS connection errror");
                            RichTextBox_infor_user.AppendText("Please connect the right oscilloscope. \n");
                            bool_OS_connect = false;
                        }
                    }
                    Button_OSconnect.Enabled = true;
                }
                else
                {
                    Button_OSconnect.Enabled = false;
                    ScopeCtrl.Disconnect();

                    Button_OSconnect.Text = "Disconnect";

                    ScopeCtrl = null;
                    bool_OS_connect = false;
                    Button_OSconnect.Enabled = true;
                }
                if (Button_OSconnect.Text == "Connected")
                {
                    Button_start.Enabled = true;
                }
            }
            else
            {
                MessageBox.Show("Please choose manual or auto.");
                RichTextBox_infor_user.Text += "Please choose manual or auto." + "\n";
                RichTextBox_infor_engineer.Text += "Please choose manual or auto." + "\n";
            }
        }
        //**********************************************************************************************************************
        //
        // Copyright (C) 2017, ND CO.,LTD. Taiwan  All Rights Reserved
        //
        //! @fn     :   CalibStatus
        //
        //! @author :   Grace.Lee
        //
        //! @date   :   2017.07.19
        //
        //! @brief  :   The enum of CalibStatus for timer_Calibration switch case.
        //
        //! @param  :   NONE
        //
        //! @return :   NONE
        //
        //**********************************************************************************************************************
        enum CalibStatus
        {
            Start,
            E200_Transmit,
            OS_Measure,
            E200_Disable,
            Check,
            NextStep,
            NextPower,
            NextMode,
            Finish
        }
        CalibStatus calibstatus;
        //**********************************************************************************************************************
        //
        // Copyright (C) 2017, ND CO.,LTD. Taiwan  All Rights Reserved
        //
        //! @fn : Button_start_Click
        //
        //! @author : Sean.Lin
        //
        //! @date : 2017.10.13
        //
        //! @brief : 01. start calibrat, timer_timer1, progressBar_Calib
        //           02. 提升300W相對應%數
        //
        //! @param :
        //
        //! @return :
        //
        //**********************************************************************************************************************
        int string_mode_list_select;
        private void Button_start_Click(object sender, EventArgs e)
        {
            stopjudgment = false;
            bool_cal_stop = false;
            Button_status.Text = "NONE";
            Button_status.BackColor = Color.White;

            //觸發 Button_com_connect 、 Button_OSconnect 、 button_RSB_connect
            if (!bool_connected_E200)
            {
                Button_E200_connect.PerformClick();
                Thread.Sleep(2000);
                if (!bool_connected_E200)
                {
                    return;
                }
            }
            if (!bool_OS_connect)
            {
                Button_OSconnect.PerformClick();
                Thread.Sleep(2000);
                if (!bool_OS_connect)
                {
                    return;
                }
            }
            if (!bool_connected_RSB)
            {
                button_RSB_connect.PerformClick();
                Thread.Sleep(2000);
                if (!bool_connected_RSB)
                {
                    return;
                }
            }

            //open or make excel file to write
            try
            {
                FileStream fs = File.OpenWrite(string_file_path + "\\Calibration Data.xlsx");
                fs.Close();
            }
            catch
            {
                MessageBox.Show("File writing problem. \n" + "Please close the file or fix the problem.\n"+"File path :\n" + string_file_path  + "\\Calibration Data.xlsx");
                return;
            }


            timer_Detect_serial_port.Stop();
            bool bool_mode_check = false;
            string[] string_mode_list = new string[checkedListBox_mode.CheckedItems.Count];
            int int_Calib_times = 0;

            // get the checked modes' list
            for (int j = 0, i = 0; j < checkedListBox_mode.Items.Count; j++)                              
            {
                if (checkedListBox_mode.GetItemChecked(j))
                {
                    bool_mode_check = true;
                    string_mode_list[i] = checkedListBox_mode.GetItemText(checkedListBox_mode.Items[j]);

                    //calicate the steps of prograss bar
                    switch (string_mode_list[i])                                                  
                    {
                        case "PURE":
                            //int_Calib_times = int_Calib_times + 20; //提升300W相對應%數 Sean.Lin_20171013
                            int_Calib_times = int_Calib_times + 30;
                            break;
                        case "BLEND1":
                            //int_Calib_times = int_Calib_times + 15; //Sean.Lin_20171013
                            int_Calib_times = int_Calib_times + 25;
                            break;
                        case "BLEND2":
                            //int_Calib_times = int_Calib_times + 15; //Sean.Lin_20171013
                            int_Calib_times = int_Calib_times + 25;
                            break;
                        case "SPRAY":
                            //int_Calib_times = int_Calib_times + 8; //Sean.Lin_20171013
                            int_Calib_times = int_Calib_times + 10;
                            break;
                        case "PINPOINT":
                            //int_Calib_times = int_Calib_times + 10; //Sean.Lin_20171013
                            int_Calib_times = int_Calib_times + 12;
                            break;
                        case "BIPOLAR":
                            //int_Calib_times = int_Calib_times + 6;  //Sean.Lin_20171013
                            int_Calib_times = int_Calib_times + 8;
                            break;
                    }
                    i++;
                }
            }


            if (!bool_connected_E200 || !bool_mode_check)                                   //check if connected E200 and if chose mode
            {
                if (!bool_connected_E200)
                {
                    RichTextBox_infor_engineer.AppendText("\nPlease Connect E200. \n\n");
                    RichTextBox_infor_user.AppendText("\nPlease Connect E200. \n\n");
                    MessageBox.Show("Please Connect E200.");
                    return;
                }

                if(!bool_mode_check)
                {
                    RichTextBox_infor_engineer.AppendText("\nPlease Choose modes. \n\n");
                    RichTextBox_infor_user.AppendText("\nPlease Choose modes. \n\n");
                    MessageBox.Show("Please Choose modes.");
                    return;
                }

                GroupBox_mode.Enabled = true;
            }
            else
            {
 //starting calib

                RichTextBox_infor_engineer.AppendText("Start calibrating...\n"+DateTime.Now.ToString("G") + "\n");
                RichTextBox_infor_user.AppendText("Start calibrating...\n" + DateTime.Now.ToString("G") + "\n");

                int_timer_counter = 0;
                timer_timer1.Interval = 1000;
                timer_timer1.Enabled = true;
                timer_timer1.Start();

                groupBox_function.Enabled = false;
                GroupBox_Connection.Enabled = false;
                GroupBox_mode.Enabled = false;
                Button_start.Enabled = false;
                Button_pause.Enabled = true;
                Button_stop.Enabled = true;
                GroupBox_report.Enabled = false;

                //show checked mode
                RichTextBox_infor_engineer.AppendText("Checked mode ");
                for (int j = 0; j < checkedListBox_mode.CheckedItems.Count; j++)
                {
                    RichTextBox_infor_engineer.AppendText(string_mode_list[j]);
                    if (j < checkedListBox_mode.CheckedItems.Count - 1)
                        RichTextBox_infor_engineer.AppendText(", ");
                }
                RichTextBox_infor_engineer.AppendText(". \n\n");

                bool_start_calibration = true;

                //set progress bar
                progressBar_Calib.Maximum = 1000;
                progressBar_Calib.Value = 0;
                progressBar_Calib.Step = 1000 / (int_Calib_times);
                label_precent.Text = Convert.ToString(progressBar_Calib.Value / 10) + "%";
                label_precent.Refresh();
            }

            calibstatus = CalibStatus.Start;
            Button_status.Text = "Running";//
            Button_status.BackColor = Color.LawnGreen;//
            bool_measure_first = true;//
            timer_Calibration.Start();//
        }
        //**********************************************************************************************************************
        //
        // Copyright (C) 2017, ND CO.,LTD. Taiwan  All Rights Reserved
        //
        //! @fn     :   timer_Calibration_Tick
        //
        //! @author :   Grace.Lee
        //
        //! @date   :   2017.07.17
        //
        //! @brief  :   Use timer to run every CalibStatus.
        //
        //! @param  :   NONE
        //
        //! @return :   NONE
        //
        //**********************************************************************************************************************

        private void timer_Calibration_Tick(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.DoEvents();
            string[] string_mode_list = new string[checkedListBox_mode.CheckedItems.Count];
            for (int j = 0, i = 0; j < checkedListBox_mode.Items.Count; j++)                              // get the checked modes' list
            {
                if (checkedListBox_mode.GetItemChecked(j))
                {
                    string_mode_list[i] = checkedListBox_mode.GetItemText(checkedListBox_mode.Items[j]);
                    i++;
                } 
            }

            //timer interval setting
            if (calibstatus == CalibStatus.E200_Transmit)
                timer_Calibration.Interval = 500;
            else if (calibstatus == CalibStatus.E200_Disable)
                timer_Calibration.Interval = 200;
            else if (calibstatus == CalibStatus.Start)
                timer_Calibration.Interval = 400;
            else if (calibstatus == CalibStatus.OS_Measure)
                timer_Calibration.Interval = 600;
            else if (calibstatus == CalibStatus.Check)
            {
                if (int_reg == 2)
                    timer_Calibration.Interval = 2100;
                else
                    timer_Calibration.Interval = 200;
            }
            else
                timer_Calibration.Interval = 100;

            //the relationship between different calibration status
            switch (calibstatus)
            {
                case CalibStatus.Start:
                    CalibStatus_Start(string_mode_list, string_mode_list_select);
                    calibstatus = CalibStatus.E200_Transmit;
                    break;
                case CalibStatus.E200_Transmit:
                    CalibStatus_E200_Transmit(string_mode_list, string_mode_list_select);
                    calibstatus = CalibStatus.OS_Measure;
                    break;
                case CalibStatus.OS_Measure:
                    CalibStatus_OS_Measure(string_mode_list, string_mode_list_select);
                    calibstatus = CalibStatus.E200_Disable;
                    break;
                case CalibStatus.E200_Disable:
                    CalibStatus_E200_Disable(string_mode_list, string_mode_list_select);
                    calibstatus = CalibStatus.Check;
                    break;
                case CalibStatus.Check:
                    CalibStatus_Check(string_mode_list, string_mode_list_select);
                    break;
                case CalibStatus.NextStep:
                    CalibStatus_NextStep(string_mode_list, string_mode_list_select);
                    calibstatus = CalibStatus.E200_Transmit;
                    break;
                case CalibStatus.NextPower:
                    CalibStatus_NextPower(string_mode_list, string_mode_list_select);
                    break;
                case CalibStatus.NextMode:
                    CalibStatus_NextMode(string_mode_list, string_mode_list_select);
                    break;
                case CalibStatus.Finish:
                    CalibStatus_Finish(string_mode_list, string_mode_list_select);
                    break;
            }
            string_recrived_E200 = "";
        }
        //**********************************************************************************************************************
        //
        // Copyright (C) 2017, ND CO.,LTD. Taiwan  All Rights Reserved
        //
        //! @fn     :   CalibStatus_OS_Measure
        //
        //! @author :   Sean.Lin
        //
        //! @date   :   2017.10.30
        //
        //! @brief  :   01. Measure the rms value of the voltage and current, and calculate the power.
        //              02. 更改最大能承受瓦數 "> 250" -> "> 330"
        //              03. 防止停止輸出後，持續判斷的問題
        //
        //! @param  :   string[] sml: string_mode_list
        //              int sml_select: string_mode_list select mode
        //
        //! @return :   NONE
        //
        //**********************************************************************************************************************
        private void CalibStatus_OS_Measure(string[] sml, int sml_select)
        {
            ///wait for stable
            timer_Calibration.Stop();
            Thread.Sleep(500);
            System.Windows.Forms.Application.DoEvents();
            if (bool_cal_stop == false)
                timer_Calibration.Start();

            RichTextBox_infor_engineer.AppendText("------------  Osilloscope Measurement  ------------ \n\n");

            if (bool_measure_first)
            {
                try
                {
                    double_measure_voltage_first = ScopeCtrl.RMS_Get(uint_voltage_channel);
                    double_measure_current_first = ScopeCtrl.RMS_Get(uint_current_channel);
                }
                catch (Exception ex)//for pull out the usb cable
                {
                    E200_transmit("MODE", "DISABLE", "0");
                    ForceStop("FAIL", Color.Red);
                    Button_OSconnect.PerformClick();
                    MessageBox.Show("Cannot get rms value from OS. Please check the OS connection.", "OS Error");
                    RichTextBox_infor_engineer.AppendText(Convert.ToString(ex)+"\n");
                }
                double_measure_power_first = double_measure_voltage_first * double_measure_current_first;
                double_power_diff_first = double_measure_power_first - int_expect_power;
                double_power_percentage_first = double_power_diff_first / int_expect_power * 100;
                bool_measure_first = false;
            }
            try
            {
                double_measure_voltage = ScopeCtrl.RMS_Get(uint_voltage_channel);
                double_measure_current = ScopeCtrl.RMS_Get(uint_current_channel);
            }
            catch (Exception ex)//for pull out the usb cable
            {
                E200_transmit("MODE", "DISABLE", "0");
                ForceStop("FAIL", Color.Red);
                Button_OSconnect.PerformClick();
                MessageBox.Show("Cannot get rms value from OS. Please check the OS connection.", "OS Error");
                RichTextBox_infor_engineer.AppendText(Convert.ToString(ex) + "\n");
            }
            double_measure_power = double_measure_voltage * double_measure_current;
            double_power_diff = double_measure_power - int_expect_power;
            double_power_percentage = double_power_diff / int_expect_power * 100;

            if (stopjudgment == false) //防止停止輸出後，持續判斷的問題 Sean.Lin20171030
            {
                //if (double_measure_voltage * double_measure_current < 1 || double_measure_voltage * double_measure_current > 250) //更改最大能承受瓦數 250->330 Sean.Lin 20171006  
                if (double_measure_voltage * double_measure_current < 1 || double_measure_voltage * double_measure_current > 330)
                {
                    E200_transmit("MODE", "DISABLE", "0");
                    RichTextBox_infor_engineer.AppendText("Connection Error. \n");
                    RichTextBox_infor_user.AppendText("Connection Error. \n");
                    ((TextAnnotation)chart_cabration_run_chart.Annotations[2]).Text = int_expect_power + "W Error.";

                    ForceStop("FAIL", Color.Red);
                    //MessageBox.Show("Measure power > 250 or < 1. \n Please fix the problem."); //更改最大能承受瓦數 250->330 Sean.Lin 20171006  
                    MessageBox.Show("Measure power > 330 or < 1. \n Please fix the problem.");
                }
            
            TextBox_vlotage.Text = Convert.ToString(double_measure_voltage);
            TextBox_current.Text = Convert.ToString(double_measure_current);
            TextBox_measpow.Text = Convert.ToString(double_measure_power);
            RichTextBox_infor_engineer.Text += "    Power       ： " + double_measure_power + " (W) \n"
                                            + "    Voltage     ： " + double_measure_voltage + " (V) \n"
                                            + "    Current		： " + double_measure_current + " (A)\n";
            RichTextBox_infor_engineer.Text += "    Power Tolerance	： " + double_power_percentage + " % \n\n";
            }
        }
        //**********************************************************************************************************************
        //
        // Copyright (C) 2017, ND CO.,LTD. Taiwan  All Rights Reserved
        //
        //! @fn     :   CalibStatus_Start
        //
        //! @author :   Sean.Lin
        //
        //! @date   :   2017.10.26
        //
        //! @brief  :   01. Initial setting of each mode.
        //              02. 更改E300對應各模式之瓦數
        //              03. 按照比例的方式修改圖所呈現範圍，避免低瓦數所呈現範圍過大；並強制10瓦Y軸顯示小數點第一位。
        //              04. Modify the lower limit . 
        //              05. RSB更改電阻(1K*2+100R*1)後，做RELAY的調整(500R需1K並聯1K)
        //
        //! @param  :   string[] sml: string_mode_list
        //              int sml_select: string_mode_list select mode
        //
        //! @return :   NONE
        //
        //**********************************************************************************************************************
        int int_calibrate_times_count = 0;
        private void CalibStatus_Start(string[] sml, int sml_select)
        {
            int_calibrate_times_count = int_calibrate_times_count + 1;
            //excel
            if (int_calibrate_times_count == 1)
            {
                Worksheet worksheet = (Worksheet)workbook.Sheets[1];
                worksheet.Name = sml[sml_select] + "_" + Convert.ToString(int_calibrate_times_count);

                if(radioButton_calibration.Checked)
                {
                    workbook.Sheets[int_calibrate_times_count].cells[2, 1] = "Calibraiton";
                }
                else 
                {
                    workbook.Sheets[int_calibrate_times_count].cells[2, 1] = "Verify";
                }
                
                workbook.Sheets[int_calibrate_times_count].cells[2, 2] = "Except Power";
                workbook.Sheets[int_calibrate_times_count].cells[2, 3] = "Measure Power";
                workbook.Sheets[int_calibrate_times_count].cells[2, 4] = "Measure Voltage";
                workbook.Sheets[int_calibrate_times_count].cells[2, 5] = "Measure Current";
                workbook.Sheets[int_calibrate_times_count].cells[2, 6] = "Power Difference";
                workbook.Sheets[int_calibrate_times_count].cells[2, 7] = "Power Tolerance";
                workbook.Sheets[int_calibrate_times_count].cells[2, 8] = "Callibration Data";
                workbook.Sheets[int_calibrate_times_count].cells[2, 9] = "Measuer Power First";
                workbook.Sheets[int_calibrate_times_count].cells[2, 10] = "Measuer Voltage First";
                workbook.Sheets[int_calibrate_times_count].cells[2, 11] = "Measuer Current First";
                workbook.Sheets[int_calibrate_times_count].cells[2, 12] = "Power Difference First";
                workbook.Sheets[int_calibrate_times_count].cells[2, 13] = "Power Tolerance First";
                workbook.Sheets[int_calibrate_times_count].cells[2, 14] = "Mode Watt";
                workbook.Sheets[int_calibrate_times_count].cells[2, 15] = "Mode Voltage";
            }
            else
            {
                Worksheet worksheet = (Worksheet)workbook.Worksheets.Add(Type.Missing, workbook.Sheets[int_calibrate_times_count - 1], Type.Missing, Type.Missing);
                worksheet.Name = sml[sml_select] + "_" + Convert.ToString(int_calibrate_times_count);

                if (radioButton_calibration.Checked)
                {
                    workbook.Sheets[int_calibrate_times_count].cells[2, 1] = "Calibraiton";
                }
                else
                {
                    workbook.Sheets[int_calibrate_times_count].cells[2, 1] = "Verify";
                }

                workbook.Sheets[int_calibrate_times_count].cells[2, 2] = "Except Power";
                workbook.Sheets[int_calibrate_times_count].cells[2, 3] = "Measure Power";
                workbook.Sheets[int_calibrate_times_count].cells[2, 4] = "Measure Voltage";
                workbook.Sheets[int_calibrate_times_count].cells[2, 5] = "Measure Current";
                workbook.Sheets[int_calibrate_times_count].cells[2, 6] = "Power Difference";
                workbook.Sheets[int_calibrate_times_count].cells[2, 7] = "Power Tolerance";
                workbook.Sheets[int_calibrate_times_count].cells[2, 8] = "Callibration Data";
                workbook.Sheets[int_calibrate_times_count].cells[2, 9] = "Measuer Power First";
                workbook.Sheets[int_calibrate_times_count].cells[2, 10] = "Measuer Voltage First";
                workbook.Sheets[int_calibrate_times_count].cells[2, 11] = "Measuer Current First";
                workbook.Sheets[int_calibrate_times_count].cells[2, 12] = "Power Difference First";
                workbook.Sheets[int_calibrate_times_count].cells[2, 13] = "Power Tolerance First";
                workbook.Sheets[int_calibrate_times_count].cells[2, 14] = "Mode Watt";
                workbook.Sheets[int_calibrate_times_count].cells[2, 15] = "Mode Voltage";
            }

            RichTextBox_infor_engineer.Text += "************************************************** \n"
                                            + "    Time        ： " + DateTime.Now.ToString("yyyy/MM/dd") + " " + DateTime.Now.ToString("HH:mm") + "\n"
                                            + "    Mode		： " + sml[sml_select] + "\n"
                                            + "	Expext Power	： 10 (W)" + "\n"
                                            + "	Load		： " + TextBox_load.Text + " (ohm) \n"
                                            + "	Power Tolerance	： 0 ~ +10 %" + "\n"
                                            + "************************************************** \n";
            int_expect_power = 10; //
            TextBox_exppow.Text = Convert.ToString(int_expect_power);
            int_Runtimes = 0;
            if (bool_measure_first)
                sml_select = 0;
            else
                sml_select = sml_select + 1;
            string_mode_list_select = sml_select;

            Button_status.Text = sml[sml_select];

            switch (sml[sml_select])
            {
                case "PURE":
                    //RSB_RELAY_select(1, 0, 1, 0, 0, 0, 1); //RSB更改電阻(1K*2+100R*1) Sean.Lin_20171026
                    RSB_RELAY_select(1, 0, 1, 0, 0, 1, 1);
                    TextBox_load.Text = "500";
                    //int_expect_power_max = 200; 更改E300對應各模式之瓦數  Sean.Lin_20171006 
                    int_expect_power_max = 300;
                    int_excel_select_mode = 1;
                    if (radioButton_verify.Checked)
                    {
                        E200_transmit("CALIB_DATA_" + "PURE", "?", "");
                    }
                    break;
                case "BLEND1":
                    //RSB_RELAY_select(1, 0, 1, 0, 0, 0, 1); //RSB更改電阻(1K*2+100R*1) Sean.Lin_20171026
                    RSB_RELAY_select(1, 0, 1, 0, 0, 1, 1);
                    TextBox_load.Text = "500";
                    //int_expect_power_max = 150; 更改E300對應各模式之瓦數  Sean.Lin_20171006 
                    int_expect_power_max = 250;
                    int_excel_select_mode = 2;
                    if (radioButton_verify.Checked)
                    {
                        E200_transmit("CALIB_DATA_" + "BLEND1", "?", "");
                    }
                    break;
                case "BLEND2":
                    //RSB_RELAY_select(1, 0, 1, 0, 0, 0, 1); //RSB更改電阻(1K*2+100R*1) Sean.Lin_20171026
                    RSB_RELAY_select(1, 0, 1, 0, 0, 1, 1);
                    TextBox_load.Text = "500";
                    //int_expect_power_max = 150; 更改E300對應各模式之瓦數  Sean.Lin_20171006 
                    int_expect_power_max = 250;
                    int_excel_select_mode = 3;
                    if (radioButton_verify.Checked)
                    {
                        E200_transmit("CALIB_DATA_" + "BLEND2", "?", "");
                    }
                    break;
                case "SPRAY":
                    RSB_RELAY_select(1, 0, 1, 0, 0, 1, 0);
                    TextBox_load.Text = "1000";
                    //int_expect_power_max = 80; 更改E300對應各模式之瓦數  Sean.Lin_20171006 
                    int_expect_power_max = 100;
                    int_excel_select_mode = 4;
                    if (radioButton_verify.Checked)
                    {
                        E200_transmit("CALIB_DATA_" + "SPRAY", "?", "");
                    }
                    break;
                case "PINPOINT":
                    //RSB_RELAY_select(1, 0, 1, 0, 0, 0, 1); //RSB更改電阻(1K*2+100R*1) Sean.Lin_20171026
                    RSB_RELAY_select(1, 0, 1, 0, 0, 1, 1);
                    TextBox_load.Text = "500";
                    //int_expect_power_max = 100; 更改E300對應各模式之瓦數  Sean.Lin_20171006 
                    int_expect_power_max = 120;
                    int_excel_select_mode = 5;
                    if (radioButton_verify.Checked)
                    {
                        E200_transmit("CALIB_DATA_" + "PINPOINT", "?", "");
                    }
                    break;
                case "BIPOLAR":
                    RSB_RELAY_select(0, 1, 0, 1, 1, 0, 0);
                    TextBox_load.Text = "100";
                    //int_expect_power_max = 60; 更改E300對應各模式之瓦數  Sean.Lin_20171006 
                    int_expect_power_max = 80;
                    int_excel_select_mode = 6;
                    if (radioButton_verify.Checked)
                    {
                        E200_transmit("CALIB_DATA_" + "BIPOLAR", "?", "");
                    }
                    break;
            }
            if (radioButton_calibration.Checked)
                double_CalibData = 1;
            //if(radioButton_verify.Checked) => in CalibStatus_E200_Transmit(sml, sml_select) for PC have enough time to get CalibData from E200

            ((TextAnnotation)chart_cabration_run_chart.Annotations[2]).Text = int_expect_power + "W Running";
            ((TextAnnotation)chart_cabration_run_chart.Annotations[2]).ForeColor = Color.Fuchsia;

            //draw chart_calibraiton_run_chart exception lines
            chart_cabration_run_chart.Series[0].Points.Clear();
            chart_cabration_run_chart.Series[1].Points.Clear();
            chart_cabration_run_chart.Series[2].Points.Clear();

            double_accacptable_area_max = (int_expect_power) + int_expect_power * double_power_percentage_high * 0.01;
            //double_accacptable_area_min = int_expect_power; //Modify the lower limit . Sean.Lin_20171018
            double_accacptable_area_min = (int_expect_power) + int_expect_power * double_power_percentage_low * 0.01;
            //chart_cabration_run_chart.ChartAreas[0].AxisY.Minimum = (double_accacptable_area_min) - 20; //修改圖所呈現範圍 Sean.Lin_20171016
            //chart_cabration_run_chart.ChartAreas[0].AxisY.Maximum = (double_accacptable_area_max) + 20;
            this.chart_cabration_run_chart.ChartAreas[0].AxisY.LabelStyle.Format = "N1"; //N1=one decimal places Sean.Lin_20171016
            chart_cabration_run_chart.ChartAreas[0].AxisY.Minimum = int_expect_power - int_expect_power * 0.3;//最大最小值按比例調整 20171102_Sean.Lin
            chart_cabration_run_chart.ChartAreas[0].AxisY.Maximum = int_expect_power + int_expect_power * 0.3;

            chart_cabration_run_chart.Series[0].Points.AddXY(0, double_accacptable_area_min, double_accacptable_area_max);
            chart_cabration_run_chart.Series[0].Points.AddXY(int_Runtimes_max, double_accacptable_area_min, double_accacptable_area_max);

            chart_cabration_run_chart.Series[1].Points.AddXY(0, int_expect_power);
            chart_cabration_run_chart.Series[1].Points.AddXY(int_Runtimes_max, int_expect_power);

            ((TextAnnotation)chart_cabration_run_chart.Annotations[0]).Text = Convert.ToString(double_accacptable_area_max);
            ((TextAnnotation)chart_cabration_run_chart.Annotations[0]).Y = chart_cabration_run_chart.Series[0].Points[0].YValues[1] + 0.5;

            ((TextAnnotation)chart_cabration_run_chart.Annotations[1]).Text = Convert.ToString(double_accacptable_area_min);
            ((TextAnnotation)chart_cabration_run_chart.Annotations[1]).Y = chart_cabration_run_chart.Series[0].Points[0].YValues[0] + 0.5;

        }
        //**********************************************************************************************************************
        //
        // Copyright (C) 2017, ND CO.,LTD. Taiwan  All Rights Reserved
        //
        //! @fn     :   CalibStatus_E200_Transmit
        //
        //! @author :   Grace.Lee
        //
        //! @date   :   2017.07.14
        //
        //! @brief  :   PC talk to E200 MPU.
        //
        //! @param  :   string[] sml: string_mode_list
        //              int sml_select: string_mode_list select mode
        //
        //! @return :   NONE
        //
        //**********************************************************************************************************************
        private void CalibStatus_E200_Transmit(string[] sml, int sml_select)
        {
            if (radioButton_verify.Checked)
                double_CalibData = double_ary_E200_calibrate_data[int_excel_select_mode - 1, (int_expect_power / 10) - 1];
            double target_power = int_expect_power * double_CalibData;
            E200_transmit("MODE", "WATT", Convert.ToString(target_power));
            E200_transmit("MODE", sml[sml_select], Convert.ToString(0));
        }
        //**********************************************************************************************************************
        //
        // Copyright (C) 2017, ND CO.,LTD. Taiwan  All Rights Reserved
        //
        //! @fn     :   CalibStatus_E200_Disable
        //
        //! @author :   Grace.Lee
        //
        //! @date   :   2017.07.14
        //
        //! @brief  :   PC talk to E200 MPU that it's disable.
        //
        //! @param  :   string[] sml: string_mode_list
        //              int sml_select: string_mode_list select mode
        //
        //! @return :   NONE
        //
        //**********************************************************************************************************************
        private void CalibStatus_E200_Disable(string[] sml, int sml_select)
        {
            E200_transmit("MODE", "DISABLE", "0");
        }
        //**********************************************************************************************************************
        //
        // Copyright (C) 2017, ND CO.,LTD. Taiwan  All Rights Reserved
        //
        //! @fn     :   writeMsg
        //
        //! @author :   Grace.Lee
        //
        //! @date   :   2017.07.14
        //
        //! @brief  :   change color of the text in the richbox.
        //
        //! @param  :   string msg
        //              Color color = new Color()
        //
        //! @return :   NONE
        //
        //**********************************************************************************************************************
        private void writeMsg(string msg, Color color = new Color())
        {
            RichTextBox_infor_engineer.SelectionColor = color;
            RichTextBox_infor_engineer.AppendText(msg + Environment.NewLine);
        }
        //**********************************************************************************************************************
        //
        // Copyright (C) 2017, ND CO.,LTD. Taiwan  All Rights Reserved
        //
        //! @fn     :   CalibStatus_Check
        //
        //! @author :   Sean.Lin
        //
        //! @date   :   2017.10.27
        //
        //! @brief  :   01. Check power percentage is in the calibration range or not.
        //              02. Check the calibration is over-run or not.
        //              03. double_power_percentage and double_CalibData 3次之值各別存入filter_power_percentage[] and filter_CalibData[] .
        //
        //! @param  :   string[] sml: string_mode_list
        //              int sml_select: string_mode_list select mode
        //
        //! @return :   NONE
        //
        //**********************************************************************************************************************
        int int_reg = 0;
        string string_pass_fail="";
        bool bool_fail = false;//bool_fail = true => fail
        double[] filter_power_percentage = new double[3];//取最精準的校正值，3代表校正次數 Sean.Lin_20171027
        double[] filter_CalibData = new double[3];//Sean.Lin_20171027

        private void CalibStatus_Check(string[] sml, int sml_select)
        {
            calibration_run_chart(double_measure_power, int_Runtimes);
            double_power_diff = double_measure_power - int_expect_power;
            double_power_percentage = double_power_diff / int_expect_power * 100;
            RichTextBox_infor_engineer.AppendText("[CalibStatus_Check] \n");

            if (double_power_percentage <= double_power_percentage_high && double_power_percentage >= double_power_percentage_low)
            {
                if (int_reg == 2)//twice in the accuracy => Pass
                {
                    filter_power_percentage[int_reg] = double_power_percentage;//存入最佳值 Sean.Lin_20171027
                    filter_CalibData[int_reg] = double_CalibData;//Sean.Lin_20171027

                    string_pass_fail = "Pass";
                    writeMsg(">>> PASS", Color.Green);
                    ((TextAnnotation)chart_cabration_run_chart.Annotations[2]).ForeColor = Color.LawnGreen;
                    ((TextAnnotation)chart_cabration_run_chart.Annotations[2]).Text = int_expect_power + "W Pass";

                    bool_measure_first = true;
                    if (radioButton_verify.Checked)
                    {
                        RichTextBox_infor_user.AppendText("[ " + sml[sml_select] + " " + int_expect_power + "W ] \n"
                                                     + "Result:" + int_expect_power + "W pass \n");
                    }
                    else//radioButton_calibration.Checked
                    {
                        RichTextBox_infor_user.AppendText("[ " + sml[sml_select] + " " + int_expect_power + "W ] \n"
                                                         + "Pass counter: " + 3 + "\n"
                                                         + "Fail counter: " + (int_Runtimes - 2) + "\n"
                                                         + "Total counter: " + (int_Runtimes + 1) + "\n"
                                                         + "Result:" + int_expect_power + "W pass \n");

                        
                        timer_Calibration.Stop();
                        Thread.Sleep(2000);
                        System.Windows.Forms.Application.DoEvents();
                        if (bool_cal_stop == false)
                            timer_Calibration.Start();
                    }
                    int_reg = 0;
                    calibstatus = CalibStatus.NextPower;
                }
                else
                {
                    //double_power_percentage與double_CalibData做一個判斷取最好的在nextpower中找出最佳送給e200 Sean.Lin_20171026紀錄
                    filter_power_percentage[int_reg] = double_power_percentage;//存入最佳值 Sean.Lin_20171027
                    filter_CalibData[int_reg] = double_CalibData;//Sean.Lin_20171027


                    int_reg = int_reg + 1;
                    ((TextAnnotation)chart_cabration_run_chart.Annotations[2]).Text = int_expect_power + "W Running";
                    ((TextAnnotation)chart_cabration_run_chart.Annotations[2]).ForeColor = Color.Fuchsia;
                    calibstatus = CalibStatus.NextStep;
                }
            }
            else
            {
                int_reg = 0;
                writeMsg("x x x FAIL", Color.Red);
                if (radioButton_verify.Checked)
                {
                    RichTextBox_infor_user.AppendText("[ " + sml[sml_select] + " " + int_expect_power + "W ] \n"
                                                     + "Result:" + int_expect_power + "W fail \n");
                    ((TextAnnotation)chart_cabration_run_chart.Annotations[2]).Text = int_expect_power + "w fail";
                    ((TextAnnotation)chart_cabration_run_chart.Annotations[2]).ForeColor = Color.Red;
                    
                    string_pass_fail = "Fail";
                    bool_fail = true;
                    calibstatus = CalibStatus.NextPower;
                }
                else
                {
                    ((TextAnnotation)chart_cabration_run_chart.Annotations[2]).Text = int_expect_power + "W Running";
                    ((TextAnnotation)chart_cabration_run_chart.Annotations[2]).ForeColor = Color.Fuchsia;
                    
                    calibstatus = CalibStatus.NextStep;
                }
            }
            if (int_Runtimes >= int_Runtimes_max)
            {
                E200_transmit("MODE", "DISABLE", "0");
                RichTextBox_infor_user.AppendText("[ " + sml[sml_select] + " " + int_expect_power + "W ] \n"
                                                     + "Pass counter: " + 0 + "\n"
                                                     + "Fail counter: " + (int_Runtimes + 1) + "\n"
                                                     + "Total counter: " + (int_Runtimes + 1) + "\n"
                                                     + "Result:" + int_expect_power + "W fail \n");
                writeMsg("Runtimes>=" + int_Runtimes_max + "\n" + "x x x FAIL", Color.Red);
                ((TextAnnotation)chart_cabration_run_chart.Annotations[2]).Text = int_expect_power + "w Fail";
                ((TextAnnotation)chart_cabration_run_chart.Annotations[2]).ForeColor = Color.Red;

                bool_fail = true;
                E200_transmit("MODE", "DISABLE", "0");
                ForceStop("FAIL", Color.Red);
            }

        }
        //**********************************************************************************************************************
        //
        // Copyright (C) 2017, ND CO.,LTD. Taiwan  All Rights Reserved
        //
        //! @fn     :   CalibStatus_NextStep
        //
        //! @author :   Sean.Lin
        //
        //! @date   :   2017.10.20
        //
        //! @brief  :   01. Set a new calibration data value for calibration when the power isn't in acceptable range.
        //              02. 在可接受範圍內，依然會對k值進行校正
        //
        //! @param  :   string[] sml: string_mode_list
        //              int sml_select: string_mode_list select mode
        //
        //! @return :   NONE
        //
        //**********************************************************************************************************************
        private void CalibStatus_NextStep(string[] sml, int sml_select)
        {
            //if(double_power_percentage<double_power_percentage_low || double_power_percentage > double_power_percentage_high) //更正:在可接受範圍內，依然會對k值進行校正。 Sean.Lin_20171020
                double_CalibData = double_CalibData - 0.01 *double_power_percentage / 2;
            //else
            //    double_CalibData = double_CalibData;
            int_Runtimes = int_Runtimes + 1;
        }
        //**********************************************************************************************************************
        //
        // Copyright (C) 2017, ND CO.,LTD. Taiwan  All Rights Reserved
        //
        //! @fn     :   CalibStatus_NextPower
        //
        //! @author :   Sean.Lin
        //
        //! @date   :   2017.10.27
        //
        //! @brief  :   01. In the same mode, change to another power for calibration.
        //              02. 按照比例的方式修改圖所呈現範圍，避免低瓦數所呈現範圍過大。
        //              03. Modify the lower limit .
        //              04. 將每次精度取捨出最接近之值作為k值
        //
        //! @param  :   string[] sml: string_mode_list
        //              int sml_select: string_mode_list select mode
        //
        //! @return :   NONE
        //
        //**********************************************************************************************************************
        private void CalibStatus_NextPower(string[] sml, int sml_select)
        {
            //將每次精度取捨出最接近之值作為k值 20171027_Sean.Lin
            double closetozero_value;
            for (int i = 0; i < 3; i++)
            {
            filter_power_percentage[i] = Math.Abs(filter_power_percentage[i]);
            }
            closetozero_value = filter_power_percentage.Min();           
            double_CalibData = filter_CalibData[Array.IndexOf(filter_power_percentage, closetozero_value)];
            //

            double_array_CalibData[(int_excel_select_mode - 1), ((int_expect_power / 10) - 1)] = double_CalibData;
            //put data into excel
            if(bool_fail)//once fail in calibration => total: Fail
            {
                Excel(int_calibrate_times_count, 1, 1, "Fail");
                workbook.Sheets[int_calibrate_times_count].Cells[ 1, 1].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);
            }
                
            else
            {
                Excel(int_calibrate_times_count, 1, 1, "Pass");
                workbook.Sheets[int_calibrate_times_count].Cells[1, 1].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(0, 255, 0));
            }
                
            Excel(int_calibrate_times_count, int_expect_power / 10 + 2, 1, string_pass_fail);
            if (string_pass_fail == "Pass")
            {
                workbook.Sheets[int_calibrate_times_count].Cells[int_expect_power / 10 + 2, 1].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(0, 255, 0));
            }
            else
            {
                workbook.Sheets[int_calibrate_times_count].Cells[int_expect_power / 10 + 2, 1].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);
            }
            Excel(int_calibrate_times_count, int_expect_power / 10 + 2, 2, Convert.ToString(int_expect_power));
            Excel(int_calibrate_times_count, int_expect_power / 10 + 2, 3, Convert.ToString(double_measure_power));
            Excel(int_calibrate_times_count, int_expect_power / 10 + 2, 4, Convert.ToString(double_measure_voltage));
            Excel(int_calibrate_times_count, int_expect_power / 10 + 2, 5, Convert.ToString(double_measure_current));
            Excel(int_calibrate_times_count, int_expect_power / 10 + 2, 6, Convert.ToString(double_power_diff));
            Excel(int_calibrate_times_count, int_expect_power / 10 + 2, 7, Convert.ToString(double_power_percentage));
            Excel(int_calibrate_times_count, int_expect_power / 10 + 2, 8, String.Format("{0:0.00}", double_CalibData));
            Excel(int_calibrate_times_count, int_expect_power / 10 + 2, 9, Convert.ToString(double_measure_power_first));
            Excel(int_calibrate_times_count, int_expect_power / 10 + 2, 10, Convert.ToString(double_measure_voltage_first));
            Excel(int_calibrate_times_count, int_expect_power / 10 + 2, 11, Convert.ToString(double_measure_current_first));
            Excel(int_calibrate_times_count, int_expect_power / 10 + 2, 12, Convert.ToString(double_power_diff_first));
            Excel(int_calibrate_times_count, int_expect_power / 10 + 2, 13, Convert.ToString(double_power_percentage_first));
            Excel(int_calibrate_times_count, int_expect_power / 10 + 2, 14, string_mode_watt);
            Excel(int_calibrate_times_count, int_expect_power / 10 + 2, 15, string_mode_voltage);
            //
            progressBar_Calib.Value += progressBar_Calib.Step;
            label_precent.Text = Convert.ToString(progressBar_Calib.Value/10) + "%";
            label_precent.Refresh();

            int_report[int_excel_select_mode - 1, int_expect_power] = int_Runtimes;
            if (int_expect_power != int_expect_power_max)
            {
                int_expect_power = int_expect_power + 10;

                TextBox_exppow.Text = Convert.ToString(int_expect_power);

                if (radioButton_verify.Checked)
                    double_CalibData = double_ary_E200_calibrate_data[int_excel_select_mode - 1, int_expect_power / 10 - 1];
                else
                    double_CalibData = 1;

                int_Runtimes = 0;
                calibstatus = CalibStatus.E200_Transmit;

                RichTextBox_infor_engineer.Text += "************************************************** \n"
                                           + "  Time        ： " + DateTime.Now.ToString("yyyy/MM/dd") + " " + DateTime.Now.ToString("HH:mm") + "\n"
                                           + "  Mode		： " + sml[sml_select] + "\n"
                                           + "	Expext Power	： " + int_expect_power + " (W)\n"
                                           + "	Load		： " + TextBox_load.Text + " (ohm) \n"
                                           + "	Power Tolerance	： 0 ~ +10 %" + "\n"
                                           + "************************************************** \n";//changetxt

                //draw chart_calibraiton_run_chart exception lines
                chart_cabration_run_chart.Series[0].Points.Clear();
                chart_cabration_run_chart.Series[1].Points.Clear();
                chart_cabration_run_chart.Series[2].Points.Clear();


                double_accacptable_area_max = (int_expect_power) + int_expect_power * double_power_percentage_high * 0.01;
                //double_accacptable_area_min = int_expect_power; //Modify the lower limit . Sean.Lin_20171018
                double_accacptable_area_min = (int_expect_power) + int_expect_power * double_power_percentage_low * 0.01;
                //chart_cabration_run_chart.ChartAreas[0].AxisY.Minimum = (double_accacptable_area_min) - 20;  //修改圖所呈現範圍 Sean.Lin_20171016
                //chart_cabration_run_chart.ChartAreas[0].AxisY.Maximum = (double_accacptable_area_max) + 20;
                this.chart_cabration_run_chart.ChartAreas[0].AxisY.LabelStyle.Format = "N0";//N0=zero decimal places Sean.Lin_20171016
                chart_cabration_run_chart.ChartAreas[0].AxisY.Minimum = int_expect_power - int_expect_power * 0.3;//最大最小值按比例調整 20171102_Sean.Lin
                chart_cabration_run_chart.ChartAreas[0].AxisY.Maximum = int_expect_power + int_expect_power * 0.3;

                chart_cabration_run_chart.Series[0].Points.AddXY(0, double_accacptable_area_min, double_accacptable_area_max);
                chart_cabration_run_chart.Series[0].Points.AddXY(int_Runtimes_max, double_accacptable_area_min, double_accacptable_area_max);

                chart_cabration_run_chart.Series[1].Points.AddXY(0, int_expect_power);
                chart_cabration_run_chart.Series[1].Points.AddXY(int_Runtimes_max, int_expect_power);

                ((TextAnnotation)chart_cabration_run_chart.Annotations[0]).Text = Convert.ToString(double_accacptable_area_max);
                ((TextAnnotation)chart_cabration_run_chart.Annotations[0]).Y = chart_cabration_run_chart.Series[0].Points[0].YValues[1] + 0.5;

                ((TextAnnotation)chart_cabration_run_chart.Annotations[1]).Text = Convert.ToString(double_accacptable_area_min);
                ((TextAnnotation)chart_cabration_run_chart.Annotations[1]).Y = chart_cabration_run_chart.Series[0].Points[0].YValues[0] + 0.5;

                ((TextAnnotation)chart_cabration_run_chart.Annotations[2]).Text = int_expect_power + "W Running";
                ((TextAnnotation)chart_cabration_run_chart.Annotations[2]).ForeColor = Color.Fuchsia;
                
  
            }
            else
            {
                calibstatus = CalibStatus.NextMode;
            }
        }
        //**********************************************************************************************************************
        //
        // Copyright (C) 2017, ND CO.,LTD. Taiwan  All Rights Reserved
        //
        //! @fn     :   CalibStatus_E200_NextMode
        //
        //! @author :   Grace.Lee
        //
        //! @date   :   2017.07.14
        //
        //! @brief  :   Change to another selected mode for calibration, and send the message of correct Calibration Data to E200.
        //
        //! @param  :   string[] sml: string_mode_list
        //              int sml_select: string_mode_list select mode
        //
        //! @return :   NONE
        //
        //**********************************************************************************************************************
        private void CalibStatus_NextMode(string[] sml, int sml_select)
        {
            string string_PC_CalibData = "";
            for (int i = 0; i < int_expect_power_max / 10; i++)
            {
                if (i != int_expect_power_max / 10 - 1)
                    string_PC_CalibData += String.Format("{0:0.00}", double_array_CalibData[(int_excel_select_mode - 1), i]) + ",";
                else
                    string_PC_CalibData += String.Format("{0:0.00}", double_array_CalibData[(int_excel_select_mode - 1), i]);
            }
            E200_transmit("CALIB_DATA", sml[sml_select], string_PC_CalibData);  //Save calibration data into EEPROM of E200
            Thread.Sleep(100);
            int int_flag = (1 << (int_excel_select_mode - 1)) | 0x80;
            E200_transmit("CALIB_DATA", "FLAG", Convert.ToString(int_flag, 16));    //Save calibration flag
            Thread.Sleep(100);
            if (sml_select == (sml.Length - 1))
            {
                calibstatus = CalibStatus.Finish;
            }
            else
            {
                bool_measure_first = false;
                calibstatus = CalibStatus.Start;
            }


        }
        //**********************************************************************************************************************
        //
        // Copyright (C) 2017, ND CO.,LTD. Taiwan  All Rights Reserved
        //
        //! @fn     :   CalibStatus_Finish
        //
        //! @author :   Grace.Lee
        //
        //! @date   :   2017.07.17
        //
        //! @brief  :   Finish the calibration, and save datas into excel files.
        //
        //! @param  :   string[] sml: string_mode_list
        //              int sml_select: string_mode_list select mode
        //
        //! @return :   NONE
        //
        //**********************************************************************************************************************
        private void CalibStatus_Finish(string[] sml, int sml_select)
        {
            progressBar_Calib.Value = 1000;
            label_precent.Text = Convert.ToString(progressBar_Calib.Value/10) + "%";
            label_precent.Refresh();
            workbook.SaveCopyAs(string_file_path + "\\Calibration Data.xlsx");


            E200_transmit("MODE", "DISABLE", "0");
            ForceStop("Finish", Color.FromArgb(192, 255, 255));
        }
        //**********************************************************************************************************************
        //
        // Copyright (C) 2017, ND CO.,LTD. Taiwan  All Rights Reserved
        //
        //! @fn     :   Button_stop_Click
        //
        //! @author :   Grace.Lee
        //
        //! @date   :   2017.10.26
        //
        //! @brief  :   01. Stop the timer_Calibration .
        //              02. TEST:多增加一次關閉輸出，看看是否會改善"STOP"會持續輸出的問題。
        //
        //! @param  :   NONE
        //
        //! @return :   NONE
        //
        //**********************************************************************************************************************
        bool bool_cal_stop = false;
        private void Button_stop_Click(object sender, EventArgs e)
        {
            stopjudgment = true;//防止停止輸出後，持續判斷的問題 Sean.Lin20171030
            workbook.SaveCopyAs(string_file_path + "\\Calibration Data.xlsx");
            E200_transmit("MODE", "DISABLE", "0");
            ForceStop("STOP", Color.Red);
            E200_transmit("MODE", "DISABLE", "0"); //多增加一次關閉輸出，看看是否會改善"STOP"會持續輸出的問題 Sean.Lin_20171026
        }
        //**********************************************************************************************************************
        //
        // Copyright (C) 2017, ND CO.,LTD. Taiwan  All Rights Reserved
        //
        //! @fn : ForceStop
        //
        //! @author : Grace.Lee
        //
        //! @date : 2017.08.04
        //
        //! @brief : use this when calibration need to stop.
        //
        //! @param :string button_status_text, Color button_status_color
        //
        //! @return :
        //
        //**********************************************************************************************************************
        private void ForceStop(string button_status_text, Color button_status_color)
        {
            bool_start_calibration = false;
            bool_cal_stop = true;
            timer_Calibration.Stop();
            timer_timer1.Stop();
            Button_status.Text = button_status_text;
            Button_status.BackColor = button_status_color;
            timer_Detect_serial_port.Start();

            groupBox_function.Enabled = true;
            GroupBox_Connection.Enabled = true;
            GroupBox_mode.Enabled = true;
            GroupBox_report.Enabled = true;
            Button_start.Enabled = true;//
            Button_pause.Enabled = false;//
            Button_stop.Enabled = false;//
        }
        //**********************************************************************************************************************
        //
        // Copyright (C) 2017, ND CO.,LTD. Taiwan  All Rights Reserved
        //
        //! @fn : 01. CheckBox_selectall_CheckedChanged
        //        02. 2017.10.24更新為radioButton_Selectall_CheckedChanged   
        //
        //! @author : Sean.Lin
        //
        //! @date : 2017.10.24
        //
        //! @brief : 01. when ckick radioButton_Selectall, automatically check all modes
        //           02. 當radioButton_Selectall勾選會取消CheckBox_clearall
        //
        //! @param :
        //
        //! @return :
        //
        //**********************************************************************************************************************       
        //private void CheckBox_selectall_CheckedChanged_1(object sender, EventArgs e)
        //{
        //    if (CheckBox_selectall.Checked)//select all
        //    {
        //        for (int intmode = 0; intmode < checkedListBox_mode.Items.Count; intmode++)
        //        {
        //            checkedListBox_mode.SetItemChecked(intmode, true);
        //        }
        //    }
        //    if (CheckBox_selectall.Checked)//Sean.Lin_20171024
        //    {
        //        CheckBox_clearall.Checked = false;
        //    }
        //    else //clear select all   //Sean.Lin_20171024
        //    {
        //        for (int intmode = 0; intmode < checkedListBox_mode.Items.Count; intmode++)
        //        {
        //            checkedListBox_mode.SetItemChecked(intmode, false);
        //        }
        //    }
        //}
        private void radioButton_Selectall_CheckedChanged(object sender, EventArgs e)//Sean.Lin_20171024
        {
            if (radioButton_Selectall.Checked)//select all
            {
                for (int intmode = 0; intmode < checkedListBox_mode.Items.Count; intmode++)
                {
                    checkedListBox_mode.SetItemChecked(intmode, true);
                }
            }
            if (radioButton_Selectall.Checked)
            {
                radioButton_Clearall.Checked = false;
            }
        }
        //**********************************************************************************************************************
        //
        // Copyright (C) 2017, ND CO.,LTD. Taiwan  All Rights Reserved
        //
        //! @fn : 01. radioButton_Clearall_CheckedChanged
        //
        //! @author : Sean.Lin
        //
        //! @date : 2017.10.24
        //
        //! @brief : 01. when ckick radioButton_Clearall, automatically uncheck all modes
        //           02. 當radioButton_Clearall勾選會取消CheckBox_selectall
        //
        //! @param :
        //
        //! @return :
        //
        //**********************************************************************************************************************
        private void radioButton_Clearall_CheckedChanged(object sender, EventArgs e)//Sean.Lin_20171024
        {
            if (radioButton_Clearall.Checked)//clear all
            {
                for (int intmode = 0; intmode < checkedListBox_mode.Items.Count; intmode++)
                {
                    checkedListBox_mode.SetItemChecked(intmode, false);
                }
            }
            if (radioButton_Clearall.Checked)
            {
                radioButton_Selectall.Checked = false;
            }
        }
        //**********************************************************************************************************************
        //
        // Copyright (C) 2017, ND CO.,LTD. Taiwan  All Rights Reserved
        //
        //! @fn : RichTextBox_infor_user_TextChanged & RichTextBox_infor_engineer_TextChanged
        //
        //! @author : Lynn.Wei
        //
        //! @date :2017.07.10
        //
        //! @brief : when put text into RichTextBox_infor, RichTextBox_infor scrolls automatically
        //
        //! @param :
        //
        //! @return :
        //
        //**********************************************************************************************************************
        private void RichTextBox_infor_user_TextChanged(object sender, EventArgs e)
        {
            RichTextBox_infor_user.SelectionStart = RichTextBox_infor_user.TextLength;
            RichTextBox_infor_user.ScrollToCaret();                                               // Scrolls the contents of the control to the current caret position.        
        }

        private void RichTextBox_infor_engineer_TextChanged(object sender, EventArgs e)
        {
            RichTextBox_infor_engineer.SelectionStart = RichTextBox_infor_engineer.TextLength;
            RichTextBox_infor_engineer.ScrollToCaret();                                                // Scrolls the contents of the control to the current caret position.            
        }
        //**********************************************************************************************************************
        //
        // Copyright (C) 2017, ND CO.,LTD. Taiwan  All Rights Reserved
        //
        //! @fn : MainForm_FormClosing
        //
        //! @author : Sean.Lin
        //
        //! @date :2017.10.18
        //
        //! @brief : 01. text in RichTextBox_infor_engineer & RichTextBox_infor_user will save to TXT file before closing the program
        //           02. 註解掉"刪除EXCEL程序"
        //
        //! @param :
        //
        //! @return :
        //
        //**********************************************************************************************************************
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {

            RichTextBox_infor_engineer.SaveFile(string_file_txt_engineer, RichTextBoxStreamType.PlainText);
            RichTextBox_infor_user.SaveFile(string_file_txt_user, RichTextBoxStreamType.PlainText);

            //下列程式會關閉其他excel故先註解掉 Sean.Lin_20171018
            //System.Diagnostics.Process[] procs = System.Diagnostics.Process.GetProcessesByName("EXCEL");         // 刪除EXCEL程序, 否則每執行一次會持續增加
            //foreach (System.Diagnostics.Process p in procs)
            //{
            //    p.Kill();
            //}
        }

        //**********************************************************************************************************************
        //
        // Copyright (C) 2017, ND CO.,LTD. Taiwan  All Rights Reserved
        //
        //! @fn     :   button_CalibData_Click
        //
        //! @author :   Grace.Lee
        //
        //! @date   :   2017.07.10
        //
        //! @brief  :   Open CalibForm2 after click the button.
        //
        //! @param  :   NONE
        //
        //! @return :   NONE
        //
        //**********************************************************************************************************************
        private void button_CalibData_Click(object sender, EventArgs e)
        {
            CalibForm2 f2 = new CalibForm2();
            f2.double_data = double_ary_E200_calibrate_data;
            f2.double_data_done = double_array_CalibData;
            f2.Visible = true;
        }
        //**********************************************************************************************************************
        //
        // Copyright (C) 2017, ND CO.,LTD. Taiwan  All Rights Reserved
        //
        //! @fn : Button_pause_Click
        //
        //! @author : Lynn.Wei
        //
        //! @date : 2017.07.18
        //
        //! @brief : pause/continue the calibration
        //
        //! @param :
        //
        //! @return :
        //
        //**********************************************************************************************************************
        bool bool_pause = false;
        private void Button_pause_Click(object sender, EventArgs e)
        {
            if (!bool_pause)
            {
                Button_pause.Text = "CONTINUE";
                Button_pause.Font = new System.Drawing.Font(Button_pause.Font.FontFamily, 28);
                bool_pause = true;
                bool_cal_stop = true;

                timer_timer1.Stop();
                timer_Calibration.Stop();
            }

            else
            {
                Button_pause.Text = "PAUSE";
                Button_pause.Font = new System.Drawing.Font(Button_pause.Font.FontFamily, 36);

                bool_cal_stop = false;
                timer_timer1.Start();
                timer_Calibration.Start();
                bool_pause = false;
            }
        }

        //**********************************************************************************************************************
        //
        // Copyright (C) 2017, ND CO.,LTD. Taiwan  All Rights Reserved
        //
        //! @fn : timer_Detect_serial_port_Tick
        //
        //! @author : Lynn.Wei
        //
        //! @date : 2017.08.01
        //
        //! @brief : 
        //
        //! @param : searching serial port
        //
        //! @return :
        //
        //**********************************************************************************************************************
        private void timer_Detect_serial_port_Tick(object sender, EventArgs e)
        {
            ComboBox_E200.Items.Clear();
            ComboBox_E200.Items.AddRange(System.IO.Ports.SerialPort.GetPortNames());
            if (ComboBox_E200.Items.Count == 0)
            {
                ComboBox_E200.Text = "";
            }

            comboBox_RSB.Items.Clear();
            comboBox_RSB.Items.AddRange(System.IO.Ports.SerialPort.GetPortNames());
            if (comboBox_RSB.Items.Count == 0)
            {
                comboBox_RSB.Text = "";
            }

        }

        //**********************************************************************************************************************
        //
        // Copyright (C) 2017, ND CO.,LTD. Taiwan  All Rights Reserved
        //
        //! @fn : label_web_click
        //
        //! @author : Lynn.Wei
        //
        //! @date : 2017.08.01
        //
        //! @brief : 
        //
        //! @param : open web
        //
        //! @return :
        //
        //**********************************************************************************************************************
        private void label_web_click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.newdean.com.tw/ND/index.aspx");
        }

        //**********************************************************************************************************************
        //
        // Copyright (C) 2017, ND CO.,LTD. Taiwan  All Rights Reserved
        //
        //! @fn : checkedListBox_mode_SelectedIndexChanged
        //
        //! @author : Sean.Lin
        //
        //! @date : 2017.10.24
        //
        //! @brief : 01. 顯示各模式相對應阻抗制至介面上。
        //           02. 當checkedListBox沒有全勾選，便將radioButton_Selectall取消；反之當checkedListBox沒有全無勾選，將radioButton_Cleartall取消。
        //
        //! @param :
        //
        //! @return :
        //
        //**********************************************************************************************************************
        private void checkedListBox_mode_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int intmode = 0; intmode < checkedListBox_mode.Items.Count; intmode++)//詳見備註2  Sean.Lin_20171024
            {
                if (!checkedListBox_mode.GetItemChecked(intmode))
                {
                    radioButton_Selectall.Checked = false;
                }
            }
            for (int intmode = 0; intmode < checkedListBox_mode.Items.Count; intmode++)//詳見備註2  Sean.Lin_20171024
            {
                if (checkedListBox_mode.GetItemChecked(intmode))
                {
                    radioButton_Clearall.Checked = false;
                }
            }

            switch (checkedListBox_mode.SelectedIndex)
            {
                case 0://"PURE"
                    TextBox_load.Text = "500";
                    break;
                case 1://"BLEND1"
                    TextBox_load.Text = "500";
                    break;
                case 2://"BLEND2"
                    TextBox_load.Text = "500";
                    break;
                case 4://"SPRAY"
                    TextBox_load.Text = "1000";
                    break;
                case 3://"PINPOINT"
                    TextBox_load.Text = "500";
                    break;
                case 5://"BIPOLAR"
                    TextBox_load.Text = "100";
                    break;
            }
        }

        //**********************************************************************************************************************
        //
        // Copyright (C) 2017, ND CO.,LTD. Taiwan  All Rights Reserved
        //
        //! @fn : checkedListBox_mode_SelectedIndexChanged
        //
        //! @author : Grace.Lee
        //
        //! @date : 2017.08.05
        //
        //! @brief : 
        //
        //! @param :
        //
        //! @return :
        //
        //**********************************************************************************************************************
        private void radioButton_calibration_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_calibration.Checked)
            {
                radioButton_verify.Checked = false;
            }
            else
            {
                radioButton_verify.Checked = true;
            }
        }

        private void radioButton_verify_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_verify.Checked)
            {
                radioButton_calibration.Checked = false;
            }
            else
            {
                radioButton_calibration.Checked = true;
            }
        }


        //**********************************************************************************************************************
        //
        // Copyright (C) 2017, ND CO.,LTD. Taiwan  All Rights Reserved
        //
        //! @fn : serialPort_RSB_DataReceived
        //
        //! @author : Lynn.Wei
        //
        //! @date : 2017.08.14
        //
        //! @brief : when serialPort_RSB receives data
        //
        //! @param :
        //
        //! @return :
        //
        //**********************************************************************************************************************
        string string_received_RSB = "";
        string[] string_RSB_K = new string[7];
        private void serialPort_RSB_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            string_received_RSB = string_received_RSB + sp.ReadExisting();
            MethodInvoker mi = new MethodInvoker(this.UpdateRSB);
            this.BeginInvoke(mi, null);
        }
        string string_test2 = "";
        private void UpdateRSB()
        {
            if(string_test2 == string_received_RSB)
            {
                return;
            }
            RichTextBox_infor_engineer.AppendText("Received RSB-> " + string_received_RSB  + "\n");
            string_test2 = string_received_RSB;
            if (string_received_RSB.IndexOf("CHK") > -1)
            {
                string string_sub_received_RSB_R_Name = "";
                string string_sub_received_RSB_CHK = "";
                if (string_received_RSB.Length >= string_received_RSB.IndexOf("CHK") + 6)
                {
                    string_sub_received_RSB_R_Name = string_received_RSB.Substring(string_received_RSB.IndexOf("CHK") + 4, 2);
                    if (string_received_RSB.Length >= string_received_RSB.IndexOf("CHK") + 8)
                    {
                        string_sub_received_RSB_CHK = string_received_RSB.Substring(string_received_RSB.IndexOf("CHK") + 7, 1);
                    }
                    else
                        string_sub_received_RSB_CHK = "";
                }
                else
                    string_sub_received_RSB_R_Name = "";
                
                
                switch (string_sub_received_RSB_R_Name)
                {
                    case ("K1"):
                        string_RSB_K[0] = string_sub_received_RSB_CHK;
                        break;
                    case ("K2"):
                        string_RSB_K[1] = string_sub_received_RSB_CHK;
                        break;
                    case ("K3"):
                        string_RSB_K[2] = string_sub_received_RSB_CHK;
                        break;
                    case ("K4"):
                        string_RSB_K[3] = string_sub_received_RSB_CHK;
                        break;
                    case ("K5"):
                        string_RSB_K[4] = string_sub_received_RSB_CHK;
                        break;
                    case ("K6"):
                        string_RSB_K[5] = string_sub_received_RSB_CHK;
                        break;
                    case ("K7"):
                        string_RSB_K[6] = string_sub_received_RSB_CHK;
                        break;
                }
            }

        }
        //**********************************************************************************************************************
        //
        // Copyright (C) 2017, ND CO.,LTD. Taiwan  All Rights Reserved
        //
        //! @fn : button_RSB_connect_Click
        //
        //! @author : Lynn.Weil
        //
        //! @date : 2017.08.14
        //
        //! @brief : when button_RSB_connect click, connect RSB
        //
        //! @param :
        //
        //! @return :
        //
        //**********************************************************************************************************************
        private void button_RSB_connect_Click(object sender, EventArgs e)
        {
            //connecting
            if (bool_connected_RSB)
            {
                try
                {
                    serialPort_RSB.Close();
                }
                catch(Exception  ex)
                {
                    
                }
               
                button_RSB_connect.Text = "Disconnect";
                comboBox_RSB.Text = "";
                bool_connected_RSB = false;
                timer_Detect_serial_port.Start();

                RichTextBox_infor_user.AppendText("Disconnect RSB.\n");
                RichTextBox_infor_engineer.AppendText("Disconnect RSB.\n");
            }
            else
            {
                bool bool_auto;

                if (RadioButton_connect_manual.Checked)
                    bool_auto = false;
                else
                    bool_auto = true;

                if (comboBox_RSB.SelectedItem == null && bool_auto == false && comboBox_RSB.Text == "")   //manual, but not choose a COM port
                {
                    RichTextBox_infor_engineer.AppendText("Choose a COM Port.\n\n");
                    RichTextBox_infor_user.AppendText("Choose a COM Port.\n\n");
                    MessageBox.Show("Please connect COM port of R.S.B."); 
                    timer_Detect_serial_port.Start();
                    return;
                }
                if (comboBox_RSB.Items.Count == 0)   //ComboBox_COMport is empty
                {
                    RichTextBox_infor_engineer.AppendText("No COM Port is exists.\n\n");
                    RichTextBox_infor_user.AppendText("No COM Port is exists.\n\n");
                    MessageBox.Show("No COM Port is exists.");
                    button_RSB_connect.Text = "Disconnect";
                    timer_Detect_serial_port.Start();
                    return;
                }
                //before connecting
                comboBox_RSB.Enabled = false;          //flase to chose COM port if connecting
                button_RSB_connect.Enabled = false;        //flase to click Button if connecting
                String string_RSB_connected_port = "non";
                if (bool_auto)
                {
                    string[] string_COMportname = new string[comboBox_RSB.Items.Count];      // the size of string_COMportname = item-numbers of ComboBox_COMport
                    comboBox_RSB.Items.CopyTo(string_COMportname, 0);                    //copy items in ComboBox_COMport to string array

                    for (int int_count = 0; int_count <= comboBox_RSB.Items.Count - 1; int_count++)
                    {
                        if (Connect_RSB_COM(string_COMportname[int_count]))
                        {
                            bool_connected_RSB = true;
                            string_RSB_connected_port = string_COMportname[int_count];
                            break;
                        }

                    }

                }
                else  //bool_manual
                {
                    string string_COMportname = comboBox_RSB.Text;
                    string_RSB_connected_port = comboBox_RSB.Text;
                    if (Connect_RSB_COM(string_COMportname))                      //如果正確連接RSB，跳出迴圈
                    {
                        bool_connected_RSB = true;
                    }
                }
                //after connecting
                button_RSB_connect.Enabled = true;

                if (!bool_auto)
                {
                    comboBox_RSB.Enabled = true;
                }
                if (!bool_connected_RSB)
                {
                    MessageBox.Show("False to connect RSB.");
                }
            }
           
        }
        //**********************************************************************************************************************
        //
        // Copyright (C) 2017, ND CO.,LTD. Taiwan  All Rights Reserved
        //
        //! @fn : Connect_RSB_COM
        //
        //! @author : Lynn.Weil
        //
        //! @date : 2017.08.14
        //
        //! @brief :
        //
        //! @param : string_COMportname
        //
        //! @return : true or false
        //
        //**********************************************************************************************************************
        private bool Connect_RSB_COM(string string_COMportname)
        {
            if (string_COMportname == ComboBox_E200.Text)
                return false;
            button_RSB_connect.Text = "Opening " + string_COMportname + " ...";
            RichTextBox_infor_engineer.AppendText("\n" + "Connecting " + string_COMportname + "...\n");
            serialPort_RSB.Close();
            Thread.Sleep(1000);
            try
            {
                serialPort_RSB.PortName = (string_COMportname);
                serialPort_RSB.Open();
            }
            catch (Exception ex_open_port)                                           //show exception
            {
                RichTextBox_infor_engineer.AppendText("False to open port" + string_COMportname + ".\n");
                RichTextBox_infor_engineer.AppendText(ex_open_port.Message + "\n");

                RichTextBox_infor_user.AppendText("False to open port" + string_COMportname + ".\n");
                button_RSB_connect.Text = "Disconnect";
                return false;
            }
            RichTextBox_infor_engineer.AppendText(string_COMportname + " Opened.\n");
            RichTextBox_infor_engineer.AppendText("Connected " + string_COMportname + ".\n");
            RichTextBox_infor_user.AppendText("Connected " + string_COMportname + ".\n");

            if (serialPort_RSB.IsOpen)                                     //make sure if connected is RSB
            {
                RichTextBox_infor_engineer.AppendText("Connecting RSB...\n");
                string_received_RSB = "";

                try
                {
                    RSB_transmit("DET", "12V", "CHK", "?", "");
                }
                catch (Exception ex_connect_RSB)
                {
                    RichTextBox_infor_engineer.AppendText(ex_connect_RSB.Message + "\n");
                    RichTextBox_infor_engineer.AppendText("False to connect RSB.\n\n");
                    RichTextBox_infor_user.AppendText("False to connect RSB.\n\n");
                    button_RSB_connect.Text = "Disconnect";
                    return false;
                }

                Thread.Sleep(1000);
                System.Windows.Forms.Application.DoEvents();

                if (string_received_RSB == "" || string_received_RSB == " ")                                                                //do not receive signal
                {
                    RichTextBox_infor_engineer.AppendText("Do not receive return signal.\n");
                    RichTextBox_infor_engineer.AppendText("False to connect RSB.\n\n");
                    RichTextBox_infor_user.AppendText("False to connect RSB.\n\n");
                    button_RSB_connect.Text = "Disconnect";
                    return false;

                }
                else if (string_received_RSB.IndexOf("RSB") < 0)                                      //recived signals, but not from RSB
                {
                    RichTextBox_infor_engineer.AppendText("Return signal is not from RSB. \n");
                    RichTextBox_infor_engineer.AppendText("False to connect RSB.\n\n");
                    RichTextBox_infor_user.AppendText("False to connect RSB.\n\n");
                    button_RSB_connect.Text = "Disconnect";
                    return false;
                }
                button_RSB_connect.Text = "Connected";
                comboBox_RSB.Text = string_COMportname;
                RichTextBox_infor_engineer.AppendText("Connected RSB.\n");
                RichTextBox_infor_user.AppendText("Connectecd RSB.\n");
                return true;
            }
            else
            {
                RichTextBox_infor_engineer.AppendText("false to Connect" + string_COMportname + ".\n");
                return false;
            }

        }
        //**********************************************************************************************************************
        //
        // Copyright (C) 2017, ND CO.,LTD. Taiwan  All Rights Reserved
        //
        //! @fn : RSB_transmit
        //
        //! @author : Lynn.Weil
        //
        //! @date : 2017.08.14
        //
        //! @brief : sent commend to RSB
        //
        //! @param : string_device, string_control, string_moverment, string_synbol, string_value
        //
        //! @return :
        //
        //**********************************************************************************************************************
        bool bool_return;
        public void RSB_transmit(string string_device, string string_control, string string_moverment, string string_synbol, string string_value)
        {
            string string_send_RSB = "PC:[" + string_device + "_" + string_control + "_" + string_moverment + string_synbol + string_value + "]";
            
            RichTextBox_infor_engineer.AppendText("Sent RSB -> " + string_send_RSB + "\n");
            try
            {
                serialPort_RSB.Write(string_send_RSB);
            }
            catch (Exception ex)
            {
                bool_return = true;
                RichTextBox_infor_engineer.AppendText(Convert.ToString(ex));
                button_RSB_connect.PerformClick();
                ForceStop("FAIL", Color.Red);
                E200_transmit("MODE", "DISABLE", "0");
                MessageBox.Show("RSB transmit error.");
            }

            string_received_RSB = "";
        }

        //**********************************************************************************************************************
        //
        // Copyright (C) 2017, ND CO.,LTD. Taiwan  All Rights Reserved
        //
        //! @fn : RSB_RELAY_select
        //
        //! @author : Grace.Lee
        //
        //! @date : 2017.08.14
        //
        //! @brief : select different relay for different mode
        //
        //! @param : int k1, int k2, int k3, int k4, int k5, int k6, int k7
        //
        //! @return :
        //
        //**********************************************************************************************************************
        private void RSB_RELAY_select(int k1, int k2, int k3, int k4, int k5, int k6, int k7)//k?=0 or 1
        {
            int[] int_k = { k1, k2, k3, k4, k5, k6, k7 };
            for (int i = 0; i < 7; i++)
            {
                RSB_transmit("RELAY", "CTRL", "K" + (i + 1), "=", Convert.ToString(int_k[i]));
                if (bool_return)
                {
                    bool_return = false;
                    return;
                }
                timer_Calibration.Stop();
                Thread.Sleep(20);
                System.Windows.Forms.Application.DoEvents();
                if (bool_cal_stop == false)
                    timer_Calibration.Start();
            }
            for (int i = 0; i < 7; i++)
            {
                RSB_transmit("RELAY", "CHK", "K" + (i + 1), "?", "");
                if(bool_return)
                {
                    bool_return = false;
                    return;
                }
                timer_Calibration.Stop();
                Thread.Sleep(25);
                System.Windows.Forms.Application.DoEvents();
                if (bool_cal_stop == false)
                    timer_Calibration.Start();
            }

            for (int i = 0; i < 7; i++)
            {
                if (string_RSB_K[i] == Convert.ToString(int_k[i]))//CTRL=0->CHK=1
                {
                    E200_transmit("MODE", "DISABLE", "0");
                    ForceStop("FAIL", Color.Red);
                    button_RSB_connect.PerformClick();
                    RichTextBox_infor_user.AppendText("RSB Switch Error." + "\n");
                    MessageBox.Show("RSB Switch Error.");
                    RichTextBox_infor_engineer.AppendText("RSB Check Error : K" + (i + 1) + "\n");
                    return;
                }
                else
                    continue;
            }

            timer_Calibration.Stop();
            Thread.Sleep(20);
            System.Windows.Forms.Application.DoEvents();
            if (bool_cal_stop == false)
                timer_Calibration.Start();
        }







    }
}
