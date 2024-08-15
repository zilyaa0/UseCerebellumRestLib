using System.Collections.Generic;

namespace CerebellumRestLib.Models.Base
{
    public class CountableList<T>
    {
        public List<T> List { get; set; }

        public int Count { get; set; }
        
        public CountableList(List<T> list, int count)
        {
            List = list ?? new List<T>();
            Count = count;
        }
    }
}