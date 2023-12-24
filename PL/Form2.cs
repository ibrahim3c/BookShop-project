using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;

namespace BookShop_project.PL
{
    public partial class fAddCat : Form
    {
        public int ID;
        public string dep;
        public fAddCat()
        {
            InitializeComponent();
        }
        public fAddCat(string dep)
        {

            this.dep = "dep";
            this.ID = 1000;
           
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // do not forger the cases

            try
            {
                BL.clsCat c = new BL.clsCat();
                if (ID == 0) // ADD
                {

                    if (string.IsNullOrEmpty(tbAddCat.Text))
                    {
                        MessageBox.Show("enter the values", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        c.insert(tbAddCat.Text);
                        PL.fMessage f = new PL.fMessage("تمت الاضافة ");
                        f.ShowDialog();
                        this.Close();



                    }
                }



                else    //Edit

                {

                    if (dep == "dep") // add Dep
                    {

                        if (string.IsNullOrEmpty(tbAddCat.Text))
                        {
                            MessageBox.Show("enter the values", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            c.insertDep(tbAddCat.Text);
                            PL.fMessage f = new PL.fMessage("تم التعديل بنجاح ");
                            f.ShowDialog();
                            this.Close();



                        }
                    }
                    else {
                        if (string.IsNullOrEmpty(tbAddCat.Text))
                        {
                            MessageBox.Show("enter the values", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            c.edit(tbAddCat.Text, ID);
                            PL.fMessage f = new PL.fMessage("تم التعديل بنجاح");
                            f.ShowDialog();
                            this.Close();



                        }

                    } }
               
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
           

        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fAddCat_Load(object sender, EventArgs e)
        {

        }

        private void lbTitle_Click(object sender, EventArgs e)
        {

        }
    }
}
