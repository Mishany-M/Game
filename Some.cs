using Microsoft.Win32;
using System.Reflection;
using System.Diagnostics;

Stopwatch stopWatch = new Stopwatch();

stopWatch.Start();

DriveInfo[] drivers = DriveInfo.GetDrives();

string[] folders = { "Windows", "Program Files", "Intel" };

//string dir = Directory.GetCurrentDirectory();
Console.WriteLine("Введите деррикторию откуда:");

string dir = Console.ReadLine();

Console.WriteLine("Введите деррикторию куда:");

string currentpath = Console.ReadLine();

DirectoryInfo diinf = new DirectoryInfo(dir);

Console.WriteLine($"Программа запущена: {diinf.Name}");

try
{
    Run(Assembly.GetExecutingAssembly().Location);
}
catch (Exception ex)
{
    Console.WriteLine(ex.ToString());
    Console.ReadLine();
}

void create(string path, string begunpath)
{
    DirectoryInfo[] dirs = diinf.GetDirectories();
    if (dirs.Length != 0)
    {
        Console.WriteLine("Дирректории найдены:");
        foreach (DirectoryInfo dirr1 in dirs)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(dirr1);
        }
        foreach (DirectoryInfo dirr in dirs)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            diinf = new DirectoryInfo(path + "\\" + dirr.Name);
            diinf.Create();
            Console.WriteLine($"Дирректория {diinf.Name} создана");
            diinf = new DirectoryInfo(begunpath + "\\" + dirr.Name);
            FileInfo[] files = diinf.GetFiles();
            if (files.Length != 0)
            {
                Console.WriteLine("Пул файлов выгружен:");
                foreach (FileInfo file in files)
                {
                    file.CopyTo(path + "\\" + dirr.Name + "\\" + file.Name);
                    Console.WriteLine("Файл скопирован");
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Файлов нет");
                Console.ResetColor();
            }
            Console.ResetColor();
            try
            {
                create(path + "\\" + dirr.Name, begunpath + "\\" + dirr.Name);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.ReadLine();
            }
        }
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Дирректории не найдены");
        Console.ResetColor();
    }
}

void Run(string path)
{
    for (int i = 0; i < drivers.Length; i++)
    {
        for (int j = 0; j < folders.Length; j++)
        {
            if (Directory.Exists(drivers[i].Name + $"\\{folders[j]}"))
            {
                //string currentpath = drivers[i].Name + $"\\{folders[j]}";
                //string currentpath = "F:\\";
                //diinf = new DirectoryInfo(dir);
                Console.WriteLine("Путь найден");
                create(currentpath, dir);
                break;
            }
        }
    }

    const string assemblyName = "name";
    RegistryKey key = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run\\");
    key.SetValue(assemblyName, path);
    key.Flush();
    key.Close();
    Console.WriteLine("Feel Good");
    stopWatch.Stop();
    TimeSpan ts = stopWatch.Elapsed;
    Console.WriteLine($"{ts.Seconds:00}:{ts.Milliseconds:00}");
    Console.ReadLine();
}