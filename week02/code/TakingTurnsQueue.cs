// Author: Reagan Otema
// Date: 2025-09-07
// Description: Implements a circular queue where people take turns

using System;
using System.Collections.Generic;

namespace Week02Queues
{
    public class TakingTurnsQueue
    {
        private readonly Queue<Person> _queue = new Queue<Person>();

        public void AddPerson(Person person)
        {
            if (person == null)
                throw new ArgumentNullException(nameof(person));

            _queue.Enqueue(person);
        }

        public Person GetNextPerson()
        {
            if (_queue.Count == 0)
                throw new InvalidOperationException("No one in the queue.");

            var person = _queue.Dequeue();

            if (person.Turns > 1)
            {
                person.Turns--;
                _queue.Enqueue(person);
            }
            else if (person.Turns <= 0) // infinite turns
            {
                _queue.Enqueue(person);
            }

            return person;
        }
    }
}
