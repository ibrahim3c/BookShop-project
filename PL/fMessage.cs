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
    public partial class fMessage : Form
    {
        public fMessage(string message)
        {
            InitializeComponent();
            lbMessage.Text = message;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lbMessage_Click(object sender, EventArgs e)
        {

        }

        private void fMessage_Load(object sender, EventArgs e)
        {

        }
    }
}
