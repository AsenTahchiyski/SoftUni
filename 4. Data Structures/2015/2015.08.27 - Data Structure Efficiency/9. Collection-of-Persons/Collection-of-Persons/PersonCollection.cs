using System;
using System.Collections.Generic;
using Wintellect.PowerCollections;

public class PersonCollection : IPersonCollection
{
    private Dictionary<string, Person> personsByEmail = new Dictionary<string, Person>();
    private Dictionary<string, SortedSet<Person>> personsByEmailDomain = new Dictionary<string, SortedSet<Person>>();
    private Dictionary<string, SortedSet<Person>> personsByNameAndTown = new Dictionary<string, SortedSet<Person>>();
    private OrderedDictionary<int, SortedSet<Person>> personsByAge = new OrderedDictionary<int, SortedSet<Person>>();
    private Dictionary<string, OrderedDictionary<int, SortedSet<Person>>> personsByAgeAndTown = new Dictionary<string, OrderedDictionary<int, SortedSet<Person>>>();

    public bool AddPerson(string email, string name, int age, string town)
    {
        if (this.FindPerson(email) != null)
        {
            // Person already exists
            return false;
        }

        var person = new Person()
        {
            Email = email,
            Name = name,
            Age = age,
            Town = town
        };

        // Add by email
        this.personsByEmail.Add(email, person);

        // Add by email domain
        var emailDomain = this.ExtractEmailDomain(email);
        if (! this.personsByEmailDomain.ContainsKey(emailDomain))
        {
            this.personsByEmailDomain.Add(emailDomain, new SortedSet<Person>());
        }
        this.personsByEmailDomain[emailDomain].Add(person);

        // Add by {name + town}
        var nameAndTown = this.CombineNameAndTown(name, town);
        if (!this.personsByNameAndTown.ContainsKey(nameAndTown))
        {
            this.personsByNameAndTown.Add(nameAndTown, new SortedSet<Person>());
        }
        this.personsByNameAndTown[nameAndTown].Add(person);

        // Add by age
        if (!this.personsByAge.ContainsKey(age))
        {
            this.personsByAge.Add(age, new SortedSet<Person>());
        }
        this.personsByAge[age].Add(person);

        // Add by {age + town}
        OrderedDictionary<int, SortedSet<Person>> personsByTown;
        if (! this.personsByAgeAndTown.TryGetValue(town, out personsByTown))
        {
            personsByTown = new OrderedDictionary<int, SortedSet<Person>>();
            personsByAgeAndTown.Add(town, personsByTown);
        }
        if (!personsByTown.ContainsKey(age))
        {
            personsByTown.Add(age, new SortedSet<Person>());
        }
        personsByTown[age].Add(person);

        return true;
    }

    private string ExtractEmailDomain(string email)
    {
        var domain = email.Split('@')[1];
        return domain;
    }

    private string CombineNameAndTown(string name, string town)
    {
        const string separator = "|!|";
        return name + separator + town;
    }

    public int Count
    {
        get { return this.personsByEmail.Count; }
    }

    public Person FindPerson(string email)
    {
        Person person;
        var personExists = this.personsByEmail.TryGetValue(email, out person);
        return person;
    }

    public bool DeletePerson(string email)
    {
        var person = this.FindPerson(email);
        if (person == null)
        {
            // Person does not exist
            return false;
        }

        // Delete person from personsByEmail
        var personDeleted = this.personsByEmail.Remove(email);

        // Delete person from personsByEmailDomain
        var emailDomain = this.ExtractEmailDomain(email);
        this.personsByEmailDomain[emailDomain].Remove(person);

        // Delete person by personsByNameAndTown
        var nameAndTown = this.CombineNameAndTown(person.Name, person.Town);
        this.personsByNameAndTown[nameAndTown].Remove(person);

        // Delete person by personsByAge
        this.personsByAge[person.Age].Remove(person);

        // Add person from personsByAgeAndTown
        personsByAgeAndTown[person.Town][person.Age].Remove(person);

        return true;
    }

    public IEnumerable<Person> FindPersons(string emailDomain)
    {
        if (this.personsByEmailDomain.ContainsKey(emailDomain))
        {
            return this.personsByEmailDomain[emailDomain];
        }
        return new Person[0];
    }

    public IEnumerable<Person> FindPersons(string name, string town)
    {
        var nameAndTown = this.CombineNameAndTown(name, town);
        if (this.personsByNameAndTown.ContainsKey(nameAndTown))
        {
            return this.personsByNameAndTown[nameAndTown];
        }
        return new Person[0];
    }

    public IEnumerable<Person> FindPersons(int startAge, int endAge)
    {
        var personsInRange = 
            this.personsByAge.Range(startAge, true, endAge, true);
        foreach (var persons in personsInRange)
        {
            foreach (var person in persons.Value)
            {
                yield return person;
            }
        }
    }

    public IEnumerable<Person> FindPersons(
        int startAge, int endAge, string town)
    {
        if (! this.personsByAgeAndTown.ContainsKey(town))
        {
            yield break;
        }

        var personsInRange =
            this.personsByAgeAndTown[town]
            .Range(startAge, true, endAge, true);
        foreach (var persons in personsInRange)
        {
            foreach (var person in persons.Value)
            {
                yield return person;
            }
        }
    }
}
