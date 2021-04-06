using System.Threading.Tasks;

namespace PipeNet
{
    public abstract class Node<T>
    {
        protected Node<T> Root;
        protected Node<T> NextNode;

        public Node<T> Next(Node<T> nextNode)
        {
            NextNode = nextNode;
            NextNode.Root = Root;
            return NextNode;
        }

        public Node<T> Finally(Node<T> lastNode)
        {
            NextNode = lastNode;
            NextNode.Root = Root;
            return Root;
        }

        public virtual Task<T> Execute(T param)
        {
            return NextNode != null ? NextNode.Execute(param) : Task.FromResult(param);
        }
    }
}