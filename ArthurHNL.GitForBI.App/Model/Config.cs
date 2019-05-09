using Newtonsoft.Json;
using System.Collections.Generic;

namespace ArthurHNL.GitForBI.App.Model
{
    [JsonObject]
    public class Config
    {
        /// <summary>
        /// The directory of the repository.
        /// </summary>
        [JsonProperty(PropertyName = "repoDir")]
        public string RepoDir { get; set; }

        /// <summary>
        /// The path to git.exe.
        /// </summary>
        [JsonProperty(PropertyName = "pathToGit")]
        public string GitPath { get; set; }

        /// <summary>
        /// The name of the default branch.
        /// </summary>
        [JsonProperty(PropertyName = "defaultBranch")]
        public string DefaultBranch { get; set; }

        /// <summary>
        /// The commands to run before pulling the latest codebase.
        /// </summary>
        [JsonProperty(PropertyName = "prePullCommands")]
        public IList<Command> PrePullCommands { get; set; }

        /// <summary>
        /// The commands to run after pulling the latest codebase.
        /// </summary>
        [JsonProperty(PropertyName = "postPullCommands")]
        public IList<Command> PostPullCommands { get; set; }
    }
}
