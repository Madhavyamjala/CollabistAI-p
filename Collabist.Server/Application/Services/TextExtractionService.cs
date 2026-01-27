namespace Collabist.Server.Application.Services
{
    /*TextExtractionService
        Purpose
            Extracts readable text from files.
        Responsibilities
            Provide raw text for semantic parsing
        Notes
            Limited to basic formats initially
        TODO
            Add PDF and DOCX extraction
     */

    public class TextExtractionService
    {
        public string Extract(string filePath)
        {
            return Path.GetExtension(filePath) switch
            {
                ".txt" => File.ReadAllText(filePath),
                ".md" => File.ReadAllText(filePath),
                _ => string.Empty
            };
        }
    }
}
