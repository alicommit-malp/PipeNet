using System;
using System.Threading.Tasks;
using PipeNet.Test.Pipeline;
using Xunit;

namespace PipeNet.Test
{
    public class PipelineTest
    {
        [Fact]
        public async Task Pipe_ShouldRunPipe_ReturnsLastNodeName()
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

            Assert.Equal(nameof(CheckoutNode), result.State);
        }

        [Fact]
        public async Task Pipe_ShouldRunPipe_ReturnsException()
        {
            static async Task Action()
            {
                await new Pipe<OrderData>()
                    .Add(new OrderNode())
                    .Add(new ExceptionNode())
                    .Add(new ProducingNode())
                    .Add(new CheckoutNode())
                    .Run(new OrderData()
                    {
                        Name = "Coffee",
                        State = "None",
                    });
            }

            var exception = await Assert.ThrowsAsync<Exception>(Action);
            Assert.Equal("100", exception.Message);
        }
    }
}