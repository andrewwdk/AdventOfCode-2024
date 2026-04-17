using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

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

        public void Run5()
        {
            string data = Environment.GetEnvironmentVariable("DATA");
            var bytes = Convert.FromBase64String(data);

            var formatter = new BinaryFormatter(); // flagged as unsafe
            var obj = formatter.Deserialize(new MemoryStream(bytes));
        }

        public void Run6()
        {
            string user = Environment.GetEnvironmentVariable("USER");

            string filter = "(cn=" + user + ")"; // unsafe concatenation

            var entry = new DirectoryEntry();
            var searcher = new DirectorySearcher(entry, filter);
            searcher.FindOne();
        }

        public void Run7()
        {
            string xml = Environment.GetEnvironmentVariable("XML");

            var settings = new XmlReaderSettings();
            settings.DtdProcessing = DtdProcessing.Parse; // unsafe

            using var reader = XmlReader.Create(new StringReader(xml), settings);
            while (reader.Read()) { }
        }
    }
}
