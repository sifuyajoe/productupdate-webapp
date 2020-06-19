using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using up_web_app.Models;

namespace up_web_app.Data
{
    public class up_web_appContext : DbContext
    {
        public up_web_appContext (DbContextOptions<up_web_appContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<up_web_app.Models.upwebapp> upwebapp { get; set; }
    }
}
