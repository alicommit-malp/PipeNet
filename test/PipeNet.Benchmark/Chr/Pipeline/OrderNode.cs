using System.Threading.Tasks;

namespace PipeNet.Benchmark.Chr.Pipeline
{
    public class OrderNode : Node<OrderData>
    {
        public override async Task<OrderData> Execute(OrderData param)
        {
            param.State = GetType().Name;
            return await base.Execute(param);
        }
    }
}