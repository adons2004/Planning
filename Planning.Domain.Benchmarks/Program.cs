using BenchmarkDotNet.Running;
using Planning.Domain.Benchmarks.Calculations;

namespace Planning.Domain.Benchmarks;

public class Program
{
    public static void Main()
    {
        BenchmarkRunner.Run<SkuCalculationBenchmarks>();
    }
}