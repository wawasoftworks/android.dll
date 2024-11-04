using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace androiddll
{
    public class AndroidDebugBridge
    {
       public string initDir = null;

        public string eg(string directory)
        {
            if (File.Exists(directory + "\\adb.exe")) {
                if (File.Exists(directory + "\\fastboot.exe"))
                {
                    initDir = directory;
                    return "OK";
                } else
                {
                    return "ERROR,Directory does not contain fastboot.exe .";
                }
            } else
            {
                return "ERROR,Directory does not contain adb.exe .";
            }
        }

        public string Adb(string command)
        {
            if (initDir == null) {
                return "ERROR,Please initialize directory before executing any command.";

            }
            else
            {
                Process p = new Process();
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.FileName = initDir + "\\adb.exe";
                p.StartInfo.Arguments = command;
                p.StartInfo.CreateNoWindow = true;
                p.Start();
                string output = p.StandardOutput.ReadToEnd();
                p.WaitForExit();
                return output;
            }
        }

        public string Fastboot(string command)
        {
            if (initDir == null)
            {
                return "ERROR,Please initialize directory before executing any command.";

            }
            else
            {
                Process p = new Process();
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.FileName = initDir + "\\fastboot.exe";
                p.StartInfo.Arguments = command;
                p.StartInfo.CreateNoWindow = true;
                p.Start();
                string output = p.StandardOutput.ReadToEnd();
                p.WaitForExit();
                return output;
            }
        }
    }
}
