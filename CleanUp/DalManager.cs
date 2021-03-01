using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace CleanUp
{
    class DalManager
    {
        public ManagementObjectCollection GetDiskMetadata()
        {
            ManagementScope managementScope = new ManagementScope();
            ObjectQuery objectQuery = new ObjectQuery("select FreeSpace,Size,Name from Win32_LogicalDisk where DriveType=3");
            ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            ManagementObjectCollection managementObjectCollection = managementObjectSearcher.Get();

            return managementObjectCollection;
        }

        public ManagementObject GetHardDiskSerialNumber(string drive = "C")
        {
            ManagementObject managementObject = new ManagementObject("Win32_LogicalDisk.DeviceID=\"" + drive + ":\"");
            managementObject.Get();
            return managementObject;
        }

        public ManagementObjectCollection MainStorage()
        {
            ObjectQuery wql = new ObjectQuery("SELECT * FROM Win32_OperatingSystem");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(wql);
            ManagementObjectCollection results = searcher.Get();

            return results;
        }

        public ManagementObjectCollection SelectAllOperatingSystem()
        {
            ObjectQuery wql = new ObjectQuery("SELECT * FROM Win32_OperatingSystem");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(wql);
            ManagementObjectCollection results = searcher.Get();
            
            return results;
        }

        public ManagementObjectCollection GetBootDevice()
        {
            Console.WriteLine("testhest start");
            ManagementScope scope = new ManagementScope("\\\\.\\ROOT\\cimv2");
            //create object query
            ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_OperatingSystem");
            //create object searcher
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);
            //get a collection of WMI objects
            ManagementObjectCollection queryCollection = searcher.Get();
            //enumerate the collection.
            
            return queryCollection;

        }

        public ManagementObjectCollection ListAllServices()
        {
            ManagementObjectSearcher windowsServicesSearcher = new ManagementObjectSearcher("root\\cimv2", "select * from Win32_Service");
            ManagementObjectCollection objectCollection = windowsServicesSearcher.Get();

            return objectCollection;
        }

        public List<string> PopulateDisk()
        {
            List<string> disk = new List<string>();

            SelectQuery selectQuery = new SelectQuery("Win32_LogicalDisk");

            ManagementObjectSearcher mnagementObjectSearcher = new ManagementObjectSearcher(selectQuery);

            foreach (ManagementObject managementObject in mnagementObjectSearcher.Get())
            {
                disk.Add(managementObject.ToString());
            }
            return disk;
        }
    }
}
