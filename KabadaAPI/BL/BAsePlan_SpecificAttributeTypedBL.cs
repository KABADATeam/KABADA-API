using KabadaAPIdao;
using System;
using System.Collections.Generic;

namespace KabadaAPI {
  public class BAsePlan_SpecificAttributeTypedBL<T> : BAsePlan_SpecificAttributeBL where T:new() {
    public T e { get { return (T)_e; } protected set { _e=value; }}

    public BAsePlan_SpecificAttributeTypedBL(short kind, Guid? plan=null) : base(kind, plan){  e=new T(); }

    public BAsePlan_SpecificAttributeTypedBL(Plan_SpecificAttribute old, bool forEdit=false, Guid? planForValidate=null, short? kindForValidate=null, List<short> kindsForValidate=null)
                   : base(old, forEdit, planForValidate, kindForValidate, kindsForValidate){ assignE<T>(attrVal); }

    public BAsePlan_SpecificAttributeTypedBL(Guid byId, Plan_SpecificAttributesRepository rp, bool forEdit=false, Guid? planForValidate=null, short? kindForValidate=null, List<short> kindsForValidate=null)
               :  this(RD(byId, rp), forEdit, planForValidate, kindForValidate, kindsForValidate){ }

    //*****************************END of COPY+ADJUST part ***************************************//
    }
  }
