using System.Collections.Generic;
using Newtonsoft.Json;
using CerebellumRestLib.Models.Base;

namespace CerebellumRestLib.Models.JSON.Entities
{
    public abstract class FilesBase : JsonBase
    {
        public abstract List<FileEntry> FileEntries { get; set; }
    }

    public class Photos : FilesBase
    {

        [JsonProperty("photos")]
        public override List<FileEntry> FileEntries { get; set; } = new List<FileEntry>();
    }

    public class Sounds : FilesBase
    {
        [JsonProperty("sounds")]
        public override List<FileEntry> FileEntries { get; set; } = new List<FileEntry>();
    }

    public class Videos : FilesBase
    {
        [JsonProperty("video")]
        public override List<FileEntry> FileEntries { get; set; } = new List<FileEntry>();
    }

    public class DifVideos : FilesBase
    {
        [JsonProperty("difvideo")]
        public override List<FileEntry> FileEntries { get; set; } = new List<FileEntry>();
    }

    public class Files : FilesBase
    {
        [JsonProperty("files")]
        public override List<FileEntry> FileEntries { get; set; } = new List<FileEntry>();
    }
}