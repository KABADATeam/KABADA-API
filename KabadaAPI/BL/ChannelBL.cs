using static KabadaAPI.Plan_AttributeRepository;

namespace KabadaAPI {
  public class ChannelBL : Plan_AttributeBL<ChannelElementBL> {
    private const short KIND=(short)PlanAttributeKind.channel;

    public ChannelBL() : base(KIND) {}
    public ChannelBL(KabadaAPIdao.Plan_Attribute old, bool forUpdate=false) : base(KIND, old, forUpdate){}
    }
  }
