using System.Threading.Tasks;

namespace Pipeline
{
    public abstract class Node<T>
    {
        public abstract Task InvokeAsync(T data);
    }
}