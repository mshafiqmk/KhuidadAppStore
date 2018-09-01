using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json;
using Storage;

namespace KhuidadAppStore
{
    public static class DeleteTodo
    {
        [FunctionName("InMemory_DeleteTodo")]
        public static IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "delete", Route = "todo/{id}")]
            HttpRequest req, TraceWriter log, string id)
        {
            log.Info("DeleteTodo function processed a request.");

            var todo = TodoApiInMemory.Items.FirstOrDefault(x => x.Id == id);

            if (todo == null)
            {
                return new NotFoundResult();
            }

            var result = TodoApiInMemory.Items.Remove(todo);
            return result ? (IActionResult)new OkObjectResult("Item deleted successfully")
                : new BadRequestResult();
        }
    }
}