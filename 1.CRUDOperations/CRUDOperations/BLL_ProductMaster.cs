using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace CRUDOperations
{
    public class BLL_ProductMaster
    {
        public static string ConnectionString()
        {
            string cstr;
            cstr = ConfigurationManager.ConnectionStrings["myConnectionstring"].ConnectionString;
            return cstr;
        }

        public static SqlConnection sqlConnectionstring()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConnectionString();
            return conn;
        }

        public DataTable GetProductData(int ProductID)
        {
            SqlConnection connection = null;
            SqlCommand command = null;
            SqlDataAdapter sqlDA = null;
            DataTable dtProducts = null;

            using (connection = sqlConnectionstring())
            {
                command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "USP_GetData_ProductMaster";
                command.Parameters.Add("@ProductID", SqlDbType.Int).Value = ProductID;
                sqlDA = new SqlDataAdapter(command);
                dtProducts = new DataTable();
                sqlDA.Fill(dtProducts);
            }
            return dtProducts;
        }

        public string Insert_Update_Product(int ProductID, string ProductCode, string ProductName, int Qty, decimal Price, string Remarks)
        {
            string message = string.Empty;
            SqlConnection connection = null;
            SqlCommand command = null;
                        
            using (connection = sqlConnectionstring())
            {
                command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "USP_CREATE_UPDATE_PRODUCTS";
                command.Parameters.Add("@ProductID", SqlDbType.Int).Value = ProductID;
                command.Parameters.Add("@ProductCode", SqlDbType.VarChar).Value = ProductCode;
                command.Parameters.Add("@ProductName", SqlDbType.VarChar).Value = ProductName;
                command.Parameters.Add("@Qty", SqlDbType.Int).Value = Qty;
                command.Parameters.Add("@Price", SqlDbType.Decimal).Value = Price;
                command.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = Remarks;
                command.Parameters.Add("@message", SqlDbType.VarChar, 250).Direction = ParameterDirection.Output;
                connection.Open();
                command.ExecuteNonQuery();
                message = command.Parameters["@message"].Value.ToString();
                connection.Close();
            }
            return message;
        }

        public string Delete_Product(int ProductID)
        {
            string message = string.Empty;
            SqlConnection connection = null;
            SqlCommand command = null;

            using (connection = sqlConnectionstring())
            {
                command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "USP_DELETE_PRODUCTS";
                command.Parameters.Add("@ProductID", SqlDbType.Int).Value = ProductID;                
                command.Parameters.Add("@message", SqlDbType.VarChar, 250).Direction = ParameterDirection.Output;
                connection.Open();
                command.ExecuteNonQuery();
                message = command.Parameters["@message"].Value.ToString();
                connection.Close();
            }
            return message;
        }
    }
}