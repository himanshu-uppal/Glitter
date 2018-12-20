using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace Glitter.Presentation.App_Start
{
    public class EFConfig
    {
        public static void Initialize()
        {
            RunMigrations();
        }
        private static void RunMigrations()
        {
            var efMigrationSettings = new Glitter.DataAccess.Migrations.Configuration();
            var efMigrator = new DbMigrator(efMigrationSettings);

            efMigrator.Update();
        }
    }
}