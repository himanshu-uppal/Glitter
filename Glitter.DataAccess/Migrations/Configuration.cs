namespace Glitter.DataAccess.Migrations
{
    using Glitter.DataAccess.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<Glitter.DataAccess.Concrete.EFDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Glitter.DataAccess.Concrete.EFDbContext context)
        {
           


            //Reaction reaction1 = new Reaction { Key = Guid.NewGuid(), Name = "Like" };
            //Reaction reaction2 = new Reaction { Key = Guid.NewGuid(), Name = "Dislike" };
            //Reaction reaction3 = new Reaction { Key = Guid.NewGuid(), Name = "Heart" };

            //context.Reactions.AddOrUpdate(reaction1, reaction2, reaction3);

          







        }
    }
}
