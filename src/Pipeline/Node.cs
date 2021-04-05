using System.Threading.Tasks;

namespace Pipe.Net
{
    public abstract class Node<T>
    {
        public abstract Task InvokeAsync(T data);
    }
}