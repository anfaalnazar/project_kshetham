using project_kshetham.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace project_kshetham.repositories
{
    public class CounterRepository
    {
        string ConnectionString = @"Server=LAPTOP-8R2JSJSS\SQLEXPRESS01; Initial Catalog=temple_db; Integrated Security=SSPI;TrustServerCertificate=True;";

        public SqlConnection GetConnection()
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            return con;
        }
        public void insertcounter(Counter model)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "[SP_INSERTCOUNTER]";
            SqlParameter[] myparams = new SqlParameter[1];
            myparams[0] = new SqlParameter("@counters", System.Data.SqlDbType.NVarChar, 25);
            myparams[0].Value = model.counters;
            cmd.Parameters.Add(myparams[0]);
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    cmd.Connection = conn;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
        }
        public List<CounterVM> listcounter(int counter_code)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.CommandText = "SP_GETSINGLEORALLCOUNTERS";

            CounterVM model = new CounterVM();

            List<CounterVM> lstcounter = new List<CounterVM>();
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    cmd.Parameters.Add(new SqlParameter("@counter_code", SqlDbType.Int));
                    cmd.Parameters[0].Value = counter_code;
                    cmd.Connection = conn;
                    conn.Open();
                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {

                        while (rd.Read())
                        {
                            model.counter_code = Convert.ToInt32(rd["counter_code"]);
                            model.counters = rd["counters"].ToString();
                            lstcounter.Add(model);
                            model = new CounterVM();


                        }

                    }

                }
                return lstcounter;
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
            return lstcounter;
        }

        public void editcounter(Counter model)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "[SP_EDITCOUNTER]";
            SqlParameter[] myparams = new SqlParameter[2];
            myparams[0] = new SqlParameter("@counter_code", System.Data.SqlDbType.Int);
            myparams[0].Value = model.counter_code;
            cmd.Parameters.Add(myparams[0]);
            myparams[1] = new SqlParameter("@counters", System.Data.SqlDbType.NVarChar, 25);
            myparams[1].Value = model.counters;
            cmd.Parameters.Add(myparams[1]);
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    cmd.Connection = conn;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
        }
    }
}

