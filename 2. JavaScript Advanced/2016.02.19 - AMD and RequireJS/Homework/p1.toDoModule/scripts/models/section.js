define(['models/item'], function(Item) {
    return (function() {
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
                    textBox.value = '';
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
});