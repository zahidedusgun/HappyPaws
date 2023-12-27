using HappyPaws.Domain.Entities;
using HappyPaws.Domain.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HappyPaws.Persistence.Contexts
{
    public class IdentityDbContext : IdentityDbContext<User,Role,Guid>
    {
        public IdentityDbContext(DbContextOptions<IdentityDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Ignore<Pet>();
            modelBuilder.Ignore<HealthRecord>();
            modelBuilder.Ignore<Adopter>();
            modelBuilder.Ignore<Adoption>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
