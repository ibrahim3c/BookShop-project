using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace BookShop_project.BL
{
    internal class clsCat
    {
        // DAL.clsCat dal = new DAL.clsCat();
        DAL.claDal d = new DAL.claDal();
        public DataTable Load()
        {
            DataTable dt = new DataTable();
           dt= d.Read("spLoadData2", null);

            return dt;
        }

        // insert
        public void insert(string Cat_Name)
        {
            SqlParameter[] par = new SqlParameter[1];
            par[0] = new SqlParameter("@name", Cat_Name);
         
            d.Execute("AddCat", par);

        }
        public void insertDep(string depName)
        {
            SqlParameter[] par = new SqlParameter[1];
            par[0] = new SqlParameter("@name", depName);

            d.Execute("AddDep", par);

        }

        // edit
        public void edit(string Cat_Name,int ID)
        {
            SqlParameter[] par = new SqlParameter[2];
            par[0] = new SqlParameter("@name", Cat_Name);
            par[1] = new SqlParameter("@ID", ID);
            d.Execute("spEditCat", par);

        }
         // delete
        public void delete(string ID)
        {
            SqlParameter[] par = new SqlParameter[1];
         
            par[0] = new SqlParameter("@ID", ID);
            d.Execute("spDelete", par);

        }


        public DataTable search(string name)
        {
            DataTable dt = new DataTable();
            SqlParameter[] par = new SqlParameter[1];
            par[0] = new SqlParameter("@search", name);
            dt = d.Read("spSearch", par);

            return dt;
        }




    }
}
