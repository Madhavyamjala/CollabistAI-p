using Collabist.Server.Domain.Entities;
using Collabist.Server.Infrastructure.Persistence;

namespace Collabist.Server.Application.Services
{
    /*SemanticIndexingService
        Purpose
            Generates semantic metadata for indexed files.
        Responsibilities
            Ensure semantic data stays in sync with file hashes
        Notes
            Safe to rerun
        TODO
            Add incremental reprocessing
     */

    public class SemanticIndexingService
    {
        private readonly CollabistDbContext _db;
        private readonly TextExtractionService _extractor;
        private readonly SemanticParsingService _parser;

        public SemanticIndexingService(
            CollabistDbContext db,
            TextExtractionService extractor,
            SemanticParsingService parser)
        {
            _db = db;
            _extractor = extractor;
            _parser = parser;
        }

        public void Process(Guid indexedFileId)
        {
            var file = _db.IndexedFiles.Find(indexedFileId);
            if (file == null)
                return;

            var exists = _db.SemanticDocuments
                .Any(s => s.IndexedFileId == indexedFileId);

            if (exists)
                return;

            var text = _extractor.Extract(file.FilePath);
            if (string.IsNullOrWhiteSpace(text))
                return;

            var semantic = _parser.Parse(text, indexedFileId);
            _db.SemanticDocuments.Add(semantic);
            _db.SaveChanges();
        }
    }
}
