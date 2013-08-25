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
        public static int EventWaitTimeout = 60000;
        
        protected void Execute()
        {
            var tempPath = Path.GetTempPath();
            var playground = Path.Combine(tempPath, "MoPlus-TestRun-" + Guid.NewGuid().ToString());

            Execute(playground);
        }

        internal void Execute(string playground)
        {
            if (Directory.Exists(playground))
            {
                // cleanup potential leftovers
                Directory.Delete(playground, true);
            }
            Directory.CreateDirectory(playground);

            // clean up any Mediator listeners:
            WorkspaceViewModel.mediator.Clear();

            WorkspaceViewModel.mediator.Register(MediatorMessages.Event_OutputChanged, new Action<StatusEventArgs>(OutputChanged));
            WorkspaceViewModel.mediator.Register(MediatorMessages.Event_StatusChanged, new Action<StatusEventArgs>(StatusChanged));
            WorkspaceViewModel.mediator.MessageUnhandled += mediator_MessageUnhandled;


            // execute the actual test.
            DoExecute(playground);
            if (EventWaitTimeout == -1)
            {
                // we're in debug mode, so don't remove anything
                return;
            }
            try
            {

                // cleanup after ourselves. We dont use a try..finaly, which would be cleaner 
                // here, but that can hide exceptions caused by the test. Rather have the test 
                // leave some garbage behind then:
                Directory.Delete(playground, true);
            }
            catch
            {
                // for now, db connections aren't closed properly, which means we cannot delete the database yet. 
                // this will happen next run (if playground is static)
            }
        }

        void mediator_MessageUnhandled(Type arg1, string arg2, object[] arg3)
        {
            Console.ForegroundColor=ConsoleColor.DarkYellow;
            Console.WriteLine("Message unhandled: '{0}', type = '{1}'", arg2, arg1.FullName);
            Console.ResetColor();
        }

        protected abstract void DoExecute(string playground);

        protected void StatusChanged(StatusEventArgs statusEventArgs)
        {
            Console.WriteLine("Status: {0}", statusEventArgs.Text);
        }

        protected void OutputChanged(StatusEventArgs statusEventArgs)
        {
            if (statusEventArgs.IsException)
            {
                throw new Exception(statusEventArgs.Title + ": " + statusEventArgs.Text);
            }
            Console.WriteLine("{0}: {1}", statusEventArgs.Title, statusEventArgs.Text);
        }
    }
}
