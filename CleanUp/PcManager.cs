using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace CleanUp
{
    class PcManager
    {
        DalManager dManager = new DalManager();

        public string GetDiskMetadata()
        {
            string temp = "";
            foreach (ManagementObject managementObject in dManager.GetDiskMetadata())
            {
                temp += "Disk Name : " + managementObject["Name"].ToString() + "\n" +
                    "FreeSpace: " + managementObject["FreeSpace"].ToString() + "\n" +
                    "Disk Size: " + managementObject["Size"].ToString() + "\n" +
                    "---------------------------------------------------";
            }
            return temp;
        }

        public string SearchProcessor()
        {
            string temp = "";
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("select * from Win32_PerfFormattedData_PerfOS_Processor");
            foreach (ManagementObject obj in searcher.Get())
            {
                var usage = obj["PercentProcessorTime"];
                var name = obj["Name"];
                temp += "name " + " : " + "usage "+ "\n" + "CPU";
            }

            return temp;
        }

        public string MainStorage()
        {
            string temp = "";
            foreach (ManagementObject result in dManager.MainStorage())
            {
                temp += $"Total Visible Memory: {result["TotalVisibleMemorySize"]}KB \n Free Physical Memory: {result["FreePhysicalMemory"]}KB"+
                    $"\n Total Virtual Memory: {result["TotalVirtualMemorySize"]}KB \n Free Virtual Memory: {result["FreeVirtualMemory"]}KB";
            }
            return temp;
        }

        public string SelectAllOperatingSystem()
        {
            string temp = "";
            foreach (ManagementObject result in dManager.SelectAllOperatingSystem())
            {
                temp += $"User:\t{result["RegisteredUser"]} \n Org.:\t{result["Organization"]} \n O/S :\t{result["Name"]}";
            }
            return temp;
        }

        public string GetBootDevice()
        {
            string temp = "";
            foreach (ManagementObject m in dManager.GetBootDevice())
            {
                // access properties of the WMI object
                temp += $"BootDevice : {m["BootDevice"]}";
            }
            return temp;
        }

        public string ListAllServices()
        {
            string temp = $"There are {dManager.ListAllServices().Count} Windows services: ";

            foreach (ManagementObject windowsService in dManager.ListAllServices())
            {
                PropertyDataCollection serviceProperties = windowsService.Properties;
                foreach (PropertyData serviceProperty in serviceProperties)
                {
                    if (serviceProperty.Value != null)
                    {
                        temp += $"Windows service property name: {serviceProperty.Name} Windows service property value: {serviceProperty.Value} \n ---------------------------------------";
                    }
                }
            }

            return temp;
        }

        public string GetHardDiskSerialNumber()
        {
            return dManager.GetHardDiskSerialNumber()["VolumeSerialNumber"].ToString();
        }

        public string PopulateDisk()
        {
            List<string> newList = dManager.PopulateDisk();
            string temp = "";
            for (int i = 0; i < newList.Count; i++)
            {
                temp += newList[i];
                temp += "\n";
            }
            return temp;
        }
    }
}
