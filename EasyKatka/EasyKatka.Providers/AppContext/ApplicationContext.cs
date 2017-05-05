using EasyKatka.Models.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyKatka.Providers.AppContext
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext() : base("EasyKatkaConnection")
        {
            Database.SetInitializer(new ApplicationInitializer());
        }

        public DbSet<Lot> Lots { get; set; }
    }
}
