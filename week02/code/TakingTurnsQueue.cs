using System;

public class TakingTurnsQueue
{
    private readonly PersonQueue _people = new();

    public int Length => _people.Length;

    public void AddPerson(string name, int turns)
    {
        var person = new Person(name, turns);
        _people.Enqueue(person);
    }

    public Person GetNextPerson()
    {
        if (_people.IsEmpty())
        {
            throw new InvalidOperationException("No one in the queue.");
        }

        Person person = _people.Dequeue();

        if (person.Turns <= 0)
        {
            // Infinite turns → Re-add as-is
            _people.Enqueue(person);
        }
        else if (person.Turns > 1)
        {
            // More than 1 turn left → Re-add with one fewer turn
            var updatedPerson = new Person(person.Name, person.Turns - 1);
            _people.Enqueue(updatedPerson);
        }

        // If Turns == 1 → Don't enqueue again (they're done)

        return person;
    }

    public override string ToString()
    {
        return _people.ToString();
    }
}
