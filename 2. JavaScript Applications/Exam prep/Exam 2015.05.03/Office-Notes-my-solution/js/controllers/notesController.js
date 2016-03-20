var app = app || {};

app.notesController = (function () {
    function NotesController(viewBag, model) {
        this.viewBag = viewBag;
        this.model = model;
    }

    NotesController.prototype.loadOfficeNotes = function (selector) {
        var _this = this;
        var date = new Date().toISOString().slice(0, 10);
        console.log(date);
        this.model.getNotesForToday(date)
            .then(function (data) {
                var result = {
                    notes: []
                };

                data.forEach(function (note) {
                    result.notes.push({
                        title: note.title,
                        text: note.text,
                        author: note.author,
                        deadline: note.deadline,
                        id: note._id
                    });
                });

                _this.viewBag.showOfficeNotes(selector, result);
                console.log(data);
            });
    };

    NotesController.prototype.loadMyNotes = function (selector) {
        var _this = this;
        var userId = sessionStorage['userId'];
        this.model.getNotesByCreatorId(userId)
            .then(function (data) {
                var result = {
                    notes: []
                };

                data.forEach(function (note) {
                    result.notes.push({
                        title: note.title,
                        text: note.text,
                        author: note.author,
                        deadline: note.deadline,
                        id: note._id
                    });
                });

                _this.viewBag.showMyNotes(selector, result);
                console.log(data);
            });
    };

    NotesController.prototype.loadAddNote = function (selector) {
        this.viewBag.showAddNote(selector);
    };

    NotesController.prototype.addNote = function (data) {
        var result = {
            title: data.title,
            text: data.text,
            deadline: data.deadline,
            author: sessionStorage['username']
        };

        this.model.addNote(result);
    };

    NotesController.prototype.loadEditNote = function (selector, data) {
        this.viewBag.showEditNote(selector, data);
    };

    NotesController.prototype.editNote = function (data) {
        data.author = sessionStorage['username'];
        this.model.editNote(data.id, data).then(function (success) {
            console.log(success);
        });
    };

    NotesController.prototype.loadDeleteNote = function (selector, data) {
        this.viewBag.showDeleteNote(selector, data);
    };

    NotesController.prototype.deleteNote = function (noteId) {
        this.model.deleteNote(noteId)
            .then(function (success) {
                location.reload();
            });
    };

    return {
        load: function (viewBag, model) {
            return new NotesController(viewBag, model);
        }
    }
})();