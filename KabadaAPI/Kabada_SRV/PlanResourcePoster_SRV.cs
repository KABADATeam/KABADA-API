using KabadaAPI;
using System;
using static KabadaAPI.TexterRepository;

namespace Kabada {
  partial class PlanResourcePoster {
    protected BLontext ctx;

    internal Guid perform(BLontext context) {
      ctx=context;

      var plan=new BusinessPlansRepository(ctx).GetPlanForUpdate(ctx.userGuid, business_plan_id); // only to validate rights on plan

      var tp=new TexterRepository(ctx).getById(resource_type_id);
      if(tp==null || tp.Kind!=(short)EnumTexterKind.keyResourceType)
        throw new Exception("wrong resource_type");

      if(resource_id==null)
        return create();
      var rid=resource_id.Value;
      //TODO update
      return rid;
      }

    private Guid create() {
      throw new NotImplementedException();
      }
    }
  }
