using ArthurHNL.GitForBI.App.Model;
using ArthurHNL.GitForBI.App.Extensions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ArthurHNL.GitForBI.App
{
    public static class CommandBatchQueueFactory
    {
        public static Queue<IList<CommandStart>> CreateCommandBatchQueue(
            Config config,
            string branchName)
        {
            var queue = new Queue<IList<CommandStart>>();

            var prePullCommands = FromCommands(config.PrePullCommands, config);
            var pullCommands = GeneratePullCommands(config, branchName);
            var postPullCommands = FromCommands(config.PostPullCommands, config);

            queue
                .AppendQueue(prePullCommands)
                .AppendQueue(pullCommands)
                .AppendQueue(postPullCommands);

            return queue;
        }

        private static Queue<IList<CommandStart>> FromCommands(IList<Command> commands, Config config)
        {
            var queue = new Queue<IList<CommandStart>>();

            commands = commands.Where(c => c != null).ToList();

            while(commands.Count != 0)
            {
                var batch = new List<CommandStart>();
                var isParallel = commands.First().Parallel;

                batch.Add(commands.First().CreateStartInfo(config.RepoDir));
                commands.Remove(commands.First());

                if (isParallel)
                {
                    var added = new List<Command>();
                    foreach(var command in commands)
                    {
                        if (!command.Parallel || command.NewBatch)
                            break;

                        batch.Add(command.CreateStartInfo(config.RepoDir));
                        added.Add(command);
                    }

                    foreach(var command in added)
                    {
                        commands.Remove(command);
                    }
                }

                queue.Enqueue(batch);
            }

            return queue;
        }

        private static Queue<IList<CommandStart>> GeneratePullCommands(Config config, string branchName)
        {
            var queue = new Queue<IList<CommandStart>>();

            queue.Enqueue(GenerateGitCommandList(config, GitOperation.CHECKOUT_FILES));
            queue.Enqueue(GenerateGitCommandList(config, GitOperation.CLEAN));
            queue.Enqueue(GenerateGitCommandList(config, GitOperation.FETCH));
            queue.Enqueue(GenerateGitCommandList(config, GitOperation.CHECKOUT_BRANCH, branchName));
            queue.Enqueue(GenerateGitCommandList(config, GitOperation.PULL));

            return queue;

        }

        private static IList<CommandStart> GenerateGitCommandList(Config config, GitOperation operation, string argument = null)
        {
            return new List<CommandStart>()
            {
                config.CreateGitCommandStart(operation, argument)
            };
        }
    }
}
