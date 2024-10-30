using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.FeatureManagement;
using BenchmarkDotNet.Jobs;
using System.Threading.Tasks;

namespace FeatureManagementBenchmark
{
    [MemoryDiagnoser]
    [RPlotExporter]
    public class Benchmarks
    {
        private IFeatureManager featureManager;

        [GlobalSetup]
        public void Setup()
        {
            //
            // Setup configuration
            IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            //
            // Setup application services + feature management
            IServiceCollection services = new ServiceCollection();

            services.AddSingleton(configuration)
                    .AddFeatureManagement();

            using (ServiceProvider serviceProvider = services.BuildServiceProvider())
            {
                featureManager = serviceProvider.GetRequiredService<IFeatureManager>();
            }
        }

        [Benchmark]
        public async Task BooleanFlagManyTimes()
        {
            bool result;

            for (int i = 0; i < 1000; i++)
            {
                result = await featureManager.IsEnabledAsync("OnTestFeature");
            }
        }

        [Benchmark]
        public async Task MissingFlagManyTimes()
        {
            bool result;

            for (int i = 0; i < 1000; i++)
            {
                result = await featureManager.IsEnabledAsync("DoesNotExist");
            }
        }

        //[Benchmark]
        //public async Task BooleanFlagOnce()
        //{
        //    bool result = await featureManager.IsEnabledAsync("OnTestFeature");
        //}

        //[Benchmark]
        //public async Task MissingFlagOnce()
        //{
        //    bool result = await featureManager.IsEnabledAsync("DoesNotExist");
        //}
    }
}
