using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;

namespace PipeNet.Benchmark.Pipeline
{
    [MemoryDiagnoser]
    public class PipeNetClient
    {
        [Benchmark]
        public async Task RunWithPipeNet()
        {
            OrderData result = await new Pipe<OrderData>()
                .Add(new OrderNode())
                .Add(new ProducingNode())
                .Add(new CheckoutNode())
                .Run(new OrderData()
                {
                    Name = "Coffee",
                    State = "None",
                });
        }

        [Benchmark]
        public async Task RunWithoutPipeNet()
        {
            var orderData = new OrderData()
            {
                Name = "Coffee",
                State = "None",
            };

            await new OrderNode().InvokeAsync(orderData);
            await new ProducingNode().InvokeAsync(orderData);
            await new CheckoutNode().InvokeAsync(orderData);
            
        }
    }
}