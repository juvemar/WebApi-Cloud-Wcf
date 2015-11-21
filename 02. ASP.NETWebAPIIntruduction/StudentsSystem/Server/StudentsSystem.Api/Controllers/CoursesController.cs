namespace StudentsSystem.Api.Controllers
{
    using Models.Courses;
    using Services.Contracts;
    using System.Linq;
    using System.Web.Http;

    public class CoursesController : ApiController
    {
        private readonly ICoursesService courses;

        public CoursesController(ICoursesService coursesService)
        {
            this.courses = coursesService;
        }

        [Route("api/course/all")]
        public IHttpActionResult Get()
        {
            var result = this.courses
                .All()
                .OrderBy(x => x.Students.Count())
                .ToList();

            return this.Ok(result);
        }

        public IHttpActionResult Get(int id)
        {
            var result = this.courses
                .All()
                .FirstOrDefault(c => c.Id == id);

            return this.Ok(result);
        }

        [Route("api/courses")]
        public IHttpActionResult Post(SaveCoursesRequestModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var createdCourse = this.courses
                .Add(
                model.Name,
                model.Description,
                model.Materials);

            return this.Ok(createdCourse);
        }
    }
}
