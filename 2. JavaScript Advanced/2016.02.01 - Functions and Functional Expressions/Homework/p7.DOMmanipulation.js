var domModule = (function () {
    return {
        appendChild: function appendChild(element, child) {
            var children = element.childNodes;
            children.push(child);
            element.children = children;
        },

        removeChild: function removeChild(element, child) {
            var children = element.childNodes;
            var removeIndex = children.indexOf(child);
            children = children.splice(removeIndex, 1);
            element.childNodes = children;
        },

        addHandler: function addHandler(element, eventType, eventHandler) {
            element.addEventListener(eventType, eventHandler);
        },

        retrieveElements: function retrieveElements(selector) {
            return document.querySelectorAll(selector);
        }
    }
})();

var liElement = document.createElement("li");
// Appends a list item to ul.birds-list
domModule.appendChild(liElement,".birds-list");
// Removes the first li child from the bird list
domModule.removeChild("ul.birds-list","li:first-child");
// Adds a click event to all bird list items
domModule.addHandler("li.birds", 'click', function(){ alert("I'm a bird!") });
// Retrieves all elements of class "bird"
var elements = domModule.retrieveElements(".bird");
