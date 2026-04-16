using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
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

        public void Run2()
        {
            string password = "test123";
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(password));
        }

        public void Run3()
        {
            string filename = Environment.GetEnvironmentVariable("FILE_NAME");
            string path = "C:\\temp\\" + filename;

            File.WriteAllText(path, "test");
        }

        public void Run4()
        {
            string userInput = Environment.GetEnvironmentVariable("USER_INPUT");

            string query = "SELECT * FROM Users WHERE Name = '" + userInput + "'";

            using (var conn = new SqlConnection("Server=.;Database=Test;Trusted_Connection=True;"))
            {
                conn.Open();
                var cmd = new SqlCommand(query, conn);
                cmd.ExecuteReader();
            }
        }
    }
}
