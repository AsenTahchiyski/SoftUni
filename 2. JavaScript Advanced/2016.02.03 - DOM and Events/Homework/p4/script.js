function HTMLGen() {
    this.createParagraph = function createParagraph(id, text) {
        var parent = document.getElementById(id);
        parent.innerHTML += '<p>' + text + '</p>';
    };

    this.createDiv = function createDiv(id, divClass) {
        var parent = document.getElementById(id);
        parent.innerHTML += '<div class="' + divClass + '"></div>';
    };

    this.createLink = function createLink(id, text, url) {
        var parent = document.getElementById(id);
        parent.innerHTML += '<a href="' + url + '">' + text + '</a>';
    };
}

var gen = new HTMLGen();
gen.createParagraph('wrapper', 'Soft Uni');
gen.createDiv('wrapper', 'section');
gen.createLink('book', 'C# basics book', 'http://www.introprogramming.info/');