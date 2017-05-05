using EasyKatka.Models.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyKatka.Providers.AppContext
{
    class ApplicationInitializer : CreateDatabaseIfNotExists<ApplicationContext>
    {
        protected override void Seed(ApplicationContext context)
        {
            ApplicationInitializer.InitializeLots(context);

            base.Seed(context);
        }

        private static void InitializeLots(ApplicationContext context)
        {
            Lot lot = new Lot() {
                Title = "Samsung Galaxy s7",
                Description = "dfgsdfghdfgsdfg",
                TradingStart = new DateTime(2017, 5, 8, 16, 0, 0),
                StartPrice = 15
            };

            context.Lots.Add(lot);

            context.SaveChanges();
        }
    }
}
