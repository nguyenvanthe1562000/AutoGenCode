using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common;
namespace WindowsFormsApp1
{
    public partial class frmTutorial : Form
    {
        public frmTutorial()
        {
            InitializeComponent();
        }

        private void frmTutorial_Load(object sender, EventArgs e)
        {
             string Path= AppDomain.CurrentDomain.BaseDirectory + "Configuration Code\\tutorial.txt";
              rtb_Tutorial.Text = ReadSaveFile.ReadFile(Path);
        }
    }
}
