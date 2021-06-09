﻿using KabadaAPI.DataSource.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KabadaAPI.DataSource.Repositories {
  public class TexterRepository : BaseRepository {
    public enum EnumTexterKind { strength=1, strength_local, oportunity=3, oportunity_local }

    public TexterRepository(Microsoft.Extensions.Configuration.IConfiguration configuration, Microsoft.Extensions.Logging.ILogger logger =null, Context context=null)
      : base(configuration, logger, context) { }

    public List<Texter> get(Guid? plan=null, List<short> kinds=null){
      var q=context.Texters.AsQueryable();
      if(plan==null)
        q=q.Where(x=>x.MasterId==null);
       else {
        var w=plan.Value;
        q=q.Where(x=>x.MasterId==null || x.MasterId==w);
        }
      if(kinds!=null)
        q=q.Where(x=>kinds.Contains(x.Kind));
      var r=q.ToList();
      return r;
      }

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
