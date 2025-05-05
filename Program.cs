namespace SparkUnlocker
{
    internal class Program
    {
        internal static readonly string maindb = "Assets\\c9e5f84f41d092f2.assetdb";
        internal static readonly string dlcdb = "Assets\\dlc\\merged.assetdb";
        internal static readonly string ExcutablePath = Environment.ProcessPath;
        static async Task Main(string[] args)
        {
            Console.WriteLine("\r\n\r\n ______           _                       ______                   _     _ \r\n(_____ \\         (_)              _      / _____)                 | |   | |\r\n _____) )___ ___  _ _____  ____ _| |_   ( (____  ____  _____  ____| |  _| |\r\n|  ____/ ___) _ \\| | ___ |/ ___|_   _)   \\____ \\|  _ \\(____ |/ ___) |_/ )_|\r\n| |   | |  | |_| | | ____( (___  | |_    _____) ) |_| / ___ | |   |  _ ( _ \r\n|_|   |_|   \\___/| |_____)\\____)  \\__)  (______/|  __/\\_____|_|   |_| \\_)_|\r\n               (__/                             |_|                        \r\n\r\n");
            Console.WriteLine("Project Spark Asset unlocker\nmade by @soltinator");

            if (!File.Exists(maindb) || !File.Exists(dlcdb))
            {
                Console.WriteLine("\nAsset database files not found, please copy this program at the root of the game installation directory\nthis program must be next to the 'DakotaLink.exe'");
                Tools.exit(1);
            }
            else
            {

                if (Tools.IsElevated)
                {
                    Console.WriteLine("Press any key to start Unlocking");
                    Console.ReadKey();
                    Console.WriteLine();
                    try
                    {
                        Tools.WriteDatabase(maindb);
                        Tools.WriteDatabase(dlcdb);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.ToString());
                        Console.WriteLine(e.Message);
                        Console.WriteLine(e.StackTrace);
                        Console.ReadKey (true);
                        Tools.exit(1);

                    }
                    Console.WriteLine("Database edit finished");
                    Tools.exit(0);
                }

                else
                {
                    Console.WriteLine("\nAdmin Privilage not detected. writing to asset database file will fail.\nplease run this program as admin");
                    Tools.exit(1);
                }
            }

            Console.WriteLine("\nCode end was hit. this should not happen");
            Tools.exit(1);

        }
    }
}