using KabadaAPI.DataSource.Models;
using System;
using System.Collections.Generic;

namespace KabadaAPI.ViewModels {
  public partial class ResourceCategory {
    public Guid id;
    public string title;
    public string description;
    public List<ResourceType> types;
    public List<ResourceSelection> selections;
    }
  }
