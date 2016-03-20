var app = app || {};

(function() {
    app.router = Sammy(function() {
        var selector = '#wrapper';

        this.get('#/', function() {
            $(selector).html('<h2>Home</h2>');
        });

        this.get('#/pesho', function() {
            $(selector).html('<h2>Hello, Pesho!</h2>');
        });

        this.get('#/gosho', function() {
            $(selector).html('<h2>Hello, Gosho!</h2>');
        });

        this.get('#/nashmat', function() {
            $(selector).html('<h2>Hello, Nashmat!</h2>');
        });
    });

    app.router.run('#/');
})();