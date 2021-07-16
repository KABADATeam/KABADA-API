namespace Kabada {
    partial class CostBase
    {
        public void unpack(string archived)
        {
            var t = Newtonsoft.Json.JsonConvert.DeserializeObject<CostBase>(archived);
            name = t.name;
            description = t.description;
        }        
    }
}
