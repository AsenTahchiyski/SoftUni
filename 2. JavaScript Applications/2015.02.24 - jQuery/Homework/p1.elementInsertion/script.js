$('#before').on('click', function() {
    var currentElement = $('#brah');
    var elementToAdd = $('<p/>').text($('input').val());
    elementToAdd.insertBefore(currentElement);
});

$('#after').on('click', function() {
    var currentElement = $('#brah');
    var elementToAdd = $('<p/>').text($('input').val());
    elementToAdd.insertAfter(currentElement);
});