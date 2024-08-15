using CerebellumRestLib.Models.Base;
using Newtonsoft.Json;

namespace CerebellumRestLib.Models.JSON.Entities
{
    public class Comment : JsonBase
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("news_id")]
        public int NewsId { get; set; }

        [JsonProperty("user_id")]
        public int UserId { get; set; }

        [JsonProperty("date")]
        public long Date { get; set; }

        [JsonProperty("update_text")]
        public string UpdateText { get; set; }

        [JsonProperty("fio")]
        public string Fio { get; set; }

        [JsonProperty("comment")]
        public string CommentText { get; set; }

        [JsonProperty("type")]
        public int Type { get; set; }

        [JsonProperty("diff")]
        public Diff Diff { get; set; }

        [JsonProperty("parent")]
        public Comment ParentComment { get; set; }

        [JsonProperty("chat_id")]
        public int ChatId { get; set; }

        [JsonProperty("chat_message_number")]
        public int ChatMessageNumber { get; set; }
    }

    public class Diff
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("date")]
        public long Date { get; set; }

        [JsonProperty("old_status")]
        public CommentStatus OldStatus { get; set; }

        [JsonProperty("new_status")]
        public CommentStatus NewStatus { get; set; }

        [JsonProperty("old_assigned_organization")]
        public CommentAssignOrganization OldAssignedOrganization { get; set; }

        [JsonProperty("new_assigned_organization")]
        public CommentAssignOrganization NewAssignedOrganization { get; set; }

        [JsonProperty("old_assigned_user")]
        public CommetnAssignedUser OldAssignedUser { get; set; }

        [JsonProperty("new_assigned_user")]
        public CommetnAssignedUser NewAssignedUser { get; set; }

        [JsonProperty("files_added")]
        public FileEntry[] FilesAdded { get; set; }

        [JsonProperty("files_deleted")]
        public FileEntry[] FilesDeleted { get; set; }

        [JsonProperty("user_id")]
        public int UserId { get; set; }

        [JsonProperty("task_id")]
        public int TaskId { get; set; }

        [JsonProperty("old_assigned_status")]
        public CommentStatus OldAssignedStatus { get; set; }

        [JsonProperty("new_assigned_status")]
        public CommentStatus NewAssignedStatus { get; set; }

        [JsonProperty("new_parent")]
        public TaskUnit NewParent { get; set; }

        [JsonProperty("old_parent")]
        public TaskUnit OldParent { get; set; }

        [JsonProperty("old_confirmed")]
        public int? OldConfirmed { get; set; }

        [JsonProperty("new_confirmed")]
        public int? NewConfirmed { get; set; }

        [JsonProperty("new_deadline")]
        public long? NewDeadline { get; set; }

        [JsonProperty("old_deadline")]
        public long? OldDeadline { get; set; }
    }

    public class CommentAssignOrganization
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class CommentStatus
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class CommetnAssignedUser
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("fio")]
        public string Fio { get; set; }
    }
}
