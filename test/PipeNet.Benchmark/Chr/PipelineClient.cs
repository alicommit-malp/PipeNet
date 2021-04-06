using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using PipeNet.Benchmark.Chr.Pipeline;

namespace PipeNet.Benchmark.Chr
{
    [MemoryDiagnoser]
    public class PipelineClient
    {
        [Benchmark]
        public async Task WithChrPipeNet()
        {
            var result = await new Pipe<OrderData>()
                .Next(new OrderNode())
                .Next(new ProducingNode())
                .Finally(new CheckoutNode())
                .Execute(new OrderData()
                {
                    Name = "Coffee",
                    State = this.GetType().Name,
                });
        }

        [Benchmark]
        public async Task RunWithoutChrPipeNet()
        {
            var orderData = new OrderData()
            {
                Name = "Coffee",
                State = "None",
            };

            await new OrderNode().Execute(orderData);
            await new ProducingNode().Execute(orderData);
            await new CheckoutNode().Execute(orderData);
        }
    }
}