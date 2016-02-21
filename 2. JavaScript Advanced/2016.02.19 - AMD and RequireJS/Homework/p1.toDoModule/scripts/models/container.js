define(['models/section'], function(Section) {
    return (function() {
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
});