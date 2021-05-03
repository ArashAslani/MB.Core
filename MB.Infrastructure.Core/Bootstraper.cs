using MB.Application;
using MB.Application.Contracts.ArticleCategory;
using MB.Domain.ArticleCategoryAgg;
using MB.Infrastructure.EfCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MB.Infrastructure.Core
{
    public static class Bootstraper
    {
        public static void Config(IServiceCollection services , string conectionString)
        {
            services.AddTransient<IArticleCategoryApplication , ArticleCategoryApplication>();
            services.AddTransient<IArticleCategoryRepository, ArticleCategoryRepository>();
            services.AddDbContext<MBContext>(option => option.UseSqlServer(conectionString));

        }
    }
}
