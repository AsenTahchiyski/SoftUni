$.get('template.html', function (template) {
    var json = {
        'header': 'Welcome to Mustache!',
        'data': [
            {
                name: 'Pesho Peshev',
                job: 'Pascal Developer',
                site: 'http://www.pascal-programming.info/'
            },
            {
                name: 'Javier Keleshev',
                job: 'Java Developer',
                site: 'http://www.javafun.net/'
            },
            {
                name: 'Stamat Stambolov',
                job: 'JavaScript Ninja',
                site: 'http://216.58.212.46'
            }
        ],
        'empty': false
    };

    var output = Mustache.render(template, json);
    $('#wrapper').html(output);
});

