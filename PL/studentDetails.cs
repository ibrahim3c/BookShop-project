using BookShop_project.BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace BookShop_project.PL
{
   
    public partial class studentDetails : Form
    {
        public int ID;
        public studentDetails(int ID)
        {
            this.ID = ID;
            InitializeComponent();
           




        }

        private void bookDetails_Load(object sender, EventArgs e)
        {

        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}
