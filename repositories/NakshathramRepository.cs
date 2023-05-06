using project_kshetham.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace project_kshetham.repositories
{
    public class NakshathramRepository
    {
        string ConnectionString = @"Server=LAPTOP-8R2JSJSS\SQLEXPRESS01; Initial Catalog=temple_db; Integrated Security=SSPI;TrustServerCertificate=True;";

        public SqlConnection GetConnection()
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            return con;
        }
        public void insertnakshathram(Nakshathram model)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "[SP_INSERTNAKSHATHRAM]";
            SqlParameter[] myparams = new SqlParameter[1];
            myparams[0] = new SqlParameter("@nakshathram_name", System.Data.SqlDbType.NVarChar, 50);
            myparams[0].Value = model.nakshathram_name;
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
        public List<NakshathramVM> lstnakshathram(int nakshathram_code)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.CommandText = "SP_GETSINGLEORALLNAKSHATHRAM";

            NakshathramVM model = new NakshathramVM();

            List<NakshathramVM> lstnakshathram = new List<NakshathramVM>();
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    cmd.Parameters.Add(new SqlParameter("@nakshathram_code", SqlDbType.Int));
                    cmd.Parameters[0].Value = nakshathram_code;
                    cmd.Connection = conn;
                    conn.Open();
                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {

                        while (rd.Read())
                        {
                            model.nakshathram_code = Convert.ToInt32(rd["nakshathram_code"]);
                            model.nakshathram_name = rd["nakshathram_name"].ToString();
                            lstnakshathram.Add(model);
                            model = new NakshathramVM();


                        }

                    }

                }
                return lstnakshathram;
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
            return lstnakshathram;
        }

        public void editnakshathram(Nakshathram model)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "[SP_EDITNAKSHATHRAM]";
            SqlParameter[] myparams = new SqlParameter[2];
            myparams[0] = new SqlParameter("@nakshathram_code", System.Data.SqlDbType.Int);
            myparams[0].Value = model.nakshathram_code;
            cmd.Parameters.Add(myparams[0]);
            myparams[1] = new SqlParameter("@nakshathram_name", System.Data.SqlDbType.NVarChar, 50);
            myparams[1].Value = model.nakshathram_name;
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
