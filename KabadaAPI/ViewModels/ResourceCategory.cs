using System;
using System.Collections.Generic;

namespace KabadaAPI {
  public partial class ResourceCategory {
    public Guid id;
    public string title;
    public string description;
    public List<ResourceType> types;
    public List<ResourceSelection> selections;
    }
  }
