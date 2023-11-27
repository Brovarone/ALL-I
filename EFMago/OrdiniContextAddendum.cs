using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

namespace EFMago.Models
{
    public class OrdiniContextAddendum : OrdiniContext
    {
        private DbSet<ALLTMPInterventiFranchigie> ExampleStoredProc_Results { get; set; }
        public IEnumerable<ALLTMPInterventiFranchigie> RunExampleStoredProc(int firstId, out bool outputBit)
        {
            var outputBitParameter = new SqlParameter
            {
                ParameterName = "outputBit",
                SqlDbType = System.Data.SqlDbType.Bit,
                Direction = ParameterDirection.Output
            };

            SqlParameter[] parameters =
            {
        new SqlParameter("firstId", firstId),
        outputBitParameter
    };

            // Need to do a ToList to get the query to execute immediately 
            // so that we can get both the results and the output parameter.
            string sqlQuery = "Exec [ExampleStoredProc] @firstId, @outputBit OUTPUT";
            var results = ExampleStoredProc_Results.FromSqlRaw(sqlQuery, parameters);

            outputBit = outputBitParameter.Value as bool? ?? default(bool);

            return results;
        }
    }
};
