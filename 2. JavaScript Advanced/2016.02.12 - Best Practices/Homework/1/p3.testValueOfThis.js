"use strict";

function testContext() {
    console.log(this);
}

//testContext();
//// Prints the window object details since owner of the function is the global context.

//function testFunction() {
//    testContext();
//}
//testFunction();
//Prints the window object details since owner of the function another function, called in the global context.
//In other words - 'this' for testFunction = 'this' for testContext = global 'this'.

var funcObj = new testContext;
//////Function is called like a constructor and therefore - is executed in the context of itself.