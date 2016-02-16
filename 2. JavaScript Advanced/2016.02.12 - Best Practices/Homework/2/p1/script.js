function showInvoiceDetails (boxId){
    var checkbox = document.getElementById('invoice');
    var visibility = 'none';
    if(checkbox.checked) {
        visibility = 'initial';
    }

    document.getElementById(boxId).style.display = visibility;
}