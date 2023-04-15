using LivrariaAnnaMVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LivrariaAnnaMVC.Data.Map
{
    public class AuthorMap : IEntityTypeConfiguration<AuthorModel>
    {
        public void Configure(EntityTypeBuilder<AuthorModel> builder)
        {
            builder.HasKey(x => x.AuthorId);
            builder.Property(x => x.AuthorName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.AuthorLastName).IsRequired().HasMaxLength(150);
            builder.Property(x => x.Birth).IsRequired();

        }

    }
}
