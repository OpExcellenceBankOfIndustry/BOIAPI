using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Oracle.ManagedDataAccess.Client;
using BOI.BOIApplications.Domain.Entities.RubikonBonitaIntegration;
using BOI.BOIApplications.Application.Contracts.Persistence.ErrorMessage;

namespace BOI.BOIApplications.Persistence.Repository.ErrorMessage
{
    public class ErrorMessageRepository : IErrorMessageRepository
    {
        public async Task<ErrorCodeDescriptionTable> GetErrorMessages(string errorCode, string connectionString)
        {
            string errorDescription = "";

            var error = new ErrorCodeDescriptionTable();

            var getErrorMessage = $"Select * from BoiLive.error_code_description_ref where ERROR_CODE like '%{errorCode}%'";

            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                error = connection.Query<ErrorCodeDescriptionTable>(getErrorMessage).ToList<ErrorCodeDescriptionTable>().FirstOrDefault();

                //errorDescription = error.Error_Desc;
            }

            return error;
        }
    }
}




