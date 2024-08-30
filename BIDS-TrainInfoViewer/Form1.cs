using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TR;
using TR.BIDSSMemLib;


namespace BIDS_TrainInfoViewer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        BIDSSharedMemoryData BSMDOld = new BIDSSharedMemoryData();
        private int mascon = 1;
        private bool yokusoku = false;
        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeSpan TSNew = TimeSpan.FromMilliseconds(BSMDOld.StateData.T);
            double jisoku = Math.Round(BSMDOld.StateData.V, 1, MidpointRounding.AwayFromZero);
            int rikko = BSMDOld.HandleData.P;
            int seido = BSMDOld.HandleData.B;

            List<string> resp = hyoujikirikae(rikko, seido,yokusoku);

            if (resp[1] == "非常")
            {
                label5.ForeColor = Color.FromArgb(255, 100, 120);
            }
            else
            {
                label5.ForeColor = Color.FromArgb(240, 130, 130);
            }

            label4.Text = resp[0];
            label5.Text = resp[1];
            label2.Text = jisoku.ToString("0.0");
            label7.Text = LeverserTrans(BSMDOld.HandleData.R);

            label10.Text = $"{TSNew.Hours.ToString("00")}:{TSNew.Minutes.ToString("00")}:{TSNew.Seconds.ToString("00")}";

            BSMDOld = StaticSMemLib.ReadBSMD();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StaticSMemLib.Begin(false, true);
        }

        private List<string> hyoujikirikae(int rikko,int seido,bool yokusoku)
        {
            List<string> respdata = new List<string>(); 
            if (rikko ==0 && seido == 0)
            {
                respdata = new List<string>() {"惰性","緩解"};
            }
            else if (hantei_hijo(seido, mascon))
            {
                respdata = new List<string>() { "切", "非常" };
            }
            else if (seido == 0 && rikko != 0)
            {
                if(BSMDOld.SpecData.P == 4 && rikko == 5)
                {
                    respdata = new List<string>() { "4段", "緩解" };
                }
                else
                {
                    respdata = new List<string>() { rikko.ToString()+"段", "緩解" };
                }
            }
            else if (rikko == 0 && seido != 0)
            {
                if (yokusoku) {
                    if(seido == 1)
                    {
                        respdata = new List<string>() { "切", "抑速" };
                    }
                    else
                    {
                        seido -= 1;
                        respdata = new List<string>() { "切", seido.ToString() + "段" }; 
                    }
                }
                else {
                    respdata = new List<string>() { "切", seido.ToString() + "段" }; 
                }
            }
            else
            {
                respdata = new List<string>() { rikko.ToString() + "段", seido.ToString() + "段" };
            }
            return respdata;
        }

        private bool hantei_hijo(int seido,int masuconk)
        {
            bool resp = false;
            int hijoseido = 5;
            switch (masuconk)
            {
                case 1: //B5段マスコン
                    hijoseido = 6;
                    break;
                case 2: //B7段マスコン
                    hijoseido = 8;
                    break;
                case 3: //B8段マスコン
                    hijoseido = 9;
                    break;
                case 4: //B13段マスコン
                    hijoseido = 14;
                    break;
                case 5: //B7段抑速マスコン
                    hijoseido = 9;
                    break;
                case 6: //B8段抑速マスコン
                    hijoseido = 10;
                    break;
            }
            if(seido == hijoseido)
            {
                resp = true;
            }
            else 
            {
                resp = false;
            }
            return resp;
        }

        private string LeverserTrans(int leve)
        {
            string resp = "切";
            switch (leve)
            {
                case -1:
                    resp = "後退";
                    label7.ForeColor = Color.FromArgb(230, 100, 100);
                    break;
                case 0:
                    resp = "中立";
                    label7.ForeColor = Color.FromArgb(80, 230, 180);
                    break;
                case 1:
                    resp = "前進";
                    label7.ForeColor = Color.FromArgb(140, 180, 180);
                    break;
            }
            return resp;
        }

        private void b5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mascon = 1;
            yokusoku = false;
            this.Text = "TrainInfoViewer - B5段モード";
        }

        private void b5ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            mascon = 1;
            yokusoku = false;
            this.Text = "TrainInfoViewer - B5段モード";
        }

        private void b7ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mascon = 2;
            yokusoku = false;
            this.Text = "TrainInfoViewer - B7段モード";
        }

        private void b7ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            mascon = 2;
            yokusoku = false;
            this.Text = "TrainInfoViewer - B7段モード";
        }
        private void 抑速つき7段ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mascon = 5;
            yokusoku = true;
            this.Text = "TrainInfoViewer - B7段抑速モード";
        }

        private void 抑速7段ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mascon = 5;
            yokusoku = true;
            this.Text = "TrainInfoViewer - B7段抑速モード";
        }

        private void b8ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            mascon = 3;
            yokusoku = false;
            this.Text = "TrainInfoViewer - B8段モード";
        }

        private void b8ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mascon = 3;
            yokusoku = false;
            this.Text = "TrainInfoViewer - B8段モード";
        }
        private void 抑速付き8段ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mascon = 6;
            yokusoku = true;
            this.Text = "TrainInfoViewer - B8段抑速モード";
        }

        private void 抑速8段ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mascon = 6;
            yokusoku = true;
            this.Text = "TrainInfoViewer - B8段抑速モード";
        }

        private void b13ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mascon = 4;
            yokusoku = false;
            this.Text = "TrainInfoViewer - B13段モード";
        }

        private void b13ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            mascon = 4;
            yokusoku = false;
            this.Text = "TrainInfoViewer - B13段モード";
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            this.TopMost = checkBox1.Checked;
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.Show();
        }

        private void 圧力計ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 f = new Form3();
            f.Show();
        }

        private void 電流計ウインドウToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 f = new Form4();
            f.Show();
        }
    }
}
