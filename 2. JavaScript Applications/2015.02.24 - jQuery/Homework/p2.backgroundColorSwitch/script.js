$('button').on('click', function() {
    var classSelector = '.' + $('#class').val();
    $(classSelector).css('background-color', $('#color').val());
});