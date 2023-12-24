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

namespace BookShop_project.PL
{
    public partial class fUserDetail : Form
    {
        public int ID;
        public fUserDetail(int ID)
        {
            this.ID = ID;
            InitializeComponent();

            clsUsers us = new clsUsers();

            try
            {
                DataTable dt = new DataTable();
                dt = us.LoadToEdit(ID);
                object obj1 = dt.Rows[0]["name"];
                object obj2 = dt.Rows[0]["user"];
                object obj3 = dt.Rows[0]["password"];
                object obj4 = dt.Rows[0]["permission"];
                //object obj5 = dt.Rows[0]["state"];
                object obj6 = dt.Rows[0]["image"];

                if (!string.IsNullOrEmpty(obj6.ToString()))
                {
                    byte[] pic = (byte[])obj6;
                    MemoryStream m = new MemoryStream(pic);
                    pbUser.Image = Image.FromStream(m);
                }
                lbName.Text = obj1.ToString();
                lbUser.Text = obj2.ToString();
                lbPassword.Text = obj3.ToString();
                lbPermission.Text = obj4.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void bookDetails_Load(object sender, EventArgs e)
        {

        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
