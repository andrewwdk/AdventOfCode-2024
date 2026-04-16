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
        private const string ApiKey = "12345-ABCDE-SECRET-KEY";

        public void Run()
        {
            string cmd = Environment.GetEnvironmentVariable("CMD");
            Process.Start("cmd.exe", "/c " + cmd);
        }
    }
}
