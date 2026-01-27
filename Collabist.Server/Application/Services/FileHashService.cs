using System.Security.Cryptography;
using System.Text;

namespace Collabist.Server.Application.Services
{
    /*FileHashService
        Purpose
            Generates stable hashes for files.
        Responsibilities
            Detects file changes efficiently
        Notes
            Uses SHA256
        TODO
            Optimize for large files
     */

    public class FileHashService
    {
        public string Compute(string path)
        {
            using var stream = File.OpenRead(path);
            using var sha = SHA256.Create();
            var hash = sha.ComputeHash(stream);
            return Convert.ToHexString(hash);
        }
    }
}
