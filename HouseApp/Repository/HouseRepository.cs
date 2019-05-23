using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace HouseApp.Repository
{
    public class HouseRepository
    {
        public static DataSet ReadData(string SQL)
        {
            DataSet ds = new DataSet();
            string connect = "Server=localhost;Database=house;Uid=root;Pwd=;";
            MySqlConnection conn = new MySqlConnection(connect);
            //conn.ConnectionString = connect;

            try
            {
                conn.Open();
                MySqlDataAdapter dap = new MySqlDataAdapter(SQL, conn);
                dap.Fill(ds);
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
            finally
            {
                conn.Close();
            }

            

            return ds;
        }

        public static int GetId(string SQL)
        {
            int result = 0;
            DataSet ds = new DataSet();
            string connect = "Server=localhost;Database=house;Uid=root;Pwd=;";
            MySqlConnection conn = new MySqlConnection(connect);
            //conn.ConnectionString = connect;

            try
            {
                conn.Open();
                MySqlDataAdapter dap = new MySqlDataAdapter(SQL, conn);
                dap.Fill(ds);
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
            finally
            {
                conn.Close();
            }

            if(ds.Tables[0].Rows.Count > 0)
            {
                result = int.Parse(ds.Tables[0].Rows[0][0].ToString());
            }

            return result;
        }

    }
}