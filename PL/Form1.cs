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
using System.Xml.Linq;

namespace BookShop_project.PL
{
    public partial class Form1 : Form
    {
        string state;


       
         public int ID;
        // var for cat
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

        //public float finePerDay = FinePerDay.fine;


        private void CustomButton(string state)
        {

            if (state != "fine")
            {
                btnAdd.Visible = true;
                btnDelete.Visible = true;
                btnDetails.Visible = true;
                btnEdit.Visible = true;
                btnEditFine.Visible = false;





            }
            else
            {

                if (state == "fine")
                {
                    btnAdd.Visible = false;
                    btnDelete.Visible = false;
                    btnDetails.Visible = false;
                    btnEdit.Visible = false;
                    btnEditFine.Visible = true;



                }
            }

        }
        public Form1()
        {
            InitializeComponent();
        }

        private void pHome_Paint(object sender, PaintEventArgs e)
        {


        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void guna2ImageButton2_Click(object sender, EventArgs e)
        {
            //if (this.WindowState == FormWindowState.Normal)
            //{
            //    this.WindowState = FormWindowState.Minimized;
            //}
            //else
            //{
            //    this.WindowState = FormWindowState.Normal;

            //}
             this.WindowState = FormWindowState.Minimized;

        }

        private void guna2ImageButton3_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;

            }
        }

        private void guna2ImageButton5_Click(object sender, EventArgs e)
        {

        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            pMain.Visible = false;
            pHome.Visible = true;
            pDashBoard.Visible = false;

            lbTitle.Text = "Home";


           
        }

        private void guna2ImageButton5_Click_1(object sender, EventArgs e)
        {
            if(pMainBar.Size.Width==168)
            {
                pMainBar.Width = 45;
                pbUser.Visible = false;
                btnSidePanel.Location = new Point(3, 3);


                // hiding the data
                lbPermission.Visible = false;
                lbUserName.Visible = false;



                btnBook.RightToLeft = RightToLeft.No;
                btnBorrow.RightToLeft = RightToLeft.No;
                btnHome.RightToLeft = RightToLeft.No;
                btnSelling.RightToLeft = RightToLeft.No;
                btnStudents.RightToLeft = RightToLeft.No;
                btnUsers.RightToLeft = RightToLeft.No;
                btnDashboard.RightToLeft = RightToLeft.No;
                btnFine.RightToLeft = RightToLeft.No;

            }
            else
            {
                pMainBar.Width = 168;
                pbUser.Visible = true;

                btnSidePanel.Location = new Point(126, 3);



                // show the data
                lbPermission.Visible = true;
                lbUserName.Visible = true;


                //btnBook.RightToLeft = RightToLeft.Yes;
                //btnBorrow.RightToLeft = RightToLeft.Yes;
                //btnHome.RightToLeft = RightToLeft.Yes;
                //btnSelling.RightToLeft = RightToLeft.Yes;
                //btnStudents.RightToLeft = RightToLeft.Yes;
                //btnUsers.RightToLeft = RightToLeft.Yes;
                //btnDashboard.RightToLeft = RightToLeft.Yes;
                //btnFine.RightToLeft = RightToLeft.Yes;




                btnBook.ImageAlign = ContentAlignment.MiddleLeft;
                btnBorrow.ImageAlign = ContentAlignment.MiddleLeft;
                btnHome.ImageAlign = ContentAlignment.MiddleLeft;
                btnSelling.ImageAlign = ContentAlignment.MiddleLeft;
                btnStudents.ImageAlign = ContentAlignment.MiddleLeft;
                btnUsers.ImageAlign = ContentAlignment.MiddleLeft;
                btnDashboard.ImageAlign = ContentAlignment.MiddleLeft;
                btnFine.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            pHome.Visible = false;
            pMain.Visible = true;
            pDashBoard.Visible = false;

            state = "sell";
            lbTitle.Text = "Selling";
            CustomButton(state);





            // load data
            try
            {


                DataTable dt = new DataTable();
                // dt = se.Load();
                 dt = se.Load2();
                dataGridView1.DataSource = dt;
                //dataGridView1.Columns[6].Visible = false;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pHome.Visible = false;
            pMain.Visible = true;
            pDashBoard.Visible = false;

            state = "students";
            lbTitle.Text = "Customers";
            CustomButton(state);





            // load data
            try
            {


                DataTable dt = new DataTable();
                dt = s.Load();
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[6].Visible = false;
               

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            pHome.Visible = false;
            pMain.Visible = false;
            pDashBoard.Visible = true;
            state = "dashboard";
            lbTitle.Text = "DashBoard";

            CustomButton(state);





            // load data
            try
            {

                lbNumOfBooks.Text = b.Load().Rows.Count.ToString();
                lbNumBorrowing.Text = bo.Load().Rows.Count.ToString();
                lbNumCategory.Text = cat.Load().Rows.Count.ToString();
                lbNumSelling.Text = se.Load().Rows.Count.ToString();
                lbNumUsers.Text = us.Load().Rows.Count.ToString();
                lbNumStudents.Text = s.Load().Rows.Count.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pMain.Visible = false;
            pHome.Visible = true;
            pDashBoard.Visible = false;

            lbTitle.Text = "Home";
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {

            if (state == "cat")
            {
                // load data
                try
                {

                    //BL.clsCat c = new BL.clsCat();
                    DataTable dt = new DataTable();
                    dt = cat.search(tbSearch.Text.ToString());
                    dataGridView1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }

            else if (state == "books")
            {
                // load data
                try
                {

                    //BL.clsCat c = new BL.clsCat();
                    DataTable dt = new DataTable();
                    dt = b.search(tbSearch.Text.ToString());
                    dataGridView1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }


            else if (state == "students")
            {
                // load data
                try
                {

                    //BL.clsCat c = new BL.clsCat();
                    DataTable dt = new DataTable();
                    dt = s.search(tbSearch.Text.ToString());
                    dataGridView1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }
            else if (state == "sell")
            {
                // load data
                try
                {

                    //BL.clsCat c = new BL.clsCat();
                    DataTable dt = new DataTable();
                    dt = se.search2(tbSearch.Text.ToString());
                    dataGridView1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }

            else if (state == "borrow")
            {
                // load data
                try
                {

                    //BL.clsCat c = new BL.clsCat();
                    DataTable dt = new DataTable();
                    dt = bo.search(tbSearch.Text.ToString());
                    dataGridView1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }


            else if (state == "user")
            {
                // load data
                try
                {

                    //BL.clsCat c = new BL.clsCat();
                    DataTable dt = new DataTable();
                    dt = us.search(tbSearch.Text.ToString());
                    dataGridView1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }


            else if (state == "fine")
            {
                // load data
                try
                {

                    //BL.clsCat c = new BL.clsCat();
                    DataTable dt = new DataTable();
                    dt = bo.searchFine(tbSearch.Text.ToString());
                    dataGridView1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (state == "cat")
            {
                PL.fAddCat f = new PL.fAddCat();
                f.ID = 0;
                f.ShowDialog();
            }

            //Add books
           else if (state == "books")
            {
                PL.fBooks f = new PL.fBooks();
                //f.ID = 0;
                f.ShowDialog();
            }
            //Add student
            else if (state == "students")
            {
                PL.fStudent s = new PL.fStudent();
                //f.ID = 0;
                s.ShowDialog();
            }
            //Add student
            else if (state == "sell")
            {
                PL.fMakeSell se = new PL.fMakeSell();
                //f.ID = 0;
                se.ShowDialog();
            }
           else if (state == "borrow")
            {
                PL.fBorrow bo = new PL.fBorrow();
                //f.ID = 0;
                bo.ShowDialog();
            }

            else if (state == "user")
            {
                PL.fUsers us = new PL.fUsers();
                //f.ID = 0;
                us.ShowDialog();
            }
        }


        private void Form1_Activated(object sender, EventArgs e)
        {

            if (lbPermission.Text != "Manager")
            {
                btnUsers.Enabled = false;

            }
            if (state == "cat")
            {
                // load data
                try
                {

                    //BL.clsCat c = new BL.clsCat();
                    DataTable dt = new DataTable();
                    dt = cat.Load();
                    dataGridView1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }

            else if (state == "books")
            {
                 
                try
                {


                    DataTable dt = new DataTable();
                    dt = b.Load();
                    dataGridView1.DataSource = dt;
                   

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }




            else if (state == "students")
            {

                try
                {


                    DataTable dt = new DataTable();
                    dt = s.Load();
                    dataGridView1.DataSource = dt;


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }


            else if (state == "sell")
            {

                try
                {

                    DataTable dt = new DataTable();
                    dt = se.Load2();
                    dataGridView1.DataSource = dt;


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }

            else if (state == "borrow")
            {

                try
                {

                    DataTable dt = new DataTable();
                    dt = bo.Load();
                    dataGridView1.DataSource = dt;


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }


            else if (state == "user")
            {

                try
                {

                    DataTable dt = new DataTable();
                    dt = us.Load();
                    dataGridView1.DataSource = dt;


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }


            else if (state == "fine")
            {

                try
                {

                    DataTable dt = new DataTable();
                    dt = bo.LoadFine();
                    dataGridView1.DataSource = dt;


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }
            else if (state == "dashboard")
            {
                // load data
                try
                {

                    lbNumOfBooks.Text = b.Load().Rows.Count.ToString();
                    lbNumBorrowing.Text = bo.Load().Rows.Count.ToString();
                    lbNumCategory.Text = cat.Load().Rows.Count.ToString();
                    lbNumSelling.Text = se.Load().Rows.Count.ToString();
                    lbNumUsers.Text = us.Load().Rows.Count.ToString();
                    lbNumStudents.Text = s.Load().Rows.Count.ToString();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (state == "cat")
            {
                
                try
                {

                    fAddCat a = new fAddCat();
                    a.btnAdd.Text = "Edit";
                    a.tbAddCat.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    a.ID = (int)dataGridView1.CurrentRow.Cells[0].Value;
                    a.ShowDialog();

                   
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }
            else if (state == "books")
            {
                try
                {
                    int id = (int)dataGridView1.CurrentRow.Cells[0].Value;
                    fBooks B = new fBooks(id);

                    
                    B.btnAdd.Text = "Edit";
                    
                    B.ID= (int)dataGridView1.CurrentRow.Cells[0].Value;
                    B.ShowDialog();



                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }

            }



            else if (state == "students")
            {
                try
                {
                    int id = (int)dataGridView1.CurrentRow.Cells[0].Value;
                    fStudent s = new fStudent(id);


                    s.btnAdd.Text = "Edit";

                    s.ID = (int)dataGridView1.CurrentRow.Cells[0].Value;
                    s.ShowDialog();



                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }

            }
            else if (state == "sell")
            {

                try
                {

                    //fMakeSell se = new fMakeSell((int)dataGridView1.CurrentRow.Cells[0].Value);
                    //se.btnAdd.Text = "Edit";

                    fEditSale f = new fEditSale((int)dataGridView1.CurrentRow.Cells[0].Value);
                   
                   
                    f.ShowDialog();


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }

            else if (state == "borrow")
            {

                try
                {

                    fBorrow bo = new fBorrow((int)dataGridView1.CurrentRow.Cells[0].Value);
                    bo.btnAdd.Text = "Edit";


                    bo.ShowDialog();


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }

            else if (state == "user")
            {

                try
                {

                    fUsers us = new fUsers((int)dataGridView1.CurrentRow.Cells[0].Value);
                    us.btnAdd.Text = "Edit";


                    us.ShowDialog();


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }


            else if (state == "fine")
            {

                try
                {
                    PL.FinePerDay f = new FinePerDay();
                    f.ShowDialog();
                   


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                string id = dataGridView1.CurrentRow.Cells[0].Value.ToString();

                if (MessageBox.Show("are u sure ?", "confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {
                    if (state == "cat")
                    {

                        try
                        {
                            cat.delete(id);

                            PL.fMessage f = new PL.fMessage("تم الحذف بنجاح");
                            f.ShowDialog();


                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);

                        }
                    }
                    else if (state == "books")
                    {

                        b.delete(id);
                        PL.fMessage f = new PL.fMessage("تم الحذف بنجاح");
                        f.ShowDialog();

                    }

                    else if (state == "students")
                    {

                        s.delete(id);
                        PL.fMessage f = new PL.fMessage("تم الحذف بنجاح");
                        f.ShowDialog();

                    }

                    else if (state == "sell")
                    {

                        se.delete(id);
                        PL.fMessage f = new PL.fMessage("تم الحذف بنجاح");
                        f.ShowDialog();

                    }
                    else if (state == "borrow")
                    {

                        bo.delete(id);
                        PL.fMessage f = new PL.fMessage("تم الحذف بنجاح");
                        f.ShowDialog();

                    }
                    else if (state == "user")
                    {

                        us.delete(id);
                        PL.fMessage f = new PL.fMessage("تم الحذف بنجاح");
                        f.ShowDialog();

                    }
                }
            }
        }
        private void btnBook_Click(object sender, EventArgs e)
        {
            pHome.Visible = false;
            pMain.Visible = true;
            pDashBoard.Visible = false;

            state = "books";
            lbTitle.Text = "Books";

            CustomButton(state);





            // load data
            try
            {

               
                DataTable dt = new DataTable();
                dt = b.Load();
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[7].Visible = false;
                dataGridView1.Columns[6].Visible = false;
                dataGridView1.Columns[5].Visible = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (state == "books")
            {
                if (dataGridView1.Rows.Count > 0)
                { // from byte[] to image
                 if (!string.IsNullOrEmpty(dataGridView1.CurrentRow.Cells[7].Value.ToString()))
                    {
                        byte[] pic = (byte[])dataGridView1.CurrentRow.Cells[7].Value;
                        MemoryStream m = new MemoryStream(pic);
                        Image picCode = Image.FromStream(m);

                        Form image = new fImageShow(picCode);
                        image.ShowDialog();
                    }
                }
            }
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            if (state == "books")
            {
                try
                {
                    int id = (int)dataGridView1.CurrentRow.Cells[0].Value;
                    bookDetails B = new bookDetails(id);


                    B.ShowDialog();



                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }


            else if (state == "students")
            {
                int id = (int)dataGridView1.CurrentRow.Cells[0].Value;
                try

                { 
                   
                    studentDetails sd = new studentDetails(id);
                    



                    BL.clsStudent s = new BL.clsStudent();
                    DataTable dt = new DataTable();
                    dt = s.LoadToEdit(id);
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
                        sd.pbCover.Image = Image.FromStream(m);
                    }
                    sd.lbDep.Text = obj3.ToString();
                    sd.lbLocation.Text = obj2.ToString();
                    
                    sd.lbName.Text = obj1.ToString();
                    sd.lbPhone.Text = obj4.ToString();
                    sd.lbEmail.Text = obj5.ToString();


                    sd.ShowDialog();



                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }
            else if (state == "user")
            {
                try
                {
                    int id = (int)dataGridView1.CurrentRow.Cells[0].Value;
                    fUserDetail us = new fUserDetail(id);


                    us.ShowDialog();



                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }

            else if (state == "sell")
            {
                try
                {
                    int id = (int)dataGridView1.CurrentRow.Cells[0].Value;

                    string student= dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    string totalPrice= dataGridView1.CurrentRow.Cells[3].Value.ToString();
                    string date= dataGridView1.CurrentRow.Cells[2].Value.ToString();
                    fSaleDetails sd = new fSaleDetails(id,student,totalPrice,date);


                    sd.ShowDialog();



                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }
        }

        private void btnBorrow_Click(object sender, EventArgs e)
        {
            pHome.Visible = false;
            pMain.Visible = true;
            state = "borrow";
            lbTitle.Text = "Borrowing";
            pDashBoard.Visible = false;

            CustomButton(state);






            // load data
            try
            {


                DataTable dt = new DataTable();
                dt = bo.Load();
                dataGridView1.DataSource = dt;
                //dataGridView1.Columns[6].Visible = false;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            pHome.Visible = false;
            pMain.Visible = true;
            pDashBoard.Visible = false;

            state = "user";
            lbTitle.Text = "Users";

            CustomButton(state);




            // load data
            try
            {


                DataTable dt = new DataTable();
                dt = us.Load();
                dataGridView1.DataSource = dt;
               


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2ImageButton4_Click(object sender, EventArgs e)
        {
            try
            {
                fLogin f = new fLogin();
                us.logout();
                this.Hide();
                f.ShowDialog();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void pbUser_Click(object sender, EventArgs e)
        {
            fImageShow f = new fImageShow(pbUser.Image);
            f.lbTitle.Text = "";
            f.ShowDialog();
        }

        private void guna2ImageButton5_Click_2(object sender, EventArgs e)
        {
            fAboutUs f = new fAboutUs();
            f.ShowDialog();
        }

        private void pDashBoard_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            fReport f = new fReport();
            f.ShowDialog();
        }

        private void btnBorowBook_Click(object sender, EventArgs e)
        {
            fBorrow f = new fBorrow();
            f.ShowDialog();
        }

        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            fStudent f = new fStudent();
            f.ShowDialog();
        }

        private void btnAddBook_Click(object sender, EventArgs e)
        {
            fBooks f = new fBooks();
            f.ShowDialog();
        }

        private void btnSellBook_Click(object sender, EventArgs e)
        {
            fMakeSell f = new fMakeSell();
            f.ShowDialog();
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            fAddCat f = new fAddCat();
            f.ShowDialog();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            pHome.Visible = false;
            pMain.Visible = true;
            state = "fine";
            lbTitle.Text = "Fines";
            pDashBoard.Visible = false;

            CustomButton(state);










            // load data
            try
            {


                DataTable dt = new DataTable();
                dt = bo.LoadFine();
                dataGridView1.DataSource = dt;
                //dataGridView1.Columns[6].Visible = false;
               


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void pMainBar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnEditFine_Click(object sender, EventArgs e)
        {
            try
            {
                PL.FinePerDay f = new FinePerDay();
                f.ShowDialog();



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void guna2HtmlToolTip1_Popup(object sender, PopupEventArgs e)
        {

        }
    }
}
