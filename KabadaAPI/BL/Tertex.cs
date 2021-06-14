using KabadaAPI.DataSource.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KabadaAPI.BL {
  public class Tertex {    // Texter tree vertex
    public Texter me;
    public string data;
    public List<Tertex> children;

    public static Tertex CreateMasterTree(List<Texter> todo){
      var root=new Tertex();
      root.fillTree(null, todo);
      return root;
      }

    private void fillTree(Guid? p, List<Texter> todo) {
      children=todo.Where(x=>x.MasterId==p).OrderBy(x=>x.OrderValue).Select(x=>new Tertex { me=x}).ToList();
      foreach(var t in children)
        t.fillTree(t.me.Id, todo);
      }
    }
  }
