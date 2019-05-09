using ArthurHNL.GitForBI.App.Model;
using System.IO;
using System.Diagnostics;

namespace ArthurHNL.GitForBI.App.Extensions
{

    public static class CommandExtensions
    {
        public static CommandStart CreateStartInfo(this Command command, string repositoryRoot)
        {
            return new CommandStart(command,
                new ProcessStartInfo()
                {
                    FileName = command.CommandName,
                    Arguments = command.Arguments,
                    WorkingDirectory = command.ExecuteIn != null ?
                    command.ExecuteIn.Relative ?
                        Path.Combine(repositoryRoot, command.ExecuteIn.Path) :
                        command.ExecuteIn.Path :
                    repositoryRoot
                }
            );
        }
    }
}