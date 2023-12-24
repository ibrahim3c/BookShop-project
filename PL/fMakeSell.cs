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
    public partial class fMakeSell : Form
    {
        public int ID;
        double totalPrice = 0;
        public fMakeSell()
        {
            InitializeComponent();


            BL.clsSell se = new BL.clsSell();
            DataTable dt = new DataTable();
            dt = se.LoadToEdit(ID);

            // load comboboxes
            DataTable dt1 = new DataTable();
            dt1 = se.loadtoComb("books");
            object[] data = new object[dt1.Rows.Count];
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                data[i] = dt1.Rows[i]["title"];

            }
            DataTable dt2 = new DataTable();
            dt2 = se.loadtoComb("students");
            object[] data2 = new object[dt2.Rows.Count];
            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                data2[i] = dt2.Rows[i]["name"];

            }
            cbBook.Items.AddRange(data);
            cbStudent.Items.AddRange(data2);
        }
        public fMakeSell(int ID)
        {
            this.ID = ID;
            InitializeComponent();
            try
            {
                BL.clsSell se = new BL.clsSell();
                DataTable dt = new DataTable();
                dt = se.LoadToEdit(ID);
                
                // load comboboxes
                DataTable dt1 = new DataTable();
                dt1 = se.loadtoComb("books");
                object[] data = new object[dt1.Rows.Count];
                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    data[i] = dt1.Rows[i]["title"];

                }
                DataTable dt2 = new DataTable();
                dt2 = se.loadtoComb("students");
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




                object obj5 = dt.Rows[0]["date"];
                lbPrice.Text = dt.Rows[0]["price"].ToString();
                DateTime date = new DateTime();
                if (DateTime.TryParse(obj5.ToString(), out date))
                {
                    dtDate.Value = date;
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
            cbBook.SelectedIndex = cbBook.StartIndex;
            cbStudent.SelectedIndex = cbStudent.StartIndex;


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
               
                BL.clsSell se = new BL.clsSell();
                if (ID == 0) // ADD
                {




                    if (string.IsNullOrEmpty(lbNStudent.Text) || string.IsNullOrEmpty(lbPrice.Text))
                    {
                        MessageBox.Show("enter the values", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    else
                    {


                        //se.insert("lbNBook.Text", lbNStudent.Text ,dtDate.Value.ToShortDateString(),lbPrice.Text);
                        int SaleID=se.insert(lbNStudent.Text, dtDate.Value.ToShortDateString(), lbTotalPrice.Text);

                        foreach (DataGridViewRow row in dgvSale.Rows)
                        {
                            string book = row.Cells["book"].Value?.ToString();
                            int quantity;
                            bool isQuantityValid = int.TryParse(row.Cells["quantity"].Value?.ToString(), out quantity);
                            string price = row.Cells["price"].Value?.ToString();

                            if (isQuantityValid)
                            {
                                // Assuming you have a method to insert a single sale row
                                se.insertSale(book, quantity.ToString(), price, SaleID);
                            }
                            else
                            {
                                MessageBox.Show("there is no data to add");
                            }
                        }






                        // Add the row to the DataTable

                        PL.fMessage f = new PL.fMessage("تمت الاضافة ");
                            f.ShowDialog();
                            this.Close();



                       
                    }
                }


                else    //Edit

                {



                    if (string.IsNullOrEmpty("lbNBook.Text") || string.IsNullOrEmpty(lbNStudent.Text) || string.IsNullOrEmpty(lbPrice.Text))
                    {
                        MessageBox.Show("enter the values", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    else
                    {


                        se.edit(ID, "lbNBook.Text", lbNStudent.Text, dtDate.Value.ToShortDateString(), lbPrice.Text);
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
            //lbNBook.Text = cbBook.Text;
            clsSell se = new clsSell();
            if (!string.IsNullOrEmpty(cbBook.Text)){
                lbPrice.Text = se.getPrice(cbBook.Text); 
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void dtDate_ValueChanged(object sender, EventArgs e)
        {

        }
        string customer = "";
        string customer2 = "";
        private void cbStudent_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbNStudent.Text == "??"||string.IsNullOrEmpty(lbNStudent.Text))
            {
                customer = lbNStudent.Text = cbStudent.Text;
            }
            else
            {
                customer2 = cbStudent.Text;

                if (!(customer == customer2))
                {
                    if (MessageBox.Show("are u sure ?", "confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                    {
                        dgvSale.Rows.Clear();

                        // reset
                        //cbBook.SelectedIndex = cbBook.StartIndex;
                        //cbStudent.SelectedIndex = cbStudent.StartIndex;

                        lbNStudent.Text = cbStudent.Text;
                        lbTotalPrice.Text = "??";
                        tbQuantity.Text = "";
                        lbPrice.Text = "??";
                    }
                }
            }



        }

        private void lbNBook_Click(object sender, EventArgs e)
        {

        }

        private void dgvSale_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            cbBook.SelectedIndex = cbBook.StartIndex;
            cbStudent.SelectedIndex = cbStudent.StartIndex;
            tbQuantity.Text = "";
            lbPrice.Text = "??";
           
        }

        private void btnBorowBook_Click(object sender, EventArgs e)
        {

            double resultPrice=0;
           

            if (string.IsNullOrEmpty(lbPrice.Text) || string.IsNullOrEmpty(tbQuantity.Text) || string.IsNullOrEmpty(cbBook.Text))
            {
                MessageBox.Show("enter the data", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {


                if (!int.TryParse(tbQuantity.Text, out int quantity))
                {

                   
                    MessageBox.Show("enter a valid value", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
               else {
                    double.TryParse(lbPrice.Text, out double price);
                    resultPrice = quantity * price;
                    totalPrice += resultPrice;


                    dgvSale.Rows.Add(resultPrice.ToString(), tbQuantity.Text, cbBook.Text);


                      cbBook.SelectedIndex = cbBook.StartIndex;
                      //cbStudent.SelectedIndex = cbStudent.StartIndex;
                      tbQuantity.Text = "";
                      lbPrice.Text = "??";
                    //lbNStudent.Text = "??";
                  
                
                    lbTotalPrice.Text = totalPrice.ToString();
                    resultPrice = 0;


                }

                

            }
        }
    }
}
