namespace StudentsSystem.Services
{
    using System;
    using System.Linq;
    using StudentsSystem.Models;
    using Data;
    using Contracts;

    public class CoursesService : ICoursesService
    {
        private readonly IRepository<Course> courses;

        public CoursesService(IRepository<Course> coursesRepo)
        {
            this.courses = coursesRepo;
        }

        public int Add(string name, string description, string materials)
        {
            var newCourse = new Course
            {
                Name = name,
                Description = description,
                Materials = materials
            };

            this.courses.Add(newCourse);
            this.courses.SaveChanges();

            return newCourse.Id;
        }

        public IQueryable<Course> All()
        {
            return this.courses
                .All();
        }
    }
}
