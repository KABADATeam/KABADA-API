namespace Kabada {
  partial class ProductAttribute {
    public void unpack(string archived){
      var t=Newtonsoft.Json.JsonConvert.DeserializeObject<ProductAttribute>(archived);
      price=t.price;
      value=t.value;
      name=t.name;
      }
   }
  }
