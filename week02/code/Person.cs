using System;

namespace Week02Queues
{
    /// <summary>
    /// Represents a person in the TakingTurnsQueue.
    /// Turns <= 0 means infinite turns.
    /// </summary>
    public class Person
    {
        public readonly string Name;
        public int Turns { get; set; }

        public Person(string name, int turns)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));

            Name = name;
            Turns = turns;
        }

        public override string ToString()
        {
            return Turns <= 0 ? $"({Name}:Forever)" : $"({Name}:{Turns})";
        }
    }
}
