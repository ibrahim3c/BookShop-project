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
    public partial class fBooks : Form
    {
        public int ID;
        public fBooks()
        {
            InitializeComponent();

           
        }
        public fBooks(int ID)
        {
            this.ID = ID;
            InitializeComponent();
            try
            {
                BL.clsBooks b = new BL.clsBooks();
                DataTable dt = new DataTable();
                dt = b.LoadToEdit(ID);
                object obj1 = dt.Rows[0]["title"];
                object obj2 = dt.Rows[0]["author"];
                object obj3 = dt.Rows[0]["category"];
                object obj4 = dt.Rows[0]["price"];
                object obj5 = dt.Rows[0]["date"];
                object obj6 = dt.Rows[0]["rate"];
                object obj7 = dt.Rows[0]["cover"];

                if (!string.IsNullOrEmpty(obj7.ToString()))
                {
                    byte[] pic = (byte[])obj7;
                    MemoryStream m = new MemoryStream(pic);
                    pbCover.Image = Image.FromStream(m);
                }
                cbCat.Text = obj3.ToString();
                tbNameAuthor.Text = obj2.ToString();
                
                tbNameBook.Text = obj1.ToString();
                tbPrice.Text = obj4.ToString();
                DateTime date = new DateTime();
                if (DateTime.TryParse(obj5.ToString(), out date))
                {
                    dtDate.Value = date;
                }
                float rate;
                if (float.TryParse(obj6.ToString(), out rate))
                {
                    RatingStars.Value = rate;
                }

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
            //try
            //{
            //    BL.clsBooks b = new BL.clsBooks();
            //    DataTable dt = new DataTable();
            //    dt = b.loadtoComb();
            //    object[] data = new object[dt.Rows.Count];
            //    for (int i = 0; i < dt.Rows.Count; i++)
            //    {
            //        data[i] = dt.Rows[i]["category"];

            //    }
            //    cbCat.Items.AddRange(data);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);

            //}


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
            PL.fAddCat f = new PL.fAddCat();
            f.ID = 0;





            f.ShowDialog();

            try
            {
                cbCat.Items.Clear();
                BL.clsBooks b = new BL.clsBooks();
                DataTable dt = new DataTable();
                dt = b.loadtoComb();
                object[] data = new object[dt.Rows.Count];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    data[i] = dt.Rows[i]["category"];

                }
                cbCat.Items.AddRange(data);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void fBooks_Activated(object sender, EventArgs e)
        {
            //try
            //{
            //    cbCat.Items.Clear();
            //    BL.clsBooks b = new BL.clsBooks();
            //    DataTable dt = new DataTable();
            //    dt = b.loadtoComb();
            //    object[] data = new object[dt.Rows.Count];
            //    for (int i = 0; i < dt.Rows.Count; i++)
            //    {
            //        data[i] = dt.Rows[i]["category"];

            //    }
            //    cbCat.Items.AddRange(data);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);

            //}


            try
            {
                cbCat.Items.Clear();
                BL.clsBooks b = new BL.clsBooks();
                DataTable dt = new DataTable();
                dt = b.loadtoComb();
                object[] data = new object[dt.Rows.Count];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    data[i] = dt.Rows[i]["category"];

                }
                cbCat.Items.AddRange(data);
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
               
                BL.clsBooks b = new BL.clsBooks();
                if (ID == 0) // ADD
                {

                    MemoryStream m = new MemoryStream();
                    pbCover.Image.Save(m, ImageFormat.Png);
                    var pic = m.ToArray();
                    float result;



                    if (string.IsNullOrEmpty(tbNameBook.Text)|| string.IsNullOrEmpty(tbNameAuthor.Text) || string.IsNullOrEmpty(cbCat.Text) || string.IsNullOrEmpty(tbPrice.Text))
                    {
                        MessageBox.Show("enter the values", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (!float.TryParse(tbPrice.Text, out result)||result<0)
                    {
                        MessageBox.Show("enter a valid price", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        
                    }
                    else
                    {
                        
                        
                        b.insert(tbNameBook.Text, cbCat.Text,tbPrice.Text ,dtDate.Value.ToShortDateString(), RatingStars.Value,pic,tbNameAuthor.Text);
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



                if (string.IsNullOrEmpty(tbNameBook.Text) || string.IsNullOrEmpty(tbNameAuthor.Text) || string.IsNullOrEmpty(cbCat.Text) || string.IsNullOrEmpty(tbPrice.Text))
                {
                    MessageBox.Show("enter the values", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (!int.TryParse(tbPrice.Text, out result) || result < 0)
                {
                    MessageBox.Show("enter a valid price", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {


                    b.edit(ID,tbNameBook.Text, cbCat.Text, tbPrice.Text, dtDate.Value.ToShortDateString(), RatingStars.Value, pic, tbNameAuthor.Text);
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

        private void tbNameAuthor_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbCat_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void tbPrice_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
