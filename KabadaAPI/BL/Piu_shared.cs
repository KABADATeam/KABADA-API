using System;
using System.Collections.Generic;

namespace KabadaAPI {
  partial class Piu {
    private const string ActualKey="piu pieejas pārbaudīte";

    public static string Parameter(string[] args){
      return ActualKey+args[0];
      }
    }
  }
