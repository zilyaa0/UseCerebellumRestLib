using CerebellumRestLib.Models.Base;
using CerebellumRestLib.Models.Enums;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CerebellumRestLib.Models.JSON.Entities
{
    public class FileEntry : JsonBase
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("num")]
        public int Num { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("extension")]
        public string Extension { get; set; }

        [JsonProperty("file_name")]
        public string FileName { get; set; }

        [JsonProperty("link")]
        public string Link { get; set; }

        [JsonProperty("sticker")]
        public Sticker Sticker { get; set; }

        [JsonProperty("create_date")]
        public long? CreateDate { get; set; }

        [JsonProperty("attachment")]
        public AttachmentInfo Attachment { get; set; }

        [JsonProperty("origin")]
        public Origin Origin { get; set; }

        [JsonProperty("author")]
        public Author Author { get; set; }

        [JsonProperty("type")]
        public FileType FileType { get; set; }

        [JsonProperty("size")]
        public long? Size { get; set; }

        [JsonProperty("file_source")]
        public string FileSource { get; set; }

        [JsonProperty("deleted")]
        public bool Deleted { get; set; }

        [JsonProperty("sample_matching")]
        public double? SampleMatching { get; set; }

        [JsonProperty("parent_photo_id")]
        public long? ParentPhotoId { get; set; }

        [JsonProperty("beacons")]
        public IEnumerable<Beacon> Beacons { get; set; }
    }
}