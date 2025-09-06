using System;
using System.Collections.Generic;

namespace Week02Queues
{
    /// <summary>
    /// A basic FIFO queue for Person objects
    /// </summary>
    public class PersonQueue
    {
        private readonly List<Person> _queue = new List<Person>();

        public int Length => _queue.Count;

        /// <summary>
        /// Add a person to the back of the queue
        /// </summary>
        /// <param name="person">The person to add</param>
        public void Enqueue(Person person)
        {
            if (person == null) throw new ArgumentNullException(nameof(person));
            _queue.Add(person); // add to the end for FIFO
        }

        /// <summary>
        /// Remove and return the person at the front of the queue
        /// </summary>
        public Person Dequeue()
        {
            if (_queue.Count == 0)
                throw new InvalidOperationException("The queue is empty.");

            Person person = _queue[0];
            _queue.RemoveAt(0); // remove from the front
            return person;
        }

        public bool IsEmpty()
        {
            return _queue.Count == 0;
        }

        public override string ToString()
        {
            return $"[{string.Join(", ", _queue)}]";
        }
    }
}
