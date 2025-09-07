// Author: Reagan Otema
// Date: 2025-09-07
// Description: Unit tests for TakingTurnsQueue with defect notes.

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Week02Queues;

[TestClass]
public class TakingTurnsQueueTests
{
    [TestMethod]
    // Scenario: Queue with Bob (2), Tim (5), Sue (3) and run until empty.
    // Expected Result: Bob Tim Sue Bob Tim Sue Tim Sue Tim Tim
    // Defect(s) Found: Original GetNextPerson() threw wrong message
    // ("The queue is empty.") instead of "No one in the queue."
    public void TestTakingTurnsQueue_FiniteRepetition()
    {
        var queue = new TakingTurnsQueue();
        queue.AddPerson(new Person("Bob", 2));
        queue.AddPerson(new Person("Tim", 5));
        queue.AddPerson(new Person("Sue", 3));

        string result = "";
        try
        {
            while (true)
            {
                result += queue.GetNextPerson().Name + " ";
            }
        }
        catch (InvalidOperationException) { }

        Assert.AreEqual("Bob Tim Sue Bob Tim Sue Tim Sue Tim Tim ", result);
    }

    [TestMethod]
    // Scenario: Queue with Alice (-1 = infinite) run 5 times.
    // Expected Result: Alice repeated 5 times.
    // Defect(s) Found: Original code did not re-enqueue infinite-turn people correctly.
    public void TestTakingTurnsQueue_InfinitePerson()
    {
        var queue = new TakingTurnsQueue();
        queue.AddPerson(new Person("Alice", -1));

        string result = "";
        for (int i = 0; i < 5; i++)
        {
            result += queue.GetNextPerson().Name + " ";
        }

        Assert.AreEqual("Alice Alice Alice Alice Alice ", result);
    }

    [TestMethod]
    // Scenario: Call GetNextPerson() on empty queue.
    // Expected Result: InvalidOperationException with "No one in the queue."
    // Defect(s) Found: Original code threw exception with wrong message.
    public void TestTakingTurnsQueue_EmptyQueue()
    {
        var queue = new TakingTurnsQueue();

        try
        {
            queue.GetNextPerson();
            Assert.Fail("Expected exception not thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("No one in the queue.", e.Message);
        }
    }
}
