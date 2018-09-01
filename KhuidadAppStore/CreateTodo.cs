using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Storage;
using System;
using System.IO;
using System.Threading.Tasks;

namespace KhuidadAppStore
{
    public static class CreateTodo
    {
        private static int _i = 1;

        [FunctionName("InMemory_CreateTodo")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous,"post", Route = "todo/add")]
            HttpRequest req, TraceWriter log)
        {
            log.Info("Creating a new todo list item");

            var requestbody = await new StreamReader(req.Body).ReadToEndAsync();
            //var input = JsonConvert.DeserializeObject<TodoCreateModel>(requestbody);

            //var todo = new Todo() { TaskDescription = input.TaskDescription };
            TodoApiInMemory.Items.Add(new Todo()
            {
                Id = _i++.ToString(),
                CreateTime = DateTime.Now,
                Iscompleted = false,
                TaskDescription = requestbody
            }
            );
            return new ObjectResult(req.Body);
        }
    }
}