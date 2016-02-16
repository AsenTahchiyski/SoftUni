var Person = (function () {
    function Person(firstName, lastName) {
        this.firstName = firstName;
        this.lastName = lastName;
    }

    Person.prototype = {
        get name() {
            return this.firstName + " " + this.lastName;
        }
    };

    return Person;
})();

var peter = new Person("Peter", "Jackson");
console.log(peter.name);
console.log(peter.firstName);
console.log(peter.lastName);
