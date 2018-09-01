using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Storage;

namespace KhuidadAppStore
{
    public static class GetTodos
    {
        [FunctionName("InMemory_GetTodos")]
        public static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "todo")]HttpRequest req, TraceWriter log)
        {
            log.Info("Getting Todo list items");

            return new OkObjectResult(TodoApiInMemory.Items);
        }
    }
}