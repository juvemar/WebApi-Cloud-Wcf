namespace StudentsSystem.Api.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using Services.Contracts;
    using Models.Students;

    public class StudentController : ApiController
    {
        private readonly IStudentsService students;

        public StudentController(IStudentsService studentsRepo)
        {
            this.students = studentsRepo;
        }

        public IHttpActionResult Get()
        {
            var result = this.students
                .All()
                .OrderBy(s => s.Name)
                .ToList();

            return this.Ok(result);
        }

        public IHttpActionResult Get(int Id)
        {
            var result = this.students
                .All()
                .FirstOrDefault(s => s.Id == Id);

            return this.Ok(result);
        }

        public IHttpActionResult Post(SaveStudentsRequestModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var createdStudent = this.students.Add(
                model.Name,
                model.Number);

            return this.Ok(createdStudent);
        }
    }
}
