using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookShop_project.PL
{
    public partial class fStudent : Form
    {
        public int ID;
        public fStudent()
        {
            InitializeComponent();
            
        }
        public fStudent(int ID)
        {
            this.ID = ID;
            InitializeComponent();
            try
            {

                BL.clsStudent s = new BL.clsStudent();
                DataTable dt = new DataTable();
                dt = s.LoadToEdit(ID);
                object obj1 = dt.Rows[0]["name"];
                object obj2 = dt.Rows[0]["Slocation"];
                object obj3 = dt.Rows[0]["State"];
                object obj4 = dt.Rows[0]["phone"];
                object obj5 = dt.Rows[0]["email"];
                object obj7 = dt.Rows[0]["cover"];

                if (!string.IsNullOrEmpty(obj7.ToString()))
                {
                    byte[] pic = (byte[])obj7;
                    MemoryStream m = new MemoryStream(pic);
                    pbCover.Image = Image.FromStream(m);
                }
                cbDep.Text = obj3.ToString();
                tbLocation.Text = obj2.ToString();
                
                tbName.Text = obj1.ToString();
                tbPhone.Text = obj4.ToString();
                tbEmail.Text = obj5.ToString();
                
               

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }





        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fBooks_Load(object sender, EventArgs e)
        {
          


        }

        private void lbDownloadCover_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image files (*.png; *.jpg; *.jpeg; *.gif; *.bmp)|*.png;*.jpg;*.jpeg;*.gif;*.bmp|All files (*.*)|*.*";
            var result = ofd.ShowDialog();
            if (result == DialogResult.OK)
            {
                pbCover.Image = Image.FromFile(ofd.FileName);

            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PL.fAddCat f = new PL.fAddCat("dep");
            f.lbTitle.Text = "Adding State";
            f.tbAddCat.PlaceholderText = "Add";

            try
            {
                cbDep.Items.Clear();
                BL.clsStudent s = new BL.clsStudent();
                DataTable dt = new DataTable();
                dt = s.loadtoComb2();
                object[] data = new object[dt.Rows.Count];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    data[i] = dt.Rows[i]["name"];

                }
                cbDep.Items.AddRange(data);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

            f.ShowDialog();
        }

        private void fBooks_Activated(object sender, EventArgs e)
        {
            //try
            //{
            //    cbDep.Items.Clear();
            //    BL.clsStudent s = new BL.clsStudent();
            //    DataTable dt = new DataTable();
            //    dt = s.loadtoComb();
            //    object[] data = new object[dt.Rows.Count];
            //    for (int i = 0; i < dt.Rows.Count; i++)
            //    {
            //        data[i] = dt.Rows[i]["name"];

            //    }
            //    cbDep.Items.AddRange(data);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);

            //}

            try
            {
               cbDep.Items.Clear();

                BL.clsStudent s = new BL.clsStudent();
                DataTable dt = new DataTable();
                dt = s.loadtoComb2();
                object[] data = new object[dt.Rows.Count];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    data[i] = dt.Rows[i]["name"];

                }
                cbDep.Items.AddRange(data);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
               
                BL.clsStudent s = new BL.clsStudent();
                if (ID == 0) // ADD
                {

                    MemoryStream m = new MemoryStream();
                    pbCover.Image.Save(m, ImageFormat.Png);
                    var pic = m.ToArray();
                    int result;



                    if (string.IsNullOrEmpty(tbName.Text)|| string.IsNullOrEmpty(tbLocation.Text) || string.IsNullOrEmpty(cbDep.Text) || string.IsNullOrEmpty(tbPhone.Text))
                    {
                        MessageBox.Show("enter the values", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    
                    
                    else
                    {
                        
                        
                        s.insert(tbName.Text, tbLocation.Text,tbPhone.Text,tbEmail.Text,cbDep.Text ,pic);
                        PL.fMessage f = new PL.fMessage("تمت الاضافة ");
                        f.ShowDialog();
                        this.Close();



                    }
                }


                else    //Edit

                {
                    MemoryStream m = new MemoryStream();
                    pbCover.Image.Save(m, ImageFormat.Png);
                    var pic = m.ToArray();
                    int result;



                    if (string.IsNullOrEmpty(tbName.Text) || string.IsNullOrEmpty(tbLocation.Text) || string.IsNullOrEmpty(cbDep.Text) || string.IsNullOrEmpty(tbPhone.Text))
                    {
                        MessageBox.Show("enter the values", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (!int.TryParse(tbPhone.Text, out result) || result < 0)
                    {
                        MessageBox.Show("enter a valid number phone", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    else
                    {


                        s.edit(ID,tbName.Text, tbLocation.Text, tbPhone.Text, tbEmail.Text, cbDep.Text, pic);
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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
