using System;

namespace Kabada {
  public class SwotUpdater {
    public Guid?  id        { get; set; }  // texter id. is null only for a new local
    public string name      { get; set; }  // name for local; 
    //public short  kind_type { get; set; } 
    public short  operation { get; set; }  // -1 remove texter element (works only for locals) 0 set value null (remove from the resolution table) >0 set this value
    }
  }
