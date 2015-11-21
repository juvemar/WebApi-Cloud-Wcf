namespace StudentsSystem.Api.Controllers
{
    using Services.Contracts;
    using Models.Homeworks;
    using System.Linq;
    using System.Web.Http;

    public class HomeworksController : ApiController
    {
        private readonly IHomeworksService homeworks;

        public HomeworksController(IHomeworksService homeworksService)
        {
            this.homeworks = homeworksService;
        }

        [Route("api/homework/all")]
        //[EnableCors("*", "*", "*")]
        public IHttpActionResult Get()
        {
            var result = this.homeworks
                .All()
                .OrderBy(h => h.TimeSent)
                .ToList();

            return this.Ok(result);
        }

        public IHttpActionResult Get(int id)
        {
            var result = this.homeworks
                .All()
               .FirstOrDefault(h => h.Id == id);

            return this.Ok(result);
        }

        //[Route("api/homeworks")]
        [HttpPost]
        public IHttpActionResult Post(SaveHomeworksRequestModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var createdHomework = this.homeworks
                .Add(model.Content);

            return this.Ok(createdHomework);
        }
    }
}
