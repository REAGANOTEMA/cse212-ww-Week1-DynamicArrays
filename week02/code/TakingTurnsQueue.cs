using System;

namespace Week02Queues
{
    /// <summary>
    /// Circular queue where each person takes turns.
    /// People with finite turns are dequeued until turns run out.
    /// People with infinite turns (Turns <= 0) stay in the queue forever.
    /// </summary>
    public class TakingTurnsQueue
    {
        private readonly PersonQueue _people = new PersonQueue();

        public int Length => _people.Length;

        /// <summary>
        /// Add a new person to the queue with a name and number of turns.
        /// </summary>
        public void AddPerson(string name, int turns)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));

            var person = new Person(name, turns);
            _people.Enqueue(person);
        }

        /// <summary>
        /// Get the next person in the queue and return them.
        /// The person goes to the back if they have turns left or infinite turns.
        /// Throws InvalidOperationException if the queue is empty.
        /// </summary>
        public Person GetNextPerson()
        {
            if (_people.IsEmpty())
                throw new InvalidOperationException("The queue is empty.");

            Person person = _people.Dequeue();

            // Re-enqueue if infinite turns or still has turns left
            if (person.Turns <= 0 || person.Turns > 1)
            {
                if (person.Turns > 1)
                    person.Turns--; // decrement finite turns
                _people.Enqueue(person);
            }

            return person;
        }

        public override string ToString()
        {
            return _people.ToString();
        }
    }
}
