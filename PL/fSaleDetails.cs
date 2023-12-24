using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookShop_project.PL
{
    public partial class fSaleDetails : Form
    {
        BL.clsSell s = new BL.clsSell();
        public fSaleDetails(int ID,string name,string price,string date)
        {
            InitializeComponent();

            lbNStudent.Text = name;
            lbTotalPrice.Text = price;
            dtDate.Text = date;


            DataTable dt = new DataTable();
            dt=s.LoadSaledBook(ID);
            dgvSale.DataSource = dt;
        }

        private void fSaleDetails_Load(object sender, EventArgs e)
        {

        }

        private void pSale_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            printDocument1.Print();        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            // Calculate the aspect ratio of the panel
            float aspectRatio = (float)pSale.Width / pSale.Height;

            // Choose the maximum size based on the print document dimensions
            int maxWidth = e.PageBounds.Width; // You can replace this with your desired maximum width
            int maxHeight = e.PageBounds.Height; // You can replace this with your desired maximum height

            // Calculate the new size while maintaining the aspect ratio
            int newWidth = maxWidth;
            int newHeight = (int)(maxWidth / aspectRatio);

            if (newHeight > maxHeight)
            {
                newHeight = maxHeight;
                newWidth = (int)(maxHeight * aspectRatio);
            }

            // Create a bitmap with the new size
            Bitmap bmp = new Bitmap(newWidth, newHeight);

            // Draw the panel onto the bitmap
            pSale.DrawToBitmap(bmp, new Rectangle(0, 0, newWidth, newHeight));

            // Draw the captured image onto the print document
            e.Graphics.DrawImage(bmp, 0, 0);

            // Dispose of the bitmap
            bmp.Dispose();

        }


    }
}
