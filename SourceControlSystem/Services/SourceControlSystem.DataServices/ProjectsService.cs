namespace SourceControlSystem.DataServices
{
    using System.Linq;
    using SourceControlSystem.Models;
    using Data;
    using Common.Constants;
    using System;

    public class ProjectsService : IProjectsService
    {
        private readonly IRepository<SoftwareProject> projects;
        private readonly IRepository<User> users;

        public ProjectsService(
            IRepository<SoftwareProject> projectRepo,
            IRepository<User> userRepo)
        {
            this.projects = projectRepo;
            this.users = userRepo;
        }

        public int Add(string name, string description, string creator, bool isPrivate = false)
        {
            var currentUser = this.users
                .All()
                .FirstOrDefault(u => u.UserName == creator);

            var newProject = new SoftwareProject
            {
                Name = name,
                Description = description,
                Private = isPrivate,
                CreatedOn = DateTime.Now
            };

            newProject.Users.Add(currentUser);

            this.projects.Add(newProject);
            this.projects.SaveChanges();

            return newProject.Id;
        }

        public IQueryable<SoftwareProject> All(int page = 1, int pageSize = GlobalConstants.DefaultPageSize)
        {
            return this.projects
                .All()
                .OrderByDescending(pr => pr.CreatedOn)
                .Skip((page - 1) * pageSize)
                .Take(pageSize);
        }
    }
}
