// Author: Reagan Otema
// Date: 2025-09-07
// Description: TakingTurnsQueue where people take turns until they run out of turns,
// or infinitely if Turns = -1.

using System;
using System.Collections.Generic;

namespace Week02Queues
{
    public class TakingTurnsQueue
    {
        private readonly Queue<Person> _people = new Queue<Person>();

        public void AddPerson(Person person)
        {
            _people.Enqueue(person);
        }

        public Person GetNextPerson()
        {
            if (_people.Count == 0)
            {
                // FIX: Changed exception message to match expected test result
                throw new InvalidOperationException("No one in the queue.");
            }

            var current = _people.Dequeue();

            if (current.Turns > 1)
            {
                current.Turns--;
                _people.Enqueue(current);
            }
            else if (current.Turns == -1)
            {
                _people.Enqueue(current);
            }

            return current;
        }
    }
}
