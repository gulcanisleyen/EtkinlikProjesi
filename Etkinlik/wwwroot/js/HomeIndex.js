function getLastSurvey() {
    $.ajax({
        type: 'GET',
        url: '/GetLastSurveyVote',
        dataType: "json",
        success: dataRender
    });
}

function voteSurvey(id) {
    
    $.ajax({
        type: "POST",
        url: "/Survey/vote/" + id,
        data: { id: id },
        success: function () {
            getLastSurvey();
        }
    });
}

function join(id) {
    $.ajax({
        type: "POST",
        url: "/Post/join/" + id,
        data: { id: id },
        success: function () {
            document.getElementById("joinSpan" + id).style.display = 'none';
            document.getElementById("quitSpan" + id).style.display = 'inline';
        }
    });
}

function quit(id) {
    $.ajax({
        type: "POST",
        url: "/Post/quit/" + id,
        data: { id: id },
        success: function () {
            document.getElementById("joinSpan" + id).style.display = 'inline';
            document.getElementById("quitSpan" + id).style.display = 'none';
        }
    })
}