﻿using System;
using static KabadaAPI.Plan_AttributeRepository;

namespace KabadaAPI {
  public class ChannelBL : BAsePlan_AttributeTypedBL<ChannelElementBL> { // Plan_AttributeBL<ChannelElementBL> {
    private const short KIND=(short)PlanAttributeKind.channel;

    public ChannelBL(Guid plan, Guid texter) : base(KIND, plan, texter) {}
    public ChannelBL(KabadaAPIdao.Plan_Attribute old, bool forUpdate=false, Guid? planForValidate=null) : base(old, forUpdate, planForValidate, kindForValidate: KIND){}
    public ChannelBL(Guid byId, Plan_AttributeRepository repo, Guid? planForValidate=null) : base(byId, repo, true, planForValidate, KIND) {}
    }
  }
