//using KabadaAPIdao;
//using System;

//namespace KabadaAPI {
//  public abstract class Plan_AttributeBL<T> : AttributeTechnicalBaseBL<T> where T:class, new() {
//    private Plan_Attribute o;

//    public Guid businessPlanId { get { return o.BusinessPlanId; } set { o.BusinessPlanId=value; }}
//    public Guid texterId { get { return o.TexterId; } set { o.TexterId=value; }}

//    public override short orderValue { get => o.OrderValue; set => o.OrderValue=value; }

//    public Plan_AttributeBL(short kindToAssign, BLontext ctx=null, Guid? business_plan_id=null) : base(kindToAssign) {
//      o=new Plan_Attribute() { Id=id, Kind=kind };
//      if(ctx!=null){
//        orderValue=new Plan_AttributeRepository(ctx).generateAtrrOrder(business_plan_id.Value);
//        }
//      }

//    public Plan_AttributeBL(short kindForValidate, KabadaAPIdao.Plan_Attribute old, bool forUpdate) : base(kindForValidate, old.Kind, old.Id, old.AttrVal){
//      if(forUpdate)
//        o=old;
//       else
//        o=old.clone();
//      }

//    public KabadaAPIdao.Plan_Attribute unload(){
//      o.AttrVal=packedValue;
//     return o;
//      }
//    }
//  }
