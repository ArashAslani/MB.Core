using MB.Domain.CommentAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json.Linq;

namespace MB.Infrastructure.EfCore.Mapping
{
    public class CommentMapping : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("Comments");
            builder.Property(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(30).IsRequired();
            builder.Property(x => x.Email).IsRequired();
            builder.Property(x => x.Massage).IsRequired();
            builder.Property(x => x.CreationDate);
            builder.Property(x => x.Status);

            builder.HasOne(x => x.Article)
                .WithMany(x => x.Comments).HasForeignKey(x => x.ArticleId);
        }
    }
}
