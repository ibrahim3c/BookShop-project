using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop_project.BL
{
    internal class clsUsers
    {
        DAL.claDal d = new DAL.claDal();
        public DataTable Load()
        {
            DataTable dt = new DataTable();
            dt = d.Read("spLoadUsers", null);

            return dt;
        }

        //insert
          public void insert(string name, string user, string password, string permission, string state, byte[] image)
        {
            
            SqlParameter[] par = new SqlParameter[6];
            par[0] = new SqlParameter("@name", name);
            par[1] = new SqlParameter("@user", user);
            par[2] = new SqlParameter("@password", password);
            par[3] = new SqlParameter("@permission", permission);
            par[4] = new SqlParameter("@state", state);
            par[5] = new SqlParameter("@image", image);



            d.Execute("spInsertUser", par);

        }


        // edit
        public void edit(int ID, string name, string user, string password, string permission, byte[] image)
        {

            SqlParameter[] par = new SqlParameter[6];
            par[0] = new SqlParameter("@name", name);
            par[1] = new SqlParameter("@user", user);
            par[2] = new SqlParameter("@password", password);
            par[3] = new SqlParameter("@permission", permission);
          //  par[4] = new SqlParameter("@state", state);
            par[4] = new SqlParameter("@image", image);
            par[5] = new SqlParameter("@ID", ID);
            d.Execute("spUpdateUser", par);

        }
        // delete
        public void delete(string ID)
        {
            SqlParameter[] par = new SqlParameter[1];

            par[0] = new SqlParameter("@ID", ID);
            d.Execute("spDeleteUser", par);

        }
        // load data for edit
        public DataTable LoadToEdit(int ID)
        {
            SqlParameter[] par = new SqlParameter[1];
            par[0] = new SqlParameter("ID", ID);
            DataTable dt = new DataTable();
            dt = d.Read("spSelectIditUser", par);

            return dt;
        }

        public DataTable search(string name)
        {
            DataTable dt = new DataTable();
            SqlParameter[] par = new SqlParameter[1];
            par[0] = new SqlParameter("@search", name);
            dt = d.Read("spUsersSearch", par);

            return dt;
        }

        public DataTable login(string user,string password)
        {
            DataTable dt = new DataTable();
            SqlParameter[] par = new SqlParameter[2];
            par[0] = new SqlParameter("@user", user);
            par[1] = new SqlParameter("@password", password);
            dt = d.Read("spLogin", par);

            return dt;
        }

        public DataTable loadtoComb()
        {
            DataTable dt = new DataTable();
            dt = d.Read("spLoadUserComboPermission", null);

            return dt;
        }
        public void logout()
        {
            d.Execute("spMakeStateLogout", null);

        }

        public void stateInLogin(string user,string password)
        {
            SqlParameter[] par = new SqlParameter[2];
            par[0] = new SqlParameter("@user", user);
            par[1] = new SqlParameter("@password", password);
            d.Execute("spMakeStateLogin", par);

        }


    }
   
}
