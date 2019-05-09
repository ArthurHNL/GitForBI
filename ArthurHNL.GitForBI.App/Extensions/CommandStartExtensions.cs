using System.Diagnostics;

namespace ArthurHNL.GitForBI.App.Extensions
{
    public static class CommandStartExtensions
    {
        public static string GetFriendlyName(this CommandStart start)
            => $"{start.Command.CommandName} {start.Command.Arguments}";

        public static Process Start(this CommandStart start)
            => Process.Start(start.StartInfo);
    }
}
