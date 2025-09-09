// Author: Reagan Otema
// Date: 2025-09-07
// Description: Unit tests for PriorityQueue

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Week02Queues;

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    public void TestDequeueByPriority()
    {
        var pq = new PriorityQueue<string>();
        pq.Enqueue("A", 2);
        pq.Enqueue("B", 1);
        pq.Enqueue("C", 3);

        Assert.AreEqual("C", pq.Dequeue());
        Assert.AreEqual("A", pq.Dequeue());
        Assert.AreEqual("B", pq.Dequeue());
    }

    [TestMethod]
    public void TestFIFOTie()
    {
        var pq = new PriorityQueue<string>();
        pq.Enqueue("A", 5);
        pq.Enqueue("B", 5);
        pq.Enqueue("C", 5);

        Assert.AreEqual("A", pq.Dequeue());
        Assert.AreEqual("B", pq.Dequeue());
        Assert.AreEqual("C", pq.Dequeue());
    }

    [TestMethod]
    public void TestEmptyQueue()
    {
        var pq = new PriorityQueue<string>();

        try
        {
            pq.Dequeue();
            Assert.Fail("Expected exception not thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
    }
}
