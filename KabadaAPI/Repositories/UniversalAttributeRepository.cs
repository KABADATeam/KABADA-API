using KabadaAPIdao;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KabadaAPI {
  public class UniversalAttributeRepository : BaseRepository {
    public UniversalAttributeRepository(BLontext bCcontext, DAcontext dContext=null) : base(bCcontext, dContext) {}

    private DbSet<UniversalAttribute> q0 { get { return daContext.UniversalAttributes; }}

    protected override object[] getAll4snap() { return q0.ToArray(); }

    internal UniversalAttribute byId(Guid id) {
      return q0.Where(x=>x.Id==id).FirstOrDefault();
      }

    internal List<UniversalAttribute> byMasters(List<Guid?> masters) {
      return q0.Where(x=>masters.Contains(x.MasterId)).ToList();
      }

    protected override string myTable => "UniversalAttributes";

    protected override bool loadData(string json, bool overwrite, bool oldDeleted, bool generateInits) {
      return loadDataRow<KabadaAPIdao.UniversalAttribute, Guid>(q0, json, overwrite, oldDeleted, generateInits);
      }

    internal void create(UniversalAttribute o) {
      q0.Add(o);
      daContext.SaveChanges();
      }

    internal static void DeleteAttribute(BLontext context, Guid resource) {
      using(var tr=new Transactioner(context)){
        var aRepo=new UniversalAttributeRepository(context, tr.Context);
        var o=aRepo.byId(resource); 
        aRepo.Delete(o);
        tr.Commit();
        }
      }

    private void Delete(UniversalAttribute o) {
      q0.Remove(o);
      daContext.SaveChanges();
      }

    internal List<Guid> usedIRs() {
      var r=q0.Where(x=>IndustryRiskPointerBL.KINDs.Contains(x.Kind)).Select(x=>x.CategoryId.Value).Distinct().ToList();
      return r;
      }

    internal int deleteIRpointers(List<Guid?> ms) {
      var deli=q0.Where(x=>IndustryRiskPointerBL.KINDs.Contains(x.Kind) && ms.Contains(x.MasterId)).ToList();
      foreach(var d in deli)
        q0.Remove(d);
      daContext.SaveChanges();
      return deli.Count;
      }
    }
  }
