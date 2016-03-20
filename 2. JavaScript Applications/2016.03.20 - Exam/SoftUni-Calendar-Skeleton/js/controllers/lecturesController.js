var app = app || {};

app.lecturesController = (function () {
    function LecturesController(viewBag, model) {
        this.viewBag = viewBag;
        this.model = model;
    }

    LecturesController.prototype.loadAllLectures = function (selector) {
        var _this = this;
        this.model.getAllLectures().then(function(data) {
            _this.viewBag.showAllLectures(selector, data);
        });
    };

    LecturesController.prototype.loadMyLectures = function (selector) {
        var _this = this;
        this.model.getMyLectures().then(function(data) {
            _this.viewBag.showMyLectures(selector, data);
        });
    };

    LecturesController.prototype.loadAddLecture = function (selector) {
        this.viewBag.showAddLecture(selector);
    };

    LecturesController.prototype.addLecture = function (data) {
        var result = {
            title:data.title,
            start:data.start,
            end:data.end,
            lecturer:data.lecturer,
            id:data._id
        };

        this.model.addLecture(result).then(function() {
            Sammy(function() {
                this.trigger('redirectUrl', {url:'#/calendar/my/'});
            })
        })
    };

    LecturesController.prototype.loadEditLecture = function (selector, data) {
        this.viewBag.showEditLecture(selector, data);
    };

    LecturesController.prototype.editLecture = function (data) {
        data.lecturer = sessionStorage['username'];
        this.model.editLecture(sessionStorage['editEventId'], data).then(function (success) {
            console.log(success);
        });
    };

    LecturesController.prototype.loadDeleteLecture = function (selector, data) {
        this.viewBag.showDeleteLecture(selector, data);
    };

    LecturesController.prototype.deleteLecture = function (lectureId) {
        this.model.deleteLecture(lectureId);
    };

    return {
        load: function (viewBag, model) {
            return new LecturesController(viewBag, model);
        }
    }
})();