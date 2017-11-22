using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Csharp
{
    public partial class CalibForm2 : Form
    {
        public CalibForm2()
        {
            InitializeComponent();
        }

        private double[,] double_array_data;
        public double[,] double_data
        {
            set
            {
                double_array_data = value;
            }
        }


        private double[,] double_array_data_done;
        public double[,] double_data_done
        {
            set
            {
                double_array_data_done = value;
            }
        }

        private void CalibForm2_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 6; i++)
            {
                if (double_array_data_done[i, 0] != 0)
                    checkedListBox1.SetItemChecked(i, true);
            }
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //CalibForm2 f2 = new CalibForm2();//
            //f2.double_data = double_ary_E200_calibrate_data;//double_array_CalibData
            //f2.double_data_done = double_array_CalibData;
            MainForm f1 = new MainForm();
            
            
            //MainForm.E200_transmit("CALIB_DATA_" + comboBox1.Text , "?", "");

            textBox1.Text = Convert.ToString(double_array_data[comboBox1.SelectedIndex, 0]);
            textBox2.Text = Convert.ToString(double_array_data[comboBox1.SelectedIndex, 1]);
            textBox3.Text = Convert.ToString(double_array_data[comboBox1.SelectedIndex, 2]);
            textBox4.Text = Convert.ToString(double_array_data[comboBox1.SelectedIndex, 3]);
            textBox5.Text = Convert.ToString(double_array_data[comboBox1.SelectedIndex, 4]);
            textBox6.Text = Convert.ToString(double_array_data[comboBox1.SelectedIndex, 5]);
            textBox7.Text = Convert.ToString(double_array_data[comboBox1.SelectedIndex, 6]);
            textBox8.Text = Convert.ToString(double_array_data[comboBox1.SelectedIndex, 7]);
            textBox9.Text = Convert.ToString(double_array_data[comboBox1.SelectedIndex, 8]);
            textBox10.Text = Convert.ToString(double_array_data[comboBox1.SelectedIndex, 9]);
            textBox11.Text = Convert.ToString(double_array_data[comboBox1.SelectedIndex, 10]);
            textBox12.Text = Convert.ToString(double_array_data[comboBox1.SelectedIndex, 11]);
            textBox13.Text = Convert.ToString(double_array_data[comboBox1.SelectedIndex, 12]);
            textBox14.Text = Convert.ToString(double_array_data[comboBox1.SelectedIndex, 13]);
            textBox15.Text = Convert.ToString(double_array_data[comboBox1.SelectedIndex, 14]);
            textBox16.Text = Convert.ToString(double_array_data[comboBox1.SelectedIndex, 15]);
            textBox17.Text = Convert.ToString(double_array_data[comboBox1.SelectedIndex, 16]);
            textBox18.Text = Convert.ToString(double_array_data[comboBox1.SelectedIndex, 17]);
            textBox19.Text = Convert.ToString(double_array_data[comboBox1.SelectedIndex, 18]);
            textBox20.Text = Convert.ToString(double_array_data[comboBox1.SelectedIndex, 19]);
            
                //for (int i = 0; i <= 20; i++)
                //{
                //    TextBox _tb = this.Controls.Find("TextBox_" + i.ToString(), true).FirstOrDefault() as TextBox;
                //    _tb.Text = Convert.ToString(double_array_data[comboBox1.SelectedIndex, i - 1]);
                //    //執行更新  _tb.Text就是你要的資料
                //    for (int j = 0; j < 6; j++)
                //    {
                //        if (double_array_data[j, i - 1] != 0)
                //            checkedListBox1.SetItemChecked(j, true);
                //    }
                //}
                switch (comboBox1.SelectedIndex)
                {
                    case 0:
                        //int_expect_power_max = 200;
                        visable_(200);
                        break;
                    case 1:
                        //int_expect_power_max = 150;
                        visable_(150);
                        break;
                    case 2:
                        //int_expect_power_max = 150;
                        visable_(150);
                        break;
                    case 3:
                        //int_expect_power_max = 80;
                        visable_(80);
                        break;
                    case 4:
                        //int_expect_power_max = 100;
                        visable_(100);
                        break;
                    case 5:
                        //int_expect_power_max = 60;
                        visable_(60);

                        break;
                }
        }
        private void visable_(int selectoin)
        {
            if (selectoin == 200)
            {
                textBox1.Visible = true;
                textBox2.Visible = true;
                textBox3.Visible = true;
                textBox4.Visible = true;
                textBox5.Visible = true;
                textBox6.Visible = true;
                textBox7.Visible = true;
                textBox8.Visible = true;
                textBox9.Visible = true;
                textBox10.Visible = true;
                textBox11.Visible = true;
                textBox12.Visible = true;
                textBox13.Visible = true;
                textBox14.Visible = true;
                textBox15.Visible = true;
                textBox16.Visible = true;
                textBox17.Visible = true;
                textBox18.Visible = true;
                textBox19.Visible = true;
                textBox20.Visible = true;

                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                label6.Visible = true;
                label7.Visible = true;
                label8.Visible = true;
                label9.Visible = true;
                label10.Visible = true;
                label11.Visible = true;
                label12.Visible = true;
                label13.Visible = true;
                label14.Visible = true;
                label15.Visible = true;
                label16.Visible = true;
                label17.Visible = true;
                label18.Visible = true;
                label19.Visible = true;
                label20.Visible = true;
            }
            if(selectoin == 150)
            {
                textBox1.Visible = true;
                textBox2.Visible = true;
                textBox3.Visible = true;
                textBox4.Visible = true;
                textBox5.Visible = true;
                textBox6.Visible = true;
                textBox7.Visible = true;
                textBox8.Visible = true;
                textBox9.Visible = true;
                textBox10.Visible = true;
                textBox11.Visible = true;
                textBox12.Visible = true;
                textBox13.Visible = true;
                textBox14.Visible = true;
                textBox15.Visible = true;
                textBox16.Visible = false;
                textBox17.Visible = false;
                textBox18.Visible = false;
                textBox19.Visible = false;
                textBox20.Visible = false;

                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                label6.Visible = true;
                label7.Visible = true;
                label8.Visible = true;
                label9.Visible = true;
                label10.Visible = true;
                label11.Visible = true;
                label12.Visible = true;
                label13.Visible = true;
                label14.Visible = true;
                label15.Visible = true;
                label16.Visible = false;
                label17.Visible = false;
                label18.Visible = false;
                label19.Visible = false;
                label20.Visible = false;
            }
            if (selectoin == 100)
            {
                textBox1.Visible = true;
                textBox2.Visible = true;
                textBox3.Visible = true;
                textBox4.Visible = true;
                textBox5.Visible = true;
                textBox6.Visible = true;
                textBox7.Visible = true;
                textBox8.Visible = true;
                textBox9.Visible = true;
                textBox10.Visible = true;
                textBox11.Visible = false;
                textBox12.Visible = false;
                textBox13.Visible = false;
                textBox14.Visible = false;
                textBox15.Visible = false;
                textBox16.Visible = false;
                textBox17.Visible = false;
                textBox18.Visible = false;
                textBox19.Visible = false;
                textBox20.Visible = false;

                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                label6.Visible = true;
                label7.Visible = true;
                label8.Visible = true;
                label9.Visible = true;
                label10.Visible = true;
                label11.Visible = false;
                label12.Visible = false;
                label13.Visible = false;
                label14.Visible = false;
                label15.Visible = false;
                label16.Visible = false;
                label17.Visible = false;
                label18.Visible = false;
                label19.Visible = false;
                label20.Visible = false;
            }
            if (selectoin == 80)
            {
                textBox1.Visible = true;
                textBox2.Visible = true;
                textBox3.Visible = true;
                textBox4.Visible = true;
                textBox5.Visible = true;
                textBox6.Visible = true;
                textBox7.Visible = true;
                textBox8.Visible = true;
                textBox9.Visible = false;
                textBox10.Visible = false;
                textBox11.Visible = false;
                textBox12.Visible = false;
                textBox13.Visible = false;
                textBox14.Visible = false;
                textBox15.Visible = false;
                textBox16.Visible = false;
                textBox17.Visible = false;
                textBox18.Visible = false;
                textBox19.Visible = false;
                textBox20.Visible = false;

                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                label6.Visible = true;
                label7.Visible = true;
                label8.Visible = true;
                label9.Visible = false;
                label10.Visible = false;
                label11.Visible = false;
                label12.Visible = false;
                label13.Visible = false;
                label14.Visible = false;
                label15.Visible = false;
                label16.Visible = false;
                label17.Visible = false;
                label18.Visible = false;
                label19.Visible = false;
                label20.Visible = false;
            } 
            if (selectoin == 60)
            {
                textBox1.Visible = true;
                textBox2.Visible = true;
                textBox3.Visible = true;
                textBox4.Visible = true;
                textBox5.Visible = true;
                textBox6.Visible = true;
                textBox7.Visible = false;
                textBox8.Visible = false;
                textBox9.Visible = false;
                textBox10.Visible = false;
                textBox11.Visible = false;
                textBox12.Visible = false;
                textBox13.Visible = false;
                textBox14.Visible = false;
                textBox15.Visible = false;
                textBox16.Visible = false;
                textBox17.Visible = false;
                textBox18.Visible = false;
                textBox19.Visible = false;
                textBox20.Visible = false;

                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                label6.Visible = true;
                label7.Visible = false;
                label8.Visible = false;
                label9.Visible = false;
                label10.Visible = false;
                label11.Visible = false;
                label12.Visible = false;
                label13.Visible = false;
                label14.Visible = false;
                label15.Visible = false;
                label16.Visible = false;
                label17.Visible = false;
                label18.Visible = false;
                label19.Visible = false;
                label20.Visible = false;
            }
        }

    }
}
