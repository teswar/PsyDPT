$(function() {

    console.log("{../Patient/Home/PredictDisorder} says-: ready!");
    OnPageload();





});



function OnPageload() {
    $('#symptoms button[type="submit"]').click(function (event) {
        event.preventDefault();

        var predictionData = getPredictionInput();
        if (!predictionData.Validate()) { return; }
        moveToStatePredicting();
        hideError();

        $.ajax({
            type: 'POST',
            url: '/patient/home/predictdisorder',
            data: predictionData,
            success: function (data) {
                console.log("Success!");
                updatePrediction(data);
                moveToStateNormal();
            },
            error: function (error) {
                console.log("error!" + error);
                moveToStateNormal();
                showError("Unexpected error occured");
            }
        });
    });
}

var RESPONSE_STATUS = {
    ERROR : 0,
    SUCCESS : 1
};

PREDICTION_INPUT_ELEMENT_SELECTORMAP =
    {
        description: $('textarea[name=\"description\"]')
    };

PREDICTION_OUTPUT_ELEMENT_SELECTORMAP =
    {
        description: $('#prediction_output')
    };

function PredictionInput(description) {
    this.description = description;
}

PredictionInput.prototype.Validate = function(){
    return true;
}


function getPredictionInput() {
    var result = new PredictionInput(PREDICTION_INPUT_ELEMENT_SELECTORMAP['description'].val());
    return result;
}


function moveToStatePredicting() {
    $('#symptoms textarea, #symptoms button[type="submit"]').prop('disabled', true);
    $('#symptoms button[type="submit"]').text('Predicting ....');
    $('#symptoms button').not('button[type="submit"]').removeClass('hidden');
}


function moveToStateNormal() {
    $('#symptoms textarea, #symptoms button[type="submit"]').prop('disabled', false);
    $('#symptoms button[type="submit"]').text('Predict');
    $('#symptoms button').not('button[type="submit"]').addClass('hidden');
}

function updatePrediction(data) {

    if (data.Status == RESPONSE_STATUS.SUCCESS) {
        var disorder = data.Data.Disorder;

        var contentToUpdate = "<p><strong>" + disorder.Name + "</strong></p>"
                                + "<p>" + disorder.Description
                                + "<a class=\"alert-link\" href=" + disorder.ExternalInfoUrl + " target=\"_blank\"> more ...</a> </p>"

        PREDICTION_OUTPUT_ELEMENT_SELECTORMAP.description.html(contentToUpdate);
        return;
    }

    showError(data.Message ? data.Message : "Perdiction failed. Unexpected error occured.");
}


function showError(message) {

    if (!message) { return; }
    var errorCompSelector = $("#error_broadcast");
    if(!errorCompSelector){return;}

    var content =  "<div class=\"alert alert-dismissable alert-danger\">"
        + "<button type=\"button\" class=\"close\" data-dismiss=\"alert\">×</button>"
             +"<h4>Error!</h4>"
             +"<p>"+ message +"</p>"
     +"</div>";

    errorCompSelector.html(content);
}

function hideError() {
    var errorCompSelector = $("#error_broadcast");
    if(!errorCompSelector){return;}
    errorCompSelector.html("");
}


function AjaxDataResponse() {
    this.Data = "",
    this.ResponseStatus = "",
    this.Message = "",
    this.Log
}


//public T Data {get; set;}
//public ResponseStatus Status{get; set;}
//public string Message { get; set; }
//public Exception Log { get; set; }