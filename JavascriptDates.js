'use strict';

process.stdin.resume();
process.stdin.setEncoding('utf-8');

let inputString = '';
let currentLine = 0;

process.stdin.on('data', inputStdin => {
    inputString += inputStdin;
});

process.stdin.on('end', _ => {
    inputString = inputString.trim().split('\n').map(string => {
        return string.trim();
    });
    
    main();    
});

function readLine() {
    return inputString[currentLine++];
}

// The days of the week are: "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"
function getDayName(dateString) {
    let dayName;
    // Write your code here

    let theDate = new Date( dateString );

    // 1/1/1970 was Thursday
    let daysSince1_1_1970 = theDate.getTime() / ( 1000 * 3600 * 24 );
    let weekdayIndex = daysSince1_1_1970 % 7;

    let weekdayNames = [ "Thursday", "Friday", "Saturday", "Sunday", "Monday", "Tuesday", "Wednesday" ];

    dayName = weekdayNames[ weekdayIndex ];

    return dayName;
}

