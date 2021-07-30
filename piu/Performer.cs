using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace piu {
  internal class Performer {
    private const string ActualKey="piu pieejas pārbaudīte";
    private const string snapPlace="vietucis";

    private Transponder _masts;
    protected Transponder masts { get{
      if(_masts==null){
        _masts=new Transponder();
        _masts.baseAddress="http://localhost:5000/";
        }
      return _masts;
      }}

    internal async Task go(string[] args) {
      if(args==null || args.Length<1)
        return;
      await go(args[0]);
      }

    private async Task go(string command) {
      if(string.IsNullOrWhiteSpace(command))
        return;
      switch(command.Trim().ToUpper()){
        case "SNAP": await doSnap(); break;
        default: break;
        }
      }

    private async Task doSnap() {
      var r=await masts.GO("/api/Technical/snap", ActualKey+snapPlace);
      }
    }
  }
