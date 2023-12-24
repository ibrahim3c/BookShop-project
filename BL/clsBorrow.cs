using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace BookShop_project.BL
{
    internal class clsBorrow
    {


        DAL.claDal d = new DAL.claDal();
        public DataTable Load()
        {
            DataTable dt = new DataTable();
            dt = d.Read("spLoadBorrow", null);

            return dt;
        }

        public DataTable LoadFine()
        {

            DataTable dt = new DataTable();
          
            dt = d.Read("spLoadFine", null);

            return dt;
        }




        //insert
        public void insert(string nameBook, string nameStudent, string Stringdate,string EndDate, string price)
        {
            if (!DateTime.TryParse(Stringdate, out DateTime date))
            {
                // Handle invalid date input here, throw an exception or log an error

            }

            if (!DateTime.TryParse(EndDate, out DateTime eDate))
            {
                // Handle invalid date input here, throw an exception or log an error

            }
            
            SqlParameter[] par = new SqlParameter[5];
            par[0] = new SqlParameter("@nameBook", nameBook);
            par[1] = new SqlParameter("@nameStudent", nameStudent);
            par[2] = new SqlParameter("@price", price);
            par[3] = new SqlParameter("@Sdate", date);
            par[4] = new SqlParameter("@Edate", eDate);



            d.Execute("spInsertBorrow", par);

        }


        // edit
        public void edit(int ID, string book, string student, string Stringdate,string EDate, string price)
        {

            if (!DateTime.TryParse(Stringdate, out DateTime date))
            {
                // Handle invalid date input here, throw an exception or log an error

            }
            if (!DateTime.TryParse(EDate, out DateTime eDate))
            {
                // Handle invalid date input here, throw an exception or log an error

            }
            SqlParameter[] par = new SqlParameter[6];
            par[0] = new SqlParameter("@ID", ID);
            par[1] = new SqlParameter("@book", book);
            par[2] = new SqlParameter("@price", price);
            par[3] = new SqlParameter("@Sdate", date);
            par[4] = new SqlParameter("@Edate", eDate);
            par[5] = new SqlParameter("@student", student);

            d.Execute("spUpdateBorrow", par);

        }
        // delete
        public void delete(string ID)
        {
            SqlParameter[] par = new SqlParameter[1];

            par[0] = new SqlParameter("@ID", ID);
            d.Execute("spDeleteBorrow", par);

        }
        // load data for edit
        public DataTable LoadToEdit(int ID)
        {
            SqlParameter[] par = new SqlParameter[1];
            par[0] = new SqlParameter("@ID", ID);
            DataTable dt = new DataTable();
            dt = d.Read("spSelectEditBorrow", par);

            return dt;
        }

        public DataTable search(string name)
        {
            DataTable dt = new DataTable();
            SqlParameter[] par = new SqlParameter[1];
            par[0] = new SqlParameter("@search", name);
            dt = d.Read("spBorrowSearch", par);

            return dt;
        }


        public DataTable searchFine(string name)
        {
            DataTable dt = new DataTable();
            SqlParameter[] par = new SqlParameter[1];
            par[0] = new SqlParameter("@search", name);
            dt = d.Read("spFineSearch", par);

            return dt;
        }



        public DataTable editFinePerDay(float FinePerDay)
        {
            DataTable dt = new DataTable();
            SqlParameter[] par = new SqlParameter[1];
            par[0] = new SqlParameter("@FinePerDay", FinePerDay);
            dt = d.Read("spFinePerDay", par);

            return dt;
        }

        // load cat to combobox of booksform
        public DataTable loadtoComb(string type)
        {
            DataTable dt = new DataTable();

            if (type == "books")
            {
                dt = d.Read("spLoadComboBook", null);
            }
            else
            {

                dt = d.Read("spLoadComboStudent", null);

            }

            return dt;
        }
        public string getPrice(string book)
        {
            DataTable dt = new DataTable();
            SqlParameter[] par = new SqlParameter[1];
            par[0] = new SqlParameter("@title", book);
            object result = d.readScaler("spGetPrice", par);
            if (result != null)
            {
                return result.ToString();
            }
            else
            {
                return "nope";
            }


        }
    }
}
