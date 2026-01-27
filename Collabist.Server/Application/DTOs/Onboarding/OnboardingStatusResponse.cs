namespace Collabist.Server.Application.DTOs.Onboarding
{
    /*OnboardingStatusResponse
        Purpose
            Represents the onboarding completion state of the application.
        Responsibilities
            Indicates whether onboarding has already been completed
        Notes
            Used by frontend during application startup
        TODO
            Add additional state metadata if needed
     */

    public class OnboardingStatusResponse
    {
        public bool IsOnboarded { get; set; }
    }
}
