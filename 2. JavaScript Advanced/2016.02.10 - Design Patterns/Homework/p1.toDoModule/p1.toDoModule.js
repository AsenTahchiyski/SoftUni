var toDoModule = (function() {
    var Container = (function() {
        function Container(name) {
            this.name = name;
            this.sections = [];
        }

        Container.prototype.addSection = function(section) {
            if(section instanceof Section) {
                this.sections.push(section);
            } else {
                throw new Error('Invalid section.')
            }
        };

        Container.prototype.addSections = function(arr) {
            if(!Array.isArray(arr)) {
                throw new Error('Please pass the sections as an array.')
            } else {
                for (var i = 0; i < arr.length; i++) {
                    this.addSection(arr[i]);
                }
            }
        };

        Container.prototype.addToDOM = function(parent) {
            var container = document.createElement('div');
            container.className = 'container';
            var innerContainer = document.createElement('div');
            innerContainer.className = 'inner-container';
            var header = document.createElement('header');
            var heading = document.createTextNode(this.name);
            header.className = 'container-header';
            header.appendChild(heading);
            container.appendChild(header);
            for (var i = 0; i < this.sections.length; i++) {
                this.sections[i].addToDOM(innerContainer);
            }
            var textBox = document.createElement('input');
            textBox.type = 'text';
            textBox.placeholder = ' Title...';
            // Add confirmation with Enter and reset text with Esc
            textBox.onkeyup = function(evt) {
                var keyCode = evt ? (evt.which ? evt.which : evt.keyCode) : event.keyCode;
                if (keyCode == 13) {
                    button.click();
                }
                if (keyCode == 27) {
                    textBox.value = '';
                } else {
                    return true;
                }
            };
            var button = document.createElement('button');
            var buttonText = document.createTextNode('New Section');
            button.appendChild(buttonText);
            // Add section with button
            var that = this;
            button.addEventListener('click', function() {
                if(!textBox.valueMissing) {
                    var section = new Section(textBox.value);
                    that.addSection(section);
                    section.addToDOM(innerContainer);
                }
            });
            container.appendChild(innerContainer);
            container.appendChild(textBox);
            container.appendChild(button);
            parent.appendChild(container);
        };

        return Container;
    })();

    var Section = (function() {
        function Section(title) {
            this.title = title;
            this.items = [];
        }

        Section.prototype.addItem = function(item) {
            if(item instanceof Item) {
                this.items.push(item);
            } else {
                throw new Error('Invalid item.')
            }
        };

        Section.prototype.addItems = function(arr) {
            if(!Array.isArray(arr)) {
                throw new Error('Please pass the items as an array.')
            } else {
                for (var i = 0; i < arr.length; i++) {
                    this.addItem(arr[i]);
                }
            }
        };

        Section.prototype.addToDOM = function(parent) {
            var section = document.createElement('section');
            var header = document.createElement('header');
            var heading = document.createTextNode(this.title);
            var innerSection = document.createElement('div');
            innerSection.className = 'inner-section';
            header.className = 'section-header';
            header.appendChild(heading);
            section.appendChild(header);
            var textBox = document.createElement('input');
            textBox.type = 'text';
            textBox.placeholder = ' Add Item...';
            // Add confirmation with Enter and reset text with Esc
            textBox.onkeyup = function(evt) {
                var keyCode = evt ? (evt.which ? evt.which : evt.keyCode) : event.keyCode;
                if (keyCode == 13) {
                    button.click();
                }
                if (keyCode == 27) {
                    textBox.value = '';
                } else {
                    return true;
                }
            };
            var button = document.createElement('button');
            var buttonText = document.createTextNode('+');
            button.appendChild(buttonText);
            // Add item with button
            var that = this;
            button.addEventListener('click', function() {
                if(!textBox.valueMissing) {
                    var item = new Item(textBox.value);
                    that.addItem(item);
                    item.addToDOM(innerSection);
                }
            });
            for (var i = 0; i < this.items.length; i++) {
                this.items[i].addToDOM(innerSection);
            }
            section.appendChild(innerSection);
            section.appendChild(textBox);
            section.appendChild(button);
            parent.appendChild(section);
        };

        return Section;
    })();

    var Item = (function() {
        function Item(content) {
            this.content = content;
            this.status = false;
        }

        Item.prototype.updateStatus = function(status) {
            if(this.status != status) {
                this.status = status;
            }
        };

        Item.prototype.addToDOM = function(parent) {
            var checkbox = document.createElement('input');
            checkbox.type = 'checkbox';
            var label = document.createElement('label');
            checkbox.addEventListener('click', function() {
                if(checkbox.checked) {
                    label.style.color = 'green';
                    label.style.fontWeight = 'bold';
                } else {
                    label.style.color = 'black';
                    label.style.fontWeight = 'normal';
                }
            });
            label.appendChild(checkbox);
            var labelText = document.createTextNode(this.content);
            label.appendChild(labelText);
            label.style.display = 'block';
            parent.appendChild(label);
        };

        return Item;
    })();

    return {
        Container: Container,
        Section: Section,
        Item: Item
    }
})();

// INIT

var container = new toDoModule.Container('Tuesday TODO List');
var shopping = new toDoModule.Section('Shopping List');
var item1 = new toDoModule.Item('Air-freshener');
var item2 = new toDoModule.Item('Pampers');
var item3 = new toDoModule.Item('Newspaper');
var item4 = new toDoModule.Item('Toilet paper');
shopping.addItems([item1, item2, item3, item4]);
container.addSection(shopping);

var business = new toDoModule.Section('Business');
var item5 = new toDoModule.Item('Inspect fiscal year report');
var item6 = new toDoModule.Item('Lunch with board of directors');
var item7 = new toDoModule.Item('Fire Jackson');
var item8 = new toDoModule.Item('Take a nap');
var item9 = new toDoModule.Item('Arrange a meeting with investors');
business.addItems([item5, item6, item7, item8, item9]);
container.addSection(business);

container.addToDOM(document.getElementById('wrapper'));