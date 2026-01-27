using Collabist.Server.Domain.Entities;

namespace Collabist.Server.Application.Services
{
    /*SemanticParsingService
        Purpose
            Generates lightweight semantic metadata for files.
        Responsibilities
            Produce summaries and keywords
        Notes
            Uses small model or heuristic logic
        TODO
            Replace mock logic with Gemma call
     */

    public class SemanticParsingService
    {
        public SemanticDocument Parse(string text, Guid indexedFileId)
        {
            var summary = text.Length > 500
                ? text.Substring(0, 500)
                : text;

            var keywords = ExtractKeywords(text);

            return new SemanticDocument
            {
                IndexedFileId = indexedFileId,
                Summary = summary,
                Keywords = keywords,
                DocumentType = InferType(text)
            };
        }

        private string ExtractKeywords(string text)
        {
            var words = text
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .GroupBy(w => w.ToLower())
                .OrderByDescending(g => g.Count())
                .Take(10)
                .Select(g => g.Key);

            return string.Join(", ", words);
        }

        private string InferType(string text)
        {
            if (text.Contains("class ") || text.Contains("function "))
                return "Code";

            if (text.Contains("#") || text.Contains("##"))
                return "Markdown";

            return "Text";
        }
    }
}
