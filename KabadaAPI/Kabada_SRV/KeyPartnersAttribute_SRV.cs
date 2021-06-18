namespace Kabada {
  partial class KeyPartnersAttribute {
    public void unpack(string archived){
      var t=Newtonsoft.Json.JsonConvert.DeserializeObject<KeyPartnersAttribute>(archived);
      comment=t.comment;
      is_priority=t.is_priority;
      name=t.name;
      website=t.website;
      }
    }
  }
