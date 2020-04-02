namespace EstacionamentoESilva.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EstacionamentoESilva.Data.EstacionamentoESilvaContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "EstacionamentoESilva.Data.EstacionamentoESilvaContext";
        }

        protected override void Seed(EstacionamentoESilva.Data.EstacionamentoESilvaContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
