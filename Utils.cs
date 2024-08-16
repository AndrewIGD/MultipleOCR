using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MultipleOCR
{
    public static class Utils
    {
        public static string GetFileDestination(string path, string output)
        {
            var fileName = Path.GetFileName(path);
            var destination = Path.Combine(output, fileName);

            return destination;
        }
    }
}
