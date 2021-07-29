using System.Collections.Generic;
using System.Linq;

namespace KabadaAPI {
  public class UserTypesRepository : BaseRepository {
    public UserTypesRepository(BLontext bCcontext, DAcontext dContext=null) : base(bCcontext, dContext) {}

    protected override object[] getAll4snap() { return daContext.UserTypes.ToArray(); }
    protected override string myTable => "UserTypes";

    protected override bool loadData(string json, bool overwrite) {
      var o = Newtonsoft.Json.JsonConvert.DeserializeObject<KabadaAPIdao.UserType>(json);
      var t=findOld(o);
      if(t==null){
        daContext.UserTypes.Add(o);
        return true;
        }
      //TODO overwrite processing
      return false;
      }

    protected Dictionary<int, object> oldI;
    protected override void getOldies(){
      oldI=getToldies<int>();  //getAll4snap().ToDictionary(x=>(int)(x.GetType().GetProperty("Id").GetValue(x, null)));
      }

    protected override object findOld(object me){
      var k=getK<int>(me);
      object r=null;
      if(oldI.TryGetValue(k, out r))
        return r;
      return null;
      }
    }
  }
