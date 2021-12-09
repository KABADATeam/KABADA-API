using System;
using System.Collections.Generic;

namespace Kabada {
  public partial class ChoiceResults {
    public Guid plan_id;
    public bool is_personal_characteristics_completed;
    public List<ChoiceElement> choices;

    public void Add(ChoiceElement me){
      if(choices==null)
        choices=new List<ChoiceElement>();
      choices.Add(me);
      }
    }
  }
