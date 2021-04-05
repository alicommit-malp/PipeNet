using System.Threading.Tasks;

namespace Pipeline.Test.Pipeline
{
    public class CheckoutNode : Node<OrderData>
    {
        public override Task InvokeAsync(OrderData data)
        {
            data.State = nameof(CheckoutNode);
            return Task.CompletedTask;
        }
    }
}