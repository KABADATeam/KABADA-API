using KabadaAPIdao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KabadaAPI {
  public abstract class BAseUniversalAttributeBL : BAseAttributeBL {
    protected UniversalAttribute o { get { return (UniversalAttribute)_o;} set { _o=value; }}

    public override Guid id { get => o.Id; protected set => o.Id=value; }
    public override short kind { get => o.Kind; protected set => o.Kind=value; }
    public override short orderValue { get => o.OrderValue; set => o.OrderValue=value; }
    protected override string attrVal { get => o.AttrVal; set => o.AttrVal=value; }

    public Guid? categoryId { get { return o.CategoryId; } set { o.CategoryId=value; }}
    public Guid? masterId { get { return o.MasterId; } set { o.MasterId=value; }}

    public virtual UniversalAttribute unload(bool skipPack=false){ return unloadMe<UniversalAttribute>(skipPack); }

   public BAseUniversalAttributeBL(short kind, Guid? master=null, Guid? category=null){
      o=new UniversalAttribute(){ Id=Guid.NewGuid(), Kind=kind };

      masterId=master;
      categoryId=category;
      }

    protected void validate(short? kindForValidate, List<short> kindsForValidate, Guid? masterForValidate){
     if(kindForValidate!=null)
        validateKind(kindForValidate.Value);
      if(kindsForValidate!=null)
        validateKind(kindsForValidate);
     if(masterForValidate!=null && masterId!=masterForValidate)
        throw new Exception("Wrong master encountered");
      }

    public BAseUniversalAttributeBL(UniversalAttribute old, bool forEdit=false, short? kindForValidate=null, List<short> kindsForValidate=null, Guid? masterForValidate=null){
      if(forEdit)
        o=old;
       else
        o=old.clone();
      validate(kindForValidate, kindsForValidate, masterForValidate);
      }

    protected static UniversalAttribute RD(Guid byId, UniversalAttributeRepository rp){ return rp.byId(byId); }

    public Guid completeSet(Guid? oldId, UniversalAttributeRepository repo){
      var w=unload();
      if(oldId==null)
        repo.create(w);
       else
        repo.daContext.SaveChanges();
      return id;
      }

    //*****************************END of COPY+ADJUST part ***************************************//
    }
  }
