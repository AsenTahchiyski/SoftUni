function pop(type, title, message, callback) {
    var popup;
    switch (type) {
        case 'success':
            popup = new Poppy.Success(type, title, message);
            break;
        case 'info':
            popup = new Poppy.Info(type, title, message);
            break;
        case 'error':
            popup = new Poppy.Error(type, title, message);
            break;
        case 'warning':
            popup = new Poppy.Warning(type, title, message, callback);
            break;
        default: break;
    }
	
	// generate view from view factory
    var view = createPopupView(popup);
    processPopup(view, popup);
}

function processPopup(domView, popup) {
    setTimeout(fadeIn(domView), 3000);
    // info
    if(popup._popupData.closeButton) {
        var button = domView.getElementsByTagName('button')[0];
        button.addEventListener('click', function() {
            fadeOut(domView);
        });
    }
    // success
    if(popup._popupData.autoHide) {
        setTimeout(function(){fadeOut(domView)}, popup._popupData.timeout);
    }
    // error
    if(popup._popupData.type == 'error') {
        domView.addEventListener('click', function(){fadeOut(domView)});
    }
    // warning
    if(popup._popupData.callback) {
        domView.addEventListener('click', popup._popupData.callback);
    }

    document.body.appendChild(domView);
}

function fadeOut(domView) {
    var op = 1;  // initial opacity
    var timer = setInterval(function () {
        if (op <= 0.1){
            clearInterval(timer);
            domView.style.display = 'none';
        }
        domView.style.opacity = op;
        domView.style.filter = 'alpha(opacity=' + op * 100 + ")";
        op -= op * 0.2;
    }, 50);
}

function fadeIn(domView) {
    var op = 0.1;  // initial opacity
    domView.style.display = 'block';
    var timer = setInterval(function () {
        if (op >= 1){
            clearInterval(timer);
        }
        domView.style.opacity = op;
        domView.style.filter = 'alpha(opacity=' + op * 100 + ")";
        op += op * 0.1;
    }, 10);
}