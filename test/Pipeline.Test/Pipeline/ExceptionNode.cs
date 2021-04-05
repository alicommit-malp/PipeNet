using System;
using System.Threading.Tasks;

namespace Pipeline.Test.Pipeline
{
    public class ExceptionNode : Node<OrderData>
    {
        public override Task InvokeAsync(OrderData data)
        {
            data.State = nameof(ExceptionNode);
            throw new Exception("100");
        }
    }
}