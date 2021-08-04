using System.Collections.Generic;

namespace KabadaAPI {
  public partial class ConsumerSegment : CustomerSegment {
    public bool is_children;
    public List<Codifier> age;
    public List<Codifier> gender;
    public List<Codifier> education;
    public List<Codifier> income;
    public List<Codifier> geographic_location;
    }
  }
