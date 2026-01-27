using Collabist.Server.Application.DTOs.KnowledgeBase;
using Collabist.Server.Domain.Entities;
using Collabist.Server.Infrastructure.Persistence;

namespace Collabist.Server.Application.Services
{
    /*KnowledgeBaseService
        Purpose
            Handles knowledge base lifecycle operations.
        Responsibilities
            Create knowledge bases
            List knowledge bases
        Notes
            Assumes single-organization context for Individual plan
        TODO
            Add organization scoping
            Add update and delete operations
     */

    public class KnowledgeBaseService
    {
        private readonly CollabistDbContext _db;

        public KnowledgeBaseService(CollabistDbContext db)
        {
            _db = db;
        }

        public KnowledgeBaseResponse Create(CreateKnowledgeBaseRequest request)
        {
            var org = _db.Organizations.First();

            var kb = new KnowledgeBase
            {
                OrganizationId = org.Id,
                Name = request.Name,
                Description = request.Description
            };

            _db.KnowledgeBases.Add(kb);
            _db.SaveChanges();

            return new KnowledgeBaseResponse
            {
                Id = kb.Id,
                Name = kb.Name,
                Description = kb.Description,
                CreatedAt = kb.CreatedAt
            };
        }

        public IEnumerable<KnowledgeBaseResponse> GetAll()
        {
            return _db.KnowledgeBases.Select(kb => new KnowledgeBaseResponse
            {
                Id = kb.Id,
                Name = kb.Name,
                Description = kb.Description,
                CreatedAt = kb.CreatedAt
            }).ToList();
        }
    }
}
