﻿using HappyPaws.Domain.Entities;
using HappyPaws.Domain.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HappyPaws.Persistence.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Adopter> Adopters { get; set; }
        public DbSet<Adoption> Adoptions { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<HealthRecord> HealthRecords { get; set; }
        //public DbSet<List<Pet>> PetList { get; set; } 


        //public static List<HealthRecord> HealthRecordList { get; set; } = new List<HealthRecord>();
        //public static List<Adopter> AdopterList { get; set; } = new List<Adopter>();
        //public static List<Adoption> AdoptionList { get; set; } = new List<Adoption>();
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Ignore<User>();
            modelBuilder.Ignore<Role>();
            modelBuilder.Ignore<UserSetting>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
