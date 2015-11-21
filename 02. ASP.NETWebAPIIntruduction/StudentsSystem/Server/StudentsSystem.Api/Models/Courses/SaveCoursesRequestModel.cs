namespace StudentsSystem.Api.Models.Courses
{
    using System.ComponentModel.DataAnnotations;

    public class SaveCoursesRequestModel
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public string Materials { get; set; }
    }
}