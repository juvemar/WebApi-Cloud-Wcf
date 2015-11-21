namespace StudentsSystem.Api.Models.Courses
{
    using System;
    using StudentsSystem.Api.Infrastructure.Mapping;
    using StudentsSystem.Models;

    public class CoursesDetailsResponseModel : IMapFrom<Course>
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public DateTime TimeSent { get; set; }
    }
}