using System;
using System.Linq.Expressions;
using System.Text;

namespace MyApp
{
    class Program
    {
        static StringBuilder solve(string azureRegion, string appName, string component, string farmRole, string enviornment, string operatingSystem, string seqNumber)
        {
            StringBuilder serverName = new StringBuilder();

            // concat azure region 
            switch (azureRegion) {
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
            if (appName.Length >= 3) {
                serverName.Append(appName.Substring(0, 3) + " ");
            } else {
                throw new Exception("Invalid app name");
            }

            // concat component
            if (component.Length > 3) {
                serverName.Append(component.Substring(0, 3) + " ");
            }
            else if (component.Length > 1) {
                serverName.Append(component + " ");
            } else {
                throw new Exception("Invalid component");
            }

            // concat farm role
            switch (farmRole) {
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
            switch (enviornment) {
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
            switch (operatingSystem) {
                case "Windows":
                    serverName.Append("W ");
                    break;
                case "Linux":
                    serverName.Append("L ");
                    break;
                default: throw new Exception("Invalid operating system");
            }

            // concat seq number 
            serverName.Append(seqNumber);

            return serverName;
        }
        static void Main(string[] args)
        {
            try
            {
                // Test Case 1: Basic case with all valid inputs
                var testCase1 = solve("SC Region", "MyA", "Co", "Web", "Development", "Windows", "12345");
                Console.WriteLine($"Test Case 1: {testCase1}");

                // Test Case 2: Another basic case with all valid inputs
                var testCase2 = solve("NC Region", "YourApp", "Component2", "App", "QA", "Linux", "67890");
                Console.WriteLine($"Test Case 2: {testCase2}");

                // Test Case 3: Case with different Azure region and farm role
                var testCase3 = solve("Azure Stack", "TheirApp", "Component3", "Database", "Production", "Windows", "54321");
                Console.WriteLine($"Test Case 3: {testCase3}");

                // Test Case 4: Case with long app name and component
                var testCase4 = solve("SC Region", "LongApplicationName", "LongComponentName", "App/Web", "Training", "Linux", "98765");
                Console.WriteLine($"Test Case 4: {testCase4}");

                // Test Case 5: Case with different environment and operating system
                var testCase5 = solve("NC Region", "TestApp", "Component4", "Web", "Stage", "Linux", "45678");
                Console.WriteLine($"Test Case 5: {testCase5}");

                // Test Case 6: Case with invalid azure region
                var testCase6 = solve("Invalid Region", "App", "Component5", "Web", "Development", "Windows", "13579");
                Console.WriteLine($"Test Case 6: {testCase6}");

                // Test Case 7: Case with invalid farm role
                var testCase7 = solve("SC Region", "App", "Component6", "InvalidRole", "Development", "Windows", "24680");
                Console.WriteLine($"Test Case 7: {testCase7}");

                // Test Case 8: Case with invalid environment
                var testCase8 = solve("NC Region", "App", "Component7", "App", "InvalidEnv", "Windows", "87654");
                Console.WriteLine($"Test Case 8: {testCase8}");

                // Test Case 9: Case with invalid operating system
                var testCase9 = solve("Azure Stack", "App", "Component8", "Database", "Production", "InvalidOS", "98765");
                Console.WriteLine($"Test Case 9: {testCase9}");

                // Test Case 10: Case with empty app name and component
                var testCase10 = solve("SC Region", "", "", "Web", "Development", "Windows", "11111");
                Console.WriteLine($"Test Case 10: {testCase10}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }

        }
    }
}