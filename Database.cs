using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace UareUSampleCSharp
{
    class Database
    {
        protected bool beginTransaction;
        protected SqlTransaction sqlTrans;
        protected SqlConnection connection;
        protected String str = "Data Source=DESKTOP-AOLSR2L\\SQLEXPRESS;Initial Catalog=persona;Integrated Security=True";

        public Database()
        {
            connection = new SqlConnection(this.str);
        }

        public DataTable getPerson(int iPersonID)
        {
            DataTable dt = new DataTable();
            try
            {
                OpenConnection(false);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetPerson";
                cmd.Parameters.AddWithValue("@iPersonID", iPersonID);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                CloseConnection();
            }

            return dt;
        }

        public DataTable getPersonLessData(int iPersonID)
        {
            DataTable dt = new DataTable();
            try
            {
                OpenConnection(false);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetPersonLessData";
                cmd.Parameters.AddWithValue("@iPersonID", iPersonID);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                CloseConnection();
            }

            return dt;
        }

        public DataTable getPersons()
        {
            DataTable dt = new DataTable();
            try
            {
                OpenConnection(false);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetPersons";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                CloseConnection();
            }

            return dt;
        }

        public int insertData(string name, string guardian, string cnic, string phone, string address, string notes, string right_thumb, string imgName, byte[] imgFile)
        {
            int rows = 0;
            try
            {
                OpenConnection(false);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsertPerson";
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@guardian", guardian);
                cmd.Parameters.AddWithValue("@cnic", cnic);
                cmd.Parameters.AddWithValue("@phone", phone);
                cmd.Parameters.AddWithValue("@address", address);
                cmd.Parameters.AddWithValue("@notes", notes);
                cmd.Parameters.AddWithValue("@right_thumb", right_thumb);
                cmd.Parameters.AddWithValue("@image_name", imgName);
                cmd.Parameters.AddWithValue("@image_file", imgFile);
                rows = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                CloseConnection();
            }

            return rows;
        }

        public DataTable searchPerson(string name, string cnic, string phone)
        {
            DataTable dt = new DataTable();
            try
            {
                OpenConnection(false);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "FindPerson";
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@cnic", cnic);
                cmd.Parameters.AddWithValue("@phone", phone);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                CloseConnection();
            }

            return dt;
        }

        public DataTable getFingerPrints()
        {
            DataTable dt = new DataTable();
            try
            {
                OpenConnection(false);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetFingerPrints";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                CloseConnection();
            }

            return dt;
        }


        #region Connection/Transaction

        public bool BeginTransaction
        {
            get { return beginTransaction; }
        }
        public void OpenConnection(bool enableTrn)
        {
            try
            {
                beginTransaction = enableTrn;
                if (connection.State != ConnectionState.Open)
                {
                    connection.ConnectionString = str;
                    connection.Open();

                    if (beginTransaction == true)
                    {
                        sqlTrans = connection.BeginTransaction();
                    }
                }
                else if (connection.State == ConnectionState.Open)
                {
                    if (sqlTrans != null && sqlTrans.Connection == null && beginTransaction == true)
                    {
                        sqlTrans = connection.BeginTransaction();
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("Unable to connect to the Database due to " + e.ToString());
            }
        }
        public void OpenConnection()
        {
            try
            {
                if (connection == null)
                    connection = new SqlConnection(str);

                if (connection.State != ConnectionState.Open)
                {
                    connection.ConnectionString = str;
                    connection.Open();

                    if (beginTransaction == true)
                    {
                        sqlTrans = connection.BeginTransaction();
                    }
                }
                else if (connection.State == ConnectionState.Open)
                {
                    if (sqlTrans != null && sqlTrans.Connection == null && beginTransaction == true)
                    {
                        sqlTrans = connection.BeginTransaction();
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("Unable to connect to the Database due to " + e.ToString());
            }
        }
        public void CloseConnection()
        {
            if (connection != null && connection.State != ConnectionState.Closed && beginTransaction == false)
            {
                connection.Close();
            }
        }
        public void CommitTransaction()
        {
            if (connection != null && connection.State != ConnectionState.Closed && beginTransaction == true)
            {
                if (sqlTrans != null && sqlTrans.Connection != null)
                {
                    sqlTrans.Commit();
                    sqlTrans = null;
                    beginTransaction = false;
                }
                connection.Close();
            }
        }
        public void RollbackTransaction()
        {
            if (connection != null && connection.State != ConnectionState.Closed && beginTransaction == true)
            {
                if (sqlTrans != null && sqlTrans.Connection != null)
                {
                    sqlTrans.Rollback();
                    sqlTrans = null;
                    beginTransaction = false;
                }
                connection.Close();
            }
        }

        #endregion
    }
}