using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;

namespace QuanLyThietBiNhaBep.Function
{
    class ConnectSQL
    {
       /* String cnnString = ConfigurationManager.ConnectionStrings["db_qltbnb"].ConnectionString;
        SqlConnection cn = null;
        public ConnectSQL()
        {
            cn = new SqlConnection(cnnString);
        }
        public SqlConnection connect()
        {
            try
            {
                if (cn.State == ConnectionState.Closed)
                    cn.Open();
                return cn;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public SqlConnection disconnect()
        {
            try
            {
                if (cn.State == ConnectionState.Open)
                    cn.Close();
                return cn;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }*/
    }
}
