using System.IO;
using System.Linq;

namespace KabadaAPI {
  public class IndustryRisksManager {
    public string getTheOldiest(string fullDirectoryPath, string pattern="*_IR.csv"){      
      var f=new DirectoryInfo(fullDirectoryPath).GetFiles(pattern).OrderBy(f => f.LastWriteTime).FirstOrDefault();
      if (f != null) return f.FullName; // return full path for the found
      return null; // nothing found
      }

    public void proccessCsvFiles(string fullDirectoryPath){
      while(true){
        var f=getTheOldiest(fullDirectoryPath);
        if(f==null)
          break;
        processSingleFile(f);
        }
      }

    private void processSingleFile(string f) {
      // file name ---> (set/DEL, List<isIndustry, i/a Guid>)
      // load scsv. if good, save to a Texter
      // create pointers to texter
      // remove not referenced texters
      throw new System.NotImplementedException();
      }
    }
  }
