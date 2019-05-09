using System.Collections.Generic;

namespace ArthurHNL.GitForBI.App.Extensions
{
    /// <summary>
    /// Provides extension methods for the <see cref="Queue{T}"/> class.
    /// </summary>
    public static class GenericQueueExtensions
    {
        /// <summary>
        /// Appends another <see cref="Queue{T}"/> to <c>this</c> <see cref="Queue{T}"/>.
        /// The items of the <paramref name="other"/> <see cref="Queue{T}"/> are placed behind
        /// <c>this</c> <see cref="Queue{T}"/>.
        /// This method is not thread-safe as it will modify your <see cref="Queue{T}"/>.
        /// </summary>
        /// <param name="queue">The queue.</param>
        /// <param name="other">The other queue.</param>
        /// <returns><c>this</c> queue to make chaining possible.<returns>
        public static Queue<T> AppendQueue<T>(this Queue<T> queue, Queue<T> other)
        {
            while(other.Count != 0)
            {
                queue.Enqueue(other.Dequeue());
            }
            return queue;
        }
    }
}
