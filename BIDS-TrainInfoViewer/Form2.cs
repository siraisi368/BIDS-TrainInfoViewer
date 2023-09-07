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
using TR;

namespace BIDS_TrainInfoViewer
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        BIDSSharedMemoryData BSMDOld = new BIDSSharedMemoryData();

        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeSpan TSNew = TimeSpan.FromMilliseconds(BSMDOld.StateData.T);

            label2.Text = BSMDOld.SpecData.C.ToString();
            
            BSMDOld = StaticSMemLib.ReadBSMD();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            StaticSMemLib.Begin(false, true);
        }
    }
}
