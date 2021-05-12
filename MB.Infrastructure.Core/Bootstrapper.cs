using MB.Application;
using MB.Application.Contracts.Article;
using MB.Application.Contracts.ArticleCategory;
using MB.Application.Contracts.Comment;
using MB.Domain.ArticleAgg;
using MB.Domain.ArticleAgg.Services;
using MB.Domain.ArticleCategoryAgg;
using MB.Domain.ArticleCategoryAgg.Services;
using MB.Domain.CommentAgg;
using MB.Infrastructure.EfCore;
using MB.Infrastructure.EfCore.Repositories;
using MB.Infrastructure.View;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MB.Infrastructure.Core
{
    public static class Bootstrapper
    {
        public static void Config(IServiceCollection services , string connectionString)
        {
            services.AddDbContext<MBContext>(option => option.UseSqlServer(connectionString));

            services.AddTransient<IArticleCategoryValidatorService, ArticleCategoryValidatorService>();
            services.AddTransient<IArticleCategoryApplication , ArticleCategoryApplication>();
            services.AddTransient<IArticleCategoryRepository, ArticleCategoryRepository>();

            services.AddTransient<IArticleValidatorService, ArticleValidatorService>();
            services.AddTransient<IArticleApplication, ArticleApplication>();
            services.AddTransient<IArticleRepository, ArticleRepository>();

            services.AddTransient<ICommentRepository,CommentRepository>();
            services.AddTransient<ICommentApplication,CommentApplication>();

            services.AddTransient<IArticleView, ArticleViewQuery>();
        }
    }
}
 