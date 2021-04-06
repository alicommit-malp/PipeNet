using System.Threading.Tasks;

namespace PipeNet
{
    public class Pipe<T> : Node<T>
    {
        public Pipe()
        {
            Root = this;
        }
        
        public override Task<T> Execute(T param)
        {
            return NextNode.Execute(param);
        }
    }
}