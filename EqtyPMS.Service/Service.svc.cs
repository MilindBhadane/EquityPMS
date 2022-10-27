using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using EqtyPMS.DAL;
using System.Data;

namespace EqtyPMS.Service
{
    public class Service : IService
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public DataSet GetSQLData(string query)
        {
            DataSet dataset = new DataSet();
            try
            {
                DBConnector dbConnector = new DBConnector();
                dataset = dbConnector.GetSQLData(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                
            }
            return dataset;
        }

        public bool ExecuteSQLData(string query)
        {
            bool retval = false;
            try
            {
                DBConnector dbConnector = new DBConnector();
                retval = dbConnector.ExecuteNonQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                
            }
            return retval;
        }

        public bool InsertTransactionData(string cmdText, int quantity, string securityCode, string operation, string side)
        {
            bool retval = false;
            try
            {
                DBConnector dbConnector = new DBConnector();
                retval = dbConnector.InsertTransactionData(cmdText, quantity, securityCode, operation, side);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
            return retval;
        }


    }
}
