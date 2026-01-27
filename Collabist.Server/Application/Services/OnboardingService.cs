using Collabist.Server.Application.DTOs.Onboarding;
using Collabist.Server.Domain.Entities;
using Collabist.Server.Domain.Enums;
using Collabist.Server.Infrastructure.Persistence;

namespace Collabist.Server.Application.Services
{
    /*OnboardingService
        Purpose
            Handles first-time setup of the application for Individual users.
        Responsibilities
            Creates and persists organization
            Creates and persists user
            Creates and persists initial knowledge base
            Creates and persists AI policy
            Prevents onboarding from running more than once
        Notes
            Individual plan supports only one onboarding lifecycle
        TODO
            Add transactional safety
            Add startup and enterprise branching logic
            Handle multi-organization scenarios later
            Support soft-reset for enterprise use
     */

    public class OnboardingService
    {
        private readonly CollabistDbContext _db;

        public OnboardingService(CollabistDbContext db)
        {
            _db = db;
        }

        public OnboardingResponse Run(OnboardingRequest request)
        {
            if (_db.Organizations.Any())
            {
                return new OnboardingResponse
                {
                    Success = false
                };
            }

            var organization = new Organization();

            var user = new User
            {
                OrganizationId = organization.Id,
                DisplayName = request.DisplayName,
                Email = request.Email,
                Role = UserRole.Owner
            };

            var knowledgeBase = new KnowledgeBase
            {
                OrganizationId = organization.Id,
                Name = request.InitialKnowledgeBaseName
            };

            var aiPolicy = new AIPolicy
            {
                OrganizationId = organization.Id,
                AllowLocalModels = request.AllowLocalModels,
                AllowCompanyCloud = request.AllowCompanyCloud,
                AllowOwnApi = request.AllowOwnApi
            };

            _db.Organizations.Add(organization);
            _db.Users.Add(user);
            _db.KnowledgeBases.Add(knowledgeBase);
            _db.AIPolicies.Add(aiPolicy);

            _db.SaveChanges();

            return new OnboardingResponse
            {
                OrganizationId = organization.Id,
                UserId = user.Id,
                KnowledgeBaseId = knowledgeBase.Id,
                Success = true
            };
        }

        public OnboardingStatusResponse GetStatus()
        {
            return new OnboardingStatusResponse
            {
                IsOnboarded = _db.Organizations.Any()
            };
        }

    }
}
