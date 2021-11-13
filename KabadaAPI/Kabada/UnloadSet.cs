using System;
using System.Collections.Generic;

namespace Kabada {
  public class UnloadSetElement {
    public Guid id;
    public string type;
    public string contents;
    }

  public partial class UnloadSet {
    public string descriptor;
    public List<UnloadSetElement> elements;
    }
  }
