/*
 * Implement a Polygon class with the following properties:
 * 1. A constructor that takes an array of integer side lengths.
 * 2. A 'perimeter' method that returns the sum of the Polygon's side lengths.
 */
function Polygon( sideLengths ) {
    this.sideLengths = sideLengths;

    this.perimeter = function () {
        let sum = 0;
        for( let i = 0; i < this.sideLengths.length; i++ ) {
            sum = sum + this.sideLengths[ i ];
        }
        return sum;
    }
}

/* Prototype Property

function Polygon( sideLengths ) {
    this.sideLengths = sideLengths;
}

Polygon.prototype.perimeter = function () {
    let sum = 0;
    for( let i = 0; i < this.sideLengths.length; i++ ) {
        sum = sum + this.sideLengths[ i ];
    }
    return sum;
}
*/

/* Object Literal

let Polygon = {
    sideLengths: 11
    , perimeter: function () {
        let sum = 0;
        for( let i = 0; i < this.sideLengths.length; i++ ) {
            sum = sum + this.sideLengths[ i ];
        }
        return sum;
    }
}
*/

/* Singleton using function

let Polygon = function() {
    this.sideLengths = 11;
    this.perimeter = function () {
        let sum = 0;
        for( let i = 0; i < this.sideLengths.length; i++ ) {
            sum = sum + this.sideLengths[ i ];
        }
        return sum;
    }
}
*/

/* Class declaration (these are NOT hoisted like the functions)

class Polygon {
    constructor( sideLengths ) {
        this.sideLengths = sideLengths;
    }
    perimeter() {
        let sum = 0;
        for( let i = 0; i < this.sideLengths.length; i++ ) {
            sum = sum + this.sideLengths[ i ];
        }
        return sum;
    }
}
*/

/* Unnamed vs Named Class Expressions

let Polygon = class {
    constructor( sideLengths ) { ...
let Polygon = class Polygon {
    constructor( sideLengths ) { ...
*/

/* Static methods

class Polygon {
    constructor( sideLengths ) { ...
    static diagonal( a, b ) { ...
*/

