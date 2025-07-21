using System.Collections.Generic;

public class Person
{
    public string Name { get; }
    public int Turns { get; set; }

    public Person(string name, int turns)
    {
        Name = name;
        Turns = turns;
    }
}

public class PersonQueue
{
    private readonly Queue<Person> _queue = new();

    public void Enqueue(Person person)
    {
        _queue.Enqueue(person);
    }

    public Person Dequeue()
    {
        return _queue.Dequeue();
    }

    public bool IsEmpty()
    {
        return _queue.Count == 0;
    }

    public int Length => _queue.Count;

    public override string ToString()
    {
        return string.Join(", ", _queue);
    }
}
