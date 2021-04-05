using System.Threading.Tasks;

namespace PipeNet
{
    public abstract class Node<T>
    {
        public abstract Task InvokeAsync(T data);
    }
}