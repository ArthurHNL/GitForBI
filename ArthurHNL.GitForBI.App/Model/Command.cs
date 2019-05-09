using Newtonsoft.Json;

namespace ArthurHNL.GitForBI.App.Model
{
    [JsonObject]
    public class Command
    {
        /// <summary>
        /// The command name.
        /// </summary>
        [JsonProperty(PropertyName = "command")]
        public string CommandName { get; set; }

        /// <summary>
        /// The arguments to pass to the command.
        /// </summary>
        [JsonProperty(PropertyName = "args")]
        public string Arguments { get; set; }

        /// <summary>
        /// The path to execute this command in.
        /// </summary>
        [JsonProperty(PropertyName = "executeIn")]
        public ExecutionPathInfo ExecuteIn { get; set; }

        /// <summary>
        /// The warning to show.
        /// </summary>
        [JsonProperty(PropertyName = "warning")]
        public string Warning { get; set; }

        /// <summary>
        /// Whether or not this command can be run in parallel, after
        /// all non-parallel command before this command have been executed.
        /// </summary>
        [JsonProperty(PropertyName = "parallel")]
        public bool Parallel { get; set; }

        /// <summary>
        /// Indicates that a new batch should be started.
        /// </summary>
        [JsonProperty(PropertyName = "newBatch")]
        public bool NewBatch { get; set; }

        /// <summary>
        /// Whether or not this commant may fail.
        /// </summary>
        [JsonProperty(PropertyName = "allowFailure")]
        public bool AllowFailure { get; set; }
    }
}
