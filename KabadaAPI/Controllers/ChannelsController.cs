using Kabada;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using Microsoft.AspNetCore.Authorization;
using static KabadaAPI.Plan_AttributeRepository;
using static KabadaAPI.TexterRepository;

namespace KabadaAPI.Controllers
{
  [Route("api/channels")]
  [ApiController]
  public class ChannelsController : KController {
    public ChannelsController(ILogger<KController> logger, IConfiguration configuration) : base(logger, configuration) {}

    protected TexterRepository tRepo { get { return new TexterRepository(context); }}
    protected Plan_AttributeRepository paRepo { get { return new Plan_AttributeRepository(context); }}
    protected BusinessPlansRepository pRepo { get { return new BusinessPlansRepository(context); }}

        [HttpGet]
        [Authorize]
        [Route("{BusinessPlan}")]
        public ActionResult<PlanChannels> MyChannels(Guid BusinessPlan) { return Prun<Guid, PlanChannels>(_MyChannels, BusinessPlan); }
        private ActionResult<PlanChannels> _MyChannels(Guid planId)
        {
            var r = new PlanChannels();
            r.read(context, planId);
            return r;
        }
        [Route("types")]
        [HttpGet]
        public ActionResult<ChannelTypes> Categories() { return Grun<ChannelTypes>(_Categories); }
        private ActionResult<ChannelTypes> _Categories()
        {
            var r = new ChannelTypes();
            r.read(context);
            return r;
        }
       

        [HttpDelete]
        [Authorize]
        [Route("{resource}")]
        public IActionResult DeleteMe(Guid resource) { return prun<Guid>(_DeleteMe, resource); }
        private IActionResult _DeleteMe(Guid resource) { Plan_AttributeRepository.DeleteAttribute(context, resource); return Ok("deleted"); }

        [HttpPost]
        [Authorize]
        [Route("save")]
        public ActionResult<Guid> Save(PlanChannelPoster update) { return Prun<PlanChannelPoster, Guid>(_Save, update); }
        private ActionResult<Guid> _Save(PlanChannelPoster update)
        {
            Guid r = update.perform(context);
            return r;
        }
        
    }
}
