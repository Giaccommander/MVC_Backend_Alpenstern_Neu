if (!Date.now) {
    Date.now = function () {
        return new Date().getTime();
    }
}
var theDate = Date.now();



document.getElementById('date').innerText = getTheDate(theDate)

document.getElementById('prev').addEventListener("click", function () {
    theDate -= 86400000;
    document.getElementById('date').innerText = getTheDate(theDate)
})
document.getElementById('next').addEventListener("click", function () {
    theDate += 86400000;
    document.getElementById('date').innerText = getTheDate(theDate)
})

function getTheDate(getDate) {
    var days = ["Sonntag", "Montag", "Dienstag",
        "Mittwoch", "Donnerstag", "Freitag", "Samstag"
    ];
    var months = ["Januar", "Februar", "März",
        "April", "Mai", "Juni", "Juli", "August",
        "September", "Oktober", "November", "Dezember"
    ];
    var theCDate = new Date(getDate);
    return days[theCDate.getDay()] + ',  ' + theCDate.getDate() + ' - ' + months[theCDate.getMonth()] + ' - ' + theCDate.getFullYear();
}





//#endregion

// #region buchung
var dateControl = document.querySelector('input[type="date"]');
dateControl.value = '2017-06-01';

function goBack(loc) {
    window.location.href = loc;
}







