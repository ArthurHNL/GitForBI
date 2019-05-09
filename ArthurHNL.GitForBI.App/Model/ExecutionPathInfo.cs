using Newtonsoft.Json;

namespace ArthurHNL.GitForBI.App.Model
{
    [JsonObject]
    public class ExecutionPathInfo
    {
        /// <summary>
        /// The path.
        /// </summary>
        [JsonProperty(PropertyName = "path")]
        public string Path { get; set; }

        /// <summary>
        /// If true, <see cref="Path"/> is relative from the repository root.
        /// </summary>
        [JsonProperty(PropertyName = "relativeFromRepoDir")]
        public bool Relative { get; set; }
    }
}
