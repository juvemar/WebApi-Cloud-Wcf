namespace StudentsSystem.Services
{
    using System.Linq;
    using Contracts;
    using Models;
    using Data;

    public class StudentsService : IStudentsService
    {
        private readonly IRepository<Student> students;

        public StudentsService(IRepository<Student> studentsRepo)
        {
            this.students = studentsRepo;
        }

        public int Add(string name, string number)
        {
            var newStudent = new Student
            {
                Name = name,
                Number = number
            };

            this.students.Add(newStudent);
            this.students.SaveChanges();

            return newStudent.Id;
        }

        public IQueryable<Student> All()
        {
            var currentStudents = this.students
                .All();

            return currentStudents;
        }
    }
}
