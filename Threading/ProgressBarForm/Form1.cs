using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgressBarForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 100;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            #region 设置进度条的值
            for (int i = 0; i < 100; i++)
            {
                progressBar1.Value = i;
                Thread.Sleep(1000);
            }
            #endregion


        }


        private delegate void SetNum(int num);

        private void Set(int num)
        {
            if (this.InvokeRequired)
            { 
                
            }
        }
    }
}
