using HappyPaws.Domain.Entities;
using HappyPaws.Domain.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyPaws.Persistence.Configurations
{
    public class AdopterConfiguration : IEntityTypeConfiguration<Adopter>
    {
        public void Configure(EntityTypeBuilder<Adopter> builder)
        {
            // Primary key
            builder.HasKey(u => u.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            // Name
            builder.Property(x => x.FirstName).IsRequired();
            builder.Property(x => x.FirstName).HasMaxLength(70);

            // LastName
            builder.Property(x => x.LastName).IsRequired();
            builder.Property(x => x.LastName).HasMaxLength(70);

            // Email
            builder.Property(x => x.Email).IsRequired();
            builder.Property(x => x.Email).HasMaxLength(200);

            // PhoneNumber
            builder.Property(x => x.PhoneNumber).IsRequired();
            builder.Property(x => x.PhoneNumber).HasMaxLength(200);

            // COMMON FIELDS

            // CreatedByUserId
            builder.Property(x => x.CreatedByUserId).IsRequired();
            builder.Property(x => x.CreatedByUserId).HasMaxLength(75);

            // CreatedOn
            builder.Property(x => x.CreatedOn).IsRequired();

            // ModifiedByUserId
            builder.Property(x => x.ModifiedByUserId).IsRequired(false);
            builder.Property(x => x.ModifiedByUserId).HasMaxLength(75);

            // LastModifiedOn
            builder.Property(x => x.ModifiedOn).IsRequired(false);

            // DeletedByUserId
            builder.Property(x => x.DeletedByUserId).IsRequired(false);
            builder.Property(x => x.DeletedByUserId).HasMaxLength(75);

            // DeletedOn
            builder.Property(x => x.DeletedOn).IsRequired(false);

            // IsDeleted
            builder.Property(x => x.IsDeleted).IsRequired();

            // Relationships

            //many to one with pets

            builder.HasMany<Pet>(x => x.AdoptedPets)
                .WithOne(x => x.Adopter)
                .HasForeignKey(x => x.AdopterId);

            ////one to many with adoptions

            //builder.HasMany(x => x.Adoptions)
            //    .WithOne(x => x.Adopter)
            //    .HasForeignKey(x => x.AdopterId);

            //one to one with user
            //builder.HasOne(x => x.User)
            //     .WithOne(u => u.Adopter)
            //     .HasForeignKey<User>(x => x.AdopterId);

            builder.ToTable("Adopters");
        }
    }
}
