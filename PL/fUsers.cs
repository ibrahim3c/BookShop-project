using BookShop_project.BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;

namespace BookShop_project.PL
{
    public partial class fUsers : Form
    {
        public int ID;

        public fUsers()
        {
            clsUsers us = new clsUsers();
            InitializeComponent();
            // load permissions to combobox
            DataTable dt1 = new DataTable();
            dt1 = us.loadtoComb();
            object[] data = new object[dt1.Rows.Count];
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                data[i] = dt1.Rows[i]["permissionName"];

            }
            cbPer.Items.AddRange(data);
        }

        public fUsers(int ID)
        {
            clsUsers us = new clsUsers();
            this.ID = ID;
            InitializeComponent();
            

            try
            {

                // load permissions to combobox
                DataTable dt1 = new DataTable();
                dt1 = us.loadtoComb();
                object[] data = new object[dt1.Rows.Count];
                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    data[i] = dt1.Rows[i]["permissionName"];

                }
                cbPer.Items.AddRange(data);



              
                DataTable dt = new DataTable();
                dt = us.LoadToEdit(ID);
                object obj1 = dt.Rows[0]["name"];
                object obj2 = dt.Rows[0]["user"];
                object obj3 = dt.Rows[0]["password"];
                //object obj4 = dt.Rows[0]["permission"];
                //object obj5 = dt.Rows[0]["state"];
                object obj6 = dt.Rows[0]["image"];

                if (!string.IsNullOrEmpty(obj6.ToString()))
                {
                    byte[] pic = (byte[])obj6;
                    MemoryStream m = new MemoryStream(pic);
                    pbUser.Image = Image.FromStream(m);
                }
                tbUName.Text = obj1.ToString();
                tbUser.Text = obj2.ToString();
                tbPassword.Text = obj3.ToString();
                //state = obj1.ToString();



                //select the book and student in combo
                cbPer.SelectedIndex = cbPer.FindString(dt.Rows[0]["permission"].ToString());

               





               



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lbDownloadCover_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image files (*.png; *.jpg; *.jpeg; *.gif; *.bmp)|*.png;*.jpg;*.jpeg;*.gif;*.bmp|All files (*.*)|*.*";
            var result = ofd.ShowDialog();
            if (result == DialogResult.OK)
            {
                pbUser.Image = Image.FromFile(ofd.FileName);

            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {

                BL.clsUsers us = new BL.clsUsers();
                if (ID == 0) // ADD
                {

                    MemoryStream m = new MemoryStream();
                    pbUser.Image.Save(m, ImageFormat.Png);
                    var pic = m.ToArray();
                    int result;



                    if (string.IsNullOrEmpty(tbUName.Text) || string.IsNullOrEmpty(tbPassword.Text) || string.IsNullOrEmpty(cbPer.Text) || string.IsNullOrEmpty(tbUser.Text))
                    {
                        MessageBox.Show("enter the values", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                   
                    else
                    {


                        us.insert(tbUName.Text, tbUser.Text, tbPassword.Text, cbPer.Text, "false", pic);
                        PL.fMessage f = new PL.fMessage("تمت الاضافة ");
                        f.ShowDialog();
                        this.Close();



                    }
                }


                else    //Edit

                {

                    MemoryStream m = new MemoryStream();
                    pbUser.Image.Save(m, ImageFormat.Png);
                    var pic = m.ToArray();
                    int result;



                    if (string.IsNullOrEmpty(tbUName.Text) || string.IsNullOrEmpty(tbPassword.Text) || string.IsNullOrEmpty(cbPer.Text) || string.IsNullOrEmpty(tbUser.Text))
                    {
                        MessageBox.Show("enter the values", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    else
                    {


                        us.edit(ID, tbUName.Text, tbUser.Text, tbPassword.Text, cbPer.Text, pic);
                        PL.fMessage f = new PL.fMessage("تم التعديل بنجاح ");
                        f.ShowDialog();
                        this.Close();



                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lbTitle_Click(object sender, EventArgs e)
        {

        }
    }
}
