"use strict";
function traverse(selector) {
    var elements = document.querySelectorAll(selector);
    var children, child, tabsStart, childClass, i, j, k;
    for (i = 0; i < elements.length; i++) {
        var traverseChildren = function traverseChildren(element, tabs) {
            children = element.children;
            for (j = 0; j < children.length; j++) {
                child = children[j];
                tabsStart = '';
                for (k = 0; k < tabs; k++) {
                    tabsStart += '\t';
                }

                childClass = child.className;
                if(childClass) {
                    console.log(tabsStart + child.tagName.toLowerCase() + ': class="' + child.className + '"');
                } else {
                    console.log(tabsStart + child.tagName.toLowerCase() + ':');
                }

                traverseChildren(child, tabs + 1);
            }
        };

        traverseChildren(elements[i], 0);
    }
}

traverse('.birds');