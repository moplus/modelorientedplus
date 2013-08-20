using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoPlus.ViewModel.Entities;
using MoPlus.ViewModel.Events;
using MoPlus.ViewModel.Interpreter;
using MoPlus.ViewModel.Messaging;
using MoPlus.ViewModel.Solutions;

namespace MoPlus.ViewModel.Tests.Staging
{
    public abstract class BaseTest
    {
        [TestMethod]
        public void Execute()
        {
            //WorkspaceViewModel.mediator.invocationList.

            var tempPath = Path.GetTempPath();
            var Playground = Path.Combine(tempPath, "MoPlus-TestRun-" + Guid.NewGuid().ToString());

            if (Directory.Exists(Playground))
            {
                // cleanup potential leftovers
                Directory.Delete(Playground, true);
            }
            Directory.CreateDirectory(Playground);

            // execute the actual test.
            DoExecute(Playground);

            // cleanup after ourselves. We dont use a try..finaly, which would be cleaner 
            // here, but that can hide exceptions caused by the test. Rather have the test 
            // leave some garbage behind then:
            Directory.Delete(Playground, true);
        }

        protected abstract void DoExecute(string playground);
    }
}
