"use strict";
var Vector = (function () {
    var result, i;
    function Vector(arr) {
        if (!arr) {
            throw new Error('Vector _dimensions not specified.')
        } else {
            this._dimensions = arr;
        }
    }

    function validateDimensions(v1, v2) {
        if (v1._dimensions.length != v2._dimensions.length) {
            throw new Error('Vector _dimensions must be the same in order to perform operations between them.')
        }
    }

    Vector.prototype.add = function (vector) {
        validateDimensions(vector, this);
        result = new Vector([null]);
        for (i = 0; i < vector._dimensions.length; i++) {
            result._dimensions[i] = this._dimensions[i] + vector._dimensions[i];
        }
        return result;
    };
    Vector.prototype.subtract = function (vector) {
        validateDimensions(vector, this);
        result = new Vector([null]);
        for (i = 0; i < vector._dimensions.length; i++) {
            result._dimensions[i] = this._dimensions[i] - vector._dimensions[i];
        }
        return result;
    };
    Vector.prototype.dot = function (vector) {
        validateDimensions(vector, this);
        result = 0;
        for (i = 0; i < vector._dimensions.length; i++) {
            result += this._dimensions[i] * vector._dimensions[i];
        }
        return result;
    };
    Vector.prototype.norm = function () {
        result = 0;
        for (i = 0; i < this._dimensions.length; i++) {
            result += this._dimensions[i] * this._dimensions[i];
        }
        return Math.sqrt(result);
    };

    Vector.prototype.toString = function () {
        return '(' + this._dimensions.join(', ') + ')';
    };

    return Vector;
})();

//var a = new Vector([1, 2, 3]);
//var b = new Vector([4, 5, 6]);
//var c = new Vector([1, 1, 1, 1, 1, 1, 1, 1, 1, 1]);
//console.log(a.toString());
//console.log(c.toString());
//
//// The following throw errors
//var wrong = new Vector();
//var anotherWrong = new Vector([]);

//var a = new Vector([1, 2, 3]);
//var b = new Vector([4, 5, 6]);
//var c = new Vector([1, 1, 1, 1, 1, 1, 1, 1, 1, 1]);
//var result = a.add(b);
//console.log(result.toString());
////a.add(c); // Error

//var a = new Vector([1, 2, 3]);
//var b = new Vector([4, 5, 6]);
//var c = new Vector([1, 1, 1, 1, 1, 1, 1, 1, 1, 1]);
//var result = a.subtract(b);
//console.log(result.toString());
//a.subtract(c); // Error

//var a = new Vector([1, 2, 3]);
//var b = new Vector([4, 5, 6]);
//var c = new Vector([1, 1, 1, 1, 1, 1, 1, 1, 1, 1]);
//var result = a.dot(b);
//console.log(result.toString());
//a.dot(c); // Error

var a = new Vector([1, 2, 3]);
var b = new Vector([4, 5, 6]);
var c = new Vector([1, 1, 1, 1, 1, 1, 1, 1, 1, 1]);
console.log(a.norm());
console.log(b.norm());
console.log(c.norm());
console.log(a.add(b).norm());