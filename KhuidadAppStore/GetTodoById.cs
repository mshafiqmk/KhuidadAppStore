using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Storage;
using System.Linq;

namespace KhuidadAppStore
{
    public static class GetTodoById
    {
        [FunctionName("InMemory_GetTodoById")]
        public static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "todo/{id}")]
            HttpRequest req, TraceWriter log, string id)
        {
            log.Info("C# HTTP trigger function processed a request.");
            var todo = TodoApiInMemory.Items.FirstOrDefault(x => x.Id == id);
            if (todo == null)
            {
                return new NotFoundResult();
            }
            return new OkObjectResult(todo);
        }
    }
}