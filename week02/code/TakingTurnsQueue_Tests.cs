// Author: Reagan Otema
// Date: 2025-09-07
// Description: Unit tests for TakingTurnsQueue

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Week02Queues;

[TestClass]
public class TakingTurnsQueueTests
{
    [TestMethod]
    public void TestFiniteTurns()
    {
        var queue = new TakingTurnsQueue();
        queue.AddPerson(new Person("Bob", 2));
        queue.AddPerson(new Person("Tim", 3));

        string result = "";
        result += queue.GetNextPerson().Name + " "; // Bob
        result += queue.GetNextPerson().Name + " "; // Tim
        result += queue.GetNextPerson().Name + " "; // Bob
        result += queue.GetNextPerson().Name + " "; // Tim
        result += queue.GetNextPerson().Name + " "; // Tim

        Assert.AreEqual("Bob Tim Bob Tim Tim ", result);
    }

    [TestMethod]
    public void TestInfiniteTurns()
    {
        var queue = new TakingTurnsQueue();
        queue.AddPerson(new Person("Alice", 0));

        string result = "";
        for (int i = 0; i < 4; i++)
        {
            result += queue.GetNextPerson().Name + " ";
        }

        Assert.AreEqual("Alice Alice Alice Alice ", result);
    }

    [TestMethod]
    public void TestEmptyQueue()
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
