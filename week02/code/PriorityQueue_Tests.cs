// Author: Reagan Otema
// Date: 2025-09-07
// Description: Unit tests for PriorityQueue with defect notes.

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Week02Queues;

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue A(2), B(1), C(3), then dequeue all.
    // Expected Result: C, A, B
    // Defect(s) Found: Original test incorrectly used built-in PriorityQueue<T>.
    // Fixed to test Week02Queues.PriorityQueue instead.
    public void TestPriorityQueue_DequeueByPriority()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("A", 2);
        pq.Enqueue("B", 1);
        pq.Enqueue("C", 3);

        Assert.AreEqual("C", pq.Dequeue());
        Assert.AreEqual("A", pq.Dequeue());
        Assert.AreEqual("B", pq.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue multiple with same priority (FIFO check).
    // Expected Result: A, B, C in order.
    // Defect(s) Found: Original test incorrectly used generic PriorityQueue<T>.
    public void TestPriorityQueue_FIFOTie()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("A", 5);
        pq.Enqueue("B", 5);
        pq.Enqueue("C", 5);

        Assert.AreEqual("A", pq.Dequeue());
        Assert.AreEqual("B", pq.Dequeue());
        Assert.AreEqual("C", pq.Dequeue());
    }

    [TestMethod]
    // Scenario: Dequeue from empty queue.
    // Expected Result: InvalidOperationException with "The queue is empty."
    // Defect(s) Found: Original test used wrong type (built-in PriorityQueue<T>).
    public void TestPriorityQueue_Empty()
    {
        var pq = new PriorityQueue();

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
