using System;
using System.Collections.Generic;

namespace Storage
{
    public static class TodoApiInMemory
    {
        public static List<Todo> Items = new List<Todo>();

        static TodoApiInMemory()
        {
            Items.Add(new Todo()
            {
                Id = "1",
                CreateTime = DateTime.Now,
                Iscompleted = true,
                TaskDescription = "Some dummy descripton"
            });
            Items.Add(new Todo()
            {
                Id = "2",
                CreateTime = DateTime.Now,
                Iscompleted = true,
                TaskDescription = "Some dummy descripton1"
            });
        }
    }
}