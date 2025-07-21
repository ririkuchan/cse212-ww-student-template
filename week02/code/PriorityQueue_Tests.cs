using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add three items with different priorities.
    // Expected Result: The item with the highest priority is dequeued first.
    // Defect(s) Found: None
    public void TestPriorityQueue_HighestPriority()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("A", 1);
        pq.Enqueue("B", 3);
        pq.Enqueue("C", 2);

        Assert.AreEqual("B", pq.Dequeue());
        Assert.AreEqual("C", pq.Dequeue());
        Assert.AreEqual("A", pq.Dequeue());
    }

    [TestMethod]
    // Scenario: Add two items with the same highest priority.
    // Expected Result: FIFO order is maintained among equal priority items.
    // Defect(s) Found: None
    public void TestPriorityQueue_SamePriorityFIFO()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("X", 5);
        pq.Enqueue("Y", 5);

        Assert.AreEqual("X", pq.Dequeue());
        Assert.AreEqual("Y", pq.Dequeue());
    }

    [TestMethod]
    // Scenario: Dequeue from an empty queue.
    // Expected Result: InvalidOperationException with "The queue is empty."
    // Defect(s) Found: None
    public void TestPriorityQueue_EmptyQueue()
    {
        var pq = new PriorityQueue();

        try
        {
            pq.Dequeue();
            Assert.Fail("Expected exception was not thrown.");
        }
        catch (InvalidOperationException ex)
        {
            Assert.AreEqual("The queue is empty.", ex.Message);
        }
    }
}
