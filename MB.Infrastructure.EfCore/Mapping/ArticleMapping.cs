using MB.Domain.ArticleAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MB.Infrastructure.EfCore.Mapping
{
    class ArticleMapping : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.ToTable("Articles");
            builder.Property(x => x.Id);
            builder.Property(x => x.Title).HasMaxLength(300).IsRequired();
            builder.Property(x => x.ShortDescription).IsRequired();
            builder.Property(x => x.Content).IsRequired();
            builder.Property(x => x.Picture);
            builder.Property(x => x.IsDeleted);
            builder.Property(x => x.CreationDate);

            builder.HasOne(x => x.ArticleCategory).WithMany(x => x.Articles)
                .HasForeignKey(x => x.CategoryId);
        }
    }
}
