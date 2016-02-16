var Poppy = (function() {
    if(!Object.prototype.extends) {
        Object.prototype.extends = function (parent) {
            this.prototype = Object.create(parent.prototype);
            this.prototype.constructor = this;
        }
    }

    var Popup = (function Popup() {
        function Popup(type, title, message, position, timeout, callback, autoHide, closeButton) {
            this._popupData = {
                position: position,
                type: type,
                autoHide: autoHide,
                timeout: timeout,
                closeButton: closeButton,
                title: title,
                message: message,
                callback: callback
            };
        }

        return Popup;
    })();

    var Success = (function() {
        function Success(type, title, message) {
            Popup.call(this, type, title, message, 'bottomLeft', 3000, false, true, false);
        }

        Success.extends(Popup);
        return Success;
    })();

    var Info = (function() {
        function Info(type, title, message) {
            Popup.call(this, type, title, message, 'topLeft', 0, false, false, true);
        }

        Info.extends(Popup);
        return Info;
    })();

    var Error = (function() {
        function Error(type, title, message) {
            Popup.call(this, type, title, message, 'topRight', 0, false, false, false);
        }

        Error.extends(Popup);
        return Error;
    })();

    var Warning = (function() {
        function Warning(type, title, message, callback) {
            Popup.call(this, type, title, message, 'bottomRight', 0, callback, false, false);
        }

        Warning.extends(Popup);
        return Warning;
    })();

    return {
        Success: Success,
        Info: Info,
        Error: Error,
        Warning: Warning
    }
})();