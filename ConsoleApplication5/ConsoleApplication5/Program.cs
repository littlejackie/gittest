using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;

namespace ConsoleApplication5
{
    class Program
    {
        static void Main(string[] args)
        {
            string caption = string.Empty;
            string manufacturer = string.Empty;
            string model = string.Empty;
            string datawidth = string.Empty;
            ManagementObjectSearcher mos = new ManagementObjectSearcher();


            mos.Query.QueryString = "SELECT * FROM Win32_OperatingSystem";
            var osInfo = mos.Get().Cast<ManagementObject>().FirstOrDefault();
            caption = osInfo?.Properties["Caption"]?.Value.ToString();
            datawidth = osInfo?.Properties["OSArchitecture"]?.Value.ToString();

            mos.Query.QueryString = "SELECT * FROM Win32_ComputerSystem";
            var mainboardInfo = mos.Get().Cast<ManagementObject>().FirstOrDefault();
            manufacturer = mainboardInfo?.Properties["Manufacturer"]?.Value.ToString();
            model = mainboardInfo?.Properties["Model"]?.Value.ToString();

            Console.WriteLine($"{caption}|{manufacturer}|{model}|{datawidth}");
            Console.ReadLine();
        }
    }
}
