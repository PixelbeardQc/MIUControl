using System;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;

namespace MIUCONTROL
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Guid commandId = new Guid("00000000-0000-0000-0000-000000000000");
            var commandArgs = new string[] { };


            if (args.Length == 0)
            {
                Console.WriteLine("Use /CommandId=00000000-0000-0000-0000-000000000000 ");
                Console.WriteLine("Where 00000000-0000-0000-0000-000000000000 is the Command GUID");
                Console.WriteLine(" ");
                Console.WriteLine("Use /allargs=\"any variables you need to pass\"");
                Console.WriteLine(" ");
                Console.WriteLine("Updated 14 may 2021");
                Console.WriteLine("twitch.tv/pixelbeardqc");
                Console.WriteLine("Big thanks to CKY and Tyren");
                return;
            }
            foreach (string arg in args)
            {
                if (arg.StartsWith("/CommandId", true, System.Globalization.CultureInfo.CurrentCulture))
                {
                    string[] id = arg.Split('=');
                    Console.WriteLine(id[1]);
                    commandId = Guid.Parse(id[1]);
                    Console.WriteLine(arg);
                }
                if (arg.StartsWith("/allargs", true, System.Globalization.CultureInfo.CurrentCulture))
                {
                    string[] var = arg.Split('=');
                    Console.WriteLine(var[1]);
                    commandArgs = var[1].Split(" ");
                    Console.WriteLine(arg);
                }
            }

            await MixItUp.API.Commands.RunCommandAsync(commandId, commandArgs);
        }
    }
}
        