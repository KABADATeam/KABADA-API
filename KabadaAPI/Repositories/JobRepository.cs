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

    public enum JobKind { invitePlanMember=1 }

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
      foreach(var t in tasks)
        runJob(t);
      LogInformation($"{mid}ended at {DateTime.Now}.");
      }

    private void runJob(Job t) {
      if(t.ExpiresAt!=null && t.ExpiresAt.Value<DateTime.Now){
        var sn=pack(t);
        delete(t);
        LogInformation($"Obsole job deleted: {sn}");
        return;
        }
      switch(t.Kind){
        case (short)JobKind.invitePlanMember: invitePlanMember(t); break;
        default: break; // unknown job kind
        }
      }

    private void invitePlanMember(Job t) {
      var u=new UsersRepository(blContext).byEmail(t.Lookup);
      if(u==null)
        return; // still not arrived
      new SharedPlanRepository(blContext, daContext).add(
        new SharedPlan(){ BusinessPlanId=new Guid(t.Value), UserId=t.Author.Value, Id=Guid.NewGuid() });
      var sn=pack(t);
      delete(t);
      LogInformation($"Job completed: {sn}");
      }

    private void delete(Job t) {
      q0.Remove(t);
      daContext.SaveChanges();
      }
    }
  }
