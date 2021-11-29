using Microsoft.Extensions.Configuration;
using System;

namespace KabadaAPI {
  public class AppSettings {
    public IConfiguration config { get; protected set; }

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

    protected TimeSpan? getD(string key, TimeSpan? defaultValue=null){
      if(config==null)
        return defaultValue;
      var w=config.GetValue<string>(key);
      if(string.IsNullOrWhiteSpace(w))
        return defaultValue;

      TimeSpan r;
      if(TimeSpan.TryParse(w, out r))
        return r;
      return defaultValue;
      }

    protected TimeSpan getDM(string key, TimeSpan defaultValue){ return getD(key, defaultValue).Value; }

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

    public string baseURL { get {
      return getS("baseURL", "http://kabada.ba.lv/");
      }}

    public TimeSpan? memberInvitationLifetime { get {
      return getD("MemberInvitationLifetime");
      }}

    public TimeSpan jobsRescanInterval { get {
      return getDM("JobsRescanInterval", new TimeSpan(0, 5, 0));
      }}

    public TimeSpan jobsNotifyRescanInterval { get {
      return getDM("JobsNotifyRescanInterval", new TimeSpan(0, 0, 5));
      }}


    public string importDirectory { get {
      return getS("importDirectory", null);
      }}

    public string sofficeDirectory { get {
      return getS("SofficeDirectory", null);
      }}

    }
  }
