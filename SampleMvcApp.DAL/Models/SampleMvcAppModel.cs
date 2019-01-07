using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SampleMvcApp.DAL.Identity;
using SampleMvcApp.Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using SampleMvcApp.DAL.Utils;

namespace SampleMvcApp.DAL.Models
{
    public partial class SampleMvcAppModel : IdentityDbContext<AppUser, AppRole, Guid>
    {
        public SampleMvcAppModel()
        {

        }

        public SampleMvcAppModel(DbContextOptions<SampleMvcAppModel> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                //.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<Item> Items { get; set; }
    }
}
