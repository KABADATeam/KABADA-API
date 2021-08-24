using System;

namespace KabadaAPI {
  public abstract class MIX {
    public static void EXC(Action<string> logger, Exception exc, string prefix=""){
      logger($"{prefix}EXCEPTION: Message='{exc.Message}' StackTrace='{exc.StackTrace}'.");
      var u=exc;
      while(u.InnerException!=null){
        u=u.InnerException;
        logger($"{prefix}Exc(inner): Message='{u.Message}' StackTrace='{u.StackTrace}'.");
        }
      }

    public static string Method(int stepsBack){
      var r=new System.Diagnostics.StackTrace().GetFrame(1+stepsBack).GetMethod().Name;
      return r; 
      }

    public static string NI(object me, int stepsBack=0){
      var r=$"Not implemented {me.GetType().Name}.{Method(1+stepsBack)}";
      return r;
      }
    }
  }
