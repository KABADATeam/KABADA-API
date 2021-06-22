using KabadaAPIdao;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KabadaAPI {
  public class TexterRepository : BaseRepository {
    public enum EnumTexterKind { strength=1, strength_local, oportunity=3, oportunity_local
                   , keyResourceCategory=5, keyResourceType=6, /*keyResourceSubType=7,*/ keyResourcesSelection=8
                   , /*keyPartners=10,*/ keyDistributors=11, keySuppliers=12, keyPartnersOther=13
                   }

    public TexterRepository(BLontext bCcontext, DAcontext dContext=null) : base(bCcontext, dContext) {}

    protected List<Texter> get(Guid? master=null, short? @from=null, short? @to=null, List<short> kinds=null, bool ignoreMaster=false){
      var q=daContext.Texters.AsQueryable();
        if(master==null){
          if(ignoreMaster==false)
            q=q.Where(x=>x.MasterId==null);
          }
         else {
          var w=master.Value;
          q=q.Where(x=>x.MasterId==null || x.MasterId==w);
          }
      if(kinds!=null)
        q=q.Where(x=>kinds.Contains(x.Kind));
      if(@from!=null){
        var w=@from.Value;
        q=q.Where(x=>x.Kind>=w);
        }
      if(@to!=null){
        var w=@to.Value;
        q=q.Where(x=>x.Kind<=w);
        }
      q=q.OrderBy(x=>x.Kind).ThenBy(x=>x.OrderValue);
      var r=q.ToList();
      return r;
      }

    internal List<Texter> get(List<Guid> tidi) {
      var r=daContext.Texters.Where(x=>tidi.Contains(x.Id)).ToList();
      return r;
      }

    public List<Texter> getSWOTs(Guid? plan=null){ return get(plan, (short)EnumTexterKind.strength, (short)EnumTexterKind.oportunity_local); }

   public List<Texter> getKeyResourceCategories(){ return get(null, (short)EnumTexterKind.keyResourceCategory, (short)EnumTexterKind.keyResourceType); }

   public List<Texter> getKeyResourceTypes(Guid? category){ return get(category, (short)EnumTexterKind.keyResourceType, (short)EnumTexterKind.keyResourceType, ignoreMaster:true); }

    //public List<Texter> getKeyResourceSubTypes(Guid? @type){ return get(@type, (short)EnumTexterKind.keyResourceSubType, (short)EnumTexterKind.keyResourceSubType); }

    public List<Texter> getKeyResourceMeta(){ return get(null, (short)EnumTexterKind.keyResourceCategory, (short)EnumTexterKind.keyResourcesSelection, ignoreMaster:true); } 

    internal List<Texter> getKeyPartnerMeta() {  return get(null, (short)EnumTexterKind.keyDistributors, (short)EnumTexterKind.keyPartnersOther); } 

    public Texter Create(Texter me) {
      daContext.Texters.Add(me);
      daContext.SaveChanges();
      return me;
      }

    public Texter getById(Guid id) {
      var r=daContext.Texters.Where(x=>x.Id==id).FirstOrDefault();
      return r;
      }

    public void Delete(Texter me) {
      daContext.Texters.Remove(me);
      daContext.SaveChanges();
      }
    }
  }
