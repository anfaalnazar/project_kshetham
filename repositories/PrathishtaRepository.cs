using project_kshetham.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace project_kshetham.repositories
{
    public class PrathishtaRepository
    {
        string ConnectionString = @"Server=LAPTOP-8R2JSJSS\SQLEXPRESS01; Initial Catalog=temple_db; Integrated Security=SSPI;TrustServerCertificate=True;";



        public SqlConnection GetConnection()
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            return con;
        }
        public void insertprathishta(Prathishta model)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "[SP_INSERTPRATHISHTA]";
            SqlParameter[] myparams = new SqlParameter[1];
            myparams[0] = new SqlParameter("@prathishta_name", System.Data.SqlDbType.NVarChar, 50);
            myparams[0].Value = model.prathishta_name;
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
        public List<PrathishtaVM> lstprathishta(int prathishta_code)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.CommandText = "SP_GETSINGLEORALLPRATHISHTA";

            PrathishtaVM model = new PrathishtaVM();

            List<PrathishtaVM> lstprathishta = new List<PrathishtaVM>();
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    cmd.Parameters.Add(new SqlParameter("@prathishta_code", SqlDbType.Int));
                    cmd.Parameters[0].Value = prathishta_code;
                    cmd.Connection = conn;
                    conn.Open();
                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {

                        while (rd.Read())
                        {
                            model.prathishta_code = Convert.ToInt32(rd["prathishta_code"]);
                            model.prathishta_name = rd["prathishta_name"].ToString();
                            lstprathishta.Add(model);
                            model = new PrathishtaVM();


                        }

                    }

                }
                return lstprathishta;
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
            return lstprathishta;
        }
        public void editprathishta(Prathishta model)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "[SP_EDITPRATHISHTA]";
            SqlParameter[] myparams = new SqlParameter[2];
            myparams[0] = new SqlParameter("@prathishta_code", System.Data.SqlDbType.Int);
            myparams[0].Value = model.prathishta_code;
            cmd.Parameters.Add(myparams[0]);
            myparams[1] = new SqlParameter("@prathishta_name",System.Data.SqlDbType.NVarChar, 50);
            myparams[1].Value = model.prathishta_name;
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
    

