namespace KabadaAPI {
  public class IndustryRiskElementBL {
    public string category;
    public string type;
    public byte? likelihood;
    public byte? severity;
    public string comments;
    public int? countryDeviationScore;
    public string countryDeviationComment;

    public void validate(){ // errors bring exception
      // category+type allowed combination
      // likelihood and severity range [1..3]
      }
    //public  total;
    }
  }
