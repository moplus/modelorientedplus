using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoPlus.ViewModel.Tests.Staging;

namespace MoPlus.ViewModel.Tests.MSSQLReverseEngineering
{
    [TestClass]
    public class TestLocaldb
    {
        [TestMethod]
        public void DoIt()
        {
            var exe = "sqllocaldb.exe";
            var arguments = "i";
            Execute(exe, arguments);
        }

        public static void Execute(string exe, string arguments)
        {
            var psi = new ProcessStartInfo(exe, arguments);
            psi.RedirectStandardError = false;
            psi.RedirectStandardOutput = false;
            psi.UseShellExecute = false;
            var p = Process.Start(psi);
            p.OutputDataReceived += (sender, args) => Console.Write(args.Data);
            p.ErrorDataReceived += (sender, args) =>
                                   {
                                       Console.Write(args.Data);
                                   };
            Assert.IsTrue(p.WaitForExit(BaseTest.EventWaitTimeout));
            Assert.AreEqual(p.ExitCode, 0);
        }
    }
}