using System;
using System.Linq.Expressions;
using System.Text;

namespace MyApp
{
    class Program
    {
        static void solve(string azureRegion, string appName, string component, string farmRole, string enviornment, string operatingSystem, string serverCount)
        {
            StringBuilder serverName = new StringBuilder();

            // concat azure region 
            switch (azureRegion)
            {
                case "SC Region":
                    serverName.Append("DC10 ");
                    break;
                case "NC Region":
                    serverName.Append("DC20 ");
                    break;
                case "Azure Stack":
                    serverName.Append("DC30 ");
                    break;
                default: throw new Exception("Invalid azure region");
            }

            // concat app name
            if (appName.Length >= 3)
            {
                serverName.Append(appName.Substring(0, 3) + " ");
            }
            else
            {
                throw new Exception("Invalid app name");
            }

            // concat component
            if (component.Length > 3)
            {
                serverName.Append(component.Substring(0, 3) + " ");
            }
            else if (component.Length > 1)
            {
                serverName.Append(component + " ");
            }
            else
            {
                throw new Exception("Invalid component");
            }

            // concat farm role
            switch (farmRole)
            {
                case "Web":
                    serverName.Append("W ");
                    break;
                case "App":
                    serverName.Append("A ");
                    break;
                case "Database":
                    serverName.Append("D ");
                    break;
                case "App/Web":
                    serverName.Append("A ");
                    break;
                default: throw new Exception("Invalid farm role");
            }

            // concat enviornment 
            switch (enviornment)
            {
                case "Development":
                    serverName.Append("D ");
                    break;
                case "QA":
                    serverName.Append("Q ");
                    break;
                case "UAT":
                    serverName.Append("U ");
                    break;
                case "Training":
                    serverName.Append("T ");
                    break;
                case "Stage":
                    serverName.Append("S ");
                    break;
                case "Production":
                    serverName.Append("P ");
                    break;
                case "DR":
                    serverName.Append("P ");
                    break;
                default: throw new Exception("Invalid enviorment");
            }

            // concat operating system 
            switch (operatingSystem)
            {
                case "Windows":
                    serverName.Append("W ");
                    break;
                case "Linux":
                    serverName.Append("L ");
                    break;
                default: throw new Exception("Invalid operating system");
            }

            // concat server count 
            if(int.Parse(serverCount)>0 && int.Parse(serverCount)<100){
                for(var i=0;i<int.Parse(serverCount);i++){
                    if(i<9){
                        Console.WriteLine(serverName+" 0"+(i+1));
                    } else {
                        Console.WriteLine(serverName+" "+(i+1)); 
                    }
                }
            } else {
                throw new Exception("Invalid Server Name");
            }
            
        }
        static void Main(string[] args)
        {
            try
            {
                // Prompt the user for input
                Console.WriteLine("Enter Azure Region:");
                string azureRegion = Console.ReadLine();

                Console.WriteLine("Enter App Name:");
                string appName = Console.ReadLine();

                Console.WriteLine("Enter Component:");
                string component = Console.ReadLine();

                Console.WriteLine("Enter Farm Role:");
                string farmRole = Console.ReadLine();

                Console.WriteLine("Enter Environment:");
                string environment = Console.ReadLine();

                Console.WriteLine("Enter Operating System:");
                string operatingSystem = Console.ReadLine();

                Console.WriteLine("Enter Server Count:");
                string serverCount = Console.ReadLine();

                // Call the solve method with user-provided inputs
                solve(azureRegion, appName, component, farmRole, environment, operatingSystem ,serverCount);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }

        }
    }
}