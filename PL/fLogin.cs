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
    public partial class fLogin : Form
    {
        public fLogin()
        {
            InitializeComponent();
        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            //this.Close();
            Environment.Exit(0);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            clsUsers us = new clsUsers();
            Form1 f = new Form1();
            DataTable dt = new DataTable();
            try
            {

                if (string.IsNullOrEmpty(tbUser.Text) || string.IsNullOrEmpty(tbPassword.Text))
                {
                    MessageBox.Show("enter the User Name and the Password", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    dt = us.login(tbUser.Text, tbPassword.Text);
                    if (dt.Rows.Count > 0)
                    {
                        // when login
                        us.stateInLogin(tbUser.Text, tbPassword.Text);
                        f.lbUserName.Text = dt.Rows[0]["name"].ToString();
                        f.lbPermission.Text = dt.Rows[0]["permission"].ToString();
                        object obj6 = dt.Rows[0]["image"];
                        if (!string.IsNullOrEmpty(obj6.ToString()))
                        {
                            byte[] pic = (byte[])obj6;
                            MemoryStream m = new MemoryStream(pic);
                            f.pbUser.Image = Image.FromStream(m);
                        }
                        this.Hide();
                       
                        f.ShowDialog();
                        this.Close();

                    }
                    else
                    {
                        MessageBox.Show("the user or password is wrong", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            tbPassword.Text = "";
            tbUser.Text = "";

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked) { 

                tbPassword.PasswordChar = '\0';

            }
            else
            {
                tbPassword.PasswordChar = '*';
            }

        }
    }
}
