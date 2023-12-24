using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace BookShop_project.BL
{
    internal class clsSell
    {

        
        DAL.claDal d = new DAL.claDal();
        public DataTable Load()
        {
            DataTable dt = new DataTable();
            dt = d.Read("spLoadSell", null);

            return dt;
        }

        public DataTable LoadSaledBook(int ID)
        {
            DataTable dt = new DataTable();
            SqlParameter[] par = new SqlParameter[1];
            par[0] = new SqlParameter("@ID", ID);
            dt = d.Read("sploadSaledBook", par);

            return dt;
        }
        public DataTable Load2()
        {
            DataTable dt = new DataTable();
            dt = d.Read("spLoadSell2", null);

            return dt;
        }

        //insert
        public void insert(string nameBook, string nameStudent, string Stringdate ,string price)
        {
            if (!DateTime.TryParse(Stringdate, out DateTime date))
            {
                // Handle invalid date input here, throw an exception or log an error

            }
            SqlParameter[] par = new SqlParameter[4];
            par[0] = new SqlParameter("@nameBook", nameBook);
            par[1] = new SqlParameter("@nameStudent", nameStudent);
            par[2] = new SqlParameter("@price", price);
            par[3] = new SqlParameter("@date", date);
           


            d.Execute("spInsertSell", par);

        }
        public int insert( string nameStudent, string Stringdate, string price)
        {
            if (!DateTime.TryParse(Stringdate, out DateTime date))
            {
                // Handle invalid date input here, throw an exception or log an error

            }
            SqlParameter[] par = new SqlParameter[3];
           
            par[0] = new SqlParameter("@nameStudent", nameStudent);
            par[1] = new SqlParameter("@price", price);
            par[2] = new SqlParameter("@date", date);



           // d.Execute("spInsertSell2", par);

             object ID=d.readScaler("spInsertSell2", par);
            if(int.TryParse(ID.ToString(),out int result))
            {
                return result;

            }
            else
            {
                return -1;
            }

        }
        

        public void insertSale(string book, string quantity, string price,int saleID)
        {
           
            SqlParameter[] par = new SqlParameter[4];

            par[0] = new SqlParameter("@book", book);
            par[1] = new SqlParameter("@price", price);
            par[2] = new SqlParameter("@quantity", quantity);
            par[3] = new SqlParameter("@SaleID", saleID);



            d.Execute("InsertSaleBook", par);

        }


        // edit
        public void edit(int ID, string book, string student, string Stringdate, string price)
        {
            
            if (!DateTime.TryParse(Stringdate, out DateTime date))
            {
                // Handle invalid date input here, throw an exception or log an error

            }
            SqlParameter[] par = new SqlParameter[5];
            par[0] = new SqlParameter("@ID", ID);
            par[1] = new SqlParameter("@book", book);
            par[2] = new SqlParameter("@price", price);
            par[3] = new SqlParameter("@date", date);
            par[4] = new SqlParameter("@student", student);
           
            d.Execute("spUpdateSell", par);

        }


        public void edit2(int ID, string student, string Stringdate)
        {

            if (!DateTime.TryParse(Stringdate, out DateTime date))
            {
                // Handle invalid date input here, throw an exception or log an error

            }
            SqlParameter[] par = new SqlParameter[3];
            par[0] = new SqlParameter("@ID", ID);
            par[1] = new SqlParameter("@date", date);
            par[2] = new SqlParameter("@student", student);

            d.Execute("spUpdateSell2", par);

        }
        // delete
        public void delete(string ID)
        {
            SqlParameter[] par = new SqlParameter[1];

            par[0] = new SqlParameter("@ID", ID);
            d.Execute("spDeleteSell", par);
           // d.Execute("spDeleteSaledBook", par);

        }
        // load data for edit
        public DataTable LoadToEdit(int ID)
        {
            SqlParameter[] par = new SqlParameter[1];
            par[0] = new SqlParameter("@ID", ID);
            DataTable dt = new DataTable();
            dt = d.Read("spSelectIditSell", par);

            return dt;
        }
        public DataTable LoadToEdit2(int ID)
        {
            SqlParameter[] par = new SqlParameter[1];
            par[0] = new SqlParameter("@ID", ID);
            DataTable dt = new DataTable();
            dt = d.Read("spSelectIditSell2", par);

            return dt;
        }

        public DataTable search(string name)
        {
            DataTable dt = new DataTable();
            SqlParameter[] par = new SqlParameter[1];
            par[0] = new SqlParameter("@search", name);
            dt = d.Read("spSellSearch", par);

            return dt;
        }

        public DataTable search2(string name)
        {
            DataTable dt = new DataTable();
            SqlParameter[] par = new SqlParameter[1];
            par[0] = new SqlParameter("@search", name);
            dt = d.Read("spSellSearch2", par);

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
           object result= d.readScaler("spGetPrice", par);
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
