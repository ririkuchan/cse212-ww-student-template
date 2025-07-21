using System;
using System.Collections.Generic;

public class PriorityQueue
{
    private class QueueItem
    {
        public string Value { get; set; }
        public int Priority { get; set; }

        public QueueItem(string value, int priority)
        {
            Value = value;
            Priority = priority;
        }
    }

    private List<QueueItem> _items = new();

    public void Enqueue(string value, int priority)
    {
        _items.Add(new QueueItem(value, priority));
    }

    public string Dequeue()
    {
        if (_items.Count == 0)
        {
            throw new InvalidOperationException("The queue is empty.");
        }

        int maxPriority = int.MinValue;
        int index = -1;

        for (int i = 0; i < _items.Count; i++)
        {
            if (_items[i].Priority > maxPriority)
            {
                maxPriority = _items[i].Priority;
                index = i;
            }
        }

        string result = _items[index].Value;
        _items.RemoveAt(index);
        return result;
    }
}
