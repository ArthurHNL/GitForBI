using ArthurHNL.GitForBI.App.Model;
using ArthurHNL.GitForBI.App.Extensions;
using Newtonsoft.Json;
using System;
using System.IO;

namespace ArthurHNL.GitForBI.App
{
    class Program
    {
        static void Main()
        {
            var config = JsonConvert.DeserializeObject<Config>(File.ReadAllText("config.json"));

            Console.WriteLine("Please keep the following warnings in mind before running this tool:");
            foreach (var warning in config.GetAllWarnings())
            {
                Console.WriteLine(warning);
            }

            Console.Write(
                "\n" +
                "\n" +
                $"Please enter the name of the branch you want to pull, or leave empty for the default branch ({config.DefaultBranch})\n> ");

            var branch = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(branch))
            {
                branch = config.DefaultBranch;
            }

            var commands = CommandBatchQueueFactory.CreateCommandBatchQueue(config, branch);

            try
            {
                CommandRunner.RunCommands(commands);
            } catch (NonZeroExitCodeException ex)
            {
                Console.Error.WriteLine(ex.Message);
                Environment.Exit(-1);
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }
    }
}
