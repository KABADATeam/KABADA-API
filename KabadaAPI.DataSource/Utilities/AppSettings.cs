using Microsoft.Extensions.Configuration;

namespace KabadaAPI.DataSource.Utilities {
  public class AppSettings {
    protected IConfiguration config;

    public AppSettings(IConfiguration configuration) { config=configuration; }

    protected string getS(string key, string defaultValue=null){
      if(config==null)
        return defaultValue;
      var r=config.GetValue<string>(key);
      if(string.IsNullOrEmpty(r))
        return defaultValue;
      return r;
      }

    protected int getI(string key, int defaultValue=0){
      if(config==null)
        return defaultValue;
       var r=config.GetValue<int>(key);
      if(r!=0 || r==defaultValue)
        return r;
      var t=getS(key);
      if(t==null)
        return defaultValue;
      return r;
      }

    public string connectionString { get {
      return getS("ConnectionStrings:DefaultConnection", @"Server=(localdb)\mssqllocaldb;Database=kabada-test;Trusted_Connection=True;MultipleActiveResultSets=true");
      }}

    public string connectionProvider { get {
      return getS("ConnectionStrings:DefaultConnectionProvider", "MS");
      }}

    public string smtpHost { get {
      return getS("Smtp:Host", "smtp.gmail.com");
      }}

    public int smtpPort { get {
      return getI("Smtp:Port", 587);
      }}

    public string smtpUsername { get {
      return getS("Smtp:Username", EmailAccount.UserName);
      }}

    public string smtpPassword { get {
      return getS("Smtp:Password", EmailAccount.Password);
      }}

    public bool useTLS { get {
      var t=getS("Smtp:Security", "Full");
      return (t=="TLS");
      }}
    }
  }
