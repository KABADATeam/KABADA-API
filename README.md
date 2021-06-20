# Kabada_API
Project setup:
1. Create ConnectionStrings.cs file under KabadaAPI.DataSource -> Utilities
2. Enter the following content:
  public static class ConnectionStrings
  {
      // public static string SQLServer = @"Data Source=.\sqlexpress; Initial Catalog=KabadaDB; Integrated Security=SSPI;";
      // or
      public static string SQLServer = @"Data Source=localhost; Initial Catalog=KabadaDB; User Id=<user>; Password=<password>;";
  }

  
  #Database update
  dotnet-ef database update -s ..\KabadaAPI\KabadaAPI.csproj
