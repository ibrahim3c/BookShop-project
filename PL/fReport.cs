using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookShop_project.PL
{
    public partial class fReport : Form
    {
        BL.clsCat cat = new BL.clsCat();

        // var for books
        BL.clsBooks b = new BL.clsBooks();

        // var for students
        BL.clsStudent s = new BL.clsStudent();

        // var for sell
        BL.clsSell se = new BL.clsSell();

        // var for borrow
        BL.clsBorrow bo = new BL.clsBorrow();

        // var for sell
        BL.clsUsers us = new BL.clsUsers();
        public fReport()
        {
            InitializeComponent();
        }

        private void lab_Click(object sender, EventArgs e)
        {

        }

        private void fReport_Load(object sender, EventArgs e)
        {
            try
            {

                lbNumOfBooks.Text = b.Load().Rows.Count.ToString();
                lbNumBorrowing.Text = bo.Load().Rows.Count.ToString();
                lbNumCategory.Text = cat.Load().Rows.Count.ToString();
                lbNumSelling.Text = se.Load().Rows.Count.ToString();
                lbNumUsers.Text = us.Load().Rows.Count.ToString();
                lbNumStudents.Text = s.Load().Rows.Count.ToString();


                PL.Form1 f = new PL.Form1();
                lbName.Text = f.lbUserName.Text;
                lbPermission.Text = f.lbPermission.Text;
                dtDate.Text = DateTime.Now.ToString();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            printDocument1.Print();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.ShowDialog();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            printDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
          
                // Capture the contents of the panel to be printed
                Bitmap bmp = new Bitmap(panel1.Width, panel1.Height);
                panel1.DrawToBitmap(bmp, new Rectangle(0, 0, panel1.Width, panel1.Height));

                // Draw the captured image onto the print document
                e.Graphics.DrawImage(bmp, 0, 0);

                // Dispose of the bitmap
                bmp.Dispose();
      

        }
    }
}
