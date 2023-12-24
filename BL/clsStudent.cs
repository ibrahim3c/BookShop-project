using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Security.Cryptography;
using System.Xml.Linq;

namespace BookShop_project.BL
{
    internal class clsStudent
    {
        DAL.claDal d = new DAL.claDal();
        public DataTable Load()
        {
            DataTable dt = new DataTable();
            dt = d.Read("loadStudents", null);

            return dt;
        }

        //insert
        public void insert(string name, string loc, string phone, string email, string dep, byte[] cover)
        {
           
            SqlParameter[] par = new SqlParameter[6];
            par[0] = new SqlParameter("@name", name);
            par[1] = new SqlParameter("@slocation", loc);
            par[2] = new SqlParameter("@phone", phone);
            par[3] = new SqlParameter("@email", email);
            par[5] = new SqlParameter("@cover", cover);
            par[4] = new SqlParameter("@dep", dep);


            d.Execute("spInsertStudent", par);

        }


        // edit
        public void edit(int ID, string name, string loc, string phone, string email, string dep, byte[] cover)
        {

            SqlParameter[] par = new SqlParameter[7];
            par[0] = new SqlParameter("@name", name);
            par[1] = new SqlParameter("@slocation", loc);
            par[2] = new SqlParameter("@phone", phone);
            par[3] = new SqlParameter("@email", email);
            par[5] = new SqlParameter("@cover", cover);
            par[4] = new SqlParameter("@dep", dep);
            par[6] = new SqlParameter("@ID", ID);
            d.Execute("spUpdateStudent", par);

            }
        // delete
        public void delete(string ID)
        {
            SqlParameter[] par = new SqlParameter[1];

            par[0] = new SqlParameter("@ID", ID);
            d.Execute("spDeleteStudent", par);

        }
        // load data for edit
        public DataTable LoadToEdit(int ID)
        {
            SqlParameter[] par = new SqlParameter[1];
            par[0] = new SqlParameter("@ID", ID);
            DataTable dt = new DataTable();
            dt = d.Read("spSelectIditStudent", par);

            return dt;
        }

        public DataTable search(string name)
        {
            DataTable dt = new DataTable();
            SqlParameter[] par = new SqlParameter[1];
            par[0] = new SqlParameter("@search", name);
            dt = d.Read("spStudentsSearch", par);

            return dt;
        }

        public DataTable loadtoComb()
        {
            DataTable dt = new DataTable();
            dt = d.Read("spLoadStudentComboCat", null);

            return dt;
        }

        public DataTable loadtoComb2()
        {
            DataTable dt = new DataTable();
            dt = d.Read("loadStateToCombo", null);

            return dt;
        }
    }
}
