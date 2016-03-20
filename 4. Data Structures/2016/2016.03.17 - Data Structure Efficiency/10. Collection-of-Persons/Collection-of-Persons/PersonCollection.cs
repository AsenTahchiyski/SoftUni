using System;
using System.Collections.Generic;
using System.Linq;
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
    private Dictionary<string, OrderedDictionary<int, SortedSet<Person>>> personsByTownAndAge = new Dictionary<string, OrderedDictionary<int, SortedSet<Person>>>();

    public bool AddPerson(string email, string name, int age, string town)
    {
        if(personsByEmail.ContainsKey(email))
        {
            return false;
        }

        Person person = new Person()
        {
            Email = email,
            Name = name,
            Age = age,
            Town = town
        };


        // personsByEmail
        this.personsByEmail.Add(email, person);

        // personsByEmailDomain - Dictionary<string, SortedSet<Person>>
        string domain = email.Split('@')[1];
        if (!this.personsByEmailDomain.ContainsKey(domain))
        {
            this.personsByEmailDomain[domain] = new SortedSet<Person>();
        }

        this.personsByEmailDomain[domain].Add(person);

        // personsByNameAndTown - Dictionary<string, SortedSet<Person>>
        string nameAndTown = name + town;
        if (!this.personsByNameAndTown.ContainsKey(nameAndTown)) {
            this.personsByNameAndTown[nameAndTown] = new SortedSet<Person>();
        }

        this.personsByNameAndTown[nameAndTown].Add(person);

        // personsByAge - OrderedDictionary<int, SortedSet<Person>>
        if (!this.personsByAge.ContainsKey(age))
        {
            this.personsByAge[age] = new SortedSet<Person>();
        }

        this.personsByAge[age].Add(person);

        // personsByTownAndAge - Dictionary<string, OrderedDictionary<int, SortedSet<Person>>>
        if (!this.personsByTownAndAge.ContainsKey(town))
        {
            this.personsByTownAndAge[town] = new OrderedDictionary<int, SortedSet<Person>>();
            this.personsByTownAndAge[town].Add(age, new SortedSet<Person>());
            this.personsByTownAndAge[town][age].Add(person);
        }
        else if (!this.personsByTownAndAge[town].ContainsKey(age))
        {
            this.personsByTownAndAge[town].Add(age, new SortedSet<Person>());
            this.personsByTownAndAge[town][age].Add(person);
        }   
        else if (!this.personsByTownAndAge[town][age].Contains(person))
        {
            this.personsByTownAndAge[town][age].Add(person);
        }

        return true;
    }

    public int Count
    {
        get
        {
            return this.personsByEmail.Count;
        }
    }

    public Person FindPerson(string email)
    {
        if (this.personsByEmail.ContainsKey(email))
        {
            return this.personsByEmail[email];
        }

        return null;
    }

    public bool DeletePerson(string email)
    {
        // TODO: implement this
        throw new NotImplementedException();
    }

    public IEnumerable<Person> FindPersons(string emailDomain)
    {
        if (this.personsByEmailDomain.ContainsKey(emailDomain))
        {
            return this.personsByEmailDomain[emailDomain];
        }

        return null;
    }

    public IEnumerable<Person> FindPersons(string name, string town)
    {
        string nameAndTown = name + town;
        if (this.personsByNameAndTown.ContainsKey(nameAndTown))
        {
            return this.personsByNameAndTown[nameAndTown];
        }

        return null;
    }

    public IEnumerable<Person> FindPersons(int startAge, int endAge)
    {
        var personsInRange = 
            this.personsByAge.Range(startAge, true, endAge, true);
        foreach (var personsByAge in personsInRange)
        {
            foreach (var person in personsByAge.Value)
            {
                yield return person;
            }
        }
    }

    public IEnumerable<Person> FindPersons(
        int startAge, int endAge, string town)
    {
        var personsInRange = this.personsByTownAndAge[town].Range(startAge, true, endAge, true);
        foreach (var personsByAge in personsInRange)
        {
            foreach (var person in personsByAge.Value)
            {
                yield return person;
            }
        }
    }
}
