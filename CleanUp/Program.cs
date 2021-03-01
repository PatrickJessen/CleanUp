using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;

namespace CleanUp
{
    class Program
    {
        static void Main(string[] args)
        {
            PcManager pManager = new PcManager();
            Console.WriteLine(pManager.GetDiskMetadata());
            Console.WriteLine(pManager.SearchProcessor());
            Console.WriteLine(pManager.MainStorage());
            Console.WriteLine(pManager.SelectAllOperatingSystem());
            Console.WriteLine(pManager.GetBootDevice());

            Console.WriteLine(pManager.GetHardDiskSerialNumber());

            
            Console.WriteLine("testhest slut");

            Console.WriteLine("process søgmimg");

            Console.WriteLine(pManager.ListAllServices());

            Console.WriteLine(pManager.PopulateDisk());
            Console.ReadKey();
        } //Slut main
    }   
}
