function findYoungestPerson(array) {
    var result = array.filter(function(person) {
        return person.hasSmartphone;
    }).sort(function(p1, p2) {
        return p1.age > p2.age;
    });

    return result[0];
}

var people = [
    { firstname : 'George', lastname: 'Kolev', age: 32, hasSmartphone: false },
    { firstname : 'Vasil', lastname: 'Kovachev', age: 40, hasSmartphone: true },
    { firstname : 'Bay', lastname: 'Ivan', age: 81, hasSmartphone: true },
    { firstname : 'Baba', lastname: 'Ginka', age: 40, hasSmartphone: false }];

var youngestOwner = findYoungestPerson(people);
console.log('The youngest person is ' + youngestOwner.firstname +
                        ' ' + youngestOwner.lastname);
