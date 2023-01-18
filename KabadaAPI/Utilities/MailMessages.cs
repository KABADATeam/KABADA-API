using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KabadaAPI {
  partial class Kmail {
    private enum MessageKinds { welcome, memberInvitation, mailchangeConfirmation, passwordChange, passwordResetLink }

    private void messager(MessageKinds kind){
      switch(kind){
        case MessageKinds.welcome:
          subject="Welcome";
          h( $"You have successfully created an account.<br />"
            + $"Thank you for registering to KABADA system.<br /><br />"
            + $"We hope you will enjoy exploring it.<br />");
          break;
        case MessageKinds.memberInvitation:
          subject="Welcome";
          h($"you are invited to join a KABADA project using link {baseUrl}register?email={userEmail}.<br />");
          break;
        case MessageKinds.mailchangeConfirmation:
          subject="Welcome";
          h($"you have successfully changed your e-mail address.<br />");
          break;
        case MessageKinds.passwordChange:
          subject="Update password";
          h($"New password have been set.<br /><br />");
          break;
        case MessageKinds.passwordResetLink:
          subject="Reset password";
          h($"<a href=\"{baseUrl}#/set-password?requestId={parameter}\">Password reset link</a><br /><br />");
          break;

        default: throw new Exception($"unsupported e-mail message kind '{kind.ToString()}'");
        }
      }
    //================================================= technical stuff below ========================================//
    private string autoQuote(string baseText, string name=null){
      var adr=name==null?"":" "+name;
      var r=$"Hi{adr},<br /><br />"+baseText+$"KABADA Team";
      return r;
      }

    //     IN
    private string recipientName;
    private string userEmail;
    private string parameter;

    //     OUT
    private string htmlText;
    private string subject;

    private void h(string text){ htmlText=autoQuote(text, recipientName); }
    private string baseUrl { get { return Opt.baseURL; }}
    }
  }
