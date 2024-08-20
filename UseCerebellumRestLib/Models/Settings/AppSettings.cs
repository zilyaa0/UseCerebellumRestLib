using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCerebellumRestLib.Models.Settings
{
    internal class AppSettings
    {
        public CerebellumSettings CerebellumSettings { get; set; }
        public MailSettings MailSettings { get; set; }
        public DbSettings DbSettings { get; set; }
        /// <summary>
        /// Приоритет
        /// </summary>
        public int PriorityId { get; set; }
        /// <summary>
        /// Группа видов работ
        /// </summary>
        public int WorkTypeGroupId { get; set; }
    }

    internal class CerebellumSettings
    {
        public string Host { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }

    internal class MailSettings
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    internal class DbSettings
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public string DbName { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public string CreateTaskTable { get; set; }
        internal string BuildConnectionString()
        {
            return $"Server={Host};Port={Port};Database={DbName};User Id={User};Password={Password}";
        }
    }
}
