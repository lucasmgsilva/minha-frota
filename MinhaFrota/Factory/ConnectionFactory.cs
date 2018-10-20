using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trinity.Factory
{
    public class ConnectionFactory
    {
        public SqlConnection getConnection()
        {
            try
            {
                return new SqlConnection(ConfigurationManager.ConnectionStrings["Trinity.Properties.Settings.BD_SISTEMAConnectionString"].ToString());
            } catch (SqlException e)
            {
                throw e;
            }
        }

    }
}
