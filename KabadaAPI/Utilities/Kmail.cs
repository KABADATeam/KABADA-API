using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;

namespace KabadaAPI {
  public class Kmail {
    private readonly IConfiguration config;

    public Kmail(IConfiguration config){ this.config = config; }

    private AppSettings _Opt;
    public AppSettings Opt { get {
      if(_Opt==null)
        _Opt=new AppSettings(config);
      return _Opt;
      }}

    public MimeEntity makeBody(string htmlBody=null, string textBody=null){
      var bodyBuilder = new BodyBuilder ();
      if(htmlBody!=null)
        bodyBuilder.HtmlBody = htmlBody;
      if(textBody!=null)
        bodyBuilder.TextBody = textBody;

      var r = bodyBuilder.ToMessageBody ();
      return r;
      }

    protected void send(MimeMessage mailMessage){
      var u=Opt.smtpUsername.Trim();
      if(u.IndexOf('@')<0)
        u+="@"+Opt.smtpHost;
      var a=new MailboxAddress("KABADA", u);
      mailMessage.From.Add(a);

      using (var smtpClient = new SmtpClient()){
//        if(opt.useTLS)
          smtpClient.Connect(Opt.smtpHost, Opt.smtpPort, SecureSocketOptions.StartTls);
         //else
         // smtpClient.Connect(opt.smtpHost, opt.smtpPort, true);
        smtpClient.Authenticate(Opt.smtpUsername, Opt.smtpPassword);
        smtpClient.Send(mailMessage);
        smtpClient.Disconnect(true);
        }
      }

    protected MimeMessage buildMessage(string subject, string htmlBody, string toAddress, string toName="", string textBody=null){
      var mailMessage = new MimeMessage();
      mailMessage.To.Add(new MailboxAddress(toName, toAddress));
      mailMessage.Subject = subject;
      mailMessage.Body = makeBody(htmlBody, textBody);
      return mailMessage;
      }


    public void send(string subject, string htmlBody, string toAddress, string toName="", string textBody=null){
      var m=buildMessage(subject, htmlBody, toAddress, toName, textBody);
      send(m);
      }


    public void send(System.Net.Mail.MailMessage me){
      send(me.Subject, me.IsBodyHtml?me.Body:null,me.To[0].Address, me.To[0].DisplayName, me.IsBodyHtml?null:me.Body);
      }

    protected string autoQuote(string baseText, string name=null){
      var r=$"Hi {name},<br /><br />"+baseText+$"KABADA Team";
      return r;
      }

    public void SendOnMailchangeConfirmation(string userEmail, string userName){
      var mb=autoQuote($"You have successfully changed your e-mail address.<br />", userName);
      send("Welcome", mb, userEmail, userName);
      }
     }
  }
