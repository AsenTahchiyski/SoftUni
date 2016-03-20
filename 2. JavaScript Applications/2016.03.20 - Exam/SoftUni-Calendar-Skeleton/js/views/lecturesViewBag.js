var app = app || {};

app.lecturesViewBag = (function () {
    function showAllLectures(selector, data) {
        $.get('templates/calendar.html', function (template) {
            var rendered = Mustache.render(template, data);
            $(selector).html(rendered);
            $('#calendar').fullCalendar({
                theme: false,
                header: {
                    left: 'prev,next today addEvent',
                    center: 'title',
                    right: 'month,agendaWeek,agendaDay'
                },
                defaultDate: '2016-01-12',
                selectable: false,
                editable: false,
                eventLimit: true,
                events: data,
                customButtons: {
                    addEvent: {
                        text: 'Add Event',
                        click: function () {
                            Sammy(function() {
                                this.trigger('redirectUrl', {url:'#/calendar/add/'});
                            });
                        }
                    }
                },
                eventClick: function (calEvent, jsEvent, view) {
                    $.get('templates/modal.html', function (templ) {
                        var rendered = Mustache.render(templ, calEvent);
                        $('#modal-body').html(rendered);

                        $('#editLecture').on('click', function() {
                            Sammy(function() {
                                this.trigger('redirectUrl',
                                    {url:'#/calendar/edit/' + calEvent._id, lecture:calEvent});
                            });
                        });

                        $('#deleteLecture').on('click', function() {
                            Sammy(function() {
                                this.trigger('redirectUrl',
                                    {url:'#/calendar/delete/' + calEvent._id, lecture:calEvent});
                            });
                        })
                    });
                    $('#events-modal').modal();
                }
            });
        });
    }

    function showMyLectures(selector, data) {
        $.get('templates/calendar.html', function (template) {
            var rendered = Mustache.render(template, data);
            $(selector).html(rendered);

            $('#calendar').fullCalendar({
                theme: false,
                header: {
                    left: 'prev,next today addEvent',
                    center: 'title',
                    right: 'month,agendaWeek,agendaDay'
                },
                defaultDate: '2016-01-12',
                selectable: false,
                editable: false,
                eventLimit: true,
                events: data,
                customButtons: {
                    addEvent: {
                        text: 'Add Event',
                        click: function () {
                            Sammy(function() {
                                this.trigger('redirectUrl', {url:'#/calendar/add/'});
                            });
                        }
                    }
                },
                eventClick: function (calEvent, jsEvent, view) {
                    $.get('templates/modal.html', function (templ) {
                        var rendered = Mustache.render(templ, calEvent);
                        $('#modal-body').html(rendered);

                        $('#editLecture').on('click', function() {
                            Sammy(function() {
                                this.trigger('redirectUrl', {
                                    url:'#/calendar/edit/' + calEvent._id, lecture: calEvent});
                            });
                        });

                        $('#deleteLecture').on('click', function() {
                            Sammy(function() {
                                this.trigger('redirectUrl', {
                                    url:'#/calendar/delete/' + calEvent._id, lecture: calEvent});
                            });
                        })
                    });
                    $('#events-modal').modal();
                }
            });
        });
    }

    function showAddLecture(selector) {
        $.get('templates/add-lecture.html', function (template) {
            $(selector).html(template);
            $('#addLecture').on('click', function () {
                var title = $('#title').val(),
                    start = $('#start').val(),
                    end = $('#end').val();

                Sammy(function () {
                    this.trigger('addLecture', {title: title, start: start, end: end});
                });
            });
        });
    }

    function showEditLecture(selector, data) {
        $.get('templates/edit-lecture.html', function (template) {
            var rendered = Mustache.render(template, data);
            $(selector).html(rendered);
            $('#editLecture').on('click', function() {
                var title = $('#title').val(),
                    start = $('#start').val(),
                    end = $('#end').val();

                Sammy(function () {
                    this.trigger('editLecture', {title: title, start: start, end: end});
                });
            });
        }).then(function() {
            $('.modal-backdrop').remove();
        });
    }

    function showDeleteLecture(selector, data) {
        $.get('templates/delete-lecture.html', function (template) {
            var rendered = Mustache.render(template, data);
            $(selector).html(rendered);
            $('#deleteLecture').on('click', function() {
                var id = $(this).attr('data-id');

                Sammy(function () {
                    this.trigger('deleteLecture', {_id: id});
                });
            });
        }).then(function() {
            $('.modal-backdrop').remove();
        });
    }

    return {
        load: function () {
            return {
                showAllLectures: showAllLectures,
                showMyLectures: showMyLectures,
                showAddLecture: showAddLecture,
                showEditLecture: showEditLecture,
                showDeleteLecture: showDeleteLecture
            }
        }
    }
})();