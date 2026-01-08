using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stockly.Core.Entities;

namespace Stockly.Infra.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
       public void Configure(EntityTypeBuilder<User> builder)
       {
              builder.ToTable("users");

              builder.HasKey(u => u.Id)
                    .HasName("pk_users");

              builder.Property(u => u.Id)
                     .HasColumnName("id")
                     .IsRequired();

              builder.Property(u => u.Name)
                     .HasColumnName("name")
                     .HasMaxLength(150)
                     .IsRequired();

              builder.Property(u => u.Email)
                     .HasColumnName("email")
                     .HasMaxLength(255)
                     .IsRequired();

              builder.HasIndex(u => u.Email)
                     .HasDatabaseName("ix_users_email")
                     .IsUnique();

              builder.Property(u => u.PasswordHash)
                     .HasColumnName("password_hash")
                     .HasMaxLength(255)
                     .IsRequired();

              builder.Property(u => u.Role)
                  .HasColumnName("role")
                  .IsRequired();

              builder.Property(u => u.CreatedAt)
                  .HasColumnName("created_at")
                  .IsRequired();

              builder.Property(u => u.UpdatedAt)
                     .HasColumnName("updated_at")
                     .IsRequired();
       }
}
