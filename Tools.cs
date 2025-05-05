using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace SparkUnlocker
{
    internal class Tools
    {
        internal static bool IsElevated
        {
            get
            {
                var id = WindowsIdentity.GetCurrent();
                return id.Owner != id.User;
            }
        }
        internal static void exit (int exitCode)
        {
            Console.WriteLine("Press any Key to close");
            Console.ReadKey();
            Environment.Exit(exitCode);
        }

        internal static void WriteDatabase(string databasePath)
        {

            using (SqliteConnection Connection = new SqliteConnection("Data Source=" + databasePath + ";\r\n")) //TODO set reletive path
            {
                Console.WriteLine($"Opened database: ({databasePath})");
                SqliteCommand command = Connection.CreateCommand();
                command.CommandText = "UPDATE AssetMeta SET Browsable = 1, Locked = 0 WHERE Deprecated = 0; ";
                Connection.Open();
                int effected = command.ExecuteNonQuery();
                Console.WriteLine($"Rows traversed: ({effected})");
            }
        }
    }
}
