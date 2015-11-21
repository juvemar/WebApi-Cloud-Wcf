namespace StudentsSystem.Services.Contracts
{
    using StudentsSystem.Models;
    using System.Linq;

    public interface ICoursesService
    {
        IQueryable<Course> All();

        int Add(string name, string description, string materials);
    }
}
