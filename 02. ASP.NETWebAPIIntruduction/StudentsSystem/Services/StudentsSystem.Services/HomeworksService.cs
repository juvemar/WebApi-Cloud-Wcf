namespace StudentsSystem.Services
{
    using System;
    using System.Linq;
    using StudentsSystem.Models;
    using StudentsSystem.Services.Contracts;
    using Data;

    public class HomeworksService : IHomeworksService
    {
        private readonly IRepository<Homework> homeworks;

        public HomeworksService(IRepository<Homework> homeworksRepo)
        {
            this.homeworks = homeworksRepo;
        }

        public int Add(string content)
        {
            var newHomework = new Homework
            {
                Content = content,
                TimeSent = DateTime.Now
            };

            this.homeworks.Add(newHomework);
            this.homeworks.SaveChanges();

            return newHomework.Id;
        }

        public IQueryable<Homework> All()
        {
            return this.homeworks
                .All();
        }
    }
}
