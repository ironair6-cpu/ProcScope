using System;
using System.Diagnostics;

class Program {
    static void Main() 
    {
        string? name = Console.ReadLine();
        if (name != "\n")
        {
            Process[] processes = Process.GetProcessesByName(name);

            if (processes.Length == 0)
            {
                Console.Write($"No processes found with name: {name}");
                return;
            }

            showNamedProcesses(name);
        }
        else showAllProcesses();
        //showNamedProcesses("Security");
    }


    static void showAllProcesses()
    {
        foreach (Process process in Process.GetProcesses())
        {
            try
            {
                Console.Write(
                    $"PID: {process.Id} Name: {process.ProcessName}\n"    
                );
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("Process is no longer available.");
            }
            finally
            {
                process.Dispose();
            }
        }
    }

    static void showNamedProcesses(string? name)
    {
        foreach (Process process in Process.GetProcessesByName(name))
        {
            try
            {
                Console.Write(
                    $"PID: {process.Id} Name: {process.ProcessName}\n"
                );
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("Process is no longer available.");
            }
            finally
            {
                process.Dispose();
            }
        }
    }
}