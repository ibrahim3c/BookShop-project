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
    public partial class bookDetails : Form
    {
        public int ID;
        public bookDetails(int ID)
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
                lbCat.Text = obj3.ToString();
                lbAuthorName.Text = obj2.ToString();

                lbTitle.Text = obj1.ToString();
                lbPrice.Text = obj4.ToString();
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

        private void bookDetails_Load(object sender, EventArgs e)
        {

        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
