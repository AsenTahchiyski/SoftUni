"use strict";
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
            this._color = color;
        }
    };

    var Circle = {
        init: function(oX, oY, color, radius) {
            Shape.init.call(this, color);
            this._oX = oX;
            this._oY = oY;
            this._radius = radius;
            return this;
        },
        toString: function() {
            return ('Circle: O(' + this._oX + ', ' + this._oY +
            '), Radius: ' + this._radius + ', Color: ' + this._color);
        }
    };

    var Rectangle = {
        init: function(aX, aY, width, height, color) {
            Shape.init.call(this, color);
            this._aX = aX;
            this._aY = aY;
            this._width = width;
            this._height = height;
            return this;
        },
        toString: function() {
            return ('Rectangle: A(' + this._aX + ', ' + this._aY + '), Width: ' +
            this._width + ', Height: ' + this._height + ', Color: ' + this._color);
        }
    };

    var Triangle = {
        init: function(aX, aY, bX, bY, cX, cY, color) {
            Shape.init.call(this, color);
            this._aX = aX;
            this._aY = aY;
            this._bX = bX;
            this._bY = bY;
            this._cX = cX;
            this._cY = cY;
            return this;
        },
        toString: function() {
            return ('Triangle: A(' + this._aX + ', ' + this._aY + '), B(' + this._bX + ', ' +
            this._bY + '), C(' + this._cX + ', ' + this._cY + '), Color: ' + this._color);
        }
    };

    var Line = {
        init: function(aX, aY, bX, bY, color) {
            Shape.init.call(this, color);
            this._aX = aX;
            this._aY = aY;
            this._bX = bX;
            this._bY = bY;
            return this;
        },
        toString: function() {
            return ('Line: A(' + this._aX + ', ' + this._aY + '), B(' + this._bX + ', ' + this._bY + '), Color: ' + this._color);
        }
    };

    var Segment = {
        init: function(aX, aY, bX, bY, color) {
            Shape.init.call(this, color);
            this._aX = aX;
            this._aY = aY;
            this._bX = bX;
            this._bY = bY;
            return this;
        },
        toString: function() {
            return ('Segment: A(' + this._aX + ', ' + this._aY + '), B(' + this._bX + ', ' + this._bY + '), Color: ' + this._color);
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