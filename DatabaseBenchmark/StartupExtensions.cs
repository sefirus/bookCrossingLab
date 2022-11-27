using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DatabaseBenchmark
{
    public static class StartupExtensions
    {
        public static void AddBenchmark(this IServiceCollection services)
        {
            services.AddControllers(options =>
                 {
                     options.SuppressAsyncSuffixInActionNames = false;
                 })
                .AddJsonOptions(jsonOptions =>
                { 
                    jsonOptions.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                })
                .AddApplicationPart(typeof(BenchmarkController).Assembly);
        }
    }
}
