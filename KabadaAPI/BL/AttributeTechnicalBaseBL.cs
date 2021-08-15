using Newtonsoft.Json;
using System;
using static KabadaAPI.Plan_AttributeRepository;

namespace KabadaAPI {
  public abstract class AttributeTechnicalBaseBL<T> where T:class, new() {
    public Guid id { get; private set; }
    protected short kind { get; private set; }
    public T e { get; private set; }
    public virtual short orderValue { get; set; }

    public AttributeTechnicalBaseBL(short kindToAssign) {
      id=Guid.NewGuid();
      kind=kindToAssign;
      e=new T();
      }

    public AttributeTechnicalBaseBL(short kindForValidate, short kindToAssign, Guid oldId, string packedValue) {
      if(kindForValidate!=kindToAssign)
        throw new Exception($"unequal kinds: required={kindForValidate}, from DB={kindToAssign}");
      kind=kindToAssign;
      id=oldId;
      
      e=JsonConvert.DeserializeObject<T>(packedValue);
      }

    public PlanAttributeKind Kind { get { return (PlanAttributeKind)kind; } protected set { kind=(short)value;} }

    public string packedValue { get { return JsonConvert.SerializeObject(e, 0, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }); }}      
    }
  }
