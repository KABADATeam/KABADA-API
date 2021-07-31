using System.Threading.Tasks;

namespace piu {
  internal class Performer {
    private Transponder _masts;
    protected Transponder masts { get{
      if(_masts==null){
        _masts=new Transponder();
        _masts.baseAddress="http://localhost:5000/";
        }
      return _masts;
      }}

    internal async Task go(string[] args) {
      var p= KabadaAPI.Piu.Parameter(args);
      var r=await masts.GO("/api/Technical/piu", p);
      }
    }
  }
