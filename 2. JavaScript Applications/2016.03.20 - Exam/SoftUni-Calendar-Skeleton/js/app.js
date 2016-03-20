var app = app || {};

(function () {
    var router = Sammy(function () {
        var selector = '#container';

        var requester = app.requester.load('kid_WkLhpw_nyb', 'a1ab9463f384464a8213c0a797a462f0', 'https://baas.kinvey.com/');

        var userModel = app.userModel.load(requester);
        var lecturesModel = app.lecturesModel.load(requester);

        var userViewBag = app.userViewBag.load();
        var welcomeViewBag = app.welcomeViewBag.load();
        var lecturesViewBag = app.lecturesViewBag.load();

        var userController = app.userController.load(userViewBag, userModel);
        var welcomeController = app.welcomeController.load(welcomeViewBag);
        var lecturesController = app.lecturesController.load(lecturesViewBag, lecturesModel);

        var lectureToEdit, lectureToDelete; // no time for better solution

        this.before(function () {
            if (sessionStorage['sessionId']) {
                $.get('templates/menu-home.html', function (template) {
                    $('#menu').html(template);
                });
            } else {
                $.get('templates/menu-login.html', function (template) {
                    $('#menu').html(template);
                });
            }
        });

        this.get('#/', function () {
            welcomeController.loadWelcomePage(selector);
        });

        this.get('#/login/', function () {
            userController.loadLoginPage(selector);
        });

        this.get('#/logout/', function () {
            userController.logout();
        });

        this.get('#/register/', function () {
            userController.loadRegisterPage(selector);
        });

        this.get('#/calendar/list/', function () {
            lecturesController.loadAllLectures(selector);
        });

        this.get('#/calendar/my/', function () {
            lecturesController.loadMyLectures(selector);
        });

        this.get('#/calendar/add/', function() {
            lecturesController.loadAddLecture(selector);
        });

        this.get(/#\/calendar\/edit\/(.*)/, function() {
            lecturesController.loadEditLecture(selector, lectureToEdit);
        });

        this.get(/#\/calendar\/delete\/(.*)/, function() {
            lecturesController.loadDeleteLecture(selector, lectureToDelete);
        });

        this.bind('redirectUrl', function (ev, data) {
            lectureToEdit = data.lecture;
            lectureToDelete = data.lecture;
            this.redirect(data.url);
        });

        this.bind('login', function (ev, data) {
            userController.login(data);
        });

        this.bind('register', function (ev, data) {
            userController.register(data);
        });

        this.bind('showAddLecture', function (ev, data) {
            lecturesController.loadAddLecture(selector, data);
        });

        this.bind('addLecture', function (ev, data) {
            lecturesController.addLecture(data);
        });

        this.bind('showEditLecture', function (ev, data) {
            lecturesController.loadEditLecture(selector, data);
        });

        this.bind('editLecture', function (ev, data) {
            lecturesController.editLecture(data);
        });

        this.bind('showDeleteLecture', function (ev, data) {
            lecturesController.loadDeleteLecture(selector, data);
        });

        this.bind('deleteLecture', function (ev, data) {
            lecturesController.deleteLecture(data._id);
        });
    });

    router.run('#/')
})();