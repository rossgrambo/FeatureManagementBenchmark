using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;

namespace FeatureManagementBenchmark
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var config = DefaultConfig.Instance
                .AddJob(Job.Default.WithNuGet("Microsoft.FeatureManagement", "3.5.0").WithId("Version 3.5.0").AsBaseline())
                .AddJob(Job.Default.WithNuGet("Microsoft.FeatureManagement", "4.0.0-preview5").WithId("Version 4.0.0-preview5"))
                .AddJob(Job.Default.WithNuGet("Microsoft.FeatureManagement", "4.9999.9999").WithId("Version 4.0.0"));
            BenchmarkSwitcher.FromAssemblies(new[] { typeof(Program).Assembly }).Run(args, config);

            // Use this to select benchmarks from the console:
            // var summaries = BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args, config);
        }
    }
}