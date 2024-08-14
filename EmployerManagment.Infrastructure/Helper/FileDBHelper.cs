using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployerManagment.Infrastructure.Helper
{
    public class FileDBHelper
    {
        private const string NameOfFile = "EmployeeDB.json";

        public static string GetPathOfFile() => Environment.CurrentDirectory;
        public static string GetNameOfFile() => NameOfFile;
        public static Stream GetStreamDBFile() => new FileStream(GetFullPathDBFile(), FileMode.Open, FileAccess.Read);
        public static string GetFullPathDBFile() => $"{GetPathOfFile()}/{GetNameOfFile()}" ?? throw new ArgumentNullException("Cannot load DB path");
        public static string ReturnTable() => File.ReadAllText(GetFullPathDBFile());
    }
}
