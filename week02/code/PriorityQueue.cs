using System;
using System.Collections.Generic;

namespace Week02Queues
{
    /// <summary>
    /// A priority queue where higher numbers have higher priority.
    /// FIFO is maintained if multiple items have the same highest priority.
    /// </summary>
    public class PriorityQueue
    {
        private readonly List<PriorityItem> _queue = new List<PriorityItem>();

        /// <summary>
        /// Add a new value to the queue with an associated priority. Always added to the back.
        /// </summary>
        public void Enqueue(string value, int priority)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            _queue.Add(new PriorityItem(value, priority));
        }

        /// <summary>
        /// Remove and return the item with the highest priority. FIFO if tie.
        /// Throws InvalidOperationException if queue is empty.
        /// </summary>
        public string Dequeue()
        {
            if (_queue.Count == 0)
                throw new InvalidOperationException("The queue is empty.");

            int highPriorityIndex = 0;
            int highestPriority = _queue[0].Priority;

            // Find first item with highest priority (FIFO for ties)
            for (int i = 1; i < _queue.Count; i++)
            {
                if (_queue[i].Priority > highestPriority)
                {
                    highestPriority = _queue[i].Priority;
                    highPriorityIndex = i;
                }
            }

            string value = _queue[highPriorityIndex].Value;
            _queue.RemoveAt(highPriorityIndex); // remove dequeued item
            return value;
        }

        // DO NOT MODIFY
        public override string ToString()
        {
            return $"[{string.Join(", ", _queue)}]";
        }
    }

    internal class PriorityItem
    {
        internal string Value { get; set; }
        internal int Priority { get; set; }

        internal PriorityItem(string value, int priority)
        {
            Value = value;
            Priority = priority;
        }

        // DO NOT MODIFY
        public override string ToString()
        {
            return $"{Value} (Pri:{Priority})";
        }
    }
}
