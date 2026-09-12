using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue three items with different priorities, dequeue once
    // Expected Result: The item with the highest priority (5) is returned
    // Defect(s) Found: Test passed, but this does not prove the code is correct — the
    // buggy loop bound (index < Count - 1) happened not to matter here since the
    // highest-priority item was not the last one enqueued.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("low", 1);
        priorityQueue.Enqueue("high", 5);
        priorityQueue.Enqueue("medium", 3);

        var result = priorityQueue.Dequeue();
        Assert.AreEqual("high", result);
    }

    [TestMethod]
    // Scenario: Enqueue two items with the same highest priority
    // Expected Result: The one enqueued first (FIFO tie-break) is returned
    // Defect(s) Found: Test passed, but only because the loop never executes when
    // Count == 2 under the buggy bound, defaulting to index 0 by accident — not
    // because tie-break logic is actually implemented.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("first", 5);
        priorityQueue.Enqueue("second", 5);

        var result = priorityQueue.Dequeue();
        Assert.AreEqual("first", result);
    }

    [TestMethod]
    // Scenario: Dequeue from an empty queue
    // Expected Result: InvalidOperationException with message "The queue is empty."
    // Defect(s) Found: 
    public void TestPriorityQueue_EmptyThrows()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
    }

    [TestMethod]
    // Scenario: Dequeue must remove the item so the next dequeue returns a different item
    // Expected Result: Second dequeue returns the next highest priority item, not the same one again
    // Defect(s) Found: Failed - expected "b", got "a". Dequeue never removes the returned
    // item from the internal list (missing RemoveAt), so the same item is returned every time.
    public void TestPriorityQueue_RemovesAfterDequeue()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("a", 1);
        priorityQueue.Enqueue("b", 2);

        var first = priorityQueue.Dequeue();
        var second = priorityQueue.Dequeue();

        Assert.AreEqual("b", first);
        Assert.AreEqual("a", second);
    }

    [TestMethod]
    // Scenario: The highest priority item is the LAST one enqueued
    // Expected Result: That last item is still correctly identified and returned
    // Defect(s) Found: Failed - expected "high", got "medium". The for loop condition
    // (index < _queue.Count - 1) excludes the last index of the list, so the last-enqueued
    // item is never considered as a candidate for highest priority.
    public void TestPriorityQueue_HighestPriorityIsLastItem()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("low", 1);
        priorityQueue.Enqueue("medium", 3);
        priorityQueue.Enqueue("high", 5);

        var result = priorityQueue.Dequeue();
        Assert.AreEqual("high", result);
    }
}