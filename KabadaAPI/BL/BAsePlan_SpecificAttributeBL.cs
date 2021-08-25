using KabadaAPIdao;
using System;
using System.Collections.Generic;

namespace KabadaAPI {
  public abstract class BAsePlan_SpecificAttributeBL : BAseAttributeBL {
    protected Plan_SpecificAttribute o { get { return (Plan_SpecificAttribute)_o;} set { _o=value; }}

    public override Guid id { get => o.Id; protected set => o.Id=value; }
    public override short kind { get => o.Kind; protected set => o.Kind=value; }
    public override short orderValue { get => o.OrderValue; set => o.OrderValue=value; }
    protected override string attrVal { get => o.AttrVal; set => o.AttrVal=value; }

    public Guid businessPlanId { get { return o.BusinessPlanId; } set { o.BusinessPlanId=value; }}

    public virtual Plan_SpecificAttribute unload(bool skipPack=false){ return unloadMe<Plan_SpecificAttribute>(skipPack); }

   public BAsePlan_SpecificAttributeBL(short kind, Guid plan){
      o=new Plan_SpecificAttribute(){ Id=Guid.NewGuid(), Kind=kind };
      businessPlanId=plan;
     }

    protected void validate(Guid? planForValidate, short? kindForValidate, List<short> kindsForValidate){
      if(planForValidate!=null && businessPlanId!=planForValidate.Value)
        throw new Exception("Attribute belongs to an another plan");
      if(kindForValidate!=null)
        validateKind(kindForValidate.Value);
      if(kindsForValidate!=null)
        validateKind(kindsForValidate);
      }

    public BAsePlan_SpecificAttributeBL(Plan_SpecificAttribute old, bool forEdit=false, Guid? planForValidate=null, short? kindForValidate=null, List<short> kindsForValidate=null){
      if(forEdit)
        o=old;
       else
        o=old.clone();
      validate(planForValidate, kindForValidate, kindsForValidate);
      }

    protected static Plan_SpecificAttribute RD(Guid byId, Plan_SpecificAttributesRepository rp, Guid? planForValidate=null){ return rp.byId(byId, planForValidate); }

    public Guid completeSet(Guid? oldId, Plan_SpecificAttributesRepository repo){
      var w=unload();
      if(oldId==null)
        repo.create(w);
       else
        repo.daContext.SaveChanges();
      return id;
      }

    //*****************************END of COPY+ADJUST part ***************************************//

    //public BAsePlan_AttributeBL(Guid byId, Plan_AttributeRepository rp, bool forEdit=false, Guid? planForValidate=null, short? kindForValidate=null, List<short> kindsForValidate=null)
    //         : this(RD(byId, rp, planForValidate), forEdit, planForValidate, kindForValidate, kindsForValidate){}
   }
  }
