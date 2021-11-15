using Newtonsoft.Json;
using System;
using System.IO;

namespace Kabada {
  partial class UnloadSet {
    public UnloadSet(){ elements=new System.Collections.Generic.List<UnloadSetElement>(); }

    internal void regIt(Guid id, object o) {
      var t=new UnloadSetElement(){ id=id, type=o.GetType().Name, contents=JsonConvert.SerializeObject(o, 0, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore })  };
      elements.Add(t);
      }

    internal void toCSV(string filePath) {     
      var t="id;type;contents;";
      using(var os=new StreamWriter(filePath, false, System.Text.Encoding.UTF8)){
        os.WriteLine(t);
        foreach(var o in elements){
          t=$"{o.id};{o.type};{o.contents};";
          os.WriteLine(t);
          }
        os.Close();
        }
      }
    }
  }
