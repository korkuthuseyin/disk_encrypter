using System;
using System.Diagnostics;

namespace YourNamespace
{
    public class DiskInfo
    {
        public static string GetDiskSerialNumber()
        {
            string serialNumber = "";
            ProcessStartInfo psi = new ProcessStartInfo("wmic", "diskdrive get serialnumber");
            psi.RedirectStandardOutput = true;
            psi.UseShellExecute = false;
            psi.CreateNoWindow = true;

            Process process = Process.Start(psi);
            process.WaitForExit();

            serialNumber = process.StandardOutput.ReadToEnd().Split('\n')[1].Trim(); // Get the serial number
            return serialNumber;
        }
    }
}
