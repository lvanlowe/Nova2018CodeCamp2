
using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Nova2018CodeCamp.Data.DatabaseModels;
using Nova2018CodeCamp.Data.Interface;
using Nova2018CodeCamp.Data.Repository;
using Nova2018CodeCamp.Data.Worker;
using Nova2018CodeCamp.Model.DataViewModel;

namespace Nova2018CodeCamp.Function
{
    public static class AddSportFunction
    {
        [FunctionName("AddSportFunction")]
        public static async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]HttpRequest req, TraceWriter log)
        {
            log.Info("Add Sport");

            var requestBody = new StreamReader(req.Body).ReadToEnd();
            var sport = JsonConvert.DeserializeObject<SportLocationView>(requestBody);
            var connectionString = Environment.GetEnvironmentVariable("SQLAZURECONNSTR_Nova2018CodeCampContext");
            try
            {
                var options = new DbContextOptionsBuilder<Nova2018CodeCampContext>()
                    .UseSqlServer(connectionString)
                    .Options;

                var context = new Nova2018CodeCampContext(options);

                IReferenceRepository repository = new ReferenceRepository(context);

                var worker = new ReferenceWorker(repository);

                var actual = await worker.AddSport(sport);

                return new OkObjectResult(actual.ToString());

            }
            catch (Exception e)
            {
                log.Error(e.ToString());
                return new BadRequestObjectResult(e.Message);
            }

        }
    }
}
