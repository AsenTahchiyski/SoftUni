$('button').on('click', function() {
    var data = eval($('input').val());
    var table = $('<table>');
    var tabHeader = '<tr>';
    for (var el in data[0]) {
        tabHeader += '<th>' + el + '</th>';
    }

    tabHeader += '</tr>';
    $(tabHeader).appendTo(table);
    $.each(data, function(index, value) {
        var row = '<tr>';
        $.each(value, function(key, val) {
            row += '<td>' + val + '</td>';
        });
        row += '</tr>';
        table.append($(row)); // also works if row isn't parsed
    });
    $('div').append(table);
});