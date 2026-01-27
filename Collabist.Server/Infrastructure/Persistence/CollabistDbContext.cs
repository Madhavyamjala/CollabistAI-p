using Collabist.Server.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Collabist.Server.Infrastructure.Persistence
{
    /*CollabistDbContext
        Purpose
            Represents the database session for the Collabist application.
        Responsibilities
            Persists core domain entities
            Acts as the boundary between domain and database
        Notes
            Uses SQLite for local-first persistence
            Designed to scale to multi-organization later
        TODO
            Add configuration for enterprise databases
            Add soft-delete filters
     */

    public class CollabistDbContext : DbContext
    {
        public DbSet<Organization> Organizations => Set<Organization>();
        public DbSet<User> Users => Set<User>();
        public DbSet<KnowledgeBase> KnowledgeBases => Set<KnowledgeBase>();
        public DbSet<DataSource> DataSources => Set<DataSource>();
        public DbSet<IndexedFile> IndexedFiles => Set<IndexedFile>();
        public DbSet<AIPolicy> AIPolicies => Set<AIPolicy>();
        public DbSet<SemanticDocument> SemanticDocuments => Set<SemanticDocument>();
        public CollabistDbContext(DbContextOptions<CollabistDbContext> options)
            : base(options)
        {
        }
    }
}
