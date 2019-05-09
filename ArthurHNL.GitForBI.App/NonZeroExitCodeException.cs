using ArthurHNL.GitForBI.App.Extensions;
using System;
using System.Diagnostics;

namespace ArthurHNL.GitForBI.App
{
    /// <summary>
    /// Immutable exception that is intended to be thrown when a <see cref="Process"/> exits with an exitcode
    /// other then 0.
    /// </summary>
    class NonZeroExitCodeException : Exception
    {
        public Process Process { get; }

        public NonZeroExitCodeException(CommandStart start, Process process) : base(
            $"Command {start.GetFriendlyName()} exited with code {process.ExitCode}.")
        {
            Process = process;
        }
    }
}
