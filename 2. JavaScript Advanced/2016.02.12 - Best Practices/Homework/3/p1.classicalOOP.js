"use strict";
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
            this._color = color;
        }

        Shape.prototype.toString = function() {
            throw new Error('Shape is an abstract class.');
        };
        return Shape;
    })();

    var Circle = (function() {
        function Circle(oX, oY, color, radius) {
            Shape.call(this, color);
            this._oX = oX;
            this._oY = oY;
            this._radius = radius;
        }

        Circle.extends(Shape);
        Circle.prototype.toString = function() {
            return ('Circle: O(' + this._oX + ', ' + this._oY +
            '), Radius: ' + this._radius + ', Color: ' + this._color);
        };
        return Circle;
    })();

    var Rectangle = (function() {
        function Rectangle(aX, aY, width, height, color) {
            Shape.call(this, color);
            this._aX = aX;
            this._aY = aY;
            this._width = width;
            this._height = height
        }

        Rectangle.extends(Shape);
        Rectangle.prototype.toString = function() {
            return ('Rectangle: A(' + this._aX + ', ' + this._aY + '), Width: ' +
            this._width + ', Height: ' + this._height + ', Color: ' + this._color);
        };
        return Rectangle;
    })();

    var Triangle = (function() {
        function Triangle(aX, aY, bX, bY, cX, cY, color) {
            Shape.call(this, color);
            this._aX = aX;
            this._aY = aY;
            this._bX = bX;
            this._bY = bY;
            this._cX = cX;
            this._cY = cY;
        }

        Triangle.extends(Shape);
        Triangle.prototype.toString = function() {
            return ('Triangle: A(' + this._aX + ', ' + this._aY + '), B(' + this._bX + ', ' +
            this._bY + '), C(' + this._cX + ', ' + this._cY + '), Color: ' + this._color);
        };
        return Triangle;
    })();

    var Line = (function() {
        function Line(aX, aY, bX, bY, color) {
            Shape.call(this, color);
            this._aX = aX;
            this._aY = aY;
            this._bX = bX;
            this._bY = bY;
        }

        Line.extends(Shape);
        Line.prototype.toString = function() {
            return ('Line: A(' + this._aX + ', ' + this._aY + '), B(' + this._bX + ', ' + this._bY + '), Color: ' + this._color);
        };
        return Line;
    })();

    var Segment = (function() {
        function Segment(aX, aY, bX, bY, color) {
            Shape.call(this, color);
            this._aX = aX;
            this._aY = aY;
            this._bX = bX;
            this._bY = bY;
        }

        Segment.extends(Shape);
        Segment.prototype.toString = function() {
            return ('Segment: A(' + this._aX + ', ' + this._aY + '), B(' + this._bX + ', ' + this._bY + '), Color: ' + this._color);
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