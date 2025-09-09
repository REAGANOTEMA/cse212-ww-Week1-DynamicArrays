// Author: Reagan Otema
// Date: 2025-09-07
// Description: PriorityQueue implementation

using System;
using System.Collections.Generic;

namespace Week02Queues
{
    /// <summary>
    /// A simple priority queue where higher numbers have higher priority.
    /// FIFO order is preserved for items with the same priority.
    /// </summary>
    public class PriorityQueue<T>
    {
        private readonly List<PriorityItem> _queue = new List<PriorityItem>();

        public void Enqueue(T value, int priority)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));
            _queue.Add(new PriorityItem(value, priority));
        }

        public T Dequeue()
        {
            if (_queue.Count == 0)
                throw new InvalidOperationException("The queue is empty.");

            int highPriorityIndex = 0;
            int highestPriority = _queue[0].Priority;

            // find the first item with the highest priority
            for (int i = 1; i < _queue.Count; i++)
            {
                if (_queue[i].Priority > highestPriority)
                {
                    highestPriority = _queue[i].Priority;
                    highPriorityIndex = i;
                }
            }

            var value = _queue[highPriorityIndex].Value;
            _queue.RemoveAt(highPriorityIndex);
            return value;
        }

        private class PriorityItem
        {
            public T Value { get; }
            public int Priority { get; }

            public PriorityItem(T value, int priority)
            {
                Value = value;
                Priority = priority;
            }
        }
    }
}
