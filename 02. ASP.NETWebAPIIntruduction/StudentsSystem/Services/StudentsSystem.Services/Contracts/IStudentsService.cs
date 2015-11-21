namespace StudentsSystem.Services.Contracts
{
    using Models;
    using System.Linq;

    public interface IStudentsService
    {
        IQueryable<Student> All();

        int Add(string name, string number);
    }
}
