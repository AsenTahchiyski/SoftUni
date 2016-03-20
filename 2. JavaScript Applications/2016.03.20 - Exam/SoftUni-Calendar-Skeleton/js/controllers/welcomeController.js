var app = app || {};

app.welcomeController = (function () {
    function WelcomeController(viewBag, model) {
        this.model = model;
        this.viewBag = viewBag;
    }

    WelcomeController.prototype.loadWelcomePage = function (selector) {
        if (sessionStorage['sessionId']) {
            var data = {
                username: sessionStorage['username'],
                fullName: sessionStorage['fullName']
            };
            this.viewBag.showUserWelcomePage(selector, data);
        } else {
            this.viewBag.showGuestWelcomePage(selector);
        }
    };

    return {
        load: function (viewBag, model) {
            return new WelcomeController(viewBag, model);
        }
    }
})();