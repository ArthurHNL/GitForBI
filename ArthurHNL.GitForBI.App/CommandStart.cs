using ArthurHNL.GitForBI.App.Model;
using System.Diagnostics;

namespace ArthurHNL.GitForBI.App
{
    public struct CommandStart
    {
        public Command Command { get; }
        public ProcessStartInfo StartInfo { get; }

        public CommandStart(Command command, ProcessStartInfo startInfo)
        {
            Command = command;
            StartInfo = startInfo;
        }
    }
}
