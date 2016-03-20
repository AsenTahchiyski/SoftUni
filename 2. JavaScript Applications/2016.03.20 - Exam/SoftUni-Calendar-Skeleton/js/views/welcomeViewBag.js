var app = app || {};

app.welcomeViewBag = (function () {
    function showGuestWelcomePage(selector) {
        $.get('templates/welcome-guest.html', function (template) {
            $(selector).html(template);
        });
    }

    function showUserWelcomePage(selector, data) {
        $.get('templates/welcome-user.html', function(template) {
            var rendered = Mustache.render(template, data);
            $(selector).html(rendered);
        });
    }

    return {
        load: function () {
            return {
                showGuestWelcomePage: showGuestWelcomePage,
                showUserWelcomePage: showUserWelcomePage
            }
        }
    };
})();