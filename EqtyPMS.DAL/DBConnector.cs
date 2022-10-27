using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;

namespace EqtyPMS.DAL
{
    public class DBConnector
    {
        readonly string strEqtyPMSConnString = Properties.Settings.Default.ConnectionString;

        public DataSet GetSQLData(string query)
        {
            DataSet dataset = new DataSet();
            SqlConnection connection = new SqlConnection(strEqtyPMSConnString);
            try
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.Fill(dataset);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection != null && connection.State != ConnectionState.Closed)
                {
                    connection.Close();
                }
            }
            return dataset;
        }

        public bool ExecuteNonQuery(string cmdText)
        {
            bool retValue = false;
            SqlConnection connection = new SqlConnection(strEqtyPMSConnString);
            try
            {
                connection.Open();

                SqlCommand command = new SqlCommand(cmdText, connection);
                command.ExecuteNonQuery();
                retValue = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection != null && connection.State != ConnectionState.Closed)
                {
                    connection.Close();
                }
            }
            return retValue;
        }

        public bool InsertTransactionData(string cmdText, int quantity, string securityCode, string operation, string side)
        {
            bool retValue = false;
            SqlConnection connection = new SqlConnection(strEqtyPMSConnString);
            try
            {
                connection.Open();

                SqlCommand command = new SqlCommand(cmdText, connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@Quantity", quantity));
                command.Parameters.Add(new SqlParameter("@SecurityCode", securityCode));
                command.Parameters.Add(new SqlParameter("@Operation", operation));
                command.Parameters.Add(new SqlParameter("@Side", side));

                command.ExecuteNonQuery();
                retValue = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection != null && connection.State != ConnectionState.Closed)
                {
                    connection.Close();
                }
            }
            return retValue;
        }
    }
}
