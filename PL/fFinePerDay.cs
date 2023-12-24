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
    public partial class FinePerDay: Form
    {

        BL.clsBorrow bo = new BL.clsBorrow();
        public FinePerDay()
        {
            InitializeComponent();
           
        }
       

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(float.TryParse(tbFine.Text,out float result))
            {

                bo.editFinePerDay(result);
               PL.fMessage f = new PL.fMessage("تم التعديل بنجاح  ");
                f.ShowDialog();
                this.Close();
            }
            else
            {
               MessageBox.Show("enter a valid amount", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
