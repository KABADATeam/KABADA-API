using KabadaAPIdao;
using System;

namespace KabadaAPI {
  public class Plan_SpecificAttributeBL<T> : AttributeTechnicalBaseBL<T> where T:class, new() {
    private Plan_SpecificAttribute o;

   public override short orderValue { get => o.OrderValue; set => o.OrderValue=value; }

    public Guid businessPlanId { get { return o.BusinessPlanId; } set { o.BusinessPlanId=value; }}
    public string comment { get { return o.Comment; } set { o.Comment=value; }}

    public Plan_SpecificAttributeBL(short kindToAssign) : base(kindToAssign) {
      o=new Plan_SpecificAttribute() { Id=id, Kind=kind };
      }

    public Plan_SpecificAttributeBL(short kindForValidate, KabadaAPIdao.Plan_SpecificAttribute old, bool forUpdate) : base(kindForValidate, old.Kind, old.Id, old.AttrVal){
      if(forUpdate)
        o=old;
       else
        o=old.clone();
      }

    public KabadaAPIdao.Plan_SpecificAttribute unload(){
      o.AttrVal=packedValue;
     return o;
      }
    }
  }
