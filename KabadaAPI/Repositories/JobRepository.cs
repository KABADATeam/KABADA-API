using KabadaAPIdao;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace KabadaAPI {
  public class JobRepository : BaseRepository {
    public JobRepository(BLontext bCcontext, DAcontext dContext=null) : base(bCcontext, dContext) {}
    protected override object[] getAll4snap() { return daContext.Jobs.ToArray(); }
    protected override string myTable => "Jobs";

    protected override bool loadData(string json, bool overwrite, bool oldDeleted, bool generateInits) {
      return loadDataRow<KabadaAPIdao.Job, Guid>(daContext.Jobs, json, overwrite, oldDeleted, generateInits);
      }

    public enum JobKind { invitePlanMember=1, onfly_loadIRs=2, onfly_imports=3 }

    private DbSet<Job> q0 { get { return daContext.Jobs; }}

    public Job create(Job me){
      if(me.Id.ToString()==new Guid().ToString())
        me.Id=Guid.NewGuid();
      me.CreatedAt=DateTime.Now;
      q0.Add(me);
      daContext.SaveChanges();
      return me;
      }

    public void runAll(){
      var mid="JobRepository.runAll: ";
      LogInformation($"{mid}started at {DateTime.Now}.");
      var tasks=q0.OrderBy(x=>x.CreatedAt).ToList();
      tasks.Add(new Job(){ Kind=(short)JobKind.onfly_imports });
      foreach(var t in tasks){
        try { runJob(t, mid); }
        catch (Exception exc) { MIX.EXC(LogError, exc, $"Job({pack(t)}) "); }
        }
      LogInformation($"{mid}ended at {DateTime.Now}.");
      }

    private void runJob(Job t, string prefix="") {
      if(t.ExpiresAt!=null && t.ExpiresAt.Value<DateTime.Now){
        var sn=pack(t);
        delete(t);
        LogInformation($"{prefix}Obsole job deleted: {sn}");
        return;
        }
      switch(t.Kind){
        case (short)JobKind.invitePlanMember: invitePlanMember(t, prefix); break;
        //case (short)JobKind.onfly_loadIRs: new IndustryRisksManager(blContext).processRegulars(); break;
        case (short)JobKind.onfly_imports: doImports(t, prefix); break;
        default: break; // unknown job kind
        }
      }

    private void doImports(Job t, string prefix) { LoaderManager.Import(blContext); }

    private void invitePlanMember(Job t, string prefix="") {
      var u=new UsersRepository(blContext).byEmail(t.Lookup);
      if(u==null)
        return; // still not arrived
      new SharedPlanRepository(blContext, daContext).add(
        new SharedPlan(){ BusinessPlanId=new Guid(t.Value), UserId=u.Id /*  t.Author.Value*/, Id=Guid.NewGuid() });
      var sn=pack(t);
      delete(t);
      LogInformation($"{prefix}Job completed: {sn}");
      }

    private void delete(Job t) {
      q0.Remove(t);
      daContext.SaveChanges();
      }

    

    protected override Guid? guid(string json) {
      var o = Newtonsoft.Json.JsonConvert.DeserializeObject<Job>(json);
      return o.Id;
      }
    }
  }
