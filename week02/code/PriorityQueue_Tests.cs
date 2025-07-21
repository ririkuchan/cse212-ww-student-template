using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    public void TestPriorityQueue_SimpleEnqueueDequeue()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("A", 1);
        pq.Enqueue("B", 5);
        pq.Enqueue("C", 3);

        Assert.AreEqual("B", pq.Dequeue());
        Assert.AreEqual("C", pq.Dequeue());
        Assert.AreEqual("A", pq.Dequeue());
    }

    [TestMethod]
    public void TestPriorityQueue_TieBreakerFIFO()
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
    public void TestPriorityQueue_EmptyThrows()
    {
        var pq = new PriorityQueue();

        try
        {
            pq.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
    }
}
