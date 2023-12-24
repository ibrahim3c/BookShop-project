using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BookShop_project.DAL
{
    internal class claDal
    {
        // Define a global variable to store the connection string
        // private static readonly string ConnectionString = "server=.;database=bookShop; user id=sa;password=ibrahimhany1020";
        private static readonly string ConnectionString = ConfigurationManager.AppSettings["conectionString"];

        public DataTable Read(string proc, SqlParameter[] par)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(proc, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (par != null)
                    {
                        cmd.Parameters.AddRange(par);
                    }
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        public SqlDataReader Read2(string proc, SqlParameter[] par)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(proc, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (par != null)
                    {
                        cmd.Parameters.AddRange(par);
                    }
                    SqlDataReader dr = cmd.ExecuteReader();
                    return dr;
                }
            }
        }

        // Insert, edit, or delete
        public void Execute(string proc, SqlParameter[] par)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(proc, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (par != null)
                    {
                        cmd.Parameters.AddRange(par);
                    }
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public object readScaler(string proc, SqlParameter[] par)
        {
            object obj = new object();
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(proc, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (par != null)
                    {
                        cmd.Parameters.AddRange(par);
                    }
                    obj = cmd.ExecuteScalar();
                }
            }
            return obj;
        }
    }
}
