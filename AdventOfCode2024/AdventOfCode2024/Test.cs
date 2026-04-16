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
            string input = Environment.GetEnvironmentVariable("CMD");

            // Snyk flags this as Command Injection
            Process.Start("bash", "-c \"" + input + "\"");
        }
    }
}
