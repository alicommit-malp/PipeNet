using System;
using System.Threading.Tasks;
using Pipe.Net.Test.Pipeline;
using Xunit;

namespace Pipe.Net.Test
{
    public class PipeTest
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
                var result = await new Pipe<OrderData>()
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