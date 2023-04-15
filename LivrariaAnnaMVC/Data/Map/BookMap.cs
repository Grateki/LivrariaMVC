using LivrariaAnnaMVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LivrariaAnnaMVC.Data.Map
{
    public class BookMap : IEntityTypeConfiguration<BookModel>
    {

        public void Configure(EntityTypeBuilder<BookModel> builder)
        {
            builder.HasKey(x => x.BookId);
            builder.Property(x => x.Title).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Isbn).IsRequired();
            builder.Property(x => x.Year).IsRequired();
            builder.Property(x => x.AuthorId).IsRequired();

            builder.HasOne(x => x.Author);




        }
    }
}

