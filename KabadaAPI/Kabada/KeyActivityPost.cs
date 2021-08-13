using System;

namespace Kabada {
  public partial class KeyActivityPost {
    public Guid? id; // "if null it is a new one, if none - update existing one",
    public Guid product_id;
    public Guid sub_type_id;
    public string name;
    public string description; // (optional)"
    }
  }
