using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pipe.Net
{
    public class Pipe<T>
    {
        private readonly Queue<Node<T>> _nodes = new Queue<Node<T>>();

        /// <summary>
        /// Adding easily the <see cref="Node{T}"/> to the pipeline
        /// </summary>
        /// <param name="node">A step in the pipeline which must inherit from the <see cref="Node{T}"/> class</param>
        /// <returns>This <see cref="Pipe{T}"/> to provide the builder pattern feature</returns>
        public Pipe<T> Add(Node<T> node)
        {
            _nodes.Enqueue(node);
            return this;
        }

        /// <summary>
        /// Run all the <see cref="Node{T}"/> in the order the have been added
        /// </summary>
        /// <param name="param"></param>
        /// <returns>A task which will be responsible for the whole execution of the pipeline</returns>
        public async Task<T> Run(T param)
        {
            while (_nodes.TryDequeue(out var node))
            {
                await node.InvokeAsync(param);
            }

            return param;
        }
    }
}