using System.IO;

namespace Kabada {
  partial class UnloadSet {
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
