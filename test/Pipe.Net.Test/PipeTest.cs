using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Pipe.Net.Test.Pipeline;
using Xunit;

namespace Pipe.Net.Test
{
    public class PipeTest
    {
        public static readonly ILogger<PipeTest> Logger = TestLogger.Create<PipeTest>();

        [Fact]
        public async Task Pipe_ShouldRunPipe_ReturnsLastNodeName()
        {
            var result = await new Pipe<OrderData>()
                .Next(new OrderNode())
                .Next(new CheckoutNode())
                .Next(new ProducingNode())
                .Run(new OrderData()
                {
                    Name = "Coffee",
                    State = "None",
                    Digit = 0
                });

            Assert.Equal(nameof(ProducingNode), result.State);
        }

        [Fact]
        public async Task Pipe_ShouldRunPipe_ReturnsException()
        {
            static async Task Action()
            {
                var result = await new Pipe<OrderData>()
                    .Next(new OrderNode())
                    .Next(new ExceptionNode())
                    .Next(new CheckoutNode())
                    .Next(new ProducingNode())
                    .Run(new OrderData() {Name = "Coffee", State = "None", Digit = 0});
            }

            var exception = await Assert.ThrowsAsync<Exception>(Action);
            Assert.Equal("100",exception.Message);
        }
    }
}