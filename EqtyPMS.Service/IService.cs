using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data;

namespace EqtyPMS.Service
{
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        string GetData(int value);

        [OperationContract]
        bool ExecuteSQLData(string query);


        [OperationContract]
        bool InsertTransactionData(string cmdText, int quantity, string securityCode, string operation, string side);

        [OperationContract]
        DataSet GetSQLData(string query);

    }
}
