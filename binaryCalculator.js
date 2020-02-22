function dec2bin( dec ) {
    return ( dec >>> 0 ).toString( 2 );
}

function calculate( aText ) {
    let regExpPattern = /[\+\-\*\/]/
    let operands = aText.split( regExpPattern );
    let operator = regExpPattern.exec( aText )[ 0 ];
    
    let operand1 = parseInt( operands[ 0 ], 2 );
    let operand2 = parseInt( operands[ 1 ], 2 );
    console.log( operands, operator );
    
    let result;
    switch( operator ) {
        case "+":
            result = operand1 + operand2;
            break;
        case "-":
            result = operand1 - operand2;
            break;
        case "*":
            result = operand1 * operand2;
            break;
        case "/":
            result = operand2 != 0 ? operand1 / operand2 : 0;
            break;
    }
    
    return dec2bin( result );
}

let clickedHandler = ( event ) => {
    let action = event.target.innerText || event.srcElement;
    let display = document.getElementById( "res" );
    
    switch( action ) {
        case "0": case "1": case "+": case "-": case "*": case "/":
            display.innerText = display.innerText + action;
            break;
        case "C":
            display.innerText = "";
            break;
        case "=":
            display.innerText = calculate( display.innerText );
            break;
    }
}

let buttons = document.getElementsByTagName( "button" );
for( let aBtn of buttons ) {
    aBtn.addEventListener( "click", clickedHandler );
}
