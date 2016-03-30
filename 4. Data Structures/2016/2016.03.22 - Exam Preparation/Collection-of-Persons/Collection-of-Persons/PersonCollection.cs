using System;
using System.Collections.Generic;
using Wintellect.PowerCollections;

public class PersonCollection : IPersonCollection
{
    private Dictionary<string, Person> peopleByEmail;
    private Dictionary<string, SortedSet<Person>> peopleByDomain;
    private Dictionary<string, SortedSet<Person>> peopleByNameAndTown;
    private OrderedDictionary<int, SortedSet<Person>> peopleByAge;
    private Dictionary<string, OrderedDictionary<int, SortedSet<Person>>> peopleByTownAndAge;

    public PersonCollection()
    {
        this.peopleByEmail = new Dictionary<string, Person>();
        this.peopleByDomain = new Dictionary<string, SortedSet<Person>>();
        this.peopleByNameAndTown = new Dictionary<string, SortedSet<Person>>();
        this.peopleByTownAndAge = new Dictionary<string, OrderedDictionary<int, SortedSet<Person>>>();
        this.peopleByAge = new OrderedDictionary<int, SortedSet<Person>>();
    }

    public bool AddPerson(string email, string name, int age, string town)
    {
        // check if person is already present
        if (this.peopleByEmail.ContainsKey(email))
        {
            return false;
        }

        var person = new Person() { Email = email, Name = name, Age = age, Town = town };

        // add to peopleByEmail
        this.peopleByEmail.Add(email, person);

        // add to peopleByDomain
        int index = email.IndexOf('@');
        string domain = email.Substring(index + 1);
        if (!this.peopleByDomain.ContainsKey(domain))
        {
            this.peopleByDomain.Add(domain, new SortedSet<Person>());
        }

        this.peopleByDomain[domain].Add(person);

        // add to peopleByNameAndTown
        var nameAndTown = name + '|' + town;
        if (!this.peopleByNameAndTown.ContainsKey(nameAndTown))
        {
            this.peopleByNameAndTown.Add(nameAndTown, new SortedSet<Person>());
        }

        this.peopleByNameAndTown[nameAndTown].Add(person);

        // add to peopleByTownAndAge
        if (!this.peopleByTownAndAge.ContainsKey(town))
        {
            this.peopleByTownAndAge.Add(town, new OrderedDictionary<int, SortedSet<Person>>());
        }

        if (!this.peopleByTownAndAge[town].ContainsKey(age))
        {
            this.peopleByTownAndAge[town].Add(age, new SortedSet<Person>());
        }

        this.peopleByTownAndAge[town][age].Add(person);

        // add to peopleByAge
        if (!this.peopleByAge.ContainsKey(age))
        {
            this.peopleByAge.Add(age, new SortedSet<Person>());
        }

        this.peopleByAge[age].Add(person);

        return true;
    }

    public int Count
    {
        get
        {
            return this.peopleByEmail.Count;
        }
    }

    public Person FindPerson(string email)
    {
        if (this.peopleByEmail.ContainsKey(email))
        {
            return this.peopleByEmail[email];
        }

        return null;
    }

    public bool DeletePerson(string email)
    {
        if (!this.peopleByEmail.ContainsKey(email))
        {
            return false;
        }

        try
        {
            var person = this.peopleByEmail[email];

            // remove from peopleByEmail
            this.peopleByEmail.Remove(email);

            // remove from peopleByDomain
            int index = email.IndexOf('@');
            string domain = email.Substring(index + 1);
            this.peopleByDomain[domain].Remove(person);

            // remove from peopleByNameAndTown
            this.peopleByNameAndTown[person.Name + '|' + person.Town].Remove(person);

            // remove from peopleByAgeAndTown
            this.peopleByTownAndAge[person.Town][person.Age].Remove(person);

            // remove from peopleByAge
            this.peopleByAge[person.Age].Remove(person);
        }
        catch (Exception)
        {
            return false;
        }

        return true;
    }

    public IEnumerable<Person> FindPersons(string emailDomain)
    {
        if (this.peopleByDomain.ContainsKey(emailDomain))
        {
            return this.peopleByDomain[emailDomain];
        }

        return new List<Person>();
    }

    public IEnumerable<Person> FindPersons(string name, string town)
    {
        var result = new List<Person>();
        var key = name + "|" + town;
        if (this.peopleByNameAndTown.ContainsKey(key))
        {
            result.AddRange(this.peopleByNameAndTown[key]);
        }
        return result;
    }

    public IEnumerable<Person> FindPersons(int startAge, int endAge)
    {
        var result = new List<Person>();
        var ageRange = this.peopleByAge.Range(startAge, true, endAge, true);
        foreach (var item in ageRange)
        {
            result.AddRange(item.Value);
        }

        return result;
    }

    public IEnumerable<Person> FindPersons(int startAge, int endAge, string town)
    {
        var result = new List<Person>();
        if (this.peopleByTownAndAge.ContainsKey(town))
        {
            var ranges = this.peopleByTownAndAge[town].Range(startAge, true, endAge, true);
            foreach (var range in ranges)
            {
                result.AddRange(range.Value);
            }
        }

        return result;
    }
}
