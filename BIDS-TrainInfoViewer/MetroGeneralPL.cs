using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TR;
using TR.BIDSSMemLib;

namespace BIDS_TrainInfoViewer
{
    public partial class MetroGeneralPL : Form
    {
        public MetroGeneralPL()
        {
            InitializeComponent();
        }
        BIDSSharedMemoryData BSMDOld = new BIDSSharedMemoryData();
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            int[] panelData = new int [2048];
            StaticSMemLib.ReadPanel().CopyTo(panelData, 0);
            switch (panelData[92])
            {
                case 0:
                    label1.Text = "切";
                    break;
                case 1:
                    label1.Text = "地下鉄";
                    break;
                case 2:
                    label1.Text = "東武";
                    break;
                case 3:
                    label1.Text = "東急・横高";
                    break;
                case 4:
                    label1.Text = "西武";
                    break;
                case 5:
                    label1.Text = "";
                    break;
                case 6:
                    label1.Text = "国鉄・伊豆急";
                    break;
                case 7:
                    label1.Text = "";
                    break;
                case 8:
                    label1.Text = "東葉";
                    break;
            }

            switch (panelData[151])
            {
                case 0:
                    label2.Text = "種別: ";
                    break;
                case 1:
                    label2.Text = "種別: 普通";
                    break;
                case 2:
                    label2.Text = "種別: 急行";
                    break;
                case 3:
                    label2.Text = "種別: 区間準急";
                    break;
                case 4:
                    label2.Text = "種別: 通勤準急";
                    break;
                case 5:
                    label2.Text = "種別: 準急";
                    break;
                case 6:
                    label2.Text = "種別: 特急";
                    break;
                case 7:
                    label2.Text = "種別: 急行";
                    break;
                case 8:
                    label2.Text = "種別: 通勤急行";
                    break;
            }

            if (panelData[104] == 1)
            {
                label3.Text = "制限: 10km/h";
            }
            else if (panelData[105] == 1)
            {
                label3.Text = "制限: 15km/h";
            }
            else if (panelData[106] == 1)
            {
                label3.Text = "制限: 20km/h";
            }
            else if (panelData[107] == 1)
            {
                label3.Text = "制限: 25km/h";
            }
            else if (panelData[108] == 1)
            {
                label3.Text = "制限: 30km/h";
            }
            else if (panelData[109] == 1)
            {
                label3.Text = "制限: 35km/h";
            }
            else if (panelData[110] == 1)
            {
                label3.Text = "制限: 40km/h";
            }
            else if (panelData[111] == 1)
            {
                label3.Text = "制限: 45km/h";
            }
            else if (panelData[112] == 1)
            {
                label3.Text = "制限: 50km/h";
            }
            else if (panelData[113] == 1)
            {
                label3.Text = "制限: 55km/h";
            }
            else if (panelData[114] == 1)
            {
                label3.Text = "制限: 60km/h";
            }
            else if (panelData[115] == 1)
            {
                label3.Text = "制限: 65km/h";
            }
            else if (panelData[116] == 1)
            {
                label3.Text = "制限: 70km/h";
            }
            else if (panelData[117] == 1)
            {
                label3.Text = "制限: 75km/h";
            }
            else if (panelData[118] == 1)
            {
                label3.Text = "制限: 80km/h";
            }
            else if (panelData[119] == 1)
            {
                label3.Text = "制限: 85km/h";
            }
            else if (panelData[120] == 1)
            {
                label3.Text = "制限: 90km/h";
            }
            else if (panelData[121] == 1)
            {
                label3.Text = "制限: 95km/h";
            }
            else if (panelData[122] == 1)
            {
                label3.Text = "制限: 100km/h";
            }
            else if (panelData[123] == 1)
            {
                label3.Text = "制限: 105km/h";
            }
            else if (panelData[124] == 1)
            {
                label3.Text = "制限: 110km/h";
            }
            else if (panelData[125] == 1)
            {
                label3.Text = "制限: 120km/h";
            }

            if (panelData[133] == 1)
            {
                label4.Text = "前方予告";
            }
            else
            {
                label4.Text = "";
            }
            
            if (panelData[134] == 1)
            {
                label5.Text = "ORP動作";
            }
            else
            {
                label5.Text = "";
            }

            if (panelData[131] == 1)
            {
                label8.ForeColor = Color.OrangeRed;
            }
            else if (panelData[132] == 1)
            {
                label8.ForeColor = Color.LightGreen;
            }

            if (panelData[73] == 1)
            {
                label6.BackColor = Color.Gold;
                label6.ForeColor = Color.Black;
            }
            else
            {
                label6.BackColor = Color.FromArgb(40, 40, 60);
                label6.ForeColor = Color.WhiteSmoke;
            }

            switch(panelData[155]){
                case 0:
                    label7.BackColor = Color.FromArgb(40, 40, 60);
                    label7.ForeColor = Color.WhiteSmoke;
                    break;
                case 1:
                    label7.BackColor = Color.Gold;
                    label7.ForeColor = Color.Black;
                    label7.Text = "ホームドア連動";
                    break;
                case 2:
                    label7.BackColor = Color.Gold;
                    label7.ForeColor = Color.Black;
                    label7.Text = "ホームドア非連動";
                    break;
            }

            if (panelData[23] == 1 || panelData[26] == 1 || panelData[77] == 1)
            {
                label9.ForeColor = Color.Black;
                label9.BackColor = Color.Gold;
            }
            else
            {
                label9.ForeColor = Color.WhiteSmoke;
                label9.BackColor = Color.FromArgb(40, 40, 60);
            }
            
            if (panelData[22] == 1 || panelData[25] == 1 || panelData[76] == 1)
            {
                label10.ForeColor = Color.Black;
                label10.BackColor = Color.Gold;
            }
            else
            {
                label10.ForeColor = Color.WhiteSmoke;
                label10.BackColor = Color.FromArgb(40, 40, 60);
            }

            if (panelData[251] == 1|| panelData[252] == 1 || panelData[253] == 1 || panelData[254] == 1)
            {
                label11.Text = "次駅停車";
                //if (serialPort1.IsOpen) serialPort1.Write("1");
            }
            else
            {
                label11.Text = "";
                //if (serialPort1.IsOpen) serialPort1.Write("0");
            }

            if (panelData[213] == 1)
            {
                label13.ForeColor = Color.Black;
                label13.BackColor = Color.Gold;
            }
            else
            {
                label13.ForeColor = Color.WhiteSmoke;
                label13.BackColor = Color.FromArgb(40, 40, 60);
            }

            if (panelData[214] != 0)
            {
                label12.Text = $"TASC-B{panelData[214]}";
            }
            else
            {
                label12.Text = "";
            }

            BSMDOld = StaticSMemLib.ReadBSMD();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            this.TopMost = checkBox1.Checked;
        }

        private void MetroGeneralPL_Load(object sender, EventArgs e)
        {
            //serialPort1.Open();
            //serialPort1.Write("0");
        }
    }
}
