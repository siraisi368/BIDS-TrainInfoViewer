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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        BIDSSharedMemoryData BSMDOld = new BIDSSharedMemoryData();

        private void Form4_Load(object sender, EventArgs e)
        {
            StaticSMemLib.Begin(false, true);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeSpan TSNew = TimeSpan.FromMilliseconds(BSMDOld.StateData.T);

            if(BSMDOld.StateData.I <= 0)
            {
                progressBar2.Value = (int)((BSMDOld.StateData.I / 2)/10)*-1;
                label4.Text = ((int)BSMDOld.StateData.I*-1).ToString()+"A";
                label3.Text = "0A";
                progressBar1.Value = 0;
            }
            else if (BSMDOld.StateData.I >= 0)
            {
                progressBar1.Value = (int)((BSMDOld.StateData.I / 2) / 10);
                label3.Text = ((int)BSMDOld.StateData.I).ToString() + "A";
                label4.Text = "0A";
                progressBar2.Value = 0;
            }

            BSMDOld = StaticSMemLib.ReadBSMD();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            this.TopMost = checkBox1.Checked;
        }
    }
}
