using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using static KabadaAPI.Plan_AttributeRepository;

namespace KabadaAPI.Controllers {
  [Route("api/custSegs")]
  [ApiController]
  public class CustomerSegmentsController : KController {
    public CustomerSegmentsController(ILogger<KController> logger, IConfiguration configuration) : base(logger, configuration) {}

   [Route("codifiers")]
   [HttpGet]
        public ActionResult<CustomerSegmentsCodifiers> Categories() { return Grun<CustomerSegmentsCodifiers>(_Categories); }
        private ActionResult<CustomerSegmentsCodifiers> _Categories()
        {
            var r = new CustomerSegmentsCodifiers();
            r.read(context);
            return r;
        }

    [HttpDelete]
    [Authorize]
    [Route("{consumer}")]
    public IActionResult DeleteMe(Guid consumer) { return prun<Guid>(_DeleteMe, consumer); }
    private IActionResult _DeleteMe(Guid resource) { Plan_SpecificAttributesRepository.DeleteAttribute(context, resource, PlanAttributeKind.consumerSegment); return Ok("deleted");}

    [HttpDelete]
    [Authorize]
    [Route("{business}")]
    public IActionResult DeleteBusiness(Guid business) { return prun<Guid>(_Deletebusiness, business); }
    private IActionResult _Deletebusiness(Guid resource) { Plan_SpecificAttributesRepository.DeleteAttribute(context, resource, PlanAttributeKind.businessSegment); return Ok("deleted");}

    [HttpDelete]
    [Authorize]
    [Route("{ngo}")]
    public IActionResult Deletengo(Guid ngo) { return prun<Guid>(_Deletengo, ngo); }
    private IActionResult _Deletengo(Guid resource) { Plan_SpecificAttributesRepository.DeleteAttribute(context, resource, PlanAttributeKind.ngoSegment); return Ok("deleted");}

    [HttpPost]
    [Authorize]
    [Route("updateConsumer")]
    public ActionResult<Guid> UpdateConsumer(ConsumerSegmentPOST update) { return Prun<ConsumerSegmentPOST, Guid>(_Update, update); }
    private ActionResult<Guid> _Update(ConsumerSegmentPOST update){
      Guid r = update.perform(context, (short)PlanAttributeKind.consumerSegment);
      return r;
      }

    [HttpPost]
    [Authorize]
    [Route("updateBusiness")]
    public ActionResult<Guid> UpdateBusiness(BusinessSegmentPOST update) { return Prun<BusinessSegmentPOST, Guid>(_Update, update); }
    private ActionResult<Guid> _Update(BusinessSegmentPOST update){
      Guid r = update.perform(context, (short)PlanAttributeKind.businessSegment);
      return r;
      }

    [HttpPost]
    [Authorize]
    [Route("updatengo")]
    public ActionResult<Guid> UpdateNgo(NgoSegmentPOST update) { return Prun<NgoSegmentPOST, Guid>(_Update, update); }
    private ActionResult<Guid> _Update(NgoSegmentPOST update){
      Guid r = update.perform(context, (short)PlanAttributeKind.ngoSegment);
      return r;
      }

    [HttpGet]
    [Authorize]
    [Route("{BusinessPlan}")]
    public ActionResult<CustomerSegments> MySegments(Guid BusinessPlan) { return Prun<Guid, CustomerSegments>(_MySegments, BusinessPlan); }
    private ActionResult<CustomerSegments> _MySegments(Guid planId) {
       var r = new CustomerSegments();
       r.read(context, planId);
       return r;
       }
    }
  }
