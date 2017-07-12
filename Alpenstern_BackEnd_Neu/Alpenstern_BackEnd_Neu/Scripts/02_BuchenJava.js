var kunden = [
    {
        nachname: "Musterman",
        vorname: "Max",
        buchungsnummer: 123456789,
        telefon: 0660123456,
        adresse: "Gehweg",
        stiege: 2,
        tuer: 12,
        land: "Österreich",
        ort: "wien",
        plz: 1230,
        passNr: 548945215,
        gebDatum: "13.05.60"
    },
    {
        nachname: "Musterman",
        vorname: "Max",
        buchungsnummer: 123456789
    }, {
        nachname: "Musterman",
        vorname: "Max",
        buchungsnummer: 123456789
    }, {
        nachname: "Musterman",
        vorname: "Max",
        buchungsnummer: 123456789
    }, {
        nachname: "Musterman",
        vorname: "Max",
        buchungsnummer: 123456789
    }, {
        nachname: "Musterman",
        vorname: "Max",
        buchungsnummer: 123456789
    }, {
        nachname: "Musterman",
        vorname: "Max",
        buchungsnummer: 123456789
    }, {
        nachname: "Musterman",
        vorname: "Max",
        buchungsnummer: 123456789
    }, {
        nachname: "Musterman",
        vorname: "Max",
        buchungsnummer: 123456789
    },




]

function ausgeben() {

    document.getElementById("vorname0").innerHTML = kunden[0].vorname;
    document.getElementById("nachname0").innerHTML = kunden[0].nachname;
    document.getElementById("buchungsnummer0").innerHTML = kunden[0].buchungsnummer;

    document.getElementById("vorname1").innerHTML = kunden[1].vorname;
    document.getElementById("nachname1").innerHTML = kunden[1].nachname;
    document.getElementById("buchungsnummer1").innerHTML = kunden[1].buchungsnummer;

    document.getElementById("vorname2").innerHTML = kunden[2].vorname;
    document.getElementById("nachname2").innerHTML = kunden[2].nachname;
    document.getElementById("buchungsnummer2").innerHTML = kunden[2].buchungsnummer;

    document.getElementById("vorname3").innerHTML = kunden[3].vorname;
    document.getElementById("nachname3").innerHTML = kunden[3].nachname;
    document.getElementById("buchungsnummer3").innerHTML = kunden[3].buchungsnummer;

}

$(document).ready(function () {
    var atLeastOneIsChecked = '#fertig';
    $('#checked1').click(function () {
        $('#row2').css('background', 'lightgray')
        $('#row3').css('background', 'lightgray')
        $('#row4').css('background', 'lightgray')
        $('#row1').css('background', 'red')
    });

    $('#checked2').click(function () {
        $('#row1').css('background', 'lightgray')
        $('#row4').css('background', 'lightgray')
        $('#row3').css('background', 'lightgray')
        $('#row2').css('background', 'red')
    });

    $('#checked3').click(function () {
        $('#row1').css('background', 'lightgray')
        $('#row2').css('background', 'lightgray')
        $('#row4').css('background', 'lightgray')
        $('#row3').css('background', 'red')
    });

    $('#checked4').click(function () {
        $('#row1').css('background', 'lightgray')
        $('#row2').css('background', 'lightgray')
        $('#row3').css('background', 'lightgray')
        $('#row4').css('background', 'red')
    });


    //$("check1").click(function () {
    //    id = $(this).attr("id");
    //    var idneu = "#" + id.replace(div, "cb");
    //});



})