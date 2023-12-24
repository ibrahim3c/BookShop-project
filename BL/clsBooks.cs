using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
namespace BookShop_project.BL
{
    internal class clsBooks
    {

        // DAL.clsCat dal = new DAL.clsCat();
        DAL.claDal d = new DAL.claDal();
        public DataTable Load()
        {
            DataTable dt = new DataTable();
            dt = d.Read("spLoadTobooks", null);

            return dt;
        }

        //insert
        public void insert(string title, string cat, string price, string Stringdate, float rate, byte[] cover, string author)
        {
            if (!DateTime.TryParse(Stringdate, out DateTime date))
            {
                // Handle invalid date input here, throw an exception or log an error

            }
            SqlParameter[] par = new SqlParameter[7];
            par[0] = new SqlParameter("@Title", title);
            par[1] = new SqlParameter("@cat", cat);
            par[2] = new SqlParameter("@price", price);
            par[3] = new SqlParameter("@date", date);
            par[4] = new SqlParameter("@rate", rate);
            par[5] = new SqlParameter("@cover", cover);
            par[6] = new SqlParameter("@author", author);


            d.Execute("spInsertBooks", par);

        }


        // edit
        public void edit( int ID,string title, string cat, string price, string Stringdate, float rate, byte[] cover, string author)
        {
            if (!DateTime.TryParse(Stringdate, out DateTime date))
            {
                // Handle invalid date input here, throw an exception or log an error

            }
            SqlParameter[] par = new SqlParameter[8];
            par[1] = new SqlParameter("@Title", title);
            par[2] = new SqlParameter("@cat", cat);
            par[3] = new SqlParameter("@price", price);
            par[4] = new SqlParameter("@date", date);
            par[5] = new SqlParameter("@rate", rate);
            par[6] = new SqlParameter("@cover", cover);
            par[7] = new SqlParameter("@author", author);
            par[0] = new SqlParameter("@ID", ID);
            d.Execute("spUpdate", par);

        }
        // delete
        public void delete(string ID)
        {
            SqlParameter[] par = new SqlParameter[1];

            par[0] = new SqlParameter("@ID", ID);
            d.Execute("spDeletebook", par);

        }
        // load data for edit
        public DataTable LoadToEdit(int ID)
        {
            SqlParameter[] par = new SqlParameter[1];
            par[0] = new SqlParameter("ID", ID);
            DataTable dt = new DataTable();
           dt=d.Read("spSelectIdit", par);

            return dt;
        }

        public DataTable search(string name)
        {
            DataTable dt = new DataTable();
            SqlParameter[] par = new SqlParameter[1];
            par[0] = new SqlParameter("@search", name);
            dt = d.Read("spBooksSearch", par);

            return dt;
        }

        // load cat to combobox of booksform
        public DataTable loadtoComb()
        {
            DataTable dt = new DataTable();
            dt = d.Read("spLoadComboCat", null);

            return dt;
        }
      
    }
}
