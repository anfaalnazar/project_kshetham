using project_kshetham.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace project_kshetham.repositories
{
    public class UnitRepository
    {
        string ConnectionString = @"Server=LAPTOP-8R2JSJSS\SQLEXPRESS01; Initial Catalog=temple_db; Integrated Security=SSPI;TrustServerCertificate=True;";



        public SqlConnection GetConnection()
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            return con;
        }

        public void insertunit(unit model)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "[SP_INSERTUNIT]";
            SqlParameter[] myparams = new SqlParameter[1];
            myparams[0] = new SqlParameter("@unitname", System.Data.SqlDbType.NVarChar, 50);
            myparams[0].Value = model.unitname;
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
        public List<unitVM> lstunit(int unitcode)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.CommandText = "SP_GETSINGLEORALLUNIT";

            unitVM model = new unitVM();

            List<unitVM> lstunit = new List<unitVM>();
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    cmd.Parameters.Add(new SqlParameter("@unitcode", SqlDbType.Int));
                    cmd.Parameters[0].Value = unitcode;
                    cmd.Connection = conn;
                    conn.Open();
                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {

                        while (rd.Read())
                        {
                            model.unitcode = Convert.ToInt32(rd["unitcode"]);
                            model.unitname = rd["unitname"].ToString();
                            lstunit.Add(model);
                            model = new unitVM();


                        }

                    }

                }
                return lstunit;
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
            return lstunit;
        }
        public void editunit(unit model)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "[SP_EDITUNIT]";
            SqlParameter[] myparams = new SqlParameter[2];
            myparams[0] = new SqlParameter("@unitcode", System.Data.SqlDbType.Int);
            myparams[0].Value = model.unitcode;
            cmd.Parameters.Add(myparams[0]);
            myparams[1] = new SqlParameter("@unitname", System.Data.SqlDbType.NVarChar, 50);
            myparams[1].Value = model.unitname;
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
