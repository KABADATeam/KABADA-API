using System.IO;
using System.Linq;

namespace KabadaAPI {
  public class IndustryRisksManager {
    public string getTheOldiest(string fullDirectoryPath, string pattern="*_IR.csv"){      
      var f=new DirectoryInfo(fullDirectoryPath).GetFiles(pattern).OrderBy(f => f.LastWriteTime).FirstOrDefault();
      if (f != null) return f.FullName; // return full path for the found
      return null; // nothing found
      }
    }
  }
