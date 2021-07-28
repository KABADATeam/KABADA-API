using KabadaAPIdao;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KabadaAPI {
  public class TexterRepository : BaseRepository {
    public enum EnumTexterKind { strength=1, strength_local, oportunity=3, oportunity_local
                   , keyResourceCategory=5, keyResourceType=6, /*keyResourceSubType=7,*/ keyResourcesSelection=8
                   , /*keyPartners=10,*/ keyDistributors=11, keySuppliers=12, keyPartnersOther=13
                   , productType=14, productFeature=15, productAdditionalIncomeSource=16, productPriceLevel=17
                   , productInnovativeOption=18, productQualityOption=19, productDifferentiationOption=20
                   , fixedCostCategory=21, variableCostCategory=22, costType=23
                   , revenueStreamType=24,revenuePriceCategory=25,revenuePriceType=26
                , channelType=27,channelSubtype=28,channelSubtypeType=29, channelLocationType=30, channelDistribution=31
        }       

        public TexterRepository(BLontext bCcontext, DAcontext dContext=null) : base(bCcontext, dContext) {}

    protected List<Texter> get(Guid? master=null, short? @from=null, short? @to=null, List<short> kinds=null, bool ignoreMaster=false){
      var q=daContext.Texters.AsQueryable();
        if(master==null){
          if(ignoreMaster==false)
            q=q.Where(x=>x.MasterId==null);
          }
         else {
          var w=master.Value;
          q=q.Where(x=>x.MasterId==null || x.MasterId==w);
          }
      if(kinds!=null)
        q=q.Where(x=>kinds.Contains(x.Kind));
      if(@from!=null){
        var w=@from.Value;
        q=q.Where(x=>x.Kind>=w);
        }
      if(@to!=null){
        var w=@to.Value;
        q=q.Where(x=>x.Kind<=w);
        }
      q=q.OrderBy(x=>x.Kind).ThenBy(x=>x.OrderValue);
      var r=q.ToList();
      return r;
      }

    internal List<Texter> get(List<Guid> tidi) {
      var r=daContext.Texters.Where(x=>tidi.Contains(x.Id)).ToList();
      return r;
      }

    public List<Texter> getSWOTs(Guid? plan=null){ return get(plan, (short)EnumTexterKind.strength, (short)EnumTexterKind.oportunity_local); }

   public List<Texter> getKeyResourceCategories(){ return get(null, (short)EnumTexterKind.keyResourceCategory, (short)EnumTexterKind.keyResourceType); }

   public List<Texter> getKeyResourceTypes(Guid? category){ return get(category, (short)EnumTexterKind.keyResourceType, (short)EnumTexterKind.keyResourceType, ignoreMaster:true); }

    //public List<Texter> getKeyResourceSubTypes(Guid? @type){ return get(@type, (short)EnumTexterKind.keyResourceSubType, (short)EnumTexterKind.keyResourceSubType); }

    public List<Texter> getKeyResourceMeta(){ return get(null, (short)EnumTexterKind.keyResourceCategory, (short)EnumTexterKind.keyResourcesSelection, ignoreMaster:true); } 

    internal List<Texter> getKeyPartnerMeta() {  return get(null, (short)EnumTexterKind.keyDistributors, (short)EnumTexterKind.keyPartnersOther); } 

    internal List<Texter> getProductTypeMeta() {  return get(null, (short)EnumTexterKind.productType, (short)EnumTexterKind.productType); } 
    internal List<Texter> getProductFeatureMeta() {  return get(null, (short)EnumTexterKind.productFeature, (short)EnumTexterKind.productFeature); } 
    internal List<Texter> getProductIncomeSourceMeta() {  return get(null, (short)EnumTexterKind.productAdditionalIncomeSource, (short)EnumTexterKind.productAdditionalIncomeSource); } 
    internal List<Texter> getProductPriceLevelMeta() {  return get(null, (short)EnumTexterKind.productPriceLevel, (short)EnumTexterKind.productPriceLevel); }
    internal List<Texter> getProductInnovativeOptionMeta() { return get(null, (short)EnumTexterKind.productInnovativeOption, (short)EnumTexterKind.productInnovativeOption); }
    internal List<Texter> getProductQualityOptionMeta() { return get(null, (short)EnumTexterKind.productQualityOption, (short)EnumTexterKind.productQualityOption); }
    internal List<Texter> getProductDifferentiationOptionMeta() { return get(null, (short)EnumTexterKind.productDifferentiationOption, (short)EnumTexterKind.productDifferentiationOption); }
    internal List<Texter> getCostCategories() { return get(null, (short)EnumTexterKind.fixedCostCategory, (short)EnumTexterKind.variableCostCategory); }
    internal List<Texter> getCostTypes() { return get(null, (short)EnumTexterKind.costType, (short)EnumTexterKind.costType, ignoreMaster: true); }
    public List<Texter> getCostMeta() { return get(null, (short)EnumTexterKind.fixedCostCategory, (short)EnumTexterKind.costType, ignoreMaster: true); }
    public List<Texter> getRevenueStreamTypes() { return get(null, (short)EnumTexterKind.revenueStreamType, (short)EnumTexterKind.revenueStreamType, ignoreMaster: true); }
    public List<Texter> getRevenuePriceMeta() { return get(null, (short)EnumTexterKind.revenuePriceCategory, (short)EnumTexterKind.revenuePriceType, ignoreMaster: true); }
    public List<Texter> getChannelTypesMeta() { return get(null, (short)EnumTexterKind.channelType, (short)EnumTexterKind.channelDistribution, ignoreMaster: true); }


        public Texter Create(Texter me) {
      daContext.Texters.Add(me);
      daContext.SaveChanges();
      return me;
      }

    public Texter getById(Guid id) {
      var r=daContext.Texters.Where(x=>x.Id==id).FirstOrDefault();
      return r;
      }

    public void Delete(Texter me) {
      daContext.Texters.Remove(me);
      daContext.SaveChanges();
      }
    
    public void Save(Texter me)
    {
            daContext.SaveChanges();
    }

     protected override object[] getAll4snap() { return daContext.Texters.ToArray(); }
    protected override string myTable => "Texters";

    protected override void loadData(string json) {
      var o=Newtonsoft.Json.JsonConvert.DeserializeObject<KabadaAPIdao.Texter>(json);
      daContext.Texters.Add(o);
      }
}
  }
