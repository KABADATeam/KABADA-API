using KabadaAPIdao;
using System;
using System.Collections.Generic;

namespace KabadaAPI {
  public class BAseUniversalAttributeTypedBL<T> : BAseUniversalAttributeBL where T:new() {
    public T e { get { return (T)_e; } protected set { _e=value; }}

    public BAseUniversalAttributeTypedBL(short kind, Guid? master=null, Guid? texter=null) : base(kind, master, texter){  e=new T(); }

    public BAseUniversalAttributeTypedBL(UniversalAttribute old, bool forEdit=false, short? kindForValidate=null, Guid? masterForValidate=null, List<short> kindsForValidate=null)
                   : base(old, forEdit, kindForValidate, kindsForValidate, masterForValidate){ assignE<T>(attrVal); }

    public BAseUniversalAttributeTypedBL(Guid byId, UniversalAttributeRepository rp, bool forEdit=false, short? kindForValidate=null, Guid? masterForValidate=null, List<short> kindsForValidate=null)
               :  this(RD(byId, rp), forEdit, kindForValidate, masterForValidate, kindsForValidate){ }

    //*****************************END of COPY+ADJUST part ***************************************//
    }
  }
