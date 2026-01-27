using System.Numerics;
using System.Reflection;

namespace Collabist.Server.Domain.Entities
{
/*AIPolicy
      Purpose
          Defines which AI execution modes are allowed.
      Responsibilities
          Controls model usage
          Enforces privacy and cost boundaries
          Acts as a gatekeeper for AI routing
      Notes
          Individual plan allows full control
          Future plans will restrict via admin policy
          Policy is evaluated before every AI request
      TODO
          Add per-knowledge-base overrides
          Add usage limits
          Add enforcement audit hooks
*/

    public class AIPolicy
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid OrganizationId { get; set; }

        public bool AllowLocalModels { get; set; } = true;

        public bool AllowCompanyCloud { get; set; } = true;

        public bool AllowOwnApi { get; set; } = true;
    }
}
