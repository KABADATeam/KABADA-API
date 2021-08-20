//using KabadaAPIdao;
//using System;

//namespace KabadaAPI {
//  public abstract class UniversalAttributeBL<T> : AttributeTechnicalBaseBL<T> where T:class, new() {
//    private UniversalAttribute o;

//    public Guid? masterId { get { return o.MasterId; } set { o.MasterId=value; }}
//    public Guid? categoryId { get { return o.CategoryId; } set { o.CategoryId=value; }}

//    public UniversalAttributeBL(short kindToAssign) : base(kindToAssign) {
//      o=new UniversalAttribute() { Id=id, Kind=kind };
//      }

//    public UniversalAttributeBL(short kindForValidate, KabadaAPIdao.UniversalAttribute old, bool forUpdate) : base(kindForValidate, old.Kind, old.Id, old.AttrVal){
//      if(forUpdate)
//        o=old;
//       else
//        o=old.clone();
//      }

//    public KabadaAPIdao.UniversalAttribute unload(){
//      o.AttrVal=packedValue;
//     return o;
//      }
//    }
//  }
