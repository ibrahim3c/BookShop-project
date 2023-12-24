using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookShop_project.PL
{
    public partial class fEditSale : Form
    {
         int ID;
        BL.clsSell se = new BL.clsSell();

        public fEditSale(int ID)
        {
            this.ID = ID;
            InitializeComponent();


            DataTable dt = new DataTable();
            dt = se.LoadToEdit2(ID);

            // load comboboxes
           
            DataTable dt2 = new DataTable();
            dt2 = se.loadtoComb("students");
            object[] data2 = new object[dt2.Rows.Count];
            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                data2[i] = dt2.Rows[i]["name"];

            }
           
            cbStudent.Items.AddRange(data2);

            //select the book and student in combo

           
            cbStudent.SelectedIndex = cbStudent.FindString(dt.Rows[0]["student"].ToString());

            object obj5 = dt.Rows[0]["student"].ToString();


            if (DateTime.TryParse(obj5.ToString(), out DateTime date))
            {
                dtDate.Value = date;
            }
            
        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fEditSale_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

            if ( string.IsNullOrEmpty(cbStudent.Text) || string.IsNullOrEmpty(dtDate.Text))
            {
                MessageBox.Show("enter the values", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {


                se.edit2(ID, cbStudent.Text, dtDate.Value.ToShortDateString());
                PL.fMessage f = new PL.fMessage("تم التعديل بنجاح ");
                f.ShowDialog();
                this.Close();


            }
        }
    }
}
