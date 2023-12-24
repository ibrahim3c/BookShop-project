using BookShop_project.BL;
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
    public partial class fBorrow: Form
    {
        public int ID;
        public fBorrow()
        {
            InitializeComponent();


            BL.clsBorrow bo = new BL.clsBorrow();
           


            // load comboboxes
            DataTable dt1 = new DataTable();
            dt1 = bo.loadtoComb("books");
            object[] data = new object[dt1.Rows.Count];
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                data[i] = dt1.Rows[i]["title"];

            }
            DataTable dt2 = new DataTable();
            dt2 = bo.loadtoComb("students");
            object[] data2 = new object[dt2.Rows.Count];
            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                data2[i] = dt2.Rows[i]["name"];

            }
            cbBook.Items.AddRange(data);
            cbStudent.Items.AddRange(data2);
        }
        public fBorrow(int ID)
        {
            this.ID = ID;
            InitializeComponent();
            try
            {
                BL.clsBorrow bo = new BL.clsBorrow();
                DataTable dt = new DataTable();
                dt = bo.LoadToEdit(ID);

                // load for dates
                if (DateTime.TryParse(dt.Rows[0]["Start_Date"].ToString(), out DateTime Sdate))
                {
                    dtSDate.Value = Sdate;
                }
                if (DateTime.TryParse(dt.Rows[0]["End_Date"].ToString(), out DateTime Edate))
                {
                    dtEDate.Value = Edate;
                }

                // load comboboxes
                DataTable dt1 = new DataTable();
                dt1 = bo.loadtoComb("books");
                object[] data = new object[dt1.Rows.Count];
                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    data[i] = dt1.Rows[i]["title"];

                }
                DataTable dt2 = new DataTable();
                dt2 = bo.loadtoComb("students");
                object[] data2 = new object[dt2.Rows.Count];
                for (int i = 0; i < dt2.Rows.Count; i++)
                {
                    data2[i] = dt2.Rows[i]["name"];

                }
                cbBook.Items.AddRange(data);
                cbStudent.Items.AddRange(data2);

                //select the book and student in combo
                cbBook.SelectedIndex = cbBook.FindString(dt.Rows[0]["book"].ToString());

                cbStudent.SelectedIndex = cbStudent.FindString(dt.Rows[0]["student"].ToString());




               
                lbPrice.Text = dt.Rows[0]["price"].ToString();
               
               

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
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

      

        private void fBooks_Activated(object sender, EventArgs e)
        { 
            try
            {
                //cbBook.Items.Clear();
                //cbStudent.Items.Clear();
                //BL.clsSell se = new BL.clsSell();
                //DataTable dt1 = new DataTable();
                //dt1 = se.loadtoComb("books");
                //object[] data = new object[dt1.Rows.Count];
                //for (int i = 0; i < dt1.Rows.Count; i++)
                //{
                //    data[i] = dt1.Rows[i]["title"];

                //}
                //DataTable dt2 = new DataTable();
                //dt2 = se.loadtoComb("students");
                //object[] data2 = new object[dt2.Rows.Count];
                //for (int i = 0; i < dt2.Rows.Count; i++)
                //{
                //    data2[i] = dt2.Rows[i]["name"];

                //}
                //cbBook.Items.AddRange(data);
                //cbStudent.Items.AddRange(data2);

                //dtDate.Text = DateTime.Now.ToString();
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
               
                BL.clsBorrow bo = new BL.clsBorrow();
                if (ID == 0) // ADD
                {

                   


                    if (string.IsNullOrEmpty(lbNBook.Text)|| string.IsNullOrEmpty(lbNStudent.Text) || string.IsNullOrEmpty(lbPrice.Text)) { 
                        MessageBox.Show("enter the values", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                   
                    else
                    {
                        
                        
                        bo.insert(lbNBook.Text, lbNStudent.Text ,dtSDate.Value.ToShortDateString(), dtEDate.Value.ToShortDateString(), lbPrice.Text);
                        PL.fMessage f = new PL.fMessage("تمت الاضافة ");
                        f.ShowDialog();
                        this.Close();



                    }
                }


                else    //Edit

                {



                    if (string.IsNullOrEmpty(lbNBook.Text) || string.IsNullOrEmpty(lbNStudent.Text) || string.IsNullOrEmpty(lbPrice.Text))
                    {   
                        MessageBox.Show("enter the values", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    else
                    {


                        bo.edit(ID, lbNBook.Text, lbNStudent.Text, dtSDate.Value.ToShortDateString(), dtEDate.Value.ToShortDateString(), lbPrice.Text);
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

        private void cbCat_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbNBook.Text = cbBook.Text;
            clsSell se = new clsSell();
            if (!string.IsNullOrEmpty(lbNBook.Text)){
                lbPrice.Text = se.getPrice(lbNBook.Text); 
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void dtDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cbStudent_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbNStudent.Text = cbStudent.Text;

        }

        private void lbPrice_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PL.fStudent s = new PL.fStudent();
            //f.ID = 0;
            s.ShowDialog();

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PL.fBooks f = new PL.fBooks();
            //f.ID = 0;
            f.ShowDialog();
        }
    }
}
