namespace StudentsSystem.Services.Contracts
{
    using System.Linq;
    using Models;

    public interface IHomeworksService
    {
        IQueryable<Homework> All();

        int Add(string content);
    }
}
