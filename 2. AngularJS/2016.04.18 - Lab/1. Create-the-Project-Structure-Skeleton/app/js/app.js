"use strict";

angular
    .module('app', [
        'ngRoute',
        'ngResource',
        'app.controllers.app',
        'app.controllers.home',
        'app.controllers.login',
        'app.controllers.register',
        'app.services.ads',
        'app.services.auth',
        'app.services.categories',
        'app.services.notify',
        'app.services.towns',
        'app.controllers-right-sidebar',
        'app.controllers.pagination',
        'ui.bootstrap.pagination',
        'ui.bootstrap.paging'
    ])
    .config(['$routeProvider', function($routeProvider) {
        $routeProvider.when('/', {
            templateUrl: 'app/templates/home.html',
            controller: 'HomeController'
        });
        $routeProvider.when('/login', {
            templateUrl: 'app/templates/login.html',
            controller: 'LoginController'
        });

        $routeProvider.when('/register', {
            templateUrl: 'app/templates/register.html',
            controller: 'RegisterController'
        });

        $routeProvider.otherwise({
            redirectTo: '/',
        });
    }])
    .constant('baseServiceUrl', 'http://softuni-ads.azurewebsites.net')
    .constant('pageSize', 5);
