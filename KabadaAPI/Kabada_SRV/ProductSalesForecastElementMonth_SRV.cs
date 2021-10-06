namespace Kabada {
  partial class ProductSalesForecastElementMonth {

    public int payShift(){
      var r=0;
      switch(paid.Trim()){
        default: break; // this month
        case "Next month": r=1; break; //	Cash in the next month
        case "After two months": r=2; break; //	Cash 2 months later
        case "After three months": r=3; break; //	Cash 3 months later
        case "One month in advanceh": r=-1; break; //	Cash in the previous month
        }
      return r;
      }
    }
  }
