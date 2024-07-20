using ETicaretAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            // Yeni bizden IProductService telebi gelse ProductServiceni gonder
            // Kodun icerisine komfigurasyon deyerleri yazmaq duzgun deyil
            services.AddDbContext<ETicaretDbContext>(options => options.UseNpgsql(Configuration.ConnectionString));

        }
    }
}
