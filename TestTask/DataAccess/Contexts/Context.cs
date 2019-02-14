using System;
using System.Configuration;
using System.Web.Configuration;

namespace DataAccess
{
    static class Context
    {
        public static string ConnectionString()
        {
            Configuration rootWebConfig = WebConfigurationManager.OpenWebConfiguration("~/TestTask/Web.config");

            if (rootWebConfig.ConnectionStrings.ConnectionStrings.Count == 0)
            {
                throw new NullReferenceException();
            }

            string connectionString = rootWebConfig.ConnectionStrings.ConnectionStrings["DefaultConnection"].ConnectionString;

            if (connectionString == null)
            {
                throw new NullReferenceException();
            }

            return connectionString;
        }
    }
}
