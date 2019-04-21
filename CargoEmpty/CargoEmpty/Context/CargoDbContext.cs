using CargoEmpty.Models.Pages;
using CargoEmpty.Models.Pages.Carusel;
using CargoEmpty.Models.Pages.Faq;
using CargoEmpty.Models.Pages.News;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CargoEmpty.Context
{
    public class CargoDbContext : DbContext
    {
        public CargoDbContext() : base("CargoDb")
        {
        }

        public DbSet<CaruselDb> Carusels { get; set; }
        public DbSet<NewsDbModel> News { get; set; }
        public DbSet<FaqDb> Faqs { get; set; }
    }
}