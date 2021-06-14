using KabadaAPI.DataSource.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KabadaAPI.DataSource.Repositories {
  public class TexterRepository : BaseRepository {
    public enum EnumTexterKind { strength=1, strength_local, oportunity=3, oportunity_local
                   , keyResourceCategory=5, keyResourceType=6, keyResourceSubType=7, keyResourcesSelection=8, keyResourceOther
                   }

    public TexterRepository(Microsoft.Extensions.Configuration.IConfiguration configuration, Microsoft.Extensions.Logging.ILogger logger =null, Context context=null)
      : base(configuration, logger, context) { }

    protected List<Texter> get(Guid? plan=null, short? @from=null, short? @to=null, List<short> kinds=null, bool ignoreMaster=false){
      var q=context.Texters.AsQueryable();
      if(ignoreMaster==false){
        if(plan==null)
          q=q.Where(x=>x.MasterId==null);
         else {
          var w=plan.Value;
          q=q.Where(x=>x.MasterId==null || x.MasterId==w);
          }
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
      var r=q.ToList();
      return r;
      }

    public List<Texter> getSWOTs(Guid? plan=null){ return get(plan, (short)EnumTexterKind.strength, (short)EnumTexterKind.oportunity_local); }

   public List<Texter> getKeyResourceCategories(){ return get(null, (short)EnumTexterKind.keyResourceCategory, (short)EnumTexterKind.keyResourceType); }

   public List<Texter> getKeyResourceTypes(Guid? kind){ return get(kind, (short)EnumTexterKind.keyResourceType, (short)EnumTexterKind.keyResourceType); }

    public List<Texter> getKeyResourceSubTypes(Guid? @type){ return get(@type, (short)EnumTexterKind.keyResourceSubType, (short)EnumTexterKind.keyResourceSubType); }

    public List<Texter> getKeyResourceMeta(){ return get(null, (short)EnumTexterKind.keyResourceCategory, (short)EnumTexterKind.keyResourcesSelection, ignoreMaster:true); } 

    public Texter Create(Texter me) {
      context.Texters.Add(me);
      context.SaveChanges();
      return me;
      }

    public Texter getById(Guid id) {
      var r=context.Texters.Where(x=>x.Id==id).FirstOrDefault();
      return r;
      }

    public void Delete(Texter me) {
      context.Texters.Remove(me);
      context.SaveChanges();
      }
    }
  }
