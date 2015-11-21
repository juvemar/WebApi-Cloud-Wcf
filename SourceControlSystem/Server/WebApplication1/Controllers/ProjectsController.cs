namespace WebApplication1.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using Models.Projects;
    using SourceControlSystem.Common.Constants;
    using SourceControlSystem.DataServices;
    using System.Web.Http.Cors;
    using AutoMapper.QueryableExtensions;
    using AutoMapper;
    using SourceControlSystem.Models;

    public class ProjectsController : ApiController
    {
        private readonly IProjectsService projects;

        public ProjectsController(IProjectsService projectsService)
        {
            this.projects = projectsService;
        }

        [EnableCors("*", "*", "*")]
        public IHttpActionResult Get()
        {
            Mapper.CreateMap<SoftwareProject, SoftwareProjectDetailResponseModel>()
                .ForMember(u => u.TotalUsers, opts => opts.MapFrom(u => u.Users.Count()));

            var result = this.projects
                .All()
                .ProjectTo<SoftwareProjectDetailResponseModel>()
                .ToList();

            return this.Ok(result);
        }

        [Route("api/project/all")]
        public IHttpActionResult Get(int page, int pageSize = GlobalConstants.DefaultPageSize)
        {
            var result = this.projects
                .All(page, pageSize)
                .ProjectTo<SoftwareProjectDetailResponseModel>()
                .ToList();

            return this.Ok(result);
        }

        [Authorize]
        public IHttpActionResult Get(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return this.BadRequest("Id cannot be null or empty!");
            }

            var result = this.projects
                .All()
                .Where(pr => pr.Name == id)
                .FirstOrDefault();

            if (result.Private && !result.Users.Any(u => u.UserName == this.User.Identity.Name))
            {
                return this.Unauthorized();
            }

            if (result == null)
            {
                return this.NotFound();
            }

            return this.Ok(result);
        }

        [Authorize]
        public IHttpActionResult Post(SaveProjectRequestModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var createdProjectId = this.projects.Add(
                model.Name,
                model.Description,
                this.User.Identity.Name,
                model.Private);

            return this.Ok(createdProjectId);
        }
    }
}
