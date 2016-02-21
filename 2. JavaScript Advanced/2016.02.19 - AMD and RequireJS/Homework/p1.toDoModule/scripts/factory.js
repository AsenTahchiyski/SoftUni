define(['models/container', 'models/item', 'models/section'], function(Container, Item, Section) {
    var toDoModule = (function() {
        return {
            Container: Container,
            Section: Section,
            Item: Item
        }
    })();

    return toDoModule;
});

