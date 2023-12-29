using HappyPaws.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyPaws.Persistence.Configurations
{
    public class PetConfiguration : IEntityTypeConfiguration<Pet>
    {
        public void Configure(EntityTypeBuilder<Pet> builder)
        {
            // Primary key
            builder.HasKey(u => u.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            // Name
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Name).HasMaxLength(70);

            // Type
            builder.Property(x => x.Type).IsRequired();
            builder.Property(x => x.Type).HasMaxLength(70);

            // Breed
            builder.Property(x => x.Breed).IsRequired();
            builder.Property(x => x.Breed).HasMaxLength(70);

            // Age
            builder.Property(x => x.Age).IsRequired();
            builder.Property(x => x.Age).HasColumnType("smallint");

            // Gender
            builder.Property(x => x.Gender).IsRequired();
            builder.Property(x => x.Gender).HasConversion<int>();

            // AdoptionStatus
            builder.Property(x => x.AdoptionStatus).IsRequired();
            builder.Property(x => x.AdoptionStatus).HasConversion<int>();

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

            builder.HasOne(x => x.Adopter)
                .WithMany(x => x.AdoptedPets)
                .HasForeignKey(x => x.AdopterId);

            builder.HasMany(x => x.HealthRecords)
                .WithOne(hr => hr.Pet)
                .HasForeignKey(hr => hr.PetId);

            builder.ToTable("Pets");

        }
    }
}
