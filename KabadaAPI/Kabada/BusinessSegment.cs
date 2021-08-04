using System.Collections.Generic;

namespace KabadaAPI {
  public partial class BusinessSegment : CustomerSegment {
    public List<Codifier> business_type;
    public List<Codifier> company_size;
    public string annual_revenue;
    public string budget;
    public List<Codifier> income;
    public List<Codifier> geographic_location;
    }
  }
