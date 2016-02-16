var shapes = (function() {
    // Make sure Object.extends is present
    if(!Object.prototype.extends) {
        Object.prototype.extends = function (parent) {
            this.prototype = Object.create(parent.prototype);
            this.prototype.constructor = this;
        }
    }

    var Shape = (function() {
        function Shape(color) {
            this.color = color;
        }

        Shape.prototype.toString = function() {
            throw new Error('Shape is an abstract class.');
        };
        return Shape;
    })();

    var Circle = (function() {
        function Circle(oX, oY, color, radius) {
            Shape.call(this, color);
            this.oX = oX;
            this.oY = oY;
            this.radius = radius;
        }

        Circle.extends(Shape);
        Circle.prototype.toString = function() {
            return ('Circle: O(' + this.oX + ', ' + this.oY +
            '), Radius: ' + this.radius + ', Color: ' + this.color);
        };
        return Circle;
    })();

    var Rectangle = (function() {
        function Rectangle(aX, aY, width, height, color) {
            Shape.call(this, color);
            this.aX = aX;
            this.aY = aY;
            this.width = width;
            this.height = height
        }

        Rectangle.extends(Shape);
        Rectangle.prototype.toString = function() {
            return ('Rectangle: A(' + this.aX + ', ' + this.aY + '), Width: ' +
            this.width + ', Height: ' + this.height + ', Color: ' + this.color);
        };
        return Rectangle;
    })();

    var Triangle = (function() {
        function Triangle(aX, aY, bX, bY, cX, cY, color) {
            Shape.call(this, color);
            this.aX = aX;
            this.aY = aY;
            this.bX = bX;
            this.bY = bY;
            this.cX = cX;
            this.cY = cY;
        }

        Triangle.extends(Shape);
        Triangle.prototype.toString = function() {
            return ('Triangle: A(' + this.aX + ', ' + this.aY + '), B(' + this.bX + ', ' +
            this.bY + '), C(' + this.cX + ', ' + this.cY + '), Color: ' + this.color);
        };
        return Triangle;
    })();

    var Line = (function() {
        function Line(aX, aY, bX, bY, color) {
            Shape.call(this, color);
            this.aX = aX;
            this.aY = aY;
            this.bX = bX;
            this.bY = bY;
        }

        Line.extends(Shape);
        Line.prototype.toString = function() {
            return ('Line: A(' + this.aX + ', ' + this.aY + '), B(' + this.bX + ', ' + this.bY + '), Color: ' + this.color);
        };
        return Line;
    })();

    var Segment = (function() {
        function Segment(aX, aY, bX, bY, color) {
            Shape.call(this, color);
            this.aX = aX;
            this.aY = aY;
            this.bX = bX;
            this.bY = bY;
        }

        Segment.extends(Shape);
        Segment.prototype.toString = function() {
            return ('Segment: A(' + this.aX + ', ' + this.aY + '), B(' + this.bX + ', ' + this.bY + '), Color: ' + this.color);
        };
        return Segment;
    })();

    return {
        Circle : Circle,
        Rectangle : Rectangle,
        Triangle : Triangle,
        Line : Line,
        Segment : Segment
    }
})();

var circle = new shapes.Circle(1, 1, 111, 2);
var rectangle = new shapes.Rectangle(1, 1, 3, 4, 222);
var triangle = new shapes.Triangle(1, 1, 2, 2, 3, 3, 333);
var line = new shapes.Line(1, 1, 5, 5, 444);
var segment = new shapes.Segment(2, 2, 4, 4, 555);

console.log(circle.toString());
console.log(rectangle.toString());
console.log(triangle.toString());
console.log(line.toString());
console.log(segment.toString());