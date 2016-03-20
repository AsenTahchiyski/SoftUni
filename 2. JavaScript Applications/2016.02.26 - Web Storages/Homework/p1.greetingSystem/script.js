(function() {
    if(!localStorage.getItem('name')) {
        var name = prompt('Please enter a username');
        localStorage.setItem('name', name);
        localStorage.setItem('totalVisits', 1);
        sessionStorage.setItem('sessionVisits', 1);
    }

    if(!sessionStorage.sessionVisits) {
        sessionStorage.sessionVisits = 1;
    }

    document.getElementsByTagName('p')[0].innerText = 'Howdy, ' + localStorage.name +
        ' (Session visits: ' + sessionStorage.sessionVisits +
        ', Total visits: ' + localStorage.totalVisits + ')';
    document.getElementsByTagName('button')[0].onclick = function() {
        delete localStorage.name;
        delete localStorage.totalVisits;
        delete sessionStorage.sessionVisits;
        alert('User data deleted. Try reloading the page.');
    };

    localStorage.totalVisits++;
    sessionStorage.sessionVisits++;
})();