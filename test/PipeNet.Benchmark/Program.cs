using BenchmarkDotNet.Running;
using PipeNet.Benchmark.Chr;

namespace PipeNet.Benchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<PipelineClient>();
        }
    }
}