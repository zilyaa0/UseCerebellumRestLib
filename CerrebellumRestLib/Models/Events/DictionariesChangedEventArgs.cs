using System;
using System.Collections.Generic;
using System.Text;

namespace CerebellumRestLib.Models.Events
{
    public class DictionariesChangedEventArgs
    {
        public long? ChangedDate { get; set; }
        public EDictionaryType DictionaryType { get; set; }
    }
    public enum EDictionaryType
    {
        Common = 1,
        Configuration = 2,
        Organizations = 3,
        WorkTypes = 4,
        Users = 5
    }
}
