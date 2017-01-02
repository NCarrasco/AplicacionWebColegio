using AplicacionWebColegio.DataAccess;
using AplicacionWebColegio.DataAccess.Migrations;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AplicacionWebColegio
{
    public class DbConfig
    {
        public static void ConfiguredDb()
        {
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<AplicacionWebColegioDbContext, Configuration>());
        }
    }
}