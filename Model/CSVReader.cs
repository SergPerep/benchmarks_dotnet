using System.Reflection;

namespace Benchmarks.Model
{
    public class CSVReader
    {
        public string ReadEmbeddedCsv(string filename)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = assembly.GetManifestResourceNames()
                                       .FirstOrDefault(r => r.EndsWith(filename));

            if (resourceName == null)
                throw new Exception($"Resource '{filename}' not found. Available: {string.Join(", ", assembly.GetManifestResourceNames())}");

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }
    }
}