using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management.Automation;
namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            // AutoStartCleaner();
            //SwapFile();
            UninstallingPrograms();
 
        }
 
        private static void UninstallingPrograms()
        {
            PowerShell.Create().AddCommand("Remove-AppxPackage")
                                  .AddParameter("-Package", "Microsoft.People_2020.901.1724.0_neutral_~_8wekyb3d8bbwe")
                                     .Invoke();
        }
 
        private static void SwapFile()
        {
 
            RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Control\Session Manager\Memory Management", true);
            key.SetValue("ClearPageFileAtShutdown", "1");
            key.Close();
 
 
        }
 
        private static void AutoStartCleaner()
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
            key.DeleteValue("OneDrive");
            key.Close();
        }
    }
}
