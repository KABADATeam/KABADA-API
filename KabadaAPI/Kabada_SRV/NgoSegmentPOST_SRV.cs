using static KabadaAPI.TexterRepository;

namespace KabadaAPI {
  public partial class NgoSegmentPOST {
    protected override void fill(CustomerSegmentUniversal t) {
      fill(t, EnumTexterKind.public_bodies_ngo, ngo_types);
      }
    }
  }
