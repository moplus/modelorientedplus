using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoPlus.Interpreter.BLL.Solutions;

namespace MoPlus.ViewModel.Tests.MSSQLReverseEngineering
{
    public static class MSBuildUtility
    {
        private static string MSBuildFileName
        {
            get
            {
                return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), "Microsoft.NET", "Framework", "v4.0.30319", "msbuild.exe");
            }
        }

        public static void Execute(string solutionFile, bool multiThreaded = false)
        {
            var sbParams = new StringBuilder();
            if (!File.Exists(solutionFile))
            {
                throw new FileNotFoundException("Solution file doesn't exist", solutionFile);
            }
            sbParams.AppendFormat("\"{0}\" ", solutionFile);

            if (multiThreaded)
            {
                sbParams.AppendFormat("/m ");
            }

            TestLocaldb.Execute(MSBuildFileName, sbParams.ToString());
        }
    }
}