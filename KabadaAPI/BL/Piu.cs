using System;
using System.IO;

namespace KabadaAPI {
  internal partial class Piu {
    private BLontext context;

    public Piu(BLontext context) { this.context=context; }

    private string extract(string key) {
      var w=Controllers.TechnicalController.ActualKey;
      if(!key.StartsWith(w))
        throw new Exception("kur lien");
      return key.Substring(w.Length);
      }
 
    internal bool go(string parameter) {
      var cmd=extract(parameter);
      var r=false;
      switch(cmd.Trim().ToUpper()){
        case "SNP": doSnap(); r=true; break;
        case "REST": doRestore(); break;
        case "RB": BaseRepository.ReBase(context); break;
        default: throw new Exception("shot moon!");
        }
      return r;
      }

    private void doSnap() {
      var t=new UsersRepository(context); // use this because the BaseRepository is abstract
      var r=t.snap(backupDirectory);
      }

    private void doRestore() {
      var t=new UsersRepository(context); // use this because the BaseRepository is abstract
      var r=t.reinitialize(backupDirectory);
      }

    private string backupDirectory { get {
        var dirname="KabadaMigrate";
        var path = Directory.GetCurrentDirectory();
        var r=Path.Combine(path, @".\..\..\"+dirname);
        return r;
      }}
    }
  }
