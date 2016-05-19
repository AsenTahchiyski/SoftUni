'use strict';

// Declare app level module which depends on views, and components
angular.module('myApp', [
        'ngRoute',
        'myApp.allView',
        'myApp.addView'
    ])
    .config(['$routeProvider', function ($routeProvider) {
        $routeProvider.otherwise({redirectTo: '/allView'});
    }])
    .service('videos', function () {
        var videos = videos || [];
        var sampleVideo1 =
            {
                title: 'The Matrix',
                picture: 'http://staticmass.net/wp-content/uploads/2011/11/matrix_1.jpg',
                length: 136,
                category: 'Action',
                likes: 2,
                date: new Date('3 Sep 1999'),
                hasSubs: 'yes',
                comments: [
                    {
                        username: 'Pesho',
                        date: new Date('12 Dec 1999'),
                        content: 'Best movie ever!',
                        picUrl: ''
                    },
                    {
                        username: 'Minka',
                        date: new Date('6 Feb 2001'),
                        content: 'Titanik e po-hubav.',
                        picUrl: ''
                    }]
            },
            sampleVideo2 =
            {
                title: 'Titanic',
                picture: 'http://howdoesthemovieend.com/images/jmovies/img_pictures/titanic-poster.jpg',
                length: 194,
                category: 'Drama',
                likes: 1,
                date: new Date('6 Mar 1997'),
                hasSubs: 'yes',
                comments: [
                    {
                        username: 'Minka',
                        date: new Date('7 Mar 1997'),
                        content: 'Leo obicham tee!1',
                        picUrl: ''
                    },
                    {
                        username: 'Pesho',
                        date: new Date('12 Dec 1997'),
                        content: 'Meh.',
                        picUrl: ''
                    }]
            },
            sampleVideo3 =
            {
                title: 'Hotshots',
                picture: 'http://www.thaidvd.biz/images/hotshots.jpg',
                length: 84,
                category: 'Comedy',
                likes: 3,
                date: new Date('31 Jul 1991'),
                hasSubs: 'no',
                comments: [
                    {
                        username: 'Pesho',
                        date: new Date('20 Apr 1992'),
                        content: 'Ahahahha!',
                        picUrl: ''
                    },
                    {
                        username: 'Gosho',
                        date: new Date('7 Nov 2013'),
                        content: 'Brao bate Charliii',
                        picUrl: ''
                    }
                ]
            };

        videos.push(sampleVideo1);
        videos.push(sampleVideo2);
        videos.push(sampleVideo3);

        var addVideo = function (video) {
            videos.push(video);
        };

        var getVideos = function () {
            return videos;
        };

        return {
            addVideo: addVideo,
            getVideos: getVideos
        };
    });

