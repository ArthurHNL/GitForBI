using ArthurHNL.GitForBI.App.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ArthurHNL.GitForBI.App.Extensions
{
    /// <summary>
    /// Class that provides extension methods for the <see cref="Config"/> type.
    /// </summary>
    public static class ConfigExtensions
    {
        public static IEnumerable<string> GetAllWarnings(this Config config)
            => config.PrePullCommands
                .GetWarnings()
                .Concat(
                    config.PostPullCommands
                    .GetWarnings())
                .Distinct();


        private static IEnumerable<string> GetWarnings(this IEnumerable<Command> commands)
            => commands
                .Select(x => x.Warning)
                .Distinct()
                .Where(x => x != null);

        public static CommandStart CreateGitCommandStart(
            this Config config,
            GitOperation operation,
            string argument = null)
        {
            var arguments = operation.CreateGitArguments(argument);
            var command = new Command()
            {
                CommandName = "git",
                Arguments = arguments
            };

            var startInfo = new ProcessStartInfo()
            {
                FileName = config.GitPath,
                Arguments = arguments,
                WorkingDirectory = config.RepoDir
            };

            return new CommandStart(command, startInfo);
        }

        private static string CreateGitArguments (
            this GitOperation operation,
            string argument = null)
        {
            switch(operation)
            {
                case GitOperation.CHECKOUT_BRANCH:
                    if (string.IsNullOrWhiteSpace(argument))
                        throw new InvalidOperationException(
                            "Cannot checkout a branch without specifying a branch name.");

                    return $"checkout {argument}";
                case GitOperation.CHECKOUT_FILES:
                    return "checkout .";
                case GitOperation.CLEAN:
                    return "clean -fd";
                case GitOperation.FETCH:
                    return "fetch";
                case GitOperation.PULL:
                    return "pull";
                default:
                    throw new NotImplementedException();
            }
        }
    }

    /// <summary>
    /// Enum that represents possible Git operations.
    /// </summary>
    public enum GitOperation
    {
        CHECKOUT_FILES,
        CLEAN,
        FETCH,
        CHECKOUT_BRANCH,
        PULL
    }
}
