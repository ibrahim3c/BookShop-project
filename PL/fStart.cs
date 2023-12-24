using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookShop_project.PL
{
    public partial class fStart : Form
    {
        public fStart()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (tmStart.Enabled == true)
            {
                tmStart.Enabled = false;
                PL.fLogin f = new fLogin();
                this.Hide();
                f.ShowDialog();
                this.Close();
            }
        }
    }
}
