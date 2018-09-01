using System;

namespace Storage
{
    public class Todo
    {
        public string Id { get; set; }
        public DateTime CreateTime { get; set; }
        public string TaskDescription { get; set; }
        public bool Iscompleted { get; set; }
    }
}