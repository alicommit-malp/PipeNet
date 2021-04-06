using System;
using System.Threading.Tasks;

namespace PipeNet.Test.Chr.Pipeline
{
    public class ExceptionNode : Node<OrderData>
    {
        public override Task<OrderData> Execute(OrderData param)
        {
            param.State = nameof(ExceptionNode);
            throw new Exception("100");
        }
    }
}