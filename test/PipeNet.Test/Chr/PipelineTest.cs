using System;
using System.Threading.Tasks;
using PipeNet.Test.Chr.Pipeline;
using Xunit;

namespace PipeNet.Test.Chr
{
    public class PipelineTest
    {
        [Fact]
        public async Task Pipe_ShouldRunPipe_ReturnsLastNodeName()
        {
            OrderData result= await new Pipe<OrderData>()
                .Next(new OrderNode())
                .Next(new ProducingNode())
                .Finally(new CheckoutNode())
                .Execute(new OrderData()
                {
                    Name = "Coffee",
                    State = this.GetType().Name, 
                });
            
            Assert.Equal(nameof(CheckoutNode),result.State);
        }
        
        
        [Fact]
        public async Task Pipe_ShouldRunPipe_ThrowsException()
        {
            var action = new Func<Task>(async () =>
            {
                var result = await new Pipe<OrderData>()
                    .Next(new OrderNode())
                    .Next(new ExceptionNode())
                    .Next(new ProducingNode())
                    .Finally(new CheckoutNode())
                    .Execute(new OrderData()
                    {
                        Name = "Coffee",
                        State = this.GetType().Name,
                    });
            });

            var exception = await Assert.ThrowsAsync<Exception>(action);
            Assert.Equal("100",exception.Message);
        }
    }
}