using Collabist.Server.Application.DTOs.Onboarding;
using Collabist.Server.Application.Services;
using Collabist.Server.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace Collabist.Server.Controllers
{
    /*OnboardingController
        Purpose
            Exposes onboarding API endpoint for first-time setup.
        Responsibilities
            Accept onboarding payload
            Persist onboarding state
            Prevent duplicate onboarding
        TODO
            Add detailed error responses
     */

    [ApiController]
    [Route("api/onboarding")]
    public class OnboardingController : ControllerBase
    {
        private readonly OnboardingService _service;

        public OnboardingController(CollabistDbContext db)
        {
            _service = new OnboardingService(db);
        }

        [HttpPost]
        public ActionResult<OnboardingResponse> Run(OnboardingRequest request)
        {
            var result = _service.Run(request);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("status")]
        public ActionResult<OnboardingStatusResponse> Status()
        {
            var status = _service.GetStatus();
            return Ok(status);
        }

    }
}
