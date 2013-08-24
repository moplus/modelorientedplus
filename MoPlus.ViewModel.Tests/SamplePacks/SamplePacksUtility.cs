using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoPlus.ViewModel.Tests.SamplePacks
{
    public static class SamplePacksUtility
    {
        public static void ExtractGettingStartedTo(string directory)
        {
            ExtractPackTo("GettingStarted.zip", directory);
        }

        public static void ExtractSampleCSharpSQLServerXmlTo(string directory)
        {
            ExtractPackTo("Sample_CSharp_SQLServer_MySQL_Xml.zip", directory);
        }

        private static void ExtractPackTo(string pack, string directory)
        {
            var tempSourceFile = Path.GetTempFileName();
            {
                using (var f = new FileStream(tempSourceFile, FileMode.Create))
                {
                    using (var input = GetManifestStream(pack))
                    {
                        input.CopyTo(f);
                    }
                }

                ZipFile.ExtractToDirectory(tempSourceFile, directory);
            }
            File.Delete(tempSourceFile);
        }

        private static Stream GetManifestStream(string name)
        {
            var stream = typeof(SamplePacksUtility).Assembly.GetManifestResourceStream(typeof(SamplePacksUtility), name);
            if (stream == null)
            {
                throw new Exception("Cannot find '" + name + "' resource!");
            }

            return stream;
        }

    }
}