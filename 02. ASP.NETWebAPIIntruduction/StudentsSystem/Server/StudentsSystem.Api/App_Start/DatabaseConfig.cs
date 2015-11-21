namespace WebApplication1
{
    using StudentsSystem.Data;
    using StudentsSystem.Data.Migrations;
    using System.Data.Entity;

    public static class DatabaseConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StudentsSystemDbContext, Configuration>());
            StudentsSystemDbContext.Create().Database.Initialize(true);
        }
    }
}