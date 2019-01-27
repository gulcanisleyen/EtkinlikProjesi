function getSurvey(id) {
    alert(id);
}

function voteSurvey(id) {

    $.ajax({
        type: "POST",
        url: "/Survey/vote/" + id,
        data: { id: id },
        
    });
}

function soru(id) {
    $.ajax({
        type: 'GET',
        url: '/surveyVote/' + id,
        data: { id: id },
        type: "json",
        success: function () {
            var parentDiv = document.getElementById("soruParent");
            var divString = '<div class="survey-result" > <h2 class="center-block soru">Soru</h2> <label class="btn-block"><input type="radio" name="optradio" class="radio-option" onclick="voteSurvey(@choice.Id)">cevap</label></div>';

            parentDiv.innerHTML = divString;
        }
    });
    
}