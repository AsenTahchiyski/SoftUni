//18
using System;
using System.Collections.Generic;
using Wintellect.PowerCollections;

public class PersonCollection : IPersonCollection
{
    private Dictionary<string, Person> personsByEmail =
        new Dictionary<string, Person>();
    private Dictionary<string, SortedSet<Person>> personsByEmailDomain =
        new Dictionary<string, SortedSet<Person>>();
    private Dictionary<string, SortedSet<Person>> personsByNameAndTown =
        new Dictionary<string, SortedSet<Person>>();
    private OrderedDictionary<int, SortedSet<Person>> personsByAge =
        new OrderedDictionary<int, SortedSet<Person>>();
    private Dictionary<string, OrderedDictionary<int, SortedSet<Person>>> personsByTownAndAge =
        new Dictionary<string, OrderedDictionary<int, SortedSet<Person>>>();

    public bool AddPerson(string email, string name, int age, string town)
    {
        if (this.FindPerson(email) != null)
        {
            // Person already exists
            return false;
        }

        var person = new Person()
        {
            Name = name,
            Age = age,
            Email = email,
            Town = town
        };
        
        // Add by email
        this.personsByEmail.Add(email, person);

        // Add by email domain
        var emailDomain = this.ExtractEmailDomain(email);
        this.personsByEmailDomain.AppendValueToKey(emailDomain, person);

        // Add by {name + town}
        var nameAndTown = this.CombineNameAndTown(name, town);
        this.personsByNameAndTown.AppendValueToKey(nameAndTown, person);

        return true;
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

        // Delete by {name + town}
        var nameAndTown = this.CombineNameAndTown(person.Name, person.Town);
        this.personsByNameAndTown[nameAndTown].Remove(person);

        return true;
    }

    public IEnumerable<Person> FindPersons(string emailDomain)
    {
        return this.personsByEmailDomain.GetValuesForKey(emailDomain);
    }

    public IEnumerable<Person> FindPersons(string name, string town)
    {
        var nameAndTown = this.CombineNameAndTown(name, town);
        return this.personsByNameAndTown.GetValuesForKey(nameAndTown);
    }

    public IEnumerable<Person> FindPersons(int startAge, int endAge)
    {
        // TODO: implement this
        throw new NotImplementedException();
    }

    public IEnumerable<Person> FindPersons(
        int startAge, int endAge, string town)
    {
        // TODO: implement this
        throw new NotImplementedException();
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
}
