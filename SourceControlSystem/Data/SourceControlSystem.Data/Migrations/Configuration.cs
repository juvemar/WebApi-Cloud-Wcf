namespace SourceControlSystem.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public sealed class Configuration : DbMigrationsConfiguration<SourceControlSystem.Data.SourceControlSystemDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(SourceControlSystem.Data.SourceControlSystemDbContext context)
        {
        }
    }
}
