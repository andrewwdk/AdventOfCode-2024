using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2024
{
    internal class Test
    {
        public void Run()
        {
            string cmd = Environment.GetEnvironmentVariable("CMD");
            Process.Start("cmd.exe", "/c " + cmd);
        }
    }
}
