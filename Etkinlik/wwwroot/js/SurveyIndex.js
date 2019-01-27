function getData(id) {
    $.ajax({
        type: 'GET',
        url: '/surveyVote/' + id,
        data: { id: id },
        dataType: "json",
        success: dataRender
    });
}

