using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json;
using Storage;

namespace KhuidadAppStore
{
    public static class UpdateTodo
    {
        [FunctionName("InMemory_UpdateTodo")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "put", Route = "todo/{id}")]
            HttpRequest req, TraceWriter log, string id)
        {
            log.Info("updateTodo function processed a request.");

            var todo = TodoApiInMemory.Items.FirstOrDefault(x => x.Id == id);
            if (null == todo)
            {
                return new NotFoundResult();
            }

            var input = await new StreamReader(req.Body).ReadToEndAsync();
            todo.Iscompleted = true;

            return new OkObjectResult(todo);
        }
    }
}