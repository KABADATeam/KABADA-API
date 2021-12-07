using KabadaAPIdao;

namespace KabadaAPI {
  public class BPjoin {
    public BusinessPlan bp;
    public Country      cn;
    public Activity     ac;
    public Industry     ind;
    public Language     lng;
    public User         us;

  public BPjoin clone(){
    var r=new BPjoin();
    if(bp!=null)
      r.bp=bp.clone();
    if(cn!=null)
      r.cn=cn.clone();
    if(ac!=null)
      r.ac=ac.clone();
    if(ind!=null)
      r.ind=ind.clone();
    if(lng!=null)
      r.lng=lng.clone();
    if(us!=null)
      r.us=us.clone();
    return r;
    }
    }
  }
