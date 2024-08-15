using System;
using System.Collections.Generic;
using CerebellumRestLib.Models.Enums;
using CerebellumRestLib.Models.JSON.Entities;
using Newtonsoft.Json;

namespace CerebellumRestLib.Models
{
    public class User
    {
        public int Id { get; set; }

        public Uri Uri { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public UserRole Role { get; set; }

        public int? DepartamentId { get; set; }

        public string FullName { get; set; }

        public double[] MapExtent { get; set; }

        public DateTime LastAuthDateTime { get; set; }

        public string Token { get; set; }

        public IEnumerable<int> WorkgroupIds { get; set; }

        public long? AvatarUpdateDate { get; set; }

        public List<Tag> Tags { get; set; }

        public UserInform UserInfo { get; set; }

        public UserType UserType { get; set; }

        public ClusterBase Cluster { get; set; }

        public IEnumerable<ClusterBase> AvailableClusters { get; set; }
    }
}
