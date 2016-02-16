function traverse(selector) {
    var elements = document.querySelectorAll(selector);
    for (var i = 0; i < elements.length; i++) {
        function traverseChildren(element, tabs) {
            var children = element.children;
            for (var j = 0; j < children.length; j++) {
                var child = children[j];
                var tabsStart = '';
                for (var k = 0; k < tabs; k++) {
                    tabsStart += '\t';
                }

                var childClass = child.className;
                if(childClass) {
                    console.log(tabsStart + child.tagName.toLowerCase() + ': class="' + child.className + '"');
                } else {
                    console.log(tabsStart + child.tagName.toLowerCase() + ':');
                }

                traverseChildren(child, tabs + 1);
            }
        }

        traverseChildren(elements[i], 0);
    }
}

traverse('.birds');