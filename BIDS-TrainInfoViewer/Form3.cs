using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TR.BIDSSMemLib;

namespace BIDS_TrainInfoViewer
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        BIDSSharedMemoryData BSMDOld = new BIDSSharedMemoryData();
        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeSpan TSNew = TimeSpan.FromMilliseconds(BSMDOld.StateData.T);
            double brake_Comp = BSMDOld.StateData.BC /10; //ブレーキシリンダ圧
            double base_Comp = BSMDOld.StateData.MR /10; //元空気タンク圧

            (progressBar1.Value, label3.Text) = ((int)brake_Comp, ((int)brake_Comp*10).ToString()+"kPa");
            (progressBar2.Value,label4.Text) = ((int)base_Comp,((int)base_Comp*10).ToString()+"kPa");

            BSMDOld = StaticSMemLib.ReadBSMD();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            StaticSMemLib.Begin(false, true);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            this.TopMost = checkBox1.Checked;
        }
    }
}
