using System;

namespace KabadaAPI.DataSource.Utilities
{
    public static class ConnectionStrings
    {
        //public static string SQLServer = @"Data Source=localhost; Initial Catalog=KabadaDB; User Id=<userName>; Password=<password>;";
        public static string SQLServer = @"Data Source=.\sqlserver; Initial Catalog=KabadaDB; Integrated Security=SSPI;";
    }
}
