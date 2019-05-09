using ArthurHNL.GitForBI.App.Extensions;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ArthurHNL.GitForBI.App
{
    public static class CommandRunner
    {
        public static void RunCommands(Queue<IList<CommandStart>> commands)
        {
            while(commands.Count != 0)
            {
                var batch = commands.Dequeue();
                var running = new Dictionary<CommandStart, Process>();

                foreach (var command in batch)
                    running[command] = command.Start();

                foreach(var command in running.Keys)
                {
                    var process = running[command];
                    process.WaitForExit();
                    if(process.ExitCode != 0 && !command.Command.AllowFailure)
                    {
                        throw new NonZeroExitCodeException(command, process);
                    }
                }
            }
        }
    }
}
