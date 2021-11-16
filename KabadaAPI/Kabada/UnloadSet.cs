using System;
using System.Collections.Generic;

namespace Kabada {
  public class UnloadSetElement {
    public Guid id;
    public string type;
    public string contents;
    }

  public partial class UnloadSet {
    public string descriptor { get; set; }
    public string user { get; set; }
    public List<UnloadSetElement> elements;
    }
  }
