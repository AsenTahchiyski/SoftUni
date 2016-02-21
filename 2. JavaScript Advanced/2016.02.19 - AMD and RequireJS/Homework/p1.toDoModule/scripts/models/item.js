define([], function() {
    return (function() {
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
});

