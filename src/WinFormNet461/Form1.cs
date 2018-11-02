using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AsyncAwaitAnalysisCommon;

namespace WinFormNet461
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void WithAsync_Click(object sender, EventArgs e)
        {
            await TestCase.RunTestTaskAsync();
        }

        private void WithNoAsync_Click(object sender, EventArgs e)
        {
            TestCase.RunTestTaskAsync().GetAwaiter().GetResult();
        }

        private void WithMockDeadLock_Click(object sender, EventArgs e)
        {
            TestCase.RunMockDeadLook().GetAwaiter().GetResult();
        }
    }
}
