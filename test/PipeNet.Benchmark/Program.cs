using BenchmarkDotNet.Running;
using PipeNet.Benchmark.Pipeline;

namespace PipeNet.Benchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<PipeNetClient>();
        }
    }
}