var app = app || {};

(function() {
    var router = Sammy(function() {
        var selector = '#container';

        var requester = app.requester.load('kid_WkLhpw_nyb', 'a1ab9463f384464a8213c0a797a462f0', 'https://baas.kinvey.com/');

        var userModel = app.userModel.load(requester);
        var notesModel = app.notesModel.load(requester);

        var userViewBag = app.userViewBag.load();
        var homeViewBag = app.homeViewBag.load();
        var notesViewBag = app.notesViewBag.load();

        var userController = app.userController.load(userViewBag, userModel);
        var homeController = app.homeController.load(homeViewBag);
        var notesController = app.notesController.load(notesViewBag, notesModel);

        this.before({except:{path:'#\/(login\/register\/)?'}}, function() {
            if(!sessionStorage['sessionId']) {
                this.redirect('#/');
                return false;
            }
        });

        this.before(function() {
            if(!sessionStorage['sessionId']) {
                $('#menu').hide();
            } else {
                $('#welcomeMenu').text('Welcome, ' + sessionStorage['fullName']);
                $('#menu').show();
            }

            //notesController.addNote({title:'Note1', text:'hi', deadline:'2016-03-19'});
            //notesController.addNote({title:'Note2', text:'sup', deadline:'2016-03-20'});
            //notesController.addNote({title:'Note3', text:'brah', deadline:'2016-03-21'});
            //notesController.addNote({title:'Note4', text:'que', deadline:'2016-03-20'});
            //notesController.addNote({title:'Note5', text:'asd', deadline:'2016-03-19'});
            //notesController.addNote({title:'Note6', text:'test', deadline:'2016-03-19'});
        });

        this.get('#/', function() {
            homeController.loadWelcomePage(selector);
        });

        this.get('#/home/', function() {
            homeController.loadHomePage(selector);
        });

        this.get('#/login/', function() {
            userController.loadLoginPage(selector);
        });

        this.get('#/logout/', function() {
            userController.logout();
        });

        this.get('#/register/', function() {
            userController.loadRegisterPage(selector);
        });

        this.get('#/office/', function() {
            notesController.loadOfficeNotes(selector);
        });

        this.get('#/myNotes/', function() {
            notesController.loadMyNotes(selector);
        });

        this.get('#/addNote/', function() {
            notesController.loadAddNote(selector);
        });

        this.bind('redirectUrl', function(ev, data) {
            this.redirect(data.url);
        });

        this.bind('login', function(ev, data) {
            userController.login(data);
        });

        this.bind('register', function(ev, data) {
            userController.register(data);
        });

        this.bind('addNote', function(ev, data) {
            notesController.addNote(data);
        });

        this.bind('showEditNote', function(ev, data) {
            notesController.loadEditNote(selector, data);
        });

        this.bind('editNote', function(ev, data) {
            notesController.editNote(data);
        });

        this.bind('showDeleteNote', function(ev, data) {
            notesController.loadDeleteNote(selector, data);
        });

        this.bind('deleteNote', function(ev, data) {
            notesController.deleteNote(data._id);
        });
    });

    router.run('#/')
})();

