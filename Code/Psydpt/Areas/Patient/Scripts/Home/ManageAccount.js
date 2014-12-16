$(function() {

    console.log("~Patient/Home/ManageAccount ready!");
    
    patientInfoContainerSelector = '#personalInfoContainer';
    patientInfoFormSelector = '#patientInfoFrm';

    patientSigeCapsContainerSelector = '#patientSigeCapsContainer';
    patientSigeCapsFormSelector = '#patientSigeCapsFrm';
    datepickerSelector = ".datepicker-control";
    OnLoad();


    

});


function OnLoad() {

    $(datepickerSelector).datepicker();


    var patientInfoFrm = $(patientInfoFormSelector);
    patientInfoFrm.submit(function (event) {
        $.ajax({
            type: patientInfoFrm.attr('method'),
            url: patientInfoFrm.attr('action'),
            data: patientInfoFrm.serialize(),
            success: function (data) {
                console.log("Success!");
                $(patientInfoContainerSelector).html(data);
            }
        });
        ev.preventDefault();
    });

    var patientSigeCapsFrm = $(patientSigeCapsFormSelector);
    patientSigeCapsFrm.submit(function (event) {
        $.ajax({
            type: patientSigeCapsFrm.attr('method'),
            url: patientSigeCapsFrm.attr('action'),
            data: patientSigeCapsFrm.serialize(),
            success: function (data) {
                console.log("Success!");
                $(patientSigeCapsContainerSelector).html(data);
            }
        });
        ev.preventDefault();
    });
}