var shapes = (function() {
    // Make sure Object.create exists
    if (!Object.create) {
        Object.create = function (proto) {
            function F() {}
            F.prototype = proto;
            return new F();
        };
    }

    var Shape = {
        init: function(color) {
            this.color = color;
        }
    };

    var Circle = {
        init: function(oX, oY, color, radius) {
            Shape.init.call(this, color);
            this.oX = oX;
            this.oY = oY;
            this.radius = radius;
            return this;
        },
        toString: function() {
            return ('Circle: O(' + this.oX + ', ' + this.oY +
            '), Radius: ' + this.radius + ', Color: ' + this.color);
        }
    };

    var Rectangle = {
        init: function(aX, aY, width, height, color) {
            Shape.init.call(this, color);
            this.aX = aX;
            this.aY = aY;
            this.width = width;
            this.height = height;
            return this;
        },
        toString: function() {
            return ('Rectangle: A(' + this.aX + ', ' + this.aY + '), Width: ' +
            this.width + ', Height: ' + this.height + ', Color: ' + this.color);
        }
    };

    var Triangle = {
        init: function(aX, aY, bX, bY, cX, cY, color) {
            Shape.init.call(this, color);
            this.aX = aX;
            this.aY = aY;
            this.bX = bX;
            this.bY = bY;
            this.cX = cX;
            this.cY = cY;
            return this;
        },
        toString: function() {
            return ('Triangle: A(' + this.aX + ', ' + this.aY + '), B(' + this.bX + ', ' +
            this.bY + '), C(' + this.cX + ', ' + this.cY + '), Color: ' + this.color);
        }
    };

    var Line = {
        init: function(aX, aY, bX, bY, color) {
            Shape.init.call(this, color);
            this.aX = aX;
            this.aY = aY;
            this.bX = bX;
            this.bY = bY;
            return this;
        },
        toString: function() {
            return ('Line: A(' + this.aX + ', ' + this.aY + '), B(' + this.bX + ', ' + this.bY + '), Color: ' + this.color);
        }
    };

    var Segment = {
        init: function(aX, aY, bX, bY, color) {
            Shape.init.call(this, color);
            this.aX = aX;
            this.aY = aY;
            this.bX = bX;
            this.bY = bY;
            return this;
        },
        toString: function() {
            return ('Segment: A(' + this.aX + ', ' + this.aY + '), B(' + this.bX + ', ' + this.bY + '), Color: ' + this.color);
        }
    };

    return {
        Circle : Circle,
        Rectangle : Rectangle,
        Triangle : Triangle,
        Line : Line,
        Segment : Segment
    }
})();

var circle = Object.create(shapes.Circle).init(1, 1, 111, 2);
var rectangle = Object.create(shapes.Rectangle).init(1, 1, 3, 4, 222);
var triangle = Object.create(shapes.Triangle).init(1, 1, 2, 2, 3, 3, 333);
var line = Object.create(shapes.Line).init(1, 1, 5, 5, 444);
var segment = Object.create(shapes.Segment).init(2, 2, 4, 4, 555);

console.log(circle.toString());
console.log(rectangle.toString());
console.log(triangle.toString());
console.log(line.toString());
console.log(segment.toString());