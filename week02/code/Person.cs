// Author: Reagan Otema
// Date: 2025-09-07
// Description: Person class used for TakingTurnsQueue.

namespace Week02Queues
{
    public class Person
    {
        public string Name { get; }
        public int Turns { get; set; }  // -1 = infinite turns

        public Person(string name, int turns = -1)
        {
            Name = name;
            Turns = turns;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
