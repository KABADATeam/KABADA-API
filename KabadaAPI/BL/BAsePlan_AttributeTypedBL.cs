using KabadaAPIdao;
using System;
using System.Collections.Generic;

namespace KabadaAPI {
  public class BAsePlan_AttributeTypedBL<T> : BAsePlan_AttributeBL where T:new() {
    public T e { get { return (T)_e; } protected set { _e=value; }}

    public BAsePlan_AttributeTypedBL(short kind, Guid plan, Guid texter) : base(kind, plan, texter){  e=new T(); }

    public BAsePlan_AttributeTypedBL(Plan_Attribute old, bool forEdit=false, Guid? planForValidate=null, short? kindForValidate=null, List<short> kindsForValidate=null)
                   : base(old, forEdit, planForValidate, kindForValidate, kindsForValidate){ assignE<T>(attrVal); }

    public BAsePlan_AttributeTypedBL(Guid byId, Plan_AttributeRepository rp, bool forEdit=false, Guid? planForValidate=null, short? kindForValidate=null, List<short> kindsForValidate=null)
               :  this(RD(byId, rp), forEdit, planForValidate, kindForValidate, kindsForValidate){ }

    //*****************************END of COPY+ADJUST part ***************************************//
    }
  }
