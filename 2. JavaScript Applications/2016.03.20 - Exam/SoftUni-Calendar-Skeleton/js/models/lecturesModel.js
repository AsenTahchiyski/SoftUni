var app = app || {};

app.lecturesModel = (function () {
    function LecturesModel(requester) {
        this.requester = requester;
        this.serviceUrl = requester.baseUrl + 'appdata/' + requester.appId + '/lectures/';
    }

    LecturesModel.prototype.getAllLectures = function() {
        var requestUrl = this.serviceUrl;
        return this.requester.get(requestUrl, true);
    };

    LecturesModel.prototype.getMyLectures = function() {
        var requestUrl = this.serviceUrl + '?query={"_acl.creator":"' + sessionStorage['userId'] + '"}';
        return this.requester.get(requestUrl, true);
    };

    LecturesModel.prototype.addLecture = function(data) {
        return this.requester.post(this.serviceUrl, data, true);
    };

    LecturesModel.prototype.editLecture = function(lectureId, data) {
        var requestUrl = this.serviceUrl + lectureId;
        return this.requester.put(requestUrl, data, true);
    };

    LecturesModel.prototype.deleteLecture = function(lectureId) {
        var requestUrl = this.serviceUrl + lectureId;
        this.requester.delete(requestUrl, true);
    };

    return {
        load: function (requester) {
            return new LecturesModel(requester);
        }
    }
})();