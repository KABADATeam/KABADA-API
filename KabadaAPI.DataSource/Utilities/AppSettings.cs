using Microsoft.Extensions.Configuration;

namespace KabadaAPI.DataSource.Utilities {
  public class AppSettings {
    protected IConfiguration config;

    public AppSettings(IConfiguration configuration) { config=configuration; }

    protected string getS(string key, string defaultValue=null){
      var r=config.GetValue<string>(key);
      if(string.IsNullOrEmpty(r))
        return defaultValue;
      return r;
      }

    public string connectionString { get {
      return getS("ConnectionStrings:DefaultConnection", @"Server=(localdb)\mssqllocaldb;Database=kabada-test;Trusted_Connection=True;MultipleActiveResultSets=true");
      }}
    }
  }
