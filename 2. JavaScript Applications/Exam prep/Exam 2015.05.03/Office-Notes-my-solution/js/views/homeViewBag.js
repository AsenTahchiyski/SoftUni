var app = app || {};

app.homeViewBag = (function() {
    function showWelcomePage(selector) {
        $.get('templates/welcome.html', function(template) {
            $(selector).html(template);
        })
    }

    function showHomePage(selector, data) {
        $.get('templates/home.html', function(template) {
            var rendered = Mustache.render(template, data);
            $(selector).html(rendered);
        })
    }

    return {
        load: function() {
            return {
                showWelcomePage: showWelcomePage,
                showHomePage: showHomePage
            }
        }
    };
})();