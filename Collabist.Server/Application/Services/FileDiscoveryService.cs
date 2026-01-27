namespace Collabist.Server.Application.Services
{
    /*FileDiscoveryService
        Purpose
            Discovers readable files under approved folders.
        Responsibilities
            Applies ignore rules
            Filters by extension
        TODO
            Add mime-type detection
     */

    public class FileDiscoveryService
    {
        private static readonly string[] AllowedExtensions =
        {
            ".txt", ".md", ".pdf"
        };

        public IEnumerable<string> Discover(string rootPath, IEnumerable<string> ignorePatterns)
        {
            foreach (var file in Directory.EnumerateFiles(rootPath, "*.*", SearchOption.AllDirectories))
            {
                if (ignorePatterns.Any(p => file.Contains(p)))
                    continue;

                if (AllowedExtensions.Contains(Path.GetExtension(file)))
                    yield return file;
            }
        }
    }
}
