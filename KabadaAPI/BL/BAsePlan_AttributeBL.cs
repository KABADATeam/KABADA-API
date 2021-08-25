using KabadaAPIdao;
using System;
using System.Collections.Generic;

namespace KabadaAPI {
  public abstract class BAsePlan_AttributeBL : BAseAttributeBL {
    protected Plan_Attribute o { get { return (Plan_Attribute)_o;} set { _o=value; }}

    public override Guid id { get => o.Id; protected set => o.Id=value; }
    public override short kind { get => o.Kind; protected set => o.Kind=value; }
    public override short orderValue { get => o.OrderValue; set => o.OrderValue=value; }
    protected override string attrVal { get => o.AttrVal; set => o.AttrVal=value; }

    public Guid businessPlanId { get { return o.BusinessPlanId; } set { o.BusinessPlanId=value; }}
    public Guid texterId { get { return o.TexterId; } set { o.TexterId=value; }}

    public virtual Plan_Attribute unload(bool skipPack=false){ return unloadMe<Plan_Attribute>(skipPack); }

   public BAsePlan_AttributeBL(short kind, Guid plan, Guid texter){
      o=new Plan_Attribute(){ Id=Guid.NewGuid(), Kind=kind, BusinessPlanId=plan, TexterId=texter };
      }

    protected void validate(Guid? planForValidate, short? kindForValidate, List<short> kindsForValidate){
      if(planForValidate!=null && businessPlanId!=planForValidate.Value)
        throw new Exception("Attribute belongs to an another plan");
      if(kindForValidate!=null)
        validateKind(kindForValidate.Value);
      if(kindsForValidate!=null)
        validateKind(kindsForValidate);
      }

    public BAsePlan_AttributeBL(Plan_Attribute old, bool forEdit=false, Guid? planForValidate=null, short? kindForValidate=null, List<short> kindsForValidate=null){
      if(forEdit)
        o=old;
       else
        o=old.clone();
      validate(planForValidate, kindForValidate, kindsForValidate);
      }

    protected static Plan_Attribute RD(Guid byId, Plan_AttributeRepository rp, Guid? planForValidate=null){ return rp.byId(byId, planForValidate); }

    public Guid completeSet(Guid? oldId, Plan_AttributeRepository repo){
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
