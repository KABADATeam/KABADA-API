using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace KabadaAPI {
  partial class Piu {
    private const string ActualKeyConst="piu pieejas pārbaudīte";

    private static string ActualKey { get {
      var server = Dns.GetHostName();
      var heserver = Dns.GetHostEntry(server);
      var al=heserver.AddressList.Select(x=>x.ToString()).OrderBy(x=>x).ToList();
      var aa=string.Join(",", al);

      return server+ActualKeyConst+aa;
      }}

    public static string Parameter(string[] args){
      return ActualKey+args[0];
      }
    }
  }
